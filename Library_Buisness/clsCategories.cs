
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

    public class clsCategories
    {

        enum enMode { AddNew, Update};

        enMode _Mode;

        public int CategoryID { set; get; }
public string CategoryName { set; get; }


        
 

public clsCategories()
{
    this._Mode = enMode.AddNew;

 this.CategoryID = -1;
this.CategoryName = " ";
 

 
}

private clsCategories( int CategoryID,string CategoryName)
{
    this._Mode = enMode.Update;

 this.CategoryID = CategoryID;
this.CategoryName = CategoryName;
 
 
 


}

public static clsCategories FindByID(int CategoryID )
{
    string CategoryName = " ";
 
    
    if (clsCategoriesDataAccess.GetCategoriesInfoByID(CategoryID,ref CategoryName))
    {
        return new clsCategories(CategoryID,CategoryName);

    }

    return null;

}

    private async Task<bool> _AddNewCategories()
{ 
    this.CategoryID = await  clsCategoriesDataAccess.AddNewCategories(this.CategoryName);

    return (this.CategoryID != -1); 
            
}private async Task<bool> _UpdateCategories()
{
    return await  clsCategoriesDataAccess.UpdateCategories(this.CategoryID,this.CategoryName);
}

 public async Task<bool> Save()
{
    switch (_Mode)
    {
        case enMode.AddNew :
            
            if ( await  _AddNewCategories())
            {

                _Mode = enMode.Update;
                return true;
            }
            else 
                return false;

        case enMode.Update :
            
            return await  _UpdateCategories(); 
           
        default :
            return false;

    }

} public static async Task<bool> DeleteCategories( int CategoryID )
{
    return await  clsCategoriesDataAccess.DeleteCategories(CategoryID);

}
public static async Task<DataTable> GetListCategories()
{

    return  await clsCategoriesDataAccess.GetListCategories();
}

public static async Task<bool> IsCategoriesExisteByID( int CategoryID )
{
    return await clsCategoriesDataAccess.IsCategoriesExisteByID(CategoryID);

}


        public static clsCategories Find(string CountryName)
        {
            int categoryID = -1;


            if (clsCategoriesDataAccess.GetCategoriesInfoByCatecoryName(CountryName, ref categoryID))

                return new clsCategories(categoryID, CountryName);
            else
                return null;

        }








    }
}