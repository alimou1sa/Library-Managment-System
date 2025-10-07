
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

    public class clsSettings
    {

        static public int GetDefualtBorrrowDays()
        {
            return clsSettingsDataAccess.GetDefualtBorrrowDays();
        }
        static public int GetDefualtFineDays()
        {
            return clsSettingsDataAccess.GetDefualtFineDays();
        }

        public static bool UpdateSettings(int DefualtBorrrowDays,int DefaultFinePerDay)
        {
           return  clsSettingsDataAccess.UpdateSetting(DefualtBorrrowDays, DefaultFinePerDay);

        }





    }
}