
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

    public class clsMembershipPlans
    {

        enum enMode { AddNew, Update};

        enMode _Mode;

        public int PlanID { set; get; }
public string PlanName { set; get; }
public int DurationMonths { set; get; }
public double Price { set; get; }


        
       public  enum enPalnType { MonthlySubscription = 1, ThreeMonthSubscriptio = 2, OneYearSubscription = 3 };
         public enPalnType palnType { set; get; }

public clsMembershipPlans()
{
    this._Mode = enMode.AddNew;

 this.PlanID = -1;
this.PlanName = " ";
this.DurationMonths = -1;
this.Price = -1;
 

 
}

private clsMembershipPlans( int PlanID,string PlanName,int DurationMonths, double Price)
{
    this._Mode = enMode.Update;

 this.PlanID = PlanID;
this.PlanName = PlanName;
this.DurationMonths = DurationMonths;
this.Price = Price;
 
 
 


}

public static clsMembershipPlans FindByID(int PlanID )
{
    string PlanName = " ";
int DurationMonths = -1;
            double Price = -1;
 
    
    if (clsMembershipPlansDataAccess.GetMembershipPlansInfoByID(PlanID,ref PlanName,ref DurationMonths,ref Price))
    {
        return new clsMembershipPlans(PlanID,PlanName,DurationMonths,Price);

    }

    return null;

}

    private async Task<bool> _AddNewMembershipPlans()
{ 
    this.PlanID =await  clsMembershipPlansDataAccess.AddNewMembershipPlans(this.PlanName,this.DurationMonths,this.Price);

    return (this.PlanID != -1); 
            
}
        private async Task<bool> _UpdateMembershipPlans()
{
    return await  clsMembershipPlansDataAccess.UpdateMembershipPlans(this.PlanID,this.PlanName,this.DurationMonths,this.Price);
}

 public async Task<bool> Save()
{
    switch (_Mode)
    {
        case enMode.AddNew :
            
            if (await  _AddNewMembershipPlans())
            {

                _Mode = enMode.Update;
                return true;
            }
            else 
                return false;

        case enMode.Update :
            
            return await  _UpdateMembershipPlans(); 
           
        default :
            return false;

    }

} 
        public static async Task<bool> DeleteMembershipPlans( int PlanID )
{
    return await  clsMembershipPlansDataAccess.DeleteMembershipPlans(PlanID);

}
public static async Task<DataTable> GetListMembershipPlans()
{

    return await clsMembershipPlansDataAccess.GetListMembershipPlans();
}

public static async Task<bool> IsMembershipPlansExisteByID( int PlanID )
{
    return await  clsMembershipPlansDataAccess.IsMembershipPlansExisteByID(PlanID);

}





        public static clsMembershipPlans FindByPlanName(string PlanName)
        {
            int PlanID = -1;
            int DurationMonths = -1;
            double Price = -1;


            if (clsMembershipPlansDataAccess.GetMembershipPlansInfoByPlanName(PlanName,ref PlanID,   ref DurationMonths, ref Price))
            {
                return new clsMembershipPlans(PlanID, PlanName, DurationMonths, Price);

            }

            return null;
        }







    }
}