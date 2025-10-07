
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

    public class clsPaymentTypes
    {

        enum enMode { AddNew, Update};

        enMode _Mode;

        public int PaymentTypeID { set; get; }
public string TypeName { set; get; }
public string Description { set; get; }


        
 

public clsPaymentTypes()
{
    this._Mode = enMode.AddNew;

 this.PaymentTypeID = -1;
this.TypeName = " ";
this.Description = " ";
 

 
}

private clsPaymentTypes( int PaymentTypeID,string TypeName,string Description)
{
    this._Mode = enMode.Update;

 this.PaymentTypeID = PaymentTypeID;
this.TypeName = TypeName;
this.Description = Description;
 
 
 


}

public static clsPaymentTypes FindByID(int PaymentTypeID )
{
    string TypeName = " ";
string Description = " ";
 
    
    if (clsPaymentTypesDataAccess.GetPaymentTypesInfoByID(PaymentTypeID,ref TypeName,ref Description))
    {
        return new clsPaymentTypes(PaymentTypeID,TypeName,Description);

    }

    return null;

}

    private async Task<bool> _AddNewPaymentTypes()
{ 
    this.PaymentTypeID =await  clsPaymentTypesDataAccess.AddNewPaymentTypes(this.TypeName,this.Description);

    return (this.PaymentTypeID != -1); 
            
}
        private async Task<bool> _UpdatePaymentTypes()
{
    return await  clsPaymentTypesDataAccess.UpdatePaymentTypes(this.PaymentTypeID,this.TypeName,this.Description);
}

 public async Task<bool> Save()
{
    switch (_Mode)
    {
        case enMode.AddNew :
            
            if (await  _AddNewPaymentTypes())
            {

                _Mode = enMode.Update;
                return true;
            }
            else 
                return false;

        case enMode.Update :
            
            return await  _UpdatePaymentTypes(); 
           
        default :
            return false;

    }

}
        public static async Task<bool> DeletePaymentTypes( int PaymentTypeID )
{
    return  await clsPaymentTypesDataAccess.DeletePaymentTypes(PaymentTypeID);

}
public static async Task<DataTable> GetListPaymentTypes()
{

    return  await clsPaymentTypesDataAccess.GetListPaymentTypes();
}

public static async Task<bool> IsPaymentTypesExisteByID( int PaymentTypeID )
{
    return await  clsPaymentTypesDataAccess.IsPaymentTypesExisteByID(PaymentTypeID);

}

        public static clsPaymentTypes FindByTypeName(string  TypeName)
        {
            int PaymentTypeID = -1;
            string Description = " ";


            if (clsPaymentTypesDataAccess.GetPaymentTypesInfoByTypeName(TypeName, ref PaymentTypeID,  ref Description))
            {
                return new clsPaymentTypes(PaymentTypeID, TypeName, Description);

            }

            return null;

        }






    }
}