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


        public MTConnectApp()
        {
            InitializeComponent();

            mAvailability = new Metric("//m:Availability",
                (aValues) => aValues["Availability"] == "AVAILABLE");

            mUtilization = new Metric("//m:Execution|//m:ControllerMode|//m:FunctionalMode",
                (aValues) => aValues["Execution"] == "ACTIVE" && 
                             aValues["ControllerMode"] == "AUTOMATIC" && 
                             aValues["FunctionalMode"] == "PRODUCTION");
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
        }

        void HandleAudio(XElement doc)
        {
        }

        void HandleConditions(XElement doc)
        {
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
