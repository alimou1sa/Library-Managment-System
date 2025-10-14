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
    public partial class frmAddUpdatePayments : Form
    {
        public delegate void DataBackEventHandler(object sender, int MemberID);
        public event DataBackEventHandler DataBack;


        private int _EntityID = -1;
        private double _Amount = -1;


        private clsPaymentDetails _paymentDetails;
        private int _PaymentDetailsID = -1;

        private clsPaymentEntities _paymentEntities;
       private int _EntityTypeID = -1;

        private int _MemberID = -1;

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        public frmAddUpdatePayments(int EntityTypeID, int EntityID, double amount,int MemberID)
        {
            InitializeComponent();

            _EntityTypeID = EntityTypeID;
             _EntityID = EntityID;
            _MemberID = MemberID;
            _Mode = enMode.AddNew;
            _Amount = amount;

        }
        public frmAddUpdatePayments(int PaymentDetailsID)
        {
            InitializeComponent();
            _PaymentDetailsID = PaymentDetailsID;
            _Mode = enMode.Update;
        }

        private async Task  _FillPaymentTypeInComoboBox()
        {
            DataTable DTPaymentType = await  clsPaymentTypes.GetListPaymentTypes();

            foreach (DataRow row in DTPaymentType.Rows)
            {
                cbPaymentType.Items.Add(row["TypeName"]);
            }
        }




        private async void _ResetDefualtValues()
        {
           await  _FillPaymentTypeInComoboBox();
            if (_Mode == enMode.AddNew)
            {
                lblTitel.Text = "Add New Payments";
                this.Text = "Add New Payments";
                _paymentDetails = new clsPaymentDetails();

                tbgPaymentInfo.Enabled = false;
                ctrlMemberCardWhithFilter1.FilterFocus();

                if (_EntityTypeID != -1)
                {
                    _paymentEntities = clsPaymentEntities.FindByID(_EntityTypeID);
                    if (_paymentEntities == null)
                    {
                        MessageBox.Show("No EntityType with ID = " + _EntityTypeID, ", Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                        return;
                    }
                }
                if (_MemberID != -1)
                {
                    ctrlMemberCardWhithFilter1.FilterEnabled = false;
                    ctrlMemberCardWhithFilter1.LoadMemberInfo(_MemberID);
                }
                lblEntityName.Text = _paymentEntities.EntityName.ToString();
                lblEntityID.Text = _EntityID.ToString();
                lblAmount.Text = _Amount.ToString();
            }
            else
            {
                lblTitel.Text = "Update Payments";
                this.Text = "Update Payments";

                tbgPaymentInfo.Enabled = true;
                btnSave.Enabled = true;
            }


            lblCrateByUser.Text=clsGlobal.CurrentUser.UserName;
            lblPaymentDate.Text=DateTime.Now.ToString("yyyy:MM:dd");
            lblPaymentStatus.Text = Convert.ToString(clsPayments.enPaymentStatus.Pending);

            cbPaymentType.SelectedIndex = 0;
        }

        private void _LoadData()
        {

            _paymentDetails = clsPaymentDetails.FindByID(_PaymentDetailsID);
            ctrlMemberCardWhithFilter1.FilterEnabled = false;

            if (_paymentDetails == null)
            {
                MessageBox.Show("No Payment with ID = " + _PaymentDetailsID, ", Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            _EntityID = _paymentDetails.EntityID;
            _EntityTypeID = _paymentDetails.EntityTypeID;
           _Amount = _paymentDetails.Amount;

            lblPaymentID.Text=_paymentDetails.PaymentID.ToString();
            lblPaymentDetailsID.Text = _paymentDetails.PaymentDetailID.ToString();

            lblAmount.Text = _paymentDetails.Amount.ToString();
            lblCrateByUser.Text = _paymentDetails.UsersInfo.UserName;
            lblEntityID.Text = _paymentDetails.EntityID.ToString();
            lblEntityName.Text = _paymentDetails.PaymentEntitiesInfo.EntityName;
            lblPaymentDate.Text = _paymentDetails.PaymentDate.ToString("yyyy:MM:dd");
            lblPaymentStatus.Text = clsPayments.GetPaymentStatusText((clsPayments.enPaymentStatus)_paymentDetails._PaymentStatus);

            cbPaymentType.SelectedIndex = cbPaymentType.FindString(clsPaymentTypes.FindByID(_paymentDetails.PaymentTypeID).TypeName);
            ctrlMemberCardWhithFilter1.LoadMemberInfo(_paymentDetails.MemberID);
        }

        private void gpPaymentInfo_Enter(object sender, EventArgs e)
        {

        }

        private void frmAddUpdatePayments_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if(_Mode==enMode.Update) 
                _LoadData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tbgPaymentInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tbgPaymentInfo"];
                return;
            }


            if (ctrlMemberCardWhithFilter1.MemberID != -1)
            {
                if (ctrlMemberCardWhithFilter1.SelectedMemberInfo.IsActive == true)
                {
                    MessageBox.Show("This Member Is Not Active ,Choose Anuther One", "Select a Book", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                //if (clsMembers.IsMembersExisteByPersonID(_SelectedPersonID))
                //{

                //    MessageBox.Show("Selected Person already has a Member, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    ctrlMemberCardWhithFilter1.FilterFocus();
                //}

                //else
                //{
                btnSave.Enabled = true;
                tbgPaymentInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tbgPaymentInfo"];
                //}
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if(_Mode==enMode.AddNew)
            {
                _paymentDetails.CreateByUserID=clsGlobal.CurrentUser.UserID;
                _paymentDetails.PaymentDate =DateTime.Now;
            }
            else
            {
                _paymentDetails.CreateByUserID = _paymentDetails.CreateByUserID;
                _paymentDetails.PaymentDate =_paymentDetails.PaymentDate;
            }
           
                _paymentDetails.MemberID = ctrlMemberCardWhithFilter1.MemberID;
                 _paymentDetails.Amount = Convert.ToDouble(lblAmount.Text);
                _paymentDetails.PaymentTypeID = clsPaymentTypes.FindByTypeName(cbPaymentType.Text.Trim()).PaymentTypeID;
                _paymentDetails.EntityID = _EntityID;
                _paymentDetails.EntityTypeID=_EntityTypeID;
                _paymentDetails.PaymentStatus=(byte)clsPayments.enPaymentStatus.Paid; 


            if (await  _paymentDetails.Save())
            {

                lblPaymentID.Text = _paymentDetails.PaymentID.ToString();
                lblPaymentDetailsID.Text = _paymentDetails.PaymentDetailID.ToString();
                lblPaymentStatus.Text = "Paid";
               await  clsMemberSubscriptions.ChangeMemberSubscriptionActiv(_paymentDetails.EntityID,true);
                _Mode = enMode.Update;
                lblTitel.Text = "Update Payments";
                this.Text = "Update Payments";
                DataBack?.Invoke(this, _paymentDetails.PaymentDetailID);

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
