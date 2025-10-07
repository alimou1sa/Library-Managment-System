
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using Library_DataAccessLayer;
using System.Runtime.CompilerServices;


namespace Library_Business
{

    public class clsPayments
    {



      public  enum enMode { AddNew, Update};

       public  enMode _Mode;

        public int PaymentID { set; get; }
public int PaymentTypeID { set; get; }
public int MemberID { set; get; }
public double Amount { set; get; }
public byte PaymentStatus { set; get; }
public int CreateByUserID { set; get; }
public DateTime PaymentDate { set; get; }


        public clsUsers UsersInfo { set; get; }
         public clsPaymentTypes PaymentTypesInfo { set; get; }


        public enum enPaymentStatus { Pending=1,Paid=2,Refunded=3,Cancelled=4 };
        public enPaymentStatus _PaymentStatus;





public clsPayments()
{
    this._Mode = enMode.AddNew;

 this.PaymentID = -1;
this.PaymentTypeID = -1;
this.MemberID = -1;
this.Amount = -1;
this.PaymentStatus = 0;
this.CreateByUserID = -1;
this.PaymentDate = DateTime.Now;
 

 this.UsersInfo = null ;
this.PaymentTypesInfo = null ;

}

private clsPayments( int PaymentID,int PaymentTypeID,int MemberID, double Amount, byte PaymentStatus,int CreateByUserID,DateTime PaymentDate)
{
    this._Mode = enMode.Update;

 this.PaymentID = PaymentID;
this.PaymentTypeID = PaymentTypeID;
this.MemberID = MemberID;
this.Amount = Amount;
this.PaymentStatus = PaymentStatus;
this.CreateByUserID = CreateByUserID;
this.PaymentDate = PaymentDate;
 
 
 this.UsersInfo = clsUsers.FindByUserID(CreateByUserID);
this.PaymentTypesInfo = clsPaymentTypes.FindByID(PaymentTypeID);

}

public static clsPayments FindByID(int PaymentID )
{
    int PaymentTypeID = -1;
int MemberID = -1;
            double Amount = -1;
            byte PaymentStatus = 0;
int CreateByUserID = -1;
DateTime PaymentDate = DateTime.Now;
 
    
    if (clsPaymentsDataAccess.GetPaymentsInfoByID(PaymentID,ref PaymentTypeID,ref MemberID,ref Amount,ref PaymentStatus,ref CreateByUserID,ref PaymentDate))
    {
        return new clsPayments(PaymentID,PaymentTypeID,MemberID,Amount,PaymentStatus,CreateByUserID,PaymentDate);

    }

    return null;

}

    private async Task<bool> _AddNewPayments()
{ 
    this.PaymentID =await  clsPaymentsDataAccess.AddNewPayments(this.PaymentTypeID,this.MemberID,this.Amount,this.PaymentStatus,this.CreateByUserID,this.PaymentDate);

    return (this.PaymentID != -1); 
            
}private async Task<bool> _UpdatePayments()
{
    return await  clsPaymentsDataAccess.UpdatePayments(this.PaymentID,this.PaymentTypeID,this.MemberID,this.Amount,this.PaymentStatus,this.CreateByUserID,this.PaymentDate);
}

 public async Task<bool> Save()
{
    switch (_Mode)
    {
        case enMode.AddNew :
            
            if (await  _AddNewPayments())
            {

                _Mode = enMode.Update;
                return true;
            }
            else 
                return false;

        case enMode.Update :
            
            return await  _UpdatePayments(); 
           
        default :
            return false;

    }

} 
        public static async Task<bool> DeletePayments(int PaymentID)
        {
            return await  clsPaymentsDataAccess.DeletePayments(PaymentID);

        }
        public async Task<bool> DeletePayments()
        {
            return await  clsPaymentsDataAccess.DeletePayments(this .PaymentID);

        }
        public static async Task<DataTable> GetListPayments()
{

    return await clsPaymentsDataAccess.GetListPayments();
}

public static async Task<bool> IsPaymentsExisteByID( int PaymentID )
{
    return await  clsPaymentsDataAccess.IsPaymentsExisteByID(PaymentID);

}


        public static string GetPaymentStatusText(enPaymentStatus PaymentStatus)
        {

            switch (PaymentStatus)
            {
                case enPaymentStatus.Cancelled:
                    return "Cancelled";
                case enPaymentStatus.Paid:
                    return "Paid";
                case enPaymentStatus.Pending:
                    return "Pending";
                case enPaymentStatus.Refunded:
                    return "Refunded";
                default:
                    return "Pending";
            }
        }





    }
}