using DVLD.Classes;
using Library;
using Library_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Manegment_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

           if (clsGlobal.GetStoredCredentialByRegjistry(ref UserName, ref Password))
           {

                txtUserName.Text = UserName;
               txtPassword.Text = clsUtil.Decrypt(Password,clsUtil.Key);

                chkRememberMe.Checked = true;
           }
            else
                chkRememberMe.Checked = false;
        }

        clsLogin clsLogin;
        clsSaveLoginInRegjistry SaveLoginRegjistry;
        private void btnLogin_Click(object sender, EventArgs e)
        {


            clsUsers user = clsUsers.FindByUsernameAndPassword(txtUserName.Text.Trim(), clsUtil.Encrypt(txtPassword.Text.Trim(), clsUtil.Key));
            if (user != null)
            {
                clsLogin = new clsLogin();
                SaveLoginRegjistry = new clsSaveLoginInRegjistry();


                if (chkRememberMe.Checked)
                {

                    SaveLoginRegjistry.Subscribe(clsLogin);
                    //clsGlobal.RememberUsernameAndPasswordByRegjistry(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                    clsLogin.LogIn(user.UserName, user.Password);
                }
                else
                {
                    SaveLoginRegjistry.Subscribe(clsLogin);
                    clsLogin.LogIn("", "");

                }

                if (!user.IsActive)
                {

                    txtUserName.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsGlobal.CurrentUser = user;
                this.Hide();
                frmMain frm = new frmMain(this);
                frm.ShowDialog();
            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this .Close();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
//txtUserName.Clear();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
          //  txtPassword.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }




    }
}
