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
    public partial class ctrlPaymentInfo : UserControl
    {
        public ctrlPaymentInfo()
        {
            InitializeComponent();
        }

        private clsPaymentDetails _paymentDetails  ;
        private int _PaymentID = -1;
        private int _paymentDetailsID = -1;
        private int _MemberID = -1;
        private int _UserID = -1;

        public int MemberID
        {
            get { return _MemberID; }
        }

        public int UserID
        {
            get { return _UserID; }
        }

        public int PaymentDetailsID
        {
            get { return _paymentDetailsID; }
        }

        public int PaymentID
        {
            get { return _PaymentID; }
        }
        public clsPayments SelectpaymentDetailsInfo
        {
            get { return _paymentDetails; }
        }

        public void LoadPaymentInfo(int PaymentDetailsID)
        {
            _paymentDetails = clsPaymentDetails.FindByID(PaymentDetailsID);
            if (_paymentDetails == null)
            {
                _ResetPaymentInfo();
                MessageBox.Show("No Payment with PaymentDetailsID = " + PaymentDetailsID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPaymentInfo();
        }

        public void _ResetPaymentInfo()
        {
            linklblUserInfo.Enabled = false;
            linkMemberInfo.Enabled = false;
            lblAmount.Text = "[???]";
            lblPaymentDate.Text = "[???]";
            lblCreateByUser.Text = "[???]";
            lblPaymentID.Text = "[???]";
            lblPaymentDetailID.Text = "[???]";
            lblPaymentType.Text = "[???]";
            lblPaymentStatus.Text = "[???]";
            lblEntityID.Text = "[???]";
            lblEntityType.Text = "[???]";
            lblMemberID.Text = "[???]";

        }
        private void _FillPaymentInfo()
        {

            linkMemberInfo.Enabled = true;
            linklblUserInfo.Enabled = true;

            _paymentDetailsID = _paymentDetails.PaymentDetailID;
            _PaymentID=_paymentDetails.PaymentID;

            lblAmount.Text = _paymentDetails.Amount.ToString();
            lblPaymentDate.Text = _paymentDetails.PaymentDate.ToString("yyyy:MM:dd");
            lblCreateByUser.Text = _paymentDetails.UsersInfo.UserName.ToString();
            lblPaymentID.Text = _paymentDetails.PaymentID.ToString();
            lblPaymentDetailID.Text = _paymentDetails.PaymentDetailID.ToString();
            lblPaymentType.Text = _paymentDetails.PaymentTypesInfo.TypeName;
            lblPaymentStatus.Text = clsPayments.GetPaymentStatusText((clsPayments.enPaymentStatus)_paymentDetails.PaymentStatus);
            lblEntityID.Text = _paymentDetails.EntityID.ToString();
            lblEntityType.Text = _paymentDetails.PaymentEntitiesInfo.EntityName;
            lblMemberID.Text = _paymentDetails.MemberID.ToString();

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmMemberDetails frmMember=new frmMemberDetails(_paymentDetails.MemberID);
            frmMember.ShowDialog();
        }

        private void linklblUserInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmUserDetails userDetails  =new frmUserDetails(_paymentDetails.UsersInfo.UserID);
            userDetails.ShowDialog();
        }
    }
}
