using DVLD.Classes;
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
    public partial class ctrlUserCard : UserControl
    {
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        private clsUsers  _User;
        private int _UserID = -1;

        public int UserID
        {
            get { return _UserID; }
        }

        public void LoadUserInfo(int UserID)
        {
            _User = clsUsers .FindByUserID(UserID);
            if (_User == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }


        private void _FillUserInfo()
        {

            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();
            lblJobTitle.Text = _User.JobTitle.ToString();
            lblPassword.Text =clsUtil.Decrypt(_User.Password.ToString(),clsUtil.Key);
            lblSalary.Text = _User.Salary.ToString();

            txtPermissions.Text= _User.GetPermissionAsString();

            if (_User.IsActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";

        }


        private void _ResetPersonInfo()
        {

            ctrlPersonCard1.ResetPersonInfo();
            lblUserID.Text = "[???]";
            lblUserName.Text = "[???]";
            lblIsActive.Text = "[???]";
            lblJobTitle.Text = "[???]";
            lblPassword.Text = "[???]";
            lblSalary.Text = "[???]";
        }




    }
}
