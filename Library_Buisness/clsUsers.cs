
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
    public class clsUsers : clsPeople
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { set; get; }

        public clsPeople PersonInfo;

        public clsCountries clsCountries;
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }
        public string  JobTitle { set; get; }
        public int Permissions { set; get; }
        public double Salary { set; get; }


        public string PersonFullName
        {
            get
            {
                return base.FullName;

            }

        }


        public clsUsers()
        {
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = true;
            this.JobTitle="";
            this.Permissions=0;
            this.Salary = 0;

            Mode = enMode.AddNew;
        }

        private clsUsers(int UserID, int PersonID, string Username, string Password, bool IsActive, string JobTitle
            , int Permissions, double Salary, string FirstName,
            string SecondName, string ThirdName, string LastName, string NationalNo, DateTime DateOfBirth,
            byte  Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.Permissions = Permissions;
            this.Salary = Salary;
            this.JobTitle=JobTitle;
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPeople.Find(PersonID);
            this.UserName = Username;
            this.Password = Password;
            this.IsActive = IsActive;
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
            this.CountriesInfo = clsCountries;
            Mode = enMode.Update;
        }



        public enum enPermissions
        { FullAccess = -1, ManageBooks =1, ManageMembers = 2, ManageUsers = 4,
            ManageLoan=8,ManageReservation=16,ManagePayments=32,ManagePurchasesBook=64};
       public  enPermissions _permissions;


        private bool _AddNewUser()
        {
            //call DataAccess Layer 

            this.UserID = clsUsersDataAccess.AddNewUsers(this.PersonID, this.UserName,
                this.Password, this.IsActive,this.JobTitle,this.Permissions,this.Salary);

            return (this.UserID != -1);
        }
        private bool _UpdateUser()
        {
            //call DataAccess Layer 

            return clsUsersDataAccess.UpdateUsers(this.UserID, this.PersonID, this.UserName,
                this.Password, this.IsActive, this.JobTitle, this.Permissions, this.Salary
                );
        }
        public static clsUsers FindByUserID(int UserID)
        {
            double Salary = 0;
            int PersonID = -1, Permissions=0;
            string UserName = "", Password = "", JobTitle="";
            bool IsActive = false;

            bool IsFound = clsUsersDataAccess.GetUsersInfoByID
                                (UserID, ref PersonID, ref UserName, ref Password, ref IsActive,ref JobTitle,ref Permissions,ref Salary);

            if (IsFound)
            //we return new object of that User with the right data
            {
                clsPeople person = clsPeople.Find(PersonID);

                return new clsUsers(UserID, PersonID, UserName, Password, IsActive, JobTitle, Permissions, Salary, person.FirstName, person.SecondName,
                    person.ThirdName, person.LastName, person.NationalNo, person.DateOfBirth, person.Gendor
                    , person.Address, person.Phone, person.Email, person.NationalityCountryID, person.ImagePath);

            }
            else
                return null;
        }
        public static clsUsers FindByPersonID(int PersonID)
        {
            double Salary = 0;
            int UserID = -1, Permissions = 0;
            string UserName = "", Password = "", JobTitle = "";
            bool IsActive = false;

            bool IsFound = clsUsersDataAccess.GetUsersInfoByPersonID
                                (PersonID, ref UserID, ref UserName, ref Password, ref IsActive, ref JobTitle, ref Permissions, ref Salary);
            if (IsFound)
            //we return new object of that User with the right data
            {
                clsPeople person = clsPeople.Find(PersonID);

                return new clsUsers(UserID, PersonID, UserName, Password, IsActive, JobTitle, Permissions, Salary, person.FirstName, person.SecondName,
                    person.ThirdName, person.LastName, person.NationalNo, person.DateOfBirth, person.Gendor
                    , person.Address, person.Phone, person.Email, person.NationalityCountryID, person.ImagePath);

            }
            else
                return null;
        }
        public static clsUsers FindByUsernameAndPassword(string UserName, string Password)
        {
            double Salary = 0;
            int UserID = -1, Permissions = 0, PersonID=-1;
            string  JobTitle = "";
            bool IsActive = false;

            bool IsFound = clsUsersDataAccess.GetUserInfoByUsernameAndPassword
                                (UserName, Password, ref UserID, ref PersonID, ref IsActive, ref JobTitle, ref Permissions, ref Salary);

            if (IsFound)
            //we return new object of that User with the right data
            {
                clsPeople person = clsPeople.Find(PersonID);

                return new clsUsers(UserID, PersonID, UserName, Password, IsActive, JobTitle, Permissions,Salary , person.FirstName, person.SecondName,
                    person.ThirdName, person.LastName, person.NationalNo, person.DateOfBirth, person.Gendor
                    , person.Address, person.Phone, person.Email, person.NationalityCountryID, person.ImagePath);

            }
            else
                return null;
        }

        public async Task<bool> Save()
        {
            base._Mode = (clsPeople.enMode)Mode;
            if (!await  base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }

            return false;
        }

        public static DataTable GetAllUsers()
        {
            return clsUsersDataAccess.GetListUsers();
        }

        //public bool DeleteUser()
        //{
        //    bool IsUserDeleted = false;
        //    bool IsBasePersonDeleted = false;

        //    IsUserDeleted = clsUsersDataAccess.DeleteUsers(this.UserID);
        //    if (!IsUserDeleted)
        //        return false;

        //    IsBasePersonDeleted = base.Delete();
        //    return IsBasePersonDeleted;
        //}
        public async Task<bool> DeleteUser()
        {
            bool IsUserDeleted = false;
            bool IsBasePersonDeleted = false;

            IsUserDeleted = clsUsersDataAccess.DeleteUsers(this.UserID);
            if (!IsUserDeleted)
                return false;

            IsBasePersonDeleted = await  base.Delete();
            return IsUserDeleted;
        }
        public static bool isUserExist(int UserID)
        {
            return clsUsersDataAccess.IsUsersExisteByID(UserID);
        }

        public static bool isUserExist(string UserName)
        {
            return clsUsersDataAccess.IsUserExist(UserName);
        }


        public static bool isUserExistForPersonID(int PersonID)
        {
            return clsUsersDataAccess.IsUserExistForPersonID(PersonID);
        }

        public bool CheckAccessPermission(enPermissions Permission)
        {
            int _Permission=(int)Permission;

            if (this.Permissions == (int)enPermissions.FullAccess)
                return true;

            if ((_Permission & this.Permissions) == _Permission)
                return true;
            else
                return false;
        }

        public string GetPermissionAsString()
        {
            string Permissions = "";

            if (this.CheckAccessPermission(clsUsers.enPermissions.FullAccess))
            {
                Permissions += " Full Access , ";
                return Permissions.Remove(Permissions.Length - 2);
            }
            if (this.CheckAccessPermission(clsUsers.enPermissions.ManageMembers))
                Permissions += " Manage Members ,";
            if (this.CheckAccessPermission(clsUsers.enPermissions.ManageBooks))
                Permissions += " Manage Books ,";
            if (this.CheckAccessPermission(clsUsers.enPermissions.ManageUsers))
                Permissions += " Manage Users , ";
            if (this.CheckAccessPermission(clsUsers.enPermissions.ManageLoan))
                Permissions += " Manage Loan , ";
            if (this.CheckAccessPermission(clsUsers.enPermissions.ManageReservation))
                Permissions += " Manage Reservation , ";
            if (this.CheckAccessPermission(clsUsers.enPermissions.ManagePayments))
                Permissions += " Manage Payments , ";
            if (this.CheckAccessPermission(clsUsers.enPermissions.ManagePurchasesBook))
                Permissions += " Manage Purchases Book , ";

            return Permissions.Remove(Permissions.Length - 2);
           }

        }
}