using Library_Business;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace Library_Manegment_System
{
    public partial class ctrlMemberCard : UserControl
    {
        public ctrlMemberCard()
        {
            InitializeComponent();
        }



        private clsMembers _Member;
        private int _MemberID = -1;

        private string _LibraryCardNumber = "";
        public string LibraryCardNumber
        {
            get { return _LibraryCardNumber; }
        }
        public int MemberID
        {
            get { return _MemberID; }
        }
        public clsMembers SelectMemberInfo
        {
            get { return _Member; }
        }

        public void LoadMemberInfo(int MemberID)
        {
            _Member =clsMembers.FindByID(MemberID);
            if (_Member == null)
            {
                linklblUserInfo.Enabled = false;
                linklblSubscribtion.Enabled = false;
                _ResetMemberInfo();
                MessageBox.Show("No MemberID with MemberID = " + MemberID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillMemberInfo();
        }

        public void LoadMemberInfo(string LibraryCardNumber)
        {
            _Member = clsMembers.FindByLCN(LibraryCardNumber);
            if (_Member == null)
            {
                linklblUserInfo.Enabled = false;
                linklblSubscribtion.Enabled = false;
                _ResetMemberInfo();
                MessageBox.Show("No MemberID with Library Card Number = " + LibraryCardNumber.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillMemberInfo();
        }

        private void _FillMemberInfo()
        {

            linklblUserInfo.Enabled= true;
            linklblSubscribtion.Enabled = true;
            _MemberID =_Member.MemberID;
            _LibraryCardNumber=_Member.LibraryCardNumber;

            ctrlPersonCard1.LoadPersonInfo(_Member.PersonID);
            lblMemberID.Text = _Member.MemberID.ToString();
            lblLibraryCardNum.Text = _Member.LibraryCardNumber.ToString();
            lblCreatedByUser.Text=_Member.UsersInfo.UserName;
            lblSbscriptionID.Text= _Member.LasrSubscriptionID.ToString();

            if (_Member.IsActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";

        }


        public void _ResetMemberInfo()
        {

            ctrlPersonCard1.ResetPersonInfo();
            lblMemberID.Text = "[???]";
            lblLibraryCardNum.Text = "[???]";
            lblIsActive.Text = "[???]";
            lblCreatedByUser.Text = "[???]";
            lblSbscriptionID.Text = "[???]";
        }






        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblUserID_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void linklblUserInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmUserDetails frmUser =new frmUserDetails(_Member.CreatedByUserID);
            frmUser.ShowDialog();
        }

        private void linklblSubscribtion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSubscriptionInfo frmSubscriptionInfo = new frmSubscriptionInfo(_Member.LasrSubscriptionID);
            frmSubscriptionInfo.ShowDialog();
        }
    }
}
