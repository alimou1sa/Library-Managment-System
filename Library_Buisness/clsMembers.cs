
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using Library_DataAccessLayer;
using System.Threading;


namespace Library_Business
{

    public class clsMembers : clsPeople
    {

        enum enMode { AddNew, Update };

        enMode _Mode;

        public int MemberID { set; get; }
        public bool IsActive { set; get; }
        public string LibraryCardNumber { set; get; }
        public int CreatedByUserID { set; get; }
        public int LastSubscriptionID { set; get; }

        public clsUsers UsersInfo { set; get; }
        public clsPeople PeopleInfo { set; get; }
        public clsCountries clsCountries { set; get; }
        public clsMemberSubscriptions SubscriptionsInfo { set; get; }


        public clsMembers()
        {
            this._Mode = enMode.AddNew;

            this.MemberID = -1;
            this.PersonID = -1;
            this.IsActive = false;
            this.LibraryCardNumber = " ";
            this.CreatedByUserID = -1;
            this.LastSubscriptionID = -1;
            this.SubscriptionsInfo = null;
            this.UsersInfo = null;
            this.PeopleInfo = null;

        }

        private clsMembers(int MemberID, int PersonID, bool IsActive,
            string LibraryCardNumber, int LasrSubscriptionID, int CreatedByUserID, string FirstName,
            string SecondName, string ThirdName, string LastName, string NationalNo, DateTime DateOfBirth,
            byte Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this._Mode = enMode.Update;

            this.MemberID = MemberID;
            this.PersonID = PersonID;
            this.IsActive = IsActive;
            this.LibraryCardNumber = LibraryCardNumber;
            this.LastSubscriptionID = LasrSubscriptionID;
            this.CreatedByUserID = CreatedByUserID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.NationalNo = NationalNo;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            this.clsCountries = clsCountries.FindByID(NationalityCountryID);

            this.UsersInfo = clsUsers.FindByUserID(CreatedByUserID);
            this.PeopleInfo = clsPeople.Find(PersonID);
            this.SubscriptionsInfo = clsMemberSubscriptions.FindByID(LasrSubscriptionID);


        }


        public static clsMembers FindByID(int MemberID)
        {
            int PersonID = -1;
            bool IsActive = false;
            string LibraryCardNumber = " ";
            int LasrSubscriptionID = -1;
            int CreatedByUserID = -1;


            if (clsMembersDataAccess.GetMembersInfoByID(MemberID, ref PersonID, ref IsActive, ref LibraryCardNumber,
                ref LasrSubscriptionID, ref CreatedByUserID))
            {
                clsPeople person = clsPeople.Find(PersonID);
                return new clsMembers(MemberID, PersonID, IsActive, LibraryCardNumber, LasrSubscriptionID,
                    CreatedByUserID, person.FirstName, person.SecondName,
                    person.ThirdName, person.LastName, person.NationalNo, person.DateOfBirth, person.Gendor
                    , person.Address, person.Phone, person.Email, person.NationalityCountryID, person.ImagePath);

            }

            return null;

        }

        private async Task<bool> _AddNewMembers()
        {
            this.MemberID = await  clsMembersDataAccess.AddNewMembers(this.PersonID, this.IsActive,
                this.LibraryCardNumber, this.LastSubscriptionID, this.CreatedByUserID);

            return (this.MemberID != -1);

        }
   
        private async Task<bool> _UpdateMembers()
        {
            return await  clsMembersDataAccess.UpdateMembers(this.MemberID, this.PersonID, this.IsActive,
                this.LibraryCardNumber, this.LastSubscriptionID, this.CreatedByUserID);
        }

        public async Task<bool> Save()
        {
            base._Mode = (clsPeople.enMode)_Mode;
            if ( ! await base.Save())
                return false;
            switch (_Mode)
            {
                case enMode.AddNew:

                    if (await  _AddNewMembers())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:

                    return await  _UpdateMembers();

                default:
                    return false;

            }

        }
   
        public async Task<bool> DeleteMembers()
        {


            bool IsMemberDeleted = false;
            bool IsBasePersonDeleted = false;

            IsMemberDeleted = await  clsMembersDataAccess.DeleteMembers(this.MemberID); ;
            if (!IsMemberDeleted)
                return false;

            IsBasePersonDeleted = await base.Delete();
            return IsBasePersonDeleted;
        }
   
        public static async Task<DataTable> GetListMembers()
        {

            return await  clsMembersDataAccess.GetListMembers();
        }

        public static async Task<bool> IsMembersExisteByID(int MemberID)
        {
            return await  clsMembersDataAccess.IsMembersExisteByID(MemberID);

        }
   
        public static async Task<bool> IsMembersExisteByLCN(string LibraryCardNumber)
        {
            return await clsMembersDataAccess.IsMembersExisteByLCN(LibraryCardNumber);
        }

        public static async Task<bool> IsMembersExisteByPersonID(int PersonID)
        {
            return await clsMembersDataAccess.IsMembersExisteByPersonID(PersonID);

        }

        public static clsMembers FindByLCN(string LibraryCardNumber)
        {
            int PersonID = -1;
            bool IsActive = false;
            int MemberID = -1;
            int CreatedByUserID = -1;
            int LasrSubscriptionID = -1;

            if (clsMembersDataAccess.GetMembersInfoByLCN(LibraryCardNumber, ref MemberID, ref PersonID,
                ref IsActive, ref LasrSubscriptionID, ref CreatedByUserID))
            {
                clsPeople person = clsPeople.Find(PersonID);
                return new clsMembers(MemberID, PersonID, IsActive, LibraryCardNumber, LasrSubscriptionID,
                    CreatedByUserID, person.FirstName, person.SecondName,
                    person.ThirdName, person.LastName, person.NationalNo, person.DateOfBirth, person.Gendor
                    , person.Address, person.Phone, person.Email, person.NationalityCountryID, person.ImagePath);

            }

            return null;

        }

        public static async Task<bool> ChangeIsMemberActive(int MemberID, bool IsActive)
        {
            return await  clsMembersDataAccess.ChangeIsMembersActive(MemberID, IsActive);
        }

        public static async Task<bool> UpdateLastSubscriptionID(int MemberID, int LastSubscriptioID)
        {
            return await clsMembersDataAccess.UpdateLastSubscriptionID(MemberID, LastSubscriptioID);
        }



    }

}
