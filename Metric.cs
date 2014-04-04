using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace MTConnectApplication
{
    class Metric
    {
        public class DataItemDict : Dictionary<string, string>
        {
            private const string Unavailable = "UNAVAILABLE";

            public bool HasValue(string aKey)
            {
                return this[aKey] != Unavailable;
            }

            new public string this[string aKey]
            {
                get
                {
                    string value;
                    if (!TryGetValue(aKey, out value))
                        value = Unavailable;
                    return value;
                }

                set { base[aKey] = value; }
            }
        }

        public delegate bool ShouldTallyDelegate(DataItemDict aValues);

        private ShouldTallyDelegate mShouldTally;
        private DateTime mStartTime;
        private DateTime mAccumulated;
        private DateTime mBaseTime;
        private bool mFirst = true;
        private bool mChecked = false;
        private string mPath;

        public bool Accumulating { get; private set; }
        public double AccumulatedTime { get; private set; }
        public DataItemDict Values { get; private set; }
        public double AccumulatedSeconds { get { return AccumulatedTime / 1000.0; } }        

        public Metric(string aPath, ShouldTallyDelegate aShouldTally)
        {
            AccumulatedTime = 0.0;
            mShouldTally = aShouldTally;
            Values = new DataItemDict();
            mPath = aPath;
            mBaseTime = DateTime.UtcNow;
        }

        public double PercentAccumulatedTime(double aTotalTime)
        {
            if (aTotalTime <= 0)
                return 0.0;
            else if (AccumulatedTime > aTotalTime)
                return 100.0;
            else
                return (AccumulatedTime / aTotalTime * 100.0);
        }


        private DateTime DocTime(XElement doc)
        {
            XNamespace ns = doc.Name.Namespace;
            XElement header = doc.Descendants(ns + "Header").First();
            string time = header.Attribute("creationTime").Value;
            return DateTime.Parse(time).ToUniversalTime();
        }

        private void AccumulateTime(DateTime aTime)
        {
            if (Accumulating)
            {
                AccumulatedTime += aTime.Subtract(mAccumulated).TotalMilliseconds;
                mAccumulated = aTime;
            }
        }

        private void CheckTallying(DateTime aTime)
        {
            // Accumulate some more time...
            AccumulateTime(aTime);

            bool wasTallying = Accumulating;
            Accumulating = mShouldTally.Invoke(Values);

            if (!wasTallying && Accumulating)
                mStartTime = mAccumulated = aTime;

            mChecked = true;
        }

        public double Evaluate(XElement doc, XmlNamespaceManager aMgr)
        {
            if (mFirst)
            {
                mBaseTime = DocTime(doc);
                mFirst = false;
            }

            var nodes = doc.XPathSelectElements(mPath, aMgr).
                OrderBy(n => n.Attribute("timestamp").Value);
           
            mChecked = false;
            // Evaluate each transition point
            foreach (var node in nodes)
            {
                Values[node.Name.LocalName] = node.Value;
                var eventTime = DateTime.Parse(node.Attribute("timestamp").Value).ToUniversalTime();
                if (eventTime < mBaseTime) eventTime = mBaseTime;

                CheckTallying(eventTime);
            }
            if (!mChecked) CheckTallying(DocTime(doc));
            
            return AccumulatedTime;

        }
    }
}
