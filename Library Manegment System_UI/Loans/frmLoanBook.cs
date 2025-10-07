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
    public partial class frmLoanBook : Form
    {


        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int? _BookID = null;
        private int? _MemberID =null;

        public enum enCreationMode { BorrowBook = 0, ReturnBook = 1 };
        private enCreationMode _CreationMode;

        clsPaymentDetails _PaymentDetails;


        private int _LoanID = -1;
        clsLoanes _Loan;
        private int _CopyID = -1;
        clsBookCopies _BookCopies;
        clsReservations _Reservations;
        bool IsReservationMode = false;


        public frmLoanBook(int BookID=-1,int MemmberID=-1 )
        {
            InitializeComponent();

            if(BookID!=-1)
                _BookID = BookID;
            if( MemmberID!=-1)
                _MemberID = MemmberID;

            _CreationMode =enCreationMode.BorrowBook;
            _Mode = enMode.AddNew;
        }

        public frmLoanBook(int LoanID,bool IsUpdateMode)
        {
            InitializeComponent();

            _LoanID = LoanID;

            _CreationMode=enCreationMode.ReturnBook;
            if (IsUpdateMode)
                _Mode = enMode.Update;
            else
                _Mode = enMode.AddNew;

        }

        private async void _ResetDefualtValues()
        {
            if (_BookID.HasValue)
            {
                if((!await  clsBookCopies.IsAvailablBook(_BookID.Value)))
                {
                    if (MessageBox.Show("This Book Is Not Available Now  ,Do you Want To Add Resarvation ", "XXX", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmAddUpdateReservations addReservations = new frmAddUpdateReservations(_BookID.Value);
                        this.Close();
                        addReservations.ShowDialog();

                    }
                    return;
                }
                ctrlBookCardWithFilter1.FilterEnabled = false;
                ctrlBookCardWithFilter1.LoadBookInfo(_BookID.Value);
            }
            if (_MemberID.HasValue)
            {
                ctrlMemberCardWhithFilter1.FilterEnabled=false;
                ctrlMemberCardWhithFilter1.LoadMemberInfo(_MemberID.Value);
            }

            if (_Mode == enMode.AddNew )
            {
                if (_CreationMode == enCreationMode.BorrowBook)
                {
                    lblTitel.Text = "Borrow Book";
                    this.Text = "Borrow Book";
                
                    tpBookInfo.Enabled=false;
                    tpLoanInfo.Enabled=false;

                    _Loan = new clsLoanes();

                }
                if(_CreationMode == enCreationMode.ReturnBook)
                { 
                    ctrlBookCardWithFilter1 .FilterEnabled = false;
                    ctrlMemberCardWhithFilter1 .FilterEnabled = false;

                        lblTitel.Text = "Return Book";
                        this.Text = "Return Book";
                   

                }

                lblLoanDate.Text = DateTime.Now.ToString("yyyy|MM|dd");
                DateTime dateTime = DateTime.Now.Date.AddDays(clsSettings.GetDefualtBorrrowDays());
                lblDueDate.Text = dateTime.ToString("yyyy|MM|dd");
                lblLoanByUser.Text = clsGlobal.CurrentUser.UserName;
                ctrlMemberCardWhithFilter1.FilterFocus();
                lblCopyID.Text = _CopyID.ToString();

            }
            else if(_Mode==enMode.Update) 
            {


                tpLoanInfo.Enabled = true;
                btnSave.Enabled = true;
                lblReturnByUser.Text = clsGlobal.CurrentUser.UserName;
              
                lblReturnDate.Text = DateTime.Now.ToString("yyyy|MM|dd");



                if (_CreationMode == enCreationMode.BorrowBook)
                {
                    lblTitel.Text = "Update Borrow Book";
                    this.Text = "Undate Borrow Book";

                }
                else
                {

                    lblTitel.Text = "Update Return Book";
                    this.Text = "Update Return Book";

                }


            }


        }
        private void _ResetFineInfo(int DifferenceDays)
        {
            _FillPaymentTypeInComoboBox();
            lblAmount.Text = (DifferenceDays * clsSettings.GetDefualtFineDays()).ToString();
            lblPaymentDate.Text = DateTime.Now.ToString("yyyy|MM|dd");
            lblPaymentStatus.Text = Convert.ToString(clsPayments.enPaymentStatus.Pending);
            cbPaymentType.SelectedIndex = 0;

        }
      
        private bool _CheckIsLateInReturning()
        {
            if (DateTime.Now > _Loan.DueDate)
            {
                TimeSpan Difference = DateTime.Now - _Loan.DueDate;

                if (MessageBox.Show("You are " + Difference.Days + " Days Late in Returning the Book , You Must Pay Fine", "Select a Member", MessageBoxButtons.OK, MessageBoxIcon.Hand) == DialogResult.OK)
                {

                    gpPaymentInfo.Enabled = true;
                    _ResetFineInfo(Difference.Days);
                    lblDays.Text = Difference.Days.ToString();
                    _PaymentDetails = new clsPaymentDetails();
                    return true;
                }

            }

            return false;
        }


        private async void _FillPaymentTypeInComoboBox()
        {
            DataTable dtPayment = await  clsPaymentTypes.GetListPaymentTypes();
            foreach (DataRow row in dtPayment.Rows)
            {
                cbPaymentType.Items.Add(row["TypeName"]);
            }
        }


        private bool _IsHasApyment()
        {
            _PaymentDetails = clsPaymentDetails.FindByEntityID(_Loan.LoanID, (byte)clsPaymentEntities.enEntityType.LateFees);

            if (_PaymentDetails != null)
            
                return true;

            
            return false;
                    
        }
       
        private void _LoadData()
        {

            _Loan = clsLoanes.FindByID(_LoanID);

            if (_Loan == null)
            {
                MessageBox.Show("No Loan with ID = " + _LoanID, "Loan Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            if(_IsHasApyment())
            {
                
                _FillPaymentTypeInComoboBox();
                lblAmount.Text =_PaymentDetails.Amount.ToString();
                lblPaymentDate.Text = _PaymentDetails.PaymentDate.ToString("yyyy:MM:dd");
                lblPaymentStatus.Text = clsPayments.GetPaymentStatusText((clsPayments.enPaymentStatus)_PaymentDetails._PaymentStatus);
                cbPaymentType.SelectedIndex = cbPaymentType.FindString(_PaymentDetails.PaymentTypesInfo.TypeName);
                lblPaymentID.Text = _PaymentDetails.PaymentID.ToString();
                TimeSpan time = _Loan.DueDate - _Loan.ReturnDate;
                lblDays.Text = time.Days. ToString();

            }


            lblLoanID.Text = _Loan.LoanID.ToString();
            lblLoanByUser.Text = _Loan.LoanUserInfo.UserName;
            lblCopyID.Text = _Loan.CopyID.ToString();
            lblLoanDate.Text = _Loan.LoanDate.ToString("yyyy|MM|dd"); ;
            lblDueDate.Text = _Loan.DueDate.ToString("yyyy|MM|dd");
            ctrlMemberCardWhithFilter1.LoadMemberInfo(_Loan.MemberID);
            ctrlBookCardWithFilter1.LoadBookInfo(_Loan.BookCopiesInfo.BookID);
        }

        private void frmBorrowBook2_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if (_Mode == enMode.Update||_CreationMode==enCreationMode.ReturnBook)
                _LoadData();
        }

        private void btnNext1_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpBookInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpBookInfo"];
                return;
            }


            if (ctrlMemberCardWhithFilter1.MemberID != -1)
            { 
                if(ctrlMemberCardWhithFilter1.SelectedMemberInfo.IsActive!=true)
                {
                    MessageBox.Show("This Member Is Not Active ,Choose Anuther One", "Select a Book", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                btnSave.Enabled = true;
                tpBookInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpBookInfo"];

            }
            else

            {
                MessageBox.Show("Please Select a Member", "Select a Book", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlMemberCardWhithFilter1.FilterFocus();

            }
        }

        private async void btnNext2_Click(object sender, EventArgs e)
        {

            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpLoanInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpLoanInfo"];
         
                return;
            }
            else
            {
               if(_CreationMode==enCreationMode.ReturnBook)
                _CheckIsLateInReturning();

            }
            if (ctrlBookCardWithFilter1.BookID != -1)
            {

                if (_CreationMode == enCreationMode.BorrowBook && _Mode == enMode.AddNew)
                {
                    _CopyID =  await  clsBookCopies.GetCopyIDAvailabl(ctrlBookCardWithFilter1.BookID);
                    if (_CopyID == -1)
                    {
                        if (MessageBox.Show("This Book Is Not Available Now  ,Do you Want To Add Resarvation ", "XXX", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            frmAddUpdateReservations addReservations = new frmAddUpdateReservations(ctrlBookCardWithFilter1.BookID);
                            this.Close();
                            addReservations.ShowDialog();
                           
                        }
                        return;
                    }
                    lblCopyID.Text=_CopyID.ToString();
                }
                btnSave.Enabled = true;
                tpLoanInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tpLoanInfo"];

            }
            else
            {
                MessageBox.Show("Please Select a Book", "Select a Book", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlBookCardWithFilter1.FilterFocus();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this .Close();
        }

        private async Task< bool> _IsThisBookReservation()
        {

            if (await  clsBookCopies.IsAvailablBook(ctrlBookCardWithFilter1.BookID))
            {

                if (clsReservations.IsThereReservationsForThisBook(ctrlBookCardWithFilter1.BookID))
                {
                    return true;

                }
            }

            return false;
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
                if (_CreationMode == enCreationMode.BorrowBook)
                {
  

                 _Loan =await  _Loan.BorrowBook(ctrlMemberCardWhithFilter1.MemberID, clsGlobal.CurrentUser.UserID, _CopyID,DateTime.Now);
            
                    if (_Loan != null)
                    {
                        clsReservations reservations = clsReservations.FindByBOOKIDAndMemberID(ctrlBookCardWithFilter1.BookID, ctrlMemberCardWhithFilter1.MemberID);
                        if(reservations!=null)
                        {
                            reservations.ChangeResrvationStatus(clsReservations.enReservationsStatus.ConvertToBorrowing);
                        }
                       
                        _Mode = enMode.Update;
                        _CreationMode = enCreationMode.BorrowBook;
                        lblTitel.Text = "Update Borrow Book";
                        this.Text = "Update Borrow Book";
                        lblLoanID.Text = _Loan.LoanID.ToString();
                        MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else if (_CreationMode == enCreationMode.ReturnBook)
                {

                    if(_Loan.ISLateInReturningAndReturnDifferenceDays()!=0)
                    _Loan =await  _Loan.ReturnBook(clsGlobal.CurrentUser.UserID, clsPaymentTypes.FindByTypeName(cbPaymentType.Text.Trim()).PaymentTypeID,DateTime.Now);
                    else
                        _Loan = await _Loan.ReturnBook(clsGlobal.CurrentUser.UserID, -1, DateTime.Now);

                    if (_Loan != null)
                    {
 

                        lblReturnByUser.Text = clsGlobal.CurrentUser.UserName;
                        _Mode = enMode.Update;
                        lblTitel.Text = "Update Return Book";
                        this.Text = "Update Return Book";
                        btnSave.Enabled = false;
                        MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (await  _IsThisBookReservation())
                        {
                            MessageBox.Show("This Book iS Availble Now,There Are Active Reservation For This Book ", "RESERVATIONs", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);  
                        }

                    }

                }
            }
            else
            {

                _Loan.MemberID=ctrlMemberCardWhithFilter1.MemberID;

                if(await  _Loan.Save())
                {
                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }



        }

        private void ctrlMemberCardWhithFilter1_OnMemberSelected(object sender, ctrlMemberCardWhithFilter.MemberSelectedEventArgs e) => _MemberID = e.MemberID;



        private async void ctrlBookCardWithFilter1_OnBookSelected(int obj)
        {
            _BookID = obj;
            if(_BookID.HasValue&&_Mode==enMode.AddNew&&_CreationMode==enCreationMode.BorrowBook)
            {

                _CopyID = await  clsBookCopies.GetCopyIDAvailabl(_BookID.Value);


                if (_CopyID == -1)
                {
                    if (MessageBox.Show("This Book Is Not Available Now  ,Do you Want To Add Resarvation", "XXX", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmAddUpdateReservations addReservations = new frmAddUpdateReservations(_BookID.Value);
                        addReservations.ShowDialog();

                    }
                    this.Close();
                }

                lblCopyID.Text=_CopyID.ToString();
            }
            if(_Mode==enMode.Update&&_CreationMode==enCreationMode.BorrowBook)
            {
                _CopyID = await  clsBookCopies.GetCopyIDAvailabl(_BookID.Value);

                if (_CopyID == -1)
                    ctrlBookCardWithFilter1.FilterEnabled = false;
                else
                    _Loan.CopyID = await  clsBookCopies.GetCopyIDAvailabl(ctrlBookCardWithFilter1.BookID);
            }
        }




    }
}
