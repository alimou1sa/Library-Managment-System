       
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using Library_DataAccessLayer;
       
      
namespace Library_Business
{

    public class clsLoanes
    {

        enum enMode { AddNew, Update };

        enMode _Mode;

        public int LoanID { set; get; }
        public int CopyID { set; get; }
        public int MemberID { set; get; }
        public int LoanByUserID { set; get; }
        public DateTime LoanDate { set; get; }
        public DateTime DueDate { set; get; }
        public DateTime ReturnDate { set; get; }
        public int ReturnByUserID { set; get; }


        public clsBookCopies BookCopiesInfo { set; get; }

        public clsUsers LoanUserInfo { set; get; }



        public clsLoanes()
        {
            this._Mode = enMode.AddNew;

            this.LoanID = -1;
            this.CopyID = -1;
            this.MemberID = -1;
            this.LoanByUserID = -1;
            this.LoanDate = DateTime.MinValue;
            this.DueDate = DateTime.MinValue;
            this.ReturnDate = DateTime.MinValue;
            this.ReturnByUserID = -1;


            this.BookCopiesInfo = null;

        }

        private clsLoanes(int LoanID, int CopyID, int MemberID, int LoanByUserID, DateTime LoanDate, DateTime DueDate, DateTime ReturnDate, int ReturnByUserID)
        {
            this._Mode = enMode.Update;

            this.LoanID = LoanID;
            this.CopyID = CopyID;
            this.MemberID = MemberID;
            this.LoanByUserID = LoanByUserID;
            this.LoanDate = LoanDate;
            this.DueDate = DueDate;
            this.ReturnDate = ReturnDate;
            this.ReturnByUserID = ReturnByUserID;

            this.LoanUserInfo = clsUsers.FindByUserID(this.LoanByUserID);
            this.BookCopiesInfo = clsBookCopies.FindByID(CopyID);


        }

        public static clsLoanes FindByID(int LoanID)
        {
            int CopyID = -1;
            int MemberID = -1;
            int LoanByUserID = -1;
            DateTime LoanDate = DateTime.MinValue;
            DateTime DueDate = DateTime.MinValue;
            DateTime ReturnDate = DateTime.MinValue;
            int ReturnByUserID = -1;


            if (clsLoanesDataAccess.GetLoanesInfoByID(LoanID, ref CopyID, ref MemberID, ref LoanByUserID, ref LoanDate, ref DueDate, ref ReturnDate, ref ReturnByUserID))
            {
                return new clsLoanes(LoanID, CopyID, MemberID, LoanByUserID, LoanDate, DueDate, ReturnDate, ReturnByUserID);

            }

            return null;

        }

        private async Task<bool> _AddNewLoanes()
        {
            this.LoanID = await clsLoanesDataAccess.AddNewLoanes(this.CopyID, this.MemberID, this.LoanByUserID, this.LoanDate, this.DueDate, this.ReturnDate, this.ReturnByUserID);

            return (this.LoanID != -1);

        }
        private async Task<bool> _UpdateLoanes()
        {
            return await clsLoanesDataAccess.UpdateLoanes(this.LoanID, this.CopyID, this.MemberID, this.LoanByUserID, this.LoanDate, this.DueDate, this.ReturnDate, this.ReturnByUserID);
        }

        public async Task<bool> Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:

                    if ( await _AddNewLoanes())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:

                    return await  _UpdateLoanes();

