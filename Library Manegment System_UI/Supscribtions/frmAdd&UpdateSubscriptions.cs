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
    public partial class frmAdd_UpdateSubscriptions : Form
    {

        public delegate void DataBackEventHandler(object sender, int SubscriptionID);
        public event DataBackEventHandler DataBack;


        public frmAdd_UpdateSubscriptions(int? memberID=null, int SubscriptionID=-1)
        {
            InitializeComponent();

            if(SubscriptionID==-1)
            _Mode=enMode.AddNew;
            else
            _Mode=enMode.Update;


            _MemberID = memberID;
            _SubscriptionID=SubscriptionID;

        }

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;


        private int ? _MemberID = null;


        private int? _SubscriptionID = null;
        clsMemberSubscriptions _MemberSubscriptions;


        clsPaymentDetails _PaymentDetails;
        private int? _PaymentDetailsID = null;


        clsMembershipPlans _MembershipPlans;
        private int ?_MembershipPlanID=null;

        private async void _FillSubscriptionPlansInComoboBox()
        {
            DataTable dtSubscription = await  clsMembershipPlans.GetListMembershipPlans();

            foreach (DataRow row in dtSubscription.Rows)
            {
                cbPlane.Items.Add(row["PlanName"]);
            }
        }

        private async void _FillPaymentTypeInComoboBox()
        {
            DataTable dtPayment =await  clsPaymentTypes.GetListPaymentTypes();
            foreach (DataRow row in dtPayment.Rows)
            {
                cbPaymentType.Items.Add(row["TypeName"]);
            }
        }


        private void _ResetDefualtValues()
        {
            _FillSubscriptionPlansInComoboBox();
            _FillPaymentTypeInComoboBox();

            if (_MemberID.HasValue)
            {
                ctrlMemberCardWhithFilter1.FilterEnabled = false;
                ctrlMemberCardWhithFilter1.LoadMemberInfo(_MemberID.Value);
            }

            if (_Mode == enMode.AddNew)
            {
                lblTitel.Text = "Add New Member Subscriptions";
                this.Text = "Add New Member Subscriptions";
                _MemberSubscriptions = new clsMemberSubscriptions();
                _PaymentDetails = new clsPaymentDetails();
                tpSubscriptionInfo.Enabled = false;
                cbSubStatus.Enabled = false;

            }
            else
            {
                lblTitel.Text = "Update Member";
                this.Text = "Update Member";

                tpSubscriptionInfo.Enabled = true;
                btnSave.Enabled = true;
                cbPlane.Enabled = false;
                cbPaymentType.Enabled = false;
            }


            chbIsSubscribtionActive.Enabled = false;


            cbPaymentType.SelectedIndex = 0;
            lblPaymentDate.Text = DateTime.Now.ToString("yyyy:MM:dd");
            lblPaymentStatus.Text = clsPayments.GetPaymentStatusText(clsPayments.enPaymentStatus.Pending);

            lblSuscriptionBuUser.Text=clsGlobal.CurrentUser.UserName;
            cbSubStatus.SelectedIndex = 1;
            cbPlane.SelectedIndex = 0;
            lblStartDate.Text = DateTime.Now.ToString("yyyy:MM:dd");
            chbIsSubscribtionActive.Checked = false;

        }

        private void _LoadData()
        {
            _MemberSubscriptions = clsMemberSubscriptions.FindByID(_SubscriptionID.Value);
            if (_MemberSubscriptions == null)
            {
                MessageBox.Show("Error: No Subsription with ID = " + _SubscriptionID.Value.ToString(),
              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }


            _PaymentDetails = clsPaymentDetails.FindByEntityID(_MemberSubscriptions.SubscriptionID, (byte)clsPaymentEntities.enEntityType.MemberSubscription);
            if (_PaymentDetails == null)
            {
                MessageBox.Show("No PaymentDetails with SubscriptionID = " + _SubscriptionID, ", Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }


            if(_MemberSubscriptions.EndDate<=DateTime.Now)
            {
                MessageBox.Show("This Subscription with SubscriptionID = " + _SubscriptionID+" is Ended", " , Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tpSubscriptionInfo.Enabled = false;
                ctrlMemberCardWhithFilter1.FilterEnabled = false;
                btnSave.Enabled = false;
                cbSubStatus.Enabled = false;
            }



            lblPaymentID.Text = _PaymentDetails.PaymentID.ToString();
            cbPaymentType.SelectedIndex = _PaymentDetails.PaymentTypeID - 1;
            lblPaymentDetailsID.Text = _PaymentDetails.PaymentDetailID.ToString();
            lblPaymentDate.Text = _PaymentDetails.PaymentDate.ToString("yyyy:MM:dd");
            lblPaymentStatus.Text = clsPayments.GetPaymentStatusText((clsPayments.enPaymentStatus)_PaymentDetails.PaymentStatus);

            ctrlMemberCardWhithFilter1.LoadMemberInfo(_MemberSubscriptions.MemberID);
            cbSubStatus.SelectedIndex = _MemberSubscriptions.SubscriptionStatus - 1;
            lblSubscriptionID.Text = _MemberSubscriptions.SubscriptionID.ToString();
            lblStartDate.Text = _MemberSubscriptions.StartDate.ToString("yyyy:MM:dd");
            lblEndDate.Text = _MemberSubscriptions.EndDate.ToString("yyyy:MM:dd");
            cbPlane.SelectedIndex = _MemberSubscriptions.PlanID - 1;
            chbIsSubscribtionActive.Checked = _MemberSubscriptions.IsActive;
            lblSuscriptionBuUser.Text=_MemberSubscriptions.UsersInfo.UserName.ToString();

        }

        private void cbPlane_SelectedIndexChanged(object sender, EventArgs e)
        {
            _MembershipPlans = clsMembershipPlans.FindByPlanName(cbPlane.Text.Trim());
            if (_MembershipPlans != null)
            {
                lblEndDate.Text = DateTime.Now.Date.AddMonths(_MembershipPlans.DurationMonths).ToString("yyyy:MM:dd");
                lblSubscriptionPrice.Text = _MembershipPlans.Price.ToString();
            }
        }

        private void frmAdd_UpdateSubscriptions_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpSubscriptionInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpSubscriptionInfo"];
                return;
            }

            if (ctrlMemberCardWhithFilter1.MemberID != -1)
            {

                if ((  ctrlMemberCardWhithFilter1.SelectedMemberInfo.IsActive&& await clsMemberSubscriptions.IsMembersHasActiveSubscription(ctrlMemberCardWhithFilter1.MemberID))&&_Mode==enMode.AddNew)

                {

                    MessageBox.Show("Selected Member already has an Active Subscription, choose another one.", "Select another Member", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlMemberCardWhithFilter1.FilterFocus();
                }

                else
                {
                    btnSave.Enabled = true;
                    tpSubscriptionInfo.Enabled = true;
                    tabControl1.SelectedTab = tabControl1.TabPages["tpSubscriptionInfo"];
                }
            }

            else
            {
                MessageBox.Show("Please Select a Member", "Select a Member", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlMemberCardWhithFilter1.FilterFocus();

            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (_Mode == enMode.AddNew)
            {
                _MembershipPlans = clsMembershipPlans.FindByPlanName(cbPlane.Text);
                _MemberSubscriptions.StartDate = DateTime.Now;
                _MemberSubscriptions.IsActive = true;
                _MemberSubscriptions.PlanID = _MembershipPlans.PlanID;
                _MemberSubscriptions.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                _MemberSubscriptions.EndDate =
                    DateTime.Now.Date.AddMonths(_MembershipPlans.DurationMonths);
                _MemberSubscriptions.SubscriptionStatus = (byte)clsMemberSubscriptions.enSubscriptionStatus.Active;


                _PaymentDetails.PaymentTypeID = clsPaymentTypes.FindByTypeName(cbPaymentType.Text.Trim()).PaymentTypeID;
                _PaymentDetails.MemberID = ctrlMemberCardWhithFilter1.MemberID;
                _PaymentDetails.Amount = _MembershipPlans.Price;
                _PaymentDetails.PaymentStatus = (byte)clsPayments.enPaymentStatus.Paid;
                _PaymentDetails.CreateByUserID = clsGlobal.CurrentUser.UserID;
                _PaymentDetails.PaymentDate = DateTime.Now;
                int EntityTypeID = (byte)clsPaymentEntities.enEntityType.MemberSubscription;
                _PaymentDetails.EntityTypeID = clsPaymentEntities.FindByID(EntityTypeID).EntityTypeID;
            }
            else
            {

                if (!clsMemberSubscriptions.IsSubscriptionActivByStatus((clsMemberSubscriptions.enSubscriptionStatus)clsMemberSubscriptions.GetSubscriptionStatusAsByte(cbSubStatus.Text.Trim())))
                    _MemberSubscriptions.IsActive = false;
                
                else
                    _MemberSubscriptions.IsActive = true;

                
                _MemberSubscriptions.SubscriptionStatus = clsMemberSubscriptions.GetSubscriptionStatusAsByte(cbSubStatus.Text.Trim());
                _PaymentDetails.PaymentTypeID = clsPaymentTypes.FindByTypeName(cbPaymentType.Text.Trim()).PaymentTypeID;
            }


            _PaymentDetails.MemberID = ctrlMemberCardWhithFilter1.MemberID;
            _MemberSubscriptions.MemberID = ctrlMemberCardWhithFilter1.MemberID;

            if (! await _MemberSubscriptions.Save())
            {
                MessageBox.Show("Error:Member Subscriptions  Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _PaymentDetails.EntityID = _MemberSubscriptions.SubscriptionID;
            chbIsSubscribtionActive.Checked = true;


           await  clsMembers.UpdateLastSubscriptionID(ctrlMemberCardWhithFilter1.MemberID, _MemberSubscriptions.SubscriptionID);


            if (await  _PaymentDetails.Save())
            {
              await   clsMembers.ChangeIsMemberActive(ctrlMemberCardWhithFilter1.MemberID, _MemberSubscriptions.IsActive);


                lblPaymentID.Text = _PaymentDetails.PaymentID.ToString();
                lblPaymentDetailsID.Text = _PaymentDetails.PaymentDetailID.ToString();
                lblSubscriptionID.Text = _MemberSubscriptions.SubscriptionID.ToString();
                cbSubStatus.Enabled = true;
                cbPaymentType.Enabled = false;
                cbPlane.Enabled = false;
                if (_Mode == enMode.AddNew) cbSubStatus.SelectedIndex = 0;

                _Mode = enMode.Update;
                lblTitel.Text = "Update Member";
                this.Text = "Update Member";

                DataBack?.Invoke(this, _MemberSubscriptions.MemberID);
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void ctrlPaymentInfo2_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void cbSubStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
     
        }
   
    
    
    }
}
