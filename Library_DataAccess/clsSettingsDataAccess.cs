 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Library_Manegment_System;


namespace Library_DataAccessLayer
{

    public class clsSettingsDataAccess
    {



        public static int GetDefualtBorrrowDays()
        {

            int Num = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"
					 select Settings.DefualtBorrrowDays from Settings
";


            SqlCommand command = new SqlCommand(query, connection);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {

                    Num = Convert.ToInt32(result);
                }
                else
                {
                    Num = -1;
                }


                connection.Close();


            }


            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
            }

            return Num;
        }



        public static int GetDefualtFineDays()
        {

            int Num = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"
									 select Settings.DefaultFinePerDay from Settings 
";


            SqlCommand command = new SqlCommand(query, connection);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {

                    Num = Convert.ToInt32(result);
                }
                else
                {
                    Num = -1;
                }


                connection.Close();


            }


            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
            }
            return Num;
        }


        public static bool UpdateSetting(int DefultBorrowDays, int LateFee)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" UPDATE [dbo].[Settings]
   SET [DefualtBorrrowDays] = @DefultBorrowDays
      ,[DefaultFinePerDay] = @LateFee";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@DefultBorrowDays", DefultBorrowDays);
                        command.Parameters.AddWithValue("@LateFee", LateFee);
                        RowsAffected = command.ExecuteNonQuery();

                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
            }

            return (RowsAffected != -1);

        }






    }
}