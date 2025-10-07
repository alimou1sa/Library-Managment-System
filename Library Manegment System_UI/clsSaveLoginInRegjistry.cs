using Library;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.HtmlRenderer.Adapters.RGraphicsPath;

namespace Library_Manegment_System
{
    public  class clsSaveLoginInRegjistry
    {

        public void Subscribe(clsLogin Login)
        {
            Login.OnUserLogin += clsGlobal.RememberUsernameAndPasswordByRegjistry;
        }

        public void UnSubscribe(clsLogin Login)
        {
            Login.OnUserLogin -= clsGlobal.RememberUsernameAndPasswordByRegjistry;
        }





    }
}
