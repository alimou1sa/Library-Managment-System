
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

    public class clsAuthors
    {

        enum enMode { AddNew, Update};

        enMode _Mode;

        public int AutherID { set; get; }
public string Name { set; get; }
public string BIi { set; get; }


        
 

public clsAuthors()
{
    this._Mode = enMode.AddNew;

 this.AutherID = -1;
this.Name = " ";
this.BIi = " ";
 

 
}

private clsAuthors( int AutherID,string Name,string BIi)
{
    this._Mode = enMode.Update;

 this.AutherID = AutherID;
this.Name = Name;
this.BIi = BIi;
 
 
 


}

public static clsAuthors FindByID(int AutherID )
{
    string Name = " ";
string BIi = " ";
 
    
    if (clsAuthorsDataAccess.GetAuthorsInfoByID(AutherID,ref Name,ref BIi))
    {
        return new clsAuthors(AutherID,Name,BIi);

    }

    return null;

}

    private async Task<bool> _AddNewAuthors()
{ 
    this.AutherID = await  clsAuthorsDataAccess.AddNewAuthors(this.Name,this.BIi);

    return (this.AutherID != -1); 
            
}private async Task<bool> _UpdateAuthors()
{
    return await  clsAuthorsDataAccess.UpdateAuthors(this.AutherID,this.Name,this.BIi);
}

 public async Task<bool> Save()
{
    switch (_Mode)
    {
        case enMode.AddNew :
            
            if ( await  _AddNewAuthors())
            {

                _Mode = enMode.Update;
                return true;
            }
            else 
                return false;

        case enMode.Update :
            
            return await  _UpdateAuthors(); 
           
        default :
            return false;

    }

} public static async Task<bool> DeleteAuthors( int AutherID )
{
    return await  clsAuthorsDataAccess.DeleteAuthors(AutherID);

}
public static async Task<DataTable> GetListAuthors()
{

    return await  clsAuthorsDataAccess.GetListAuthors();
}

public static async Task<bool >IsAuthorsExisteByID( int AutherID )
{
    return await   clsAuthorsDataAccess.IsAuthorsExisteByID(AutherID);

}



        public static clsAuthors Find(string Name)
        {
            int AutherID = -1;
            string Bio = "";

            if (clsAuthorsDataAccess.GetAutherInfoByName(Name, ref AutherID,ref Bio))

                return new clsAuthors(AutherID, Name,Bio);
            else
                return null;

        }

    }
}