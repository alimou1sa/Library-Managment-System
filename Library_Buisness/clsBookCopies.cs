
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

    public class clsBookCopies
    {

        enum enMode { AddNew, Update};
        enMode _Mode;

        public int CopyID { set; get; }
        public int BookID { set; get; }
        public byte Status { set; get; }
        public clsBooks BooksInfo { set; get; }

 
       public  enum enStatusCopy { Available=1,Damaged=2,Lost=3,Borrowed=4,Sold=5};
       public  enStatusCopy _StatusCopy;

        public clsBookCopies()
        {
            this._Mode = enMode.AddNew;

            this.CopyID = -1;
            this.BookID = -1;
            this.Status = 0;


            this.BooksInfo = null;

        }
              
              private clsBookCopies( int CopyID,int BookID,byte Status)
         {
             this._Mode = enMode.Update;
         
          this.CopyID = CopyID;
         this.BookID = BookID;
         this.Status = Status;
          
          
          this.BooksInfo = clsBooks.FindByID(BookID);
         
         
         
         }
              
              public static clsBookCopies FindByID(int CopyID )
         {
             int BookID = -1;
         byte Status = 0;
          
             
             if (clsBookCopiesDataAccess.GetBookCopiesInfoByID(CopyID,ref BookID,ref Status))
             {
                 return new clsBookCopies(CopyID,BookID,Status);
         
             }
         
             return null;
         
         }
              
         private async Task<bool> _AddNewBookCopies()
         { 
             this.CopyID = await  clsBookCopiesDataAccess.AddNewBookCopies(this.BookID,this.Status);
         
             return (this.CopyID != -1); 
                     
         }
         private async Task<bool >_UpdateBookCopies()
         {
             return await  clsBookCopiesDataAccess.UpdateBookCopies(this.CopyID,this.BookID,this.Status);
         }
         
         public async Task<bool> Save()
         {
             switch (_Mode)
             {
                 case enMode.AddNew :
                     
                     if ( await  _AddNewBookCopies())
                     {
         
                         _Mode = enMode.Update;
                         return true;
                     }
                     else 
                         return false;
         
                 case enMode.Update :
                     
                     return await  _UpdateBookCopies(); 
                    
                 default :
                     return false;
         
             }
         
         } 
                 
                 
                 
          public static async Task<bool> DeleteBookCopies( int CopyID )
          {
               return await  clsBookCopiesDataAccess.DeleteBookCopies(CopyID);
                
          }
          public static async Task<DataTable> GetListBookCopies(int BookID)
          {
          
              return await  clsBookCopiesDataAccess.GetListBookCopies(BookID);
          }
         
         public static async Task<bool> IsBookCopiesExisteByID( int CopyID )
         {
             return await  clsBookCopiesDataAccess.IsBookCopiesExisteByID(CopyID);
         
         }
         
         


        static public async Task<int> GetNumberOfAllBookCopies(int BookID)
        {
            return await  clsBookCopiesDataAccess.GetNumberOfAllBookCopies(BookID);
        }

        static public async Task<int> GetNumberOfAvailableBookCopies(int BookID, byte Status)
        {
            return await  clsBookCopiesDataAccess.GetNumberOfAvailableBookCopies(BookID,Status);
        }

        public static async Task<bool> DeleteBookCopiesByBookID(int BookID)
        {
            return await  clsBookCopiesDataAccess.DeleteBookCopiesByBooKID(BookID);
        }


        static public async Task<int> GetCopyIDAvailabl(int BookID)
        {
            return await clsBookCopiesDataAccess.GetCopyIDForAvailableBookCopies(BookID);
        }

        static public async Task<bool > IsAvailablBook(int BookID)
        {
            return await  GetCopyIDAvailabl(BookID)!= -1;
        }
        public static async Task<bool >IsBookCopiesExisteByBookID(int BookID)
        {
            return await  clsBookCopiesDataAccess.IsBookCopiesExisteByBookID(BookID);

        }

        public static async Task<clsBookCopies> ChangeCopyStatus(int CopyID,enStatusCopy statusCopy)
        {
            clsBookCopies BookCopies = clsBookCopies.FindByID(CopyID);

            if (BookCopies != null)
                BookCopies.Status = (byte)statusCopy;

           if (await BookCopies.Save())
                return BookCopies;

           return null;


        }


      






    }
}