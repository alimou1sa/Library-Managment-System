
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

    public class clsCountries
    {

        enum enMode { AddNew, Update};

        enMode _Mode;

        public int CountryID { set; get; }
public string CountryName { set; get; }


        
 

public clsCountries()
{
    this._Mode = enMode.AddNew;

 this.CountryID = -1;
this.CountryName = " ";
 

 
}

private clsCountries( int CountryID,string CountryName)
{
    this._Mode = enMode.Update;

 this.CountryID = CountryID;
this.CountryName = CountryName;
 
 
 


}

public static clsCountries FindByID(int CountryID )
{
    string CountryName = " ";
 
    
    if (clsCountriesDataAccess.GetCountriesInfoByID(CountryID,ref CountryName))
    {
        return new clsCountries(CountryID,CountryName);

    }

    return null;

}

    private async Task<bool> _AddNewCountries()
{ 
    this.CountryID =  await clsCountriesDataAccess.AddNewCountries(this.CountryName);

    return (this.CountryID != -1); 
            
}private async Task<bool> _UpdateCountries()
{
    return await  clsCountriesDataAccess.UpdateCountries(this.CountryID,this.CountryName);
}

 public async Task<bool> Save()
{
    switch (_Mode)
    {
        case enMode.AddNew :
            
            if ( await  _AddNewCountries())
            {

                _Mode = enMode.Update;
                return true;
            }
            else 
                return false;

        case enMode.Update :
            
            return await  _UpdateCountries(); 
           
        default :
            return false;

    }

} public static async Task<bool> DeleteCountries( int CountryID )
{
    return await  clsCountriesDataAccess.DeleteCountries(CountryID);

}
public static async Task<DataTable> GetListCountries()
{

    return await  clsCountriesDataAccess.GetListCountries();
}

public static async Task<bool> IsCountriesExisteByID( int CountryID )
{
    return await   clsCountriesDataAccess.IsCountriesExisteByID(CountryID);

}


        public static clsCountries Find(string CountryName)
        {

            int ID = -1;

            if ( clsCountriesDataAccess.GetCountryInfoByName(CountryName, ref ID))

                return new clsCountries(ID, CountryName);
            else
                return null;

        }


    }
}