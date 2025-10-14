using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Manegment_System
{
    public  class clsErrorEventLog
    {
        //readonly
        private  static string SourceName = "Library_DB";
        static clsErrorEventLog()
        {

            if (!EventLog.Exists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }
        }

        public static void LogError(string ErrorMessage, EventLogEntryType entryType = EventLogEntryType.Error)
        {   
            EventLog.WriteEntry(SourceName, ErrorMessage, entryType);
        }
    }
}
