using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library_DataAccessLayer
{


    public class clsDataAccessSettings
    {

        // public static string connectionString = "Server =.;DataBase =Library_DB;User ID =sa;Password =sa123456";
       public static string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
  
    
    }   

}