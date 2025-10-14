       
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
        public byte CopyStatus { set; get; }

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
            this.CopyStatus = 0;

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
            this.LoanID = await clsLoanesDataAccess.AddNewBorrowBook(this.CopyID, this.MemberID, this.LoanByUserID
               , this.DueDate,(byte)clsBookCopies.enStatusCopy.Borrowed,(byte)clsReservations.enReservationsStatus.ConvertToBorrowing);

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

        [Obsolete("This method is marked as obsolete, and will be deprecated in the future.")]
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

        public static async Task<clsLoanes> BorrowBook(int MemberID, int CreateByUserID, int CopyID)
        {
    
            clsLoanes _Loan = new clsLoanes() ;
            _Loan.MemberID = MemberID;
            _Loan.CopyID = CopyID;
            _Loan.LoanByUserID = CreateByUserID;
            _Loan.DueDate =DateTime.Now.Date.AddDays(clsSettings.GetDefualtBorrrowDays());
         
            if (await _Loan.Save())
                return _Loan;
            
            return null;
        }

        public static  async Task<int> ReturnBook(int LoanID,int ReturnByUserID, int PaymentTypeID)
        { 
            int? PaymentDetailsID = null;

            PaymentDetailsID = await clsLoanesDataAccess.ReturnBook(LoanID, ReturnByUserID,
                (byte)clsBookCopies.enStatusCopy.Available, PaymentTypeID, (byte)clsPayments.enPaymentStatus.Paid);

            return PaymentDetailsID.Value;
        }



    }

}