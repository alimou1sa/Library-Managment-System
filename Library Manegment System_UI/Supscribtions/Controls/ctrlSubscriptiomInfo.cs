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
    public partial class ctrlSubscriptiomInfo : UserControl
    {
        public ctrlSubscriptiomInfo()
        {
            InitializeComponent();
        }

        private clsMemberSubscriptions _MemberSubscriptions;
        private int _MemberSubscriptionID = -1;

        public int MemberSubscriptionID
        {
            get { return _MemberSubscriptionID; }
        }
        public clsMemberSubscriptions SelectMemberSubscriptionsInfo
        {
            get { return _MemberSubscriptions; }
        }


        public void _ResetMemberSubscriptionsInfo()
        {
            linklblUserInfo.Enabled = false;
            linlLblManagePlane.Enabled = false;

            lblSubscriptionID.Text = "[???]";
            lblStartDate.Text = "[???]";
            lblEndDate.Text = "[???]";
            lblSuscriptionBuUser.Text = "[???]";
            lblSubscriptionStatus.Text = "[???]";
           lblIsActive.Text="[???]";
            lblSubscriptionPlane.Text = "[???]";
        }

        private void _FillMemberSubscriptionsInfo()
        {
            linklblUserInfo.Enabled = true ;
            linlLblManagePlane.Enabled = true ;

            lblSubscriptionID.Text = _MemberSubscriptions.SubscriptionID.ToString() ;
            lblStartDate.Text = _MemberSubscriptions.StartDate.ToString("yyyy:MM:dd") ;
            lblEndDate.Text = _MemberSubscriptions .EndDate.ToString("yyyy:MM:dd") ;
            lblSuscriptionBuUser.Text = _MemberSubscriptions.UsersInfo.UserName.ToString() ;
            lblSubscriptionStatus.Text = clsMemberSubscriptions.GetSubscriptionStatusText
                ((clsMemberSubscriptions.enSubscriptionStatus)_MemberSubscriptions.SubscriptionStatus);

            lblSubscriptionPlane.Text = _MemberSubscriptions.MembershipPlansInfo.PlanName.ToString() ;

            if (_MemberSubscriptions.IsActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";
        }


        public void LoadMemberSubscriptionsInfo(int MemberSubscriptionID)
        {
            _MemberSubscriptions = clsMemberSubscriptions.FindByID(MemberSubscriptionID);
            if (_MemberSubscriptions == null)
            {
                _ResetMemberSubscriptionsInfo();
                MessageBox.Show("No Member Subscription with Member SubscriptionID = " + MemberSubscriptionID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillMemberSubscriptionsInfo();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblSuscriptionBuUser_Click(object sender, EventArgs e)
        {

        }

        private void linlLblManagePlane_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          //
        }

        private void linklblUserInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmUserDetails frmUserDetails=new frmUserDetails(_MemberSubscriptions.CreatedByUserID);
            frmUserDetails.ShowDialog();
        }

 
    }
}
