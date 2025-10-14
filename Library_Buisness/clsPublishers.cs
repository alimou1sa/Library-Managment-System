
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

    public class clsPublishers
    {

        enum enMode { AddNew, Update};

        enMode _Mode;

        public int PublisherID { set; get; }
public string Name { set; get; }
public string Address { set; get; }
public string Phone { set; get; }


        
 

public clsPublishers()
{
    this._Mode = enMode.AddNew;

 this.PublisherID = -1;
this.Name = " ";
this.Address = " ";
this.Phone = " ";
 

 
}

private clsPublishers( int PublisherID,string Name,string Address,string Phone)
{
    this._Mode = enMode.Update;

 this.PublisherID = PublisherID;
this.Name = Name;
this.Address = Address;
this.Phone = Phone;
 
 
 


}

public static clsPublishers FindByID(int PublisherID )
{
    string Name = " ";
string Address = " ";
string Phone = " ";
 
    
    if (clsPublishersDataAccess.GetPublishersInfoByID(PublisherID,ref Name,ref Address,ref Phone))
    {
        return new clsPublishers(PublisherID,Name,Address,Phone);

    }

    return null;

}

    private async Task<bool> _AddNewPublishers()
{ 
    this.PublisherID = await  clsPublishersDataAccess.AddNewPublishers(this.Name,this.Address,this.Phone);

    return (this.PublisherID != -1); 
            
}private async Task<bool> _UpdatePublishers()
{
    return await  clsPublishersDataAccess.UpdatePublishers(this.PublisherID,this.Name,this.Address,this.Phone);
}

        public async Task< bool> Save()
{
    switch (_Mode)
    {
        case enMode.AddNew :
            
            if (await  _AddNewPublishers())
            {

                _Mode = enMode.Update;
                return true;
            }
            else 
                return false;

        case enMode.Update :
            
            return await  _UpdatePublishers(); 
           
        default :
            return false;

    }

} public static async Task<bool> DeletePublishers( string Name)
{
    return await  clsPublishersDataAccess.DeletePublishers(Name);

}
public static async Task<DataTable> GetListPublishers()
{

    return  await clsPublishersDataAccess.GetListPublishers();
}

public static async Task<bool> IsPublishersExisteByID( int PublisherID )
{
    return await  clsPublishersDataAccess.IsPublishersExisteByID(PublisherID);

}



        public static clsPublishers FindByPublisgerName(  string Name)
        {
            int PublisherID = -1;
      
            string Address = " ";
            string Phone = " ";


            if (clsPublishersDataAccess.GetPublisherInfoByName( Name,ref PublisherID,  ref Address, ref Phone))
            {
                return new clsPublishers(PublisherID, Name, Address, Phone);

            }

            return null;

        }



    }
}