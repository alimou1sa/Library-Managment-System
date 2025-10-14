
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using Library_DataAccessLayer;
using static Library_Business.clsBookCopies;


namespace Library_Business
{

    public class clsReservations
    {

        enum enMode { AddNew, Update};

        enMode _Mode;

        public int ReservationID { set; get; }
public int MemberID { set; get; }
public int BookID { set; get; }
public DateTime ReservationDate { set; get; }
public byte Status { set; get; }
public int CreateByUserID { set; get; }


        public clsBooks BookInfo { set; get; }
public clsUsers UsersInfo { set; get; }
public clsMembers MembersInfo { set; get; }

        
        public enum enReservationsStatus { Reserved= 1, ConvertToBorrowing = 2, Cancelled = 3,  };
        public enReservationsStatus _ReservationsStatus;

        public clsReservations()
{
    this._Mode = enMode.AddNew;

 this.ReservationID = -1;
this.MemberID = -1;
this.BookID = -1;
this.ReservationDate = DateTime.Now;
this.Status = 0;
this.CreateByUserID = -1;
 

 this.BookInfo = null ;
this.UsersInfo = null ;
this.MembersInfo = null ;

}

private clsReservations( int ReservationID,int MemberID,int BookID, DateTime ReservationDate,byte Status,int CreateByUserID)
{
    this._Mode = enMode.Update;

 this.ReservationID = ReservationID;
this.MemberID = MemberID;
this.BookID = BookID;
this.ReservationDate = ReservationDate;
this.Status = Status;
this.CreateByUserID = CreateByUserID;
 
 
 this.BookInfo = clsBooks.FindByID(BookID);
this.UsersInfo =clsUsers.FindByUserID(CreateByUserID);
this.MembersInfo = clsMembers.FindByID(MemberID);



}

public static clsReservations FindByID(int ReservationID )
{
    int MemberID = -1;
int BookID = -1;
DateTime ReservationDate = DateTime.Now;
byte Status = 0;
int CreateByUserID = -1;
 
    
    if (clsReservationsDataAccess.GetReservationsInfoByID(ReservationID,ref MemberID,ref BookID, ref ReservationDate,ref Status,ref CreateByUserID))
    {
        return new clsReservations(ReservationID,MemberID, BookID, ReservationDate,Status,CreateByUserID);

    }

    return null;

}

    private async Task<bool> _AddNewReservations()
{ 
    this.ReservationID =await   clsReservationsDataAccess.AddNewReservations(this.MemberID,this.BookID, this.ReservationDate,this.Status,this.CreateByUserID);

    return (this.ReservationID != -1); 
            
}private async Task<bool> _UpdateReservations()
{
    return await  clsReservationsDataAccess.UpdateReservations(this.ReservationID,this.MemberID,this.BookID, this.ReservationDate,this.Status,this.CreateByUserID);
}

 public async Task<bool> Save()
{
    switch (_Mode)
    {
        case enMode.AddNew :
            
            if (await  _AddNewReservations())
            {

                _Mode = enMode.Update;
                return true;
            }
            else 
                return false;

        case enMode.Update :
            
            return await  _UpdateReservations(); 
           
        default :
            return false;

    }

} public static async Task<bool> DeleteReservations( int ReservationID )
{
    return await  clsReservationsDataAccess.DeleteReservations(ReservationID);

}
public static async Task<DataTable> GetListReservations()
{

    return await clsReservationsDataAccess.GetListReservations();
}

public static async Task<bool> IsReservationsExisteByBookIDAndMemberID( int BookID,int MemberID )
{
    return await  clsReservationsDataAccess.IsReservationsExisteByBookIDAndMemberID(BookID,MemberID);

}


        public static clsReservations FindByBOOKID(int BookID)
        {
            int MemberID = -1;
            int ReservationID = -1;
            DateTime ReservationDate = DateTime.Now;
            byte Status = 0;
            int CreateByUserID = -1;


            if (clsReservationsDataAccess.GetReservationsInfoByBookID(BookID, ref ReservationID, ref MemberID, ref ReservationDate, ref Status, ref CreateByUserID))
            {
                return new clsReservations(ReservationID, MemberID, BookID, ReservationDate, Status, CreateByUserID);

            }

            return null;

        }


        public async Task<clsReservations> ChangeResrvationStatus(clsReservations.enReservationsStatus reservationsStatus)
        {

            clsReservations clsReservations = this ;

            clsReservations.Status=(byte )reservationsStatus;

            if(await  clsReservations.Save())
                return clsReservations;

            return null;

        }

        public static string GetReservationStatusAsString(byte Status)
        {
            enReservationsStatus reservationsStatus = (enReservationsStatus)Status;
            switch (reservationsStatus)
            {
                case enReservationsStatus.Reserved:
                    return "Reserved";
                    break;
                case  enReservationsStatus.Cancelled:
                    return "Cancelled";
                    break;
                case enReservationsStatus.ConvertToBorrowing:
                    return "Convert To Borrowing";
                    break;
                default:
                    return " Cancelled";

            }

        }



        public static async Task<bool> IsThereReservationsForThisBook(int BookID)
        {
            return  await clsReservationsDataAccess.IsThereReservationsForThisBook(BookID);

        }


        public static clsReservations FindByBOOKIDAndMemberID(int BookID,int MemberID)
        {
            int ReservationID = -1;
            DateTime ReservationDate = DateTime.Now;
            byte Status = 0;
            int CreateByUserID = -1;


            if (clsReservationsDataAccess.GetActiveReservationsInfoByBookIDAndMemberID(MemberID,BookID,   ref ReservationID, ref ReservationDate, ref Status, ref CreateByUserID))
            {
                return new clsReservations(ReservationID, MemberID, BookID, ReservationDate, Status, CreateByUserID);

            }

            return null;

        }

    }
}