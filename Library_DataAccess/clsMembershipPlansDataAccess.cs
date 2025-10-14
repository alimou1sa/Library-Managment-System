 
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

    public class clsMembershipPlansDataAccess
    {

        public static bool GetMembershipPlansInfoByID(int PlanID, ref string PlanName, ref int DurationMonths, ref double Price)

        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From MembershipPlans Where PlanID = @PlanID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PlanID", PlanID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                PlanName = (string)(reader["PlanName"] == System.DBNull.Value ? "" : reader["PlanName"]);
                                DurationMonths = (int)reader["DurationMonths"];
                                Price = Convert.ToDouble(reader["Price"]);

                            }
                        }



                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);

                IsFound = false;

            }

            return IsFound;

        }



        public static async Task<int> AddNewMembershipPlans(string PlanName, int DurationMonths, double Price)


        {
            int InsertedID = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                   await connection.OpenAsync();

                    string query = @"INSERT INTO MembershipPlans(PlanName, DurationMonths, Price)
                                   
                                       VALUES (@PlanName, @DurationMonths, @Price) 
                
                                SELECT SCOPE_IDENTITY();";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PlanName", PlanName);
                        command.Parameters.AddWithValue("@DurationMonths", DurationMonths);
                        command.Parameters.AddWithValue("@Price", Price);


                        object Result =await command.ExecuteScalarAsync();

                        int ID = 0;

                        if (Result != null && int.TryParse(Result.ToString(), out ID))
                        {
                            InsertedID = ID;

                        }

                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
            }

            return InsertedID;

        }
        public static async Task<bool> UpdateMembershipPlans(int PlanID, string PlanName, int DurationMonths, double Price)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @"Update MembershipPlans SET PlanName = @PlanName,DurationMonths = @DurationMonths,Price = @Price

                                    WHERE PlanID= @PlanID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@PlanID", PlanID);
                        command.Parameters.AddWithValue("@PlanName", PlanName);
                        command.Parameters.AddWithValue("@DurationMonths", DurationMonths);
                        command.Parameters.AddWithValue("@Price", Price);


                        RowsAffected =await command.ExecuteNonQueryAsync();



                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
            }

            return (RowsAffected != -1);

        }
        public static async Task<DataTable> GetListMembershipPlans()
        {
            DataTable dtList = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();


                    string query = @" Select * From MembershipPlans";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        using (SqlDataReader reader =await command.ExecuteReaderAsync())
                        {

                            if (reader.HasRows)
                            {

                                dtList.Load(reader);

                            }
                        }



                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
            }
            return dtList;

        }
        public static async Task<bool> DeleteMembershipPlans(int PlanID)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();


                    string query = @" Delete From MembershipPlans Where PlanID = @PlanID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PlanID", PlanID);


                        RowsAffected =await command.ExecuteNonQueryAsync();



                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
            }

            return (RowsAffected != -1);

        }
        public static async Task<bool> IsMembershipPlansExisteByID(int PlanID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();


                    string query = @" Select Found = 1 From MembershipPlans Where PlanID = @PlanID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PlanID", PlanID);


                        using (SqlDataReader reader =await command.ExecuteReaderAsync())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;


                            }
                        }



                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);

                IsFound = false;

            }

            return IsFound;

        }


        public static bool GetMembershipPlansInfoByPlanName(string PlanName, ref int PlanID, ref int DurationMonths, ref double Price)

        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From MembershipPlans Where PlanName = @PlanName";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PlanName", PlanName);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                PlanID = (int)reader["PlanID"];
                                DurationMonths = (int)reader["DurationMonths"];
                                Price = Convert.ToDouble(reader["Price"]);

                            }
                        }



                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);

                IsFound = false;

            }

            return IsFound;

        }











    }
}