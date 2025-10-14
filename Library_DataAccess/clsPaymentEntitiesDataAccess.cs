 
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

    public class clsPaymentEntitiesDataAccess
    {

        public static bool GetPaymentEntitiesInfoByID(int EntityTypeID, ref string EntityName)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From PaymentEntities Where EntityTypeID = @EntityTypeID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EntityTypeID", EntityTypeID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                EntityName = (string)(reader["EntityName"] == System.DBNull.Value ? "" : reader["EntityName"]);

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



        public static async Task<int> AddNewPaymentEntities(string EntityName)
        {
            int InsertedID = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @"INSERT INTO PaymentEntities(EntityName)
                                   
                                       VALUES (@EntityName) 
                
                                SELECT SCOPE_IDENTITY();";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EntityName", EntityName);


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
        public static async Task<bool> UpdatePaymentEntities(int EntityTypeID, string EntityName)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @"Update PaymentEntities SET EntityName = @EntityName

                                    WHERE EntityTypeID= @EntityTypeID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@EntityTypeID", EntityTypeID);
                        command.Parameters.AddWithValue("@EntityName", EntityName);


                        RowsAffected =await  command.ExecuteNonQueryAsync();



                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
            }

            return (RowsAffected != -1);

        }
        public static async Task<DataTable> GetListPaymentEntities()
        {
            DataTable dtList = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @" Select * From PaymentEntities";


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
        public static async Task<bool> DeletePaymentEntities(int EntityTypeID)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();
                    string query = @" Delete From PaymentEntities Where EntityTypeID = @EntityTypeID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EntityTypeID", EntityTypeID);


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
        public static async Task<bool> IsPaymentEntitiesExisteByID(int EntityTypeID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {

                    await connection.OpenAsync();
                    string query = @" Select Found = 1 From PaymentEntities Where EntityTypeID = @EntityTypeID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EntityTypeID", EntityTypeID);


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

        public static bool GetPaymentEntitiesInfoByEntityName(string EntityName, ref int EntityTypeID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From PaymentEntities Where EntityName = @EntityName";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EntityName", EntityName);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                EntityTypeID = (int)reader["EntityTypeID"];

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