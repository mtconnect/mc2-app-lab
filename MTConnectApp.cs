using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MTConnect;
using System.IO;
using System.Net;
using System.Xml.Linq;
using System.Xml;
using NAudio.Wave;

namespace MTConnectApplication
{
    public partial class MTConnectApp : Form
    {
        MTConnectStream stream = new MTConnect.MTConnectStream();
        delegate void ReceiveStreamCallback(object sender, MTConnect.RealTimeEventArgs args);
        delegate void ErrorCallback(object sender, MTConnect.ErrorArgs args);

        static int heartbeat = 10000;
        Uri mUri;

        private DateTime mStartTime;

        private Metric mAvailability;
        private Metric mUtilization;
        private Metric mSpindleTime;

        private double mNoise;
        private double mAvgNoise;

        private IWavePlayer mPlayer;
        private BufferedWaveProvider mWaveBuffer;

        public MTConnectApp()
        {
            InitializeComponent();

            mAvailability = new Metric("//m:Availability",
                (aValues) => aValues["Availability"] == "AVAILABLE");

            mUtilization = new Metric("//m:Execution|//m:ControllerMode|//m:FunctionalMode",
                (aValues) => aValues["Execution"] == "ACTIVE" && 
                             aValues["ControllerMode"] == "AUTOMATIC" && 
                             aValues["FunctionalMode"] == "PRODUCTION" && 
                             mSpindleTime.Accumulating &&
                             mNoise > 0.20);

            mSpindleTime = new Metric("//m:ComponentStream[@name='C']//m:RotaryVelocity",
                (aValues) => aValues.HasValue("RotaryVelocity") && 
                             Convert.ToDouble(aValues["RotaryVelocity"]) > 1000.0);
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            String b = url.Text;
            if (!b.EndsWith("/")) b = b + "/";

            mUri = new Uri(b);
            stream.Source = b + "sample?interval=1000";
            stream.RequestTimeout = heartbeat * 2;
            stream.HeartbeatTimeout = heartbeat * 2;
            stream.DataEvent += new MTConnect.RealTimeData.RealTimeEventHandler(ReceiveStream);
            stream.ConnectionEvent += new MTConnect.ConnectionError.ConnectionErrorHandler(HandleConnectionError);
            stream.Start();

            connected.Checked = true;
            mStartTime = DateTime.UtcNow;

            mPlayer = new WaveOut();
            mWaveBuffer = new BufferedWaveProvider(new WaveFormat(8000, 1));
            mPlayer.Init(mWaveBuffer);
            mPlayer.Play();
        }

        void ReceiveStream(object sender, MTConnect.RealTimeEventArgs args)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.connectButton.InvokeRequired)
            {
                ReceiveStreamCallback d = new ReceiveStreamCallback(ReceiveStream);
                this.Invoke(d, new object[] { sender, args });
            }
            else
            {
                var doc = XDocument.Parse(args.document);
                var reader = doc.CreateReader();
                var root = doc.Root;
                var nameMgr = new XmlNamespaceManager(reader.NameTable);
                nameMgr.AddNamespace("m", root.Name.Namespace.NamespaceName);
                HandleDocument(root, nameMgr);
            }
        }

        private void HandleDocument(XElement doc, XmlNamespaceManager aMgr)
        {
            XNamespace ns = doc.Name.Namespace;
            XElement header = doc.Descendants(ns + "Header").First();
            string time = header.Attribute("creationTime").Value;
            DateTime createTime = DateTime.Parse(time).ToUniversalTime();

            double totalTime = createTime.Subtract(mStartTime).TotalMilliseconds;

            mAvailability.Evaluate(doc, aMgr);
            availability.Value = (int)mAvailability.PercentAccumulatedTime(totalTime);
            availabilityValue.Text = mAvailability.AccumulatedSeconds.ToString();

            mSpindleTime.Evaluate(doc, aMgr);
            spindleTime1.Text = mSpindleTime.AccumulatedSeconds.ToString();
            spindleTimeBar.Value = (int) mSpindleTime.PercentAccumulatedTime(totalTime);

            mUtilization.Evaluate(doc, aMgr);
            utilization.Value = (int)mUtilization.PercentAccumulatedTime(totalTime);
            utilizationValue.Text = mUtilization.AccumulatedSeconds.ToString();

            execution.Text = mUtilization.Values["Execution"];
            controllerMode.Text = mUtilization.Values["ControllerMode"];
            functionalMode.Text = mUtilization.Values["FunctionalMode"];

            if (mUtilization.Accumulating)
            {
                producing.Text = "Producing";
                producing.BackColor = Color.Green;
            }
            else
            {
                producing.Text = "Not Producing";
                producing.BackColor = Color.Red;
            }

            HandleConditions(doc);
            HandleAudio(doc);
        }

        void HandleAudio(XElement doc)
        {
            XNamespace ns = doc.Name.Namespace;

            char[] sep = { ' ' };
            var nodes = doc.Descendants(ns + "DisplacementTimeSeries").
                OrderBy(n => n.Attribute("timestamp").Value);
            var values = nodes.Where((node) => node.Value != "UNAVAILABLE").
                SelectMany((node) => node.Value.Split(sep).Where((s) => s.Length > 0).
                Select((s) => Convert.ToDouble(s))).ToArray();

            // Check if there is nothing in the buffer.
            if (values.Length == 0) return;

            int count = values.Length * 2;
            byte[] buffer = new byte[count];
            for (int i = 0; i < count; i += 2)
            {
                // Convert from 0.0 .. 1.0 to a signed short and split into bytes.
                short sample = (short)(values[i / 2] * 32768.0);
                buffer[i] = (byte)(sample & 0xFF);
                buffer[i + 1] = (byte)((sample >> 8) & 0xFF);
            }

            mNoise = values.Max();
            mAvgNoise = values.Average((d) => Math.Abs(d));

            magnitude.Text = mNoise.ToString();
            avgNoise.Text = mAvgNoise.ToString();

            try
            {
                Stream memStream = new MemoryStream();
                mWaveBuffer.AddSamples(buffer, 0, count);
                memStream.Write(buffer, 0, count);
                waveViewer.WaveStream = new RawSourceWaveStream(memStream, mWaveBuffer.WaveFormat);
            }
            catch (InvalidOperationException ex)
            {
                // The wave buffer overflowed, nothing much to do.
            }
        }

        void HandleConditions(XElement doc)
        {
            XNamespace ns = doc.Name.Namespace;
            var nodes = doc.Descendants(ns + "Condition").SelectMany((conds) => conds.Descendants()).
                OrderBy(n => n.Attribute("timestamp").Value);
            foreach (var cond in nodes)
                conditions.Items.Add(cond.Attribute("timestamp").Value + ": " + cond.Name.LocalName + " - " +
                                        cond.Attribute("type") + " - " + cond.Value);
        }

        void HandleConnectionError(object sender, MTConnect.ErrorArgs args)
        {
            if (connected.InvokeRequired)
            {
                ErrorCallback d = new ErrorCallback(HandleConnectionError);
                this.Invoke(d, new object[] { sender, args });
            }
            else
            {
                connected.Checked = false;
            }
        }

    }
}
