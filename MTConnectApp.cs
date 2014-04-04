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


        public MTConnectApp()
        {
            InitializeComponent();
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
