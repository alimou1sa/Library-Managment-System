
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



    public class clsPeople
    {

        public enum enMode { AddNew, Update };

        public enMode _Mode;

        public int PersonID { set; get; }
        public string NationalNo { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public DateTime DateOfBirth { set; get; }
        public byte Gendor { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int NationalityCountryID { set; get; }
        private string _ImagePath { set; get; }


        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }

        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }

        }
        public clsCountries CountriesInfo { set; get; }



        public clsPeople()
        {
            this._Mode = enMode.AddNew;

            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gendor = 0;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";


            this.CountriesInfo = null;

        }

        private clsPeople(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName,
            string LastName, DateTime DateOfBirth, byte Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this._Mode = enMode.Update;

            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;


            this.CountriesInfo = clsCountries.FindByID(NationalityCountryID);

        }

        public static clsPeople Find(int PersonID)
        {
            string NationalNo = " ";
            string FirstName = " ";
            string SecondName = " ";
            string ThirdName = " ";
            string LastName = " ";
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            string Address = " ";
            string Phone = " ";
            string Email = " ";
            int NationalityCountryID = -1;
            string ImagePath = " ";


            if (clsPeopleDataAccess.GetPeopleInfoByID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName,
                ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID,
                ref ImagePath))
            {
                return new clsPeople(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);

            }

            return null;

        }

        private async Task<bool> _AddNewPeople()
        {
            this.PersonID =await  clsPeopleDataAccess.AddNewPeople(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

            return (this.PersonID != -1);

        }
        private async Task<bool> _UpdatePeople()
        {
            return await  clsPeopleDataAccess.UpdatePeople(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }

        public async Task<bool> Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:

                    if ( await _AddNewPeople())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:

                    return await  _UpdatePeople();

                default:
                    return false;

            }

        }
        public static async Task<bool> DeletePeople(int PersonID)
        {
            return await clsPeopleDataAccess.DeletePeople(PersonID);

        }
        public static async Task<DataTable> GetListPeople()
        {

            return await   clsPeopleDataAccess.GetListPeople();
        }

        public static async Task<bool> IsPeopleExisteByID(int PersonID)
        {
            return await  clsPeopleDataAccess.IsPeopleExisteByID(PersonID);

        }

        public async Task<bool> Delete()
        {
            return await  clsPeopleDataAccess.DeletePeople(this.PersonID);
        }


        public static clsPeople Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int PersonID = -1, NationalityCountryID = -1;
            byte Gendor = 0;

            bool IsFound = clsPeopleDataAccess.GetPeopleInfoByNationalNo
                                (
                                    NationalNo, ref PersonID, ref FirstName, ref SecondName,
                                    ref ThirdName, ref LastName, ref DateOfBirth,
                                    ref Gendor, ref Address, ref Phone, ref Email,
                                    ref NationalityCountryID, ref ImagePath
                                );

            if (IsFound)

                return new clsPeople(PersonID, FirstName, SecondName, ThirdName, LastName,
                          NationalNo, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;
        }




        public static async Task<bool> isPersonExist(string NationlNo)
        {
            return await  clsPeopleDataAccess.IsPeopleExisteByNationalNo(NationlNo);
        }









    }
}