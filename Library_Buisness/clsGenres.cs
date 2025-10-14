
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

    public class clsGenres
    {

        enum enMode { AddNew, Update };

        enMode _Mode;

        public int GenreID { set; get; }
        public string GenreName { set; get; }





        public clsGenres()
        {
            this._Mode = enMode.AddNew;

            this.GenreID = -1;
            this.GenreName = " ";



        }

        private clsGenres(int GenreID, string GenreName)
        {
            this._Mode = enMode.Update;

            this.GenreID = GenreID;
            this.GenreName = GenreName;
        }

        public static clsGenres FindByID(int GenreID)
        {
            string GenreName = " ";


            if (clsGenresDataAccess.GetGenresInfoByID(GenreID, ref GenreName))
            {
                return new clsGenres(GenreID, GenreName);

            }

            return null;

        }

        private async Task<bool> _AddNewGenres()
        {
            this.GenreID = await clsGenresDataAccess.AddNewGenres(this.GenreName);

            return (this.GenreID != -1);

        }
        private async Task<bool> _UpdateGenres()
        {
            return await  clsGenresDataAccess.UpdateGenres(this.GenreID, this.GenreName);
        }

        public async Task<bool> Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:

                    if (await _AddNewGenres())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:

                    return await _UpdateGenres();

                default:
                    return false;

            }

        }
        public static async Task<bool> DeleteGenres(string GenreName)
        {
            return await  clsGenresDataAccess.DeleteGenres(GenreName);

        }
        public static async Task<DataTable> GetListGenres()
        {

            return await clsGenresDataAccess.GetListGenres();
        }

        public static async Task<bool> IsGenresExisteByID(int GenreID)
        {
            return await  clsGenresDataAccess.IsGenresExisteByID(GenreID);

        }



        public static clsGenres FindByGenreNAme(string GenreName)
        {
            int GenreID = -1;



            if (clsGenresDataAccess.GetGenresInfoByGenreNAme(GenreName, ref GenreID))
            {
                return new clsGenres(GenreID, GenreName);

            }

            return null;

        }

    }
}