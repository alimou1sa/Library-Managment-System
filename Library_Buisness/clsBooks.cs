
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

    public class clsBooks
    {

        enum enMode { AddNew, Update};
        enMode _Mode;

        public int BookID { set; get; }
public string Title { set; get; }
public string ISBN { set; get; }
public int GenreID { set; get; }
public int PublisherID { set; get; }
public DateTime YearPublished { set; get; }
public string AdditionalDetails { set; get; }
public int CategoryID { set; get; }
public int AuthorID { set; get; }
public double BookPrice { set; get; }
        public short NumberOfCopies {  set; get; }

        public clsPublishers PublishersInfo { set; get; }
public clsAuthors AuthorsInfo { set; get; }
public clsGenres GenresInfo { set; get; }
public clsCategories CategoriesInfo { set; get; }

 

public clsBooks()
{
    this._Mode = enMode.AddNew;

 this.BookID = -1;
this.Title = " ";
this.ISBN = " ";
this.GenreID = -1;
this.PublisherID = -1;
this.YearPublished = DateTime.Now;
this.AdditionalDetails = " ";
this.CategoryID = -1;
this.AuthorID = -1;
this.BookPrice = -1;
 this.NumberOfCopies = -1;

 this.PublishersInfo = null ;
this.AuthorsInfo = null ;
this.GenresInfo = null ;
this.CategoriesInfo = null ;

}

private clsBooks( int BookID,string Title,string ISBN,int GenreID,int PublisherID,DateTime YearPublished
    ,string AdditionalDetails,int CategoryID,int AuthorID, double BookPrice)
{
    this._Mode = enMode.Update;

 this.BookID = BookID;
this.Title = Title;
this.ISBN = ISBN;
this.GenreID = GenreID;
this.PublisherID = PublisherID;
this.YearPublished = YearPublished;
this.AdditionalDetails = AdditionalDetails;
this.CategoryID = CategoryID;
this.AuthorID = AuthorID;
this.BookPrice = BookPrice;
 
 
 this.PublishersInfo = clsPublishers.FindByID(PublisherID);
this.AuthorsInfo = clsAuthors.FindByID(AuthorID);
this.GenresInfo = clsGenres.FindByID(GenreID);
this.CategoriesInfo = clsCategories.FindByID(CategoryID);



}

public static clsBooks FindByID(int BookID )
{
    string Title = " ";
string ISBN = " ";
DateTime PublicationDate = DateTime.Now;
int GenreID = -1;
int PublisherID = -1;
DateTime YearPublished = DateTime.Now;
string AdditionalDetails = " ";
int CategoryID = -1;
int AuthorID = -1;
            double BookPrice = -1;
 
    
    if (clsBooksDataAccess.GetBooksInfoByID(BookID,ref Title,ref ISBN,ref GenreID,ref PublisherID,ref 
        YearPublished,ref AdditionalDetails,ref CategoryID,ref AuthorID,ref BookPrice))
    {
        return new clsBooks(BookID,Title,ISBN,GenreID,PublisherID,YearPublished,AdditionalDetails,CategoryID,AuthorID,BookPrice);

    }

    return null;

}

    private async Task<bool> _AddNewBooksAndCopies()
{ 
    this.BookID = await clsBooksDataAccess.AddNewBooksAndCopies(this.Title,this.ISBN,this.GenreID,this.PublisherID,
        this.YearPublished,this.AdditionalDetails,this.CategoryID,this.AuthorID,this.BookPrice,this.NumberOfCopies,(byte)clsBookCopies.enStatusCopy.Available);

    return (this.BookID != -1); 
            
}
        private async Task<bool> _UpdateBooks()
{
    return await clsBooksDataAccess.UpdateBooks(this.BookID,this.Title,this.ISBN,this.GenreID
        ,this.PublisherID,this.YearPublished,this.AdditionalDetails,this.CategoryID,this.AuthorID,this.BookPrice);
}

 public async Task< bool> Save()
{
    switch (_Mode)
    {
        case enMode.AddNew :
            
            if (await _AddNewBooksAndCopies())
            {

                _Mode = enMode.Update;
                return true;
            }
            else 
                return false;

        case enMode.Update :
            
            return await  _UpdateBooks(); 
           
        default :
            return false;

    }

} 
        public static async Task< bool> DeleteBooks( int BookID )
{
    return await  clsBooksDataAccess.DeleteBooks(BookID);

}


        public static async Task<DataTable> GetListBooks()
        {

            return await clsBooksDataAccess.GetListBooks();
        }


public static async Task< bool> IsBooksExisteByID( int BookID )
{
    return await clsBooksDataAccess.IsBooksExisteByID(BookID);

}


        public static clsBooks FindByISBN(string ISBN)
        {
            string Title = " ";
            int BookID = -1;
            DateTime PublicationDate = DateTime.Now;
            int GenreID = -1;
            int PublisherID = -1;
            DateTime YearPublished = DateTime.Now;
            string AdditionalDetails = " ";
            int CategoryID = -1;
            int AuthorID = -1;
            double BookPrice = -1;


            if (clsBooksDataAccess.GetBooksInfoByISBN(Title ,ref BookID,  ref ISBN, ref GenreID, ref PublisherID, ref
                YearPublished, ref AdditionalDetails, ref CategoryID, ref AuthorID, ref BookPrice))
            {
                return new clsBooks(BookID, Title, ISBN, GenreID, PublisherID, YearPublished, AdditionalDetails, CategoryID, AuthorID, BookPrice);

            }

            return null;

        }


        public static bool IsBooksExisteByISBN(string ISBN)
        {
            return  clsBooksDataAccess.IsBooksExisteByISBN(ISBN);

        }

    }
}