                default:
                    return false;

            }

        }
        public static async Task<bool >DeleteLoanes(int LoanID)
        {
            return await  clsLoanesDataAccess.DeleteLoanes(LoanID);

        }
        public  static async Task<DataTable> GetListLoanes()
        {

            return await  clsLoanesDataAccess.GetListLoanes();
        }

        public static async Task<bool> IsLoanesExisteByID(int LoanID)
        {
            return await  clsLoanesDataAccess.IsLoanesExisteByID(LoanID);

        }
        public static async Task<bool> IsLoanesBorrowedeByLoanID(int LoanID)
        {
            return await  clsLoanesDataAccess.IsLoanesBorrowedeByLoanID(LoanID);

        }


        public  int ISLateInReturningAndReturnDifferenceDays()
        {
            clsLoanes loanes = this;

            if (DateTime.Now > loanes.DueDate)
            {
                TimeSpan Difference = DateTime.Now - loanes.DueDate;
                return Difference.Days;
            }

            return 0;
        }


        /*
                public class NewBorrow
                {
                    public event EventHandler<clsLoanes> AddNewBorrow;
                    public bool SaveLoan(clsLoanes loanes)
                    {
                        if (loanes.Save())
                        {
                            OnAddNewLoan(loanes);
                            return true;
                        }
                        return false;
                    }

                    protected virtual void OnAddNewLoan(clsLoanes Borrow)
                    {
                        AddNewBorrow?.Invoke(this, Borrow);
                    }

                }


                public class ChangeBookCopy
                {
                    public void Subscribe(NewBorrow borrow )
                    {
                        borrow.AddNewBorrow += HandleBookCopyStatus;
                    }

                    public void HandleBookCopyStatus(object sender, clsLoanes loanes )
                    {
                        clsBookCopies.ChangeCopyStatus(loanes.CopyID, clsBookCopies.enStatusCopy.Borrowed);
                    }

                }
        */

        public async Task<clsLoanes> BorrowBook(int MemberID, int CreateByUserID, int CopyID, DateTime LoanDate)
        {
            //  NewBorrow borrow  = new NewBorrow();
            //  ChangeBookCopy bookCopy = new ChangeBookCopy();
            //  bookCopy.Subscribe(borrow);


            clsLoanes _Loan = this;
            _Loan.MemberID = MemberID;
            _Loan.CopyID = CopyID;
            _Loan.LoanByUserID = CreateByUserID;
            _Loan.LoanDate = LoanDate;
            _Loan.DueDate = _Loan.LoanDate.Date.AddDays(clsSettings.GetDefualtBorrrowDays());

            //  if(borrow.SaveLoan(_Loan))
            //return _Loan;

            if (await  _Loan.Save())
            {
                clsBookCopies.ChangeCopyStatus(CopyID, clsBookCopies.enStatusCopy.Borrowed);

                return _Loan;
            }

            return null;
        }


        [Obsolete("This method is marked as obsolete, and will be deprecated in the future.")]
        public  async Task<clsLoanes> ReturnBook(int ReturnByUserID, int PaymentTypeiD, DateTime ReturnDate)
        {
            clsLoanes _Loan = this;
            _Loan.ReturnByUserID = ReturnByUserID;
            _Loan.ReturnDate = ReturnDate;
            _Loan.MemberID = this.MemberID;
            _Loan.CopyID = this.CopyID;
            _Loan.LoanByUserID = this.LoanByUserID;
            _Loan.LoanDate = this.LoanDate;
            _Loan.DueDate = this.DueDate;


            if (! await  _Loan.Save())
            {
                return null;
            }



           await clsBookCopies.ChangeCopyStatus(_Loan.CopyID, clsBookCopies.enStatusCopy.Available);

            int Days = ISLateInReturningAndReturnDifferenceDays();
            if (Days != 0 || PaymentTypeiD != -1)
            {
                clsPaymentDetails _PaymentDetails = new clsPaymentDetails();

                _PaymentDetails.PaymentTypeID = PaymentTypeiD;
                _PaymentDetails.MemberID = this.MemberID;
                _PaymentDetails.Amount = Days * clsSettings.GetDefualtFineDays();
                _PaymentDetails.PaymentStatus = (byte)clsPayments.enPaymentStatus.Paid;
                _PaymentDetails.CreateByUserID = ReturnByUserID;
                _PaymentDetails.PaymentDate = DateTime.Now;
                int EntityTypeID = (byte)clsPaymentEntities.enEntityType.LateFees;
                _PaymentDetails.EntityTypeID = clsPaymentEntities.FindByID(EntityTypeID).EntityTypeID;
                _PaymentDetails.EntityID = _Loan.LoanID;

                if (! await _PaymentDetails.Save())
                {
                    return null;

                }

            }

            return _Loan;
        }



    }

}