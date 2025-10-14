
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

    public class clsPurchasesBooks
    {

        enum enMode { AddNew, Update };

        enMode _Mode;

        public int PurchaseID { set; get; }
        public int BookID { set; get; }
        public int MemberID { set; get; }
        public int CopiesPurchased { set; get; }
        public double TotalPrice { set; get; }
        public DateTime PurchaseDate { set; get; }
        public int CreateByUserID { set; get; }


        public clsBooks BooksInfo { set; get; }
        public clsUsers UsersInfo { set; get; }
        public clsMembers MembersInfo { set; get; }



        public clsPurchasesBooks()
        {
            this._Mode = enMode.AddNew;

            this.PurchaseID = -1;
            this.BookID = -1;
            this.MemberID = -1;
            this.CopiesPurchased = -1;
            this.TotalPrice = -1;
            this.PurchaseDate = DateTime.Now;
            this.CreateByUserID = -1;


            this.BooksInfo = null;
            this.UsersInfo = null;
            this.MembersInfo = null;

        }

        private clsPurchasesBooks(int PurchaseID, int BookID, int MemberID, int CopiesPurchased, double TotalPrice, DateTime PurchaseDate, int CreateByUserID)
        {
            this._Mode = enMode.Update;

            this.PurchaseID = PurchaseID;
            this.BookID = BookID;
            this.MemberID = MemberID;
            this.CopiesPurchased = CopiesPurchased;
            this.TotalPrice = TotalPrice;
            this.PurchaseDate = PurchaseDate;
            this.CreateByUserID = CreateByUserID;


            this.BooksInfo = clsBooks.FindByID(BookID);
            this.UsersInfo = clsUsers.FindByUserID(CreateByUserID);
            this.MembersInfo = clsMembers.FindByID(MemberID);



        }

        public static clsPurchasesBooks FindByID(int PurchaseID)
        {
            int BookID = -1;
            int MemberID = -1;
            int CopiesPurchased = -1;
            double TotalPrice = -1;
            DateTime PurchaseDate = DateTime.Now;
            int CreateByUserID = -1;


            if (clsPurchasesBooksDataAccess.GetPurchasesBooksInfoByID(PurchaseID, ref BookID, ref MemberID, ref CopiesPurchased, ref TotalPrice, ref PurchaseDate, ref CreateByUserID))
            {
                return new clsPurchasesBooks(PurchaseID, BookID, MemberID, CopiesPurchased, TotalPrice, PurchaseDate, CreateByUserID);

            }

            return null;

        }

        private async Task<bool> _AddNewPurchasesBooks()
        {
            this.PurchaseID = await clsPurchasesBooksDataAccess.AddNewPurchasesBooks(this.BookID, this.MemberID, this.CopiesPurchased, this.TotalPrice, this.PurchaseDate, this.CreateByUserID);

            return (this.PurchaseID != -1);

        }
        private async Task<bool> _UpdatePurchasesBooks()
        {
            return await clsPurchasesBooksDataAccess.UpdatePurchasesBooks(this.PurchaseID, this.BookID, this.MemberID, this.CopiesPurchased, this.TotalPrice, this.PurchaseDate, this.CreateByUserID);
        }

        public async Task<bool> Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:

                    if (await _AddNewPurchasesBooks())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:

                    return await _UpdatePurchasesBooks();

                default:
                    return false;

            }

        }
        public static async Task<bool> DeletePurchasesBooks(int PurchaseID)
        {
            return await clsPurchasesBooksDataAccess.DeletePurchasesBooks(PurchaseID);

        }
        public static async Task<DataTable> GetListPurchasesBooks()
        {

            return await clsPurchasesBooksDataAccess.GetListPurchasesBooks();
        }

        public static async Task<bool> IsPurchasesBooksExisteByID(int PurchaseID)
        {
            return await clsPurchasesBooksDataAccess.IsPurchasesBooksExisteByID(PurchaseID);

        }




    }
}