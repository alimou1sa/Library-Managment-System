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
    public partial class frmPurchasesBook : Form
    {
        public frmPurchasesBook(int PurchasesBookID)
        {
            InitializeComponent();
            _PurchasesBookID = PurchasesBookID;
            _Mode=enMode.Update;
        }


        public frmPurchasesBook()
        {
            InitializeComponent();
            _Mode=enMode.AddNew;
        }

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _PurchasesBookID = -1;
        private int _CopyID = -1;

        clsPurchasesBooks _PurchasesBook;
        clsPaymentDetails _PaymentDetails;





        private async void _FillPaymentTypeInComoboBox()
        {
            DataTable dtPayment = await  clsPaymentTypes.GetListPaymentTypes();
            foreach (DataRow row in dtPayment.Rows)
            {
                cbPaymentType.Items.Add(row["TypeName"]);
            }
        }

        private void _ResetDefualtValues()
        {
            _ResetPaymentValues();
            cbPaymentType.SelectedIndex = 0;
            if (_Mode == enMode.AddNew)
            {
                lblTitel.Text = "Purchases Book";
                this.Text = "Purchases Book";
                _PurchasesBook = new clsPurchasesBooks();
                _PaymentDetails = new clsPaymentDetails();

                tpMemberInfo.Enabled = false;
                dtpPurchaseDate.Enabled = true ;
                lblCreateByUser.Enabled = false;
                dtpPurchaseDate.Value = DateTime.Now;
                ctrlBookCardWithFilter1.FilterFocus();
                ctrlMemberCardWhithFilter1.FilterFocus();
                lblCreateByUser.Text=clsGlobal.CurrentUser.UserName;

            }
            else
            {
                lblTitel.Text = "Update Purchases Book";
                this.Text = "Update Purchases Book";

       
                tpMemberInfo.Enabled = false;
                tpBookInfo.Enabled = false;
                tpPurchasesBookInfo.Enabled = true;
                btnSave.Enabled = true;
            }





        }

        private void _ResetPaymentValues()
        {
            _FillPaymentTypeInComoboBox();

            cbPaymentType.SelectedIndex =0;
            lblPaymentDate.Text = DateTime.Now.ToString("yyyy|MM|dd");
            lblTotalPrice.Text = 0.ToString();
            lblPaymentStatus.Text = clsPaymentDetails.GetPaymentStatusText(clsPaymentDetails.enPaymentStatus.Pending);

        }

        private async Task<bool> _SavePayment()
        {
            _PaymentDetails.PaymentTypeID = clsPaymentTypes.FindByTypeName(cbPaymentType.Text.Trim()).PaymentTypeID;
            _PaymentDetails.MemberID = ctrlMemberCardWhithFilter1.MemberID;
            _PaymentDetails.Amount = Convert.ToInt32(lblTotalPrice.Text.Trim());
            _PaymentDetails.PaymentStatus = (byte)clsPayments.enPaymentStatus.Paid;
            _PaymentDetails.CreateByUserID = clsGlobal.CurrentUser.UserID;
            _PaymentDetails.PaymentDate = DateTime.Now;
            int EntityTypeID = (byte)clsPaymentEntities.enEntityType.Purchases;
            _PaymentDetails.EntityTypeID = clsPaymentEntities.FindByID(EntityTypeID).EntityTypeID;
            _PaymentDetails.EntityID = _PurchasesBook.PurchaseID;

            if (await  _PaymentDetails.Save())
            {
                lblPaymentID.Text = _PaymentDetails.PaymentID.ToString();
                lblPaymentStatus.Text = Convert.ToString(clsPayments.enPaymentStatus.Paid);

                return true;
            }
            return false;

        }

        private void _LoadData()
        {

            _PurchasesBook = clsPurchasesBooks.FindByID(_PurchasesBookID);
            NupdCopiesPurchased.Enabled=false;
            ctrlMemberCardWhithFilter1.FilterEnabled = false;
            ctrlBookCardWithFilter1.FilterEnabled = false;

            if (_PurchasesBook == null)
            {
                MessageBox.Show("No Purchases with ID = " + _PurchasesBookID, "Purchases Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            _PaymentDetails = clsPaymentDetails.FindByEntityID(_PurchasesBook.PurchaseID, (byte)clsPaymentEntities.enEntityType.Purchases);

            if (_PaymentDetails == null)
            {
                MessageBox.Show("No Payment with ID = " + _PaymentDetails.PaymentID, " Payment Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            lblPaymentID.Text = _PaymentDetails.PaymentID.ToString();
            cbPaymentType.SelectedIndex = _PaymentDetails.PaymentTypeID-1;
            ctrlMemberCardWhithFilter1.LoadMemberInfo(_PurchasesBook.MemberID);
            ctrlBookCardWithFilter1.LoadBookInfo(_PurchasesBook.BookID);
            tabControl1.SelectedTab = tabControl1.TabPages["tpPurchasesBookInfo"];
            lblPurchaseID.Text = _PurchasesBook.PurchaseID.ToString();
            lblCreateByUser.Text = _PurchasesBook.UsersInfo.UserName;
            dtpPurchaseDate.Value = _PurchasesBook.PurchaseDate;
            NupdCopiesPurchased.Value = _PurchasesBook.CopiesPurchased;

            lblTotalPrice .Text =_PaymentDetails.Amount.ToString();
            lblPaymentStatus.Text = clsPaymentDetails.GetPaymentStatusText((clsPayments.enPaymentStatus)_PaymentDetails.PaymentStatus);


        }

        private async void _Save()
        {

            if (!this.ValidateChildren())
            {

                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (_Mode == enMode.AddNew)
            {
                _PurchasesBook.TotalPrice = ((double)NupdCopiesPurchased.Value) * ((double)ctrlBookCardWithFilter1.SelectedBookInfo.BookPrice);
                _PurchasesBook.CreateByUserID = clsGlobal.CurrentUser.UserID;
                _PurchasesBook.PurchaseDate = dtpPurchaseDate.Value;
                _PurchasesBook.MemberID = ctrlMemberCardWhithFilter1.MemberID;
                _PurchasesBook.BookID = ctrlBookCardWithFilter1.BookID;
                _PurchasesBook.CopiesPurchased = (int)NupdCopiesPurchased.Value;

                for (int i = 0; i < _PurchasesBook.CopiesPurchased; i++)
                {

                    clsBookCopies.ChangeCopyStatus(_CopyID, clsBookCopies.enStatusCopy.Sold);
                    _GetCopyID();
                }
            }
            else if (_Mode == enMode.Update)
                _PurchasesBook.PurchaseDate = dtpPurchaseDate.Value;

            

            if (  _PurchasesBook.Save() && await  _SavePayment())
            {

                lblPurchaseID.Text = _PurchasesBook.PurchaseID.ToString();
                lblPaymentID.Text = _PaymentDetails.PaymentID.ToString();
             
                    _Mode = enMode.Update;
                    lblTitel.Text = "Update Purchases Book";
                    this.Text = "Update Purchases Book";

                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
      


            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }

        private async void _GetCopyID()
        {
                _CopyID = await   clsBookCopies.GetCopyIDAvailabl(ctrlBookCardWithFilter1.BookID);
                if (_CopyID == -1)
                {
                    if (MessageBox.Show("This Book Is Not Available Now ", "XXX", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ctrlBookCardWithFilter1.FilterFocus();
                        return;
                    }
                }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpMemberInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpMemberInfo"];
                return;
            }


            if (ctrlBookCardWithFilter1.BookID != -1)
            {

                _GetCopyID();

                btnSave.Enabled = true;
                tpMemberInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpMemberInfo"];



            }
            else

            {
                MessageBox.Show("Please Select a PurchasesBoo", "Select a PurchasesBoo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlBookCardWithFilter1.FilterFocus();
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpPurchasesBookInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpPurchasesBookInfo"];
                return;
            }


            if (ctrlMemberCardWhithFilter1.MemberID != -1)
            {
                if (ctrlMemberCardWhithFilter1.SelectedMemberInfo.IsActive != true)
                {
                    MessageBox.Show("This Member Is Not Active ,Choose Anuther One", "Select a Book", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                btnSave.Enabled = true;
                tpPurchasesBookInfo.Enabled = true;
                lblTotalPrice.Text = (((double)NupdCopiesPurchased.Value) * ((double)ctrlBookCardWithFilter1.SelectedBookInfo.BookPrice)).ToString();
                tabControl1.SelectedTab = tabControl1.TabPages["tpPurchasesBookInfo"];

            }
            else

            {
                MessageBox.Show("Please Select a Member", "Select a Member", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlMemberCardWhithFilter1.FilterFocus();

            }
        }

        private void frmPurchasesBook_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if(_Mode == enMode.Update) 
                _LoadData();

        }

        private async void NupdCopiesPurchased_ValueChanged(object sender, EventArgs e)
        {
            if (_Mode != enMode.Update)
            {
                int NumberOfAvailableCopies =
                  await   clsBookCopies.GetNumberOfAvailableBookCopies(ctrlBookCardWithFilter1.BookID, (byte)clsBookCopies.enStatusCopy.Available);
                if (NupdCopiesPurchased.Value > NumberOfAvailableCopies)
                {
                    MessageBox.Show("Ther Are Only " + NumberOfAvailableCopies + " Available Book Copies", "XXX", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    NupdCopiesPurchased.Value = NumberOfAvailableCopies;


                }
                lblTotalPrice.Text = (((double)NupdCopiesPurchased.Value) * ((double)ctrlBookCardWithFilter1.SelectedBookInfo.BookPrice)).ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
