using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFAAdapter
{
    public sealed class DummyLogger
    {
        private const string ApplicationLog = "Application";
        private const string ApplicationTag = "DummyMFAAdapter";

        private DummyLogger()
        {
        }

        public static void Log(string logtext)
        {
            EventLog.WriteEntry(ApplicationLog, ApplicationTag + ": " + logtext, EventLogEntryType.Warning);
        }
    }
}
