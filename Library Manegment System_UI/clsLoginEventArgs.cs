using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Manegment_System
{
    public class clsLoginEventArgs
    {

        public string UserName { get; }
        public string Passoword { get; }

        public clsLoginEventArgs(string  UserName, string  Passoword)
        {
            this.UserName = UserName;
            this.Passoword = Passoword;
        }










    }
}
