using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Manegment_System
{
    public  class clsLogin
    {

        public event EventHandler<clsLoginEventArgs> OnUserLogin;

        public void LogIn(string UserName, string Passoword)
        {
            OnUserLogin?.Invoke(this, new clsLoginEventArgs(UserName, Passoword));
        }


    }
}
