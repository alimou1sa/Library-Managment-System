
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using Library_DataAccessLayer;
using static Library_Business.clsReservations;
using static Library_Business.clsPayments;
using static Library_Business.clsMemberSubscriptions;


namespace Library_Business
{

    public class clsMemberSubscriptions
    {

        enum enMode { AddNew, Update};

        enMode _Mode;

        public int SubscriptionID { set; get; }
        public int MemberID { set; get; }
        public int PlanID { set; get; }
public DateTime StartDate { set; get; }
public DateTime EndDate { set; get; }
public bool IsActive { set; get; }
public int CreatedByUserID { set; get; }
        public byte SubscriptionStatus { set; get; }

        public clsMembers MembersInfo { set; get; }
public clsUsers UsersInfo { set; get; }
public clsMembershipPlans MembershipPlansInfo { set; get; }




public clsMemberSubscriptions()
{
    this._Mode = enMode.AddNew;

 this.SubscriptionID = -1;
this.MemberID = -1;
this.PlanID = -1;
this.StartDate = DateTime.Now;
this.EndDate = DateTime.Now;
this.IsActive = false;
this.CreatedByUserID = -1;

            this.SubscriptionStatus = 0;
 this.MembersInfo = null ;
this.UsersInfo = null ;
this.MembershipPlansInfo = null ;
            
}




       public enum enSubscriptionStatus { Active=1,Expired=2,Pending=3 }

        public enSubscriptionStatus esubscriptionStatus; 




private clsMemberSubscriptions( int SubscriptionID,int PlanID,int MemberID, DateTime StartDate,DateTime EndDate,
    bool IsActive,byte SubscriptionStatus, int CreatedByUserID)
{
    this._Mode = enMode.Update;

 this.SubscriptionID = SubscriptionID;
            this.MemberID = MemberID;
this.PlanID = PlanID;
this.StartDate = StartDate;
this.EndDate = EndDate;
this.IsActive = IsActive;
this.CreatedByUserID = CreatedByUserID;
 this .SubscriptionStatus = SubscriptionStatus;
 
this.UsersInfo = clsUsers.FindByUserID(CreatedByUserID);
this.MembershipPlansInfo = clsMembershipPlans.FindByID(PlanID);



}

public static clsMemberSubscriptions FindByID(int SubscriptionID )
{
    int MemberID = -1;
int PlanID = -1;
DateTime StartDate = DateTime.Now;
DateTime EndDate = DateTime.Now;
bool IsActive = false;
byte SubscriptionStatus = 0;
int CreatedByUserID = -1;
 
    
    if (clsMemberSubscriptionsDataAccess.GetMemberSubscriptionsInfoByID(SubscriptionID
        ,ref PlanID,ref MemberID, ref StartDate,ref EndDate,ref IsActive,ref SubscriptionStatus, ref CreatedByUserID))
    {
        return new clsMemberSubscriptions(SubscriptionID,PlanID, MemberID, StartDate,EndDate,IsActive, SubscriptionStatus, CreatedByUserID);

    }

    return null;

}

    private async Task<bool> _AddNewMemberSubscriptions()
{ 
    this.SubscriptionID =await  clsMemberSubscriptionsDataAccess.AddNewMemberSubscriptions(this.PlanID,this .MemberID,this.SubscriptionStatus, this.CreatedByUserID,this.IsActive );
    return (this.SubscriptionID != -1); 
            
}private async Task<bool> _UpdateMemberSubscriptions()
{
    return await  clsMemberSubscriptionsDataAccess.UpdateMemberSubscriptions(this.SubscriptionID,
        this.PlanID,this .MemberID, this.StartDate,this.EndDate,this.IsActive,this.SubscriptionStatus, this.CreatedByUserID);
}

 public async Task<bool> Save()
{
    switch (_Mode)
    {
        case enMode.AddNew :
            
            if ( await _AddNewMemberSubscriptions())
            {

                _Mode = enMode.Update;
                return true;
            }
            else 
                return false;

        case enMode.Update :
            
            return await  _UpdateMemberSubscriptions(); 
           
        default :
            return false;

    }

} 
        public static async Task<bool> DeleteMemberSubscriptions( int SubscriptionID )
{
    return await clsMemberSubscriptionsDataAccess.DeleteMemberSubscriptions(SubscriptionID);

}
public static async Task<DataTable> GetListMemberSubscriptionsByMemberID(int MemberID)
{

    return await  clsMemberSubscriptionsDataAccess.GetListMemberSubscriptionsByMemberID(MemberID);
}

public static async Task<bool> IsMemberSubscriptionsExisteByID( int SubscriptionID )
{
    return await  clsMemberSubscriptionsDataAccess.IsMemberSubscriptionsExisteByID(SubscriptionID);

}


        public static async Task<bool> IsMembersHasActiveSubscription(int MemberID)
        {
            return await  clsMemberSubscriptionsDataAccess.IsMembersHasActiveSubscription(MemberID);

        }




        public static async Task<bool> ChangeMemberSubscriptionActiv(int SubscriptionID,bool IsActive)
        {
            return await  clsMemberSubscriptionsDataAccess.ChangeMemberSubscriptionsActive(SubscriptionID,IsActive);

        }

        public static string GetSubscriptionStatusText(enSubscriptionStatus subscriptionStatus)
        {
            switch (subscriptionStatus)
            {
                case enSubscriptionStatus.Active:
                    return "Active";
                case enSubscriptionStatus.Expired:
                    return "Expired";
                case enSubscriptionStatus.Pending:
                    return "Pending";
                default:
                    return "Pending";
            }
        }
        public static byte GetSubscriptionStatusAsByte(string subscriptionStatus)
        {
            switch (subscriptionStatus)
            {
                case "Active":
                    return (byte)enSubscriptionStatus.Active ;
                case "Expired":
                    return (byte)enSubscriptionStatus.Expired;
                case "Pending":
                    return (byte)enSubscriptionStatus.Pending;
                default:
                    return (byte)enSubscriptionStatus.Pending;
            }
        }

        public async Task<clsMemberSubscriptions> AddNewSubscription(clsMembershipPlans _MembershipPlans,int CreateByUserID)
        {

            clsMemberSubscriptions _MemberSubscriptions = this;


            _MemberSubscriptions.StartDate = DateTime.Now;
            _MemberSubscriptions.IsActive =true;
            _MemberSubscriptions.PlanID = _MembershipPlans.PlanID;
            _MemberSubscriptions.CreatedByUserID = CreateByUserID;
            _MemberSubscriptions.EndDate =
                DateTime.Now.Date.AddMonths(_MembershipPlans.DurationMonths);
            _MemberSubscriptions.SubscriptionStatus =(byte)clsMemberSubscriptions.enSubscriptionStatus.Active;

            if (!await  _MembershipPlans.Save())
                return null;
            return _MemberSubscriptions;
        }

        public static bool IsSubscriptionActivByStatus(enSubscriptionStatus  subscriptionStatus)
        {
            switch (subscriptionStatus)
            {
                case enSubscriptionStatus.Active:
                    return true;
                case enSubscriptionStatus.Expired:
                    return false;
                case enSubscriptionStatus.Pending:
                    return false;
                default:
                    return false;
            }

        }


    }
}