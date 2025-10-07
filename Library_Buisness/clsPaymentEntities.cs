
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

    public class clsPaymentEntities
    {

        enum enMode { AddNew, Update};

        enMode _Mode;

        public int EntityTypeID { set; get; }
public string EntityName { set; get; }

        public enum enEntityType { LateFees=1,Purchases=2, MemberSubscription=3 }
      public  enEntityType _EntityType;



        public clsPaymentEntities()
{
    this._Mode = enMode.AddNew;

 this.EntityTypeID = -1;
this.EntityName = " ";
 

 
}

private clsPaymentEntities( int EntityTypeID,string EntityName)
{
    this._Mode = enMode.Update;

 this.EntityTypeID = EntityTypeID;
this.EntityName = EntityName;
 
 
 


}

public static clsPaymentEntities FindByID(int EntityTypeID )
{
    string EntityName = " ";
 
    
    if (clsPaymentEntitiesDataAccess.GetPaymentEntitiesInfoByID(EntityTypeID,ref EntityName))
    {
        return new clsPaymentEntities(EntityTypeID,EntityName);

    }

    return null;

}

    private async Task<bool> _AddNewPaymentEntities()
{ 
    this.EntityTypeID =await  clsPaymentEntitiesDataAccess.AddNewPaymentEntities(this.EntityName);

    return (this.EntityTypeID != -1); 
            
}private async Task<bool >_UpdatePaymentEntities()
{
    return await  clsPaymentEntitiesDataAccess.UpdatePaymentEntities(this.EntityTypeID,this.EntityName);
}

 public async Task<bool> Save()
{
    switch (_Mode)
    {
        case enMode.AddNew :
            
            if (await  _AddNewPaymentEntities())
            {

                _Mode = enMode.Update;
                return true;
            }
            else 
                return false;

        case enMode.Update :
            
            return await  _UpdatePaymentEntities(); 
           
        default :
            return false;

    }

} public static async Task<bool> DeletePaymentEntities( int EntityTypeID )
{
    return await  clsPaymentEntitiesDataAccess.DeletePaymentEntities(EntityTypeID);

}
public static async Task<DataTable> GetListPaymentEntities()
{

    return await  clsPaymentEntitiesDataAccess.GetListPaymentEntities();
}

public static async Task< bool> IsPaymentEntitiesExisteByID( int EntityTypeID )
{
    return await clsPaymentEntitiesDataAccess.IsPaymentEntitiesExisteByID(EntityTypeID);

}


        public static clsPaymentEntities FindByEntityName(string  EntityName)
        {
            int EntityTypeID = -1;


            if (clsPaymentEntitiesDataAccess.GetPaymentEntitiesInfoByEntityName(EntityName, ref EntityTypeID))
            {
                return new clsPaymentEntities(EntityTypeID, EntityName);

            }

            return null;

        }


    }
}