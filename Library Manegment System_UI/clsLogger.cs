using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Manegment_System
{
    public class clsLogger
    {
        public delegate void logAction(string errorMessage);
        private logAction _logAction;

        public clsLogger(logAction logAction) => _logAction = logAction;

        public void log(string errorMessage) => _logAction(errorMessage);


    }
}
