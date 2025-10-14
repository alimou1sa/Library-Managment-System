 
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

    public class clsPaymentDetailsDataAccess
    {

        public static bool GetPaymentDetailsInfoByID(int PaymentDetailID, ref int PaymentID, ref int EntityTypeID, ref int EntityID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From PaymentDetails Where PaymentDetailID = @PaymentDetailID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentDetailID", PaymentDetailID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                PaymentID = (int)reader["PaymentID"];
                                EntityTypeID = (int)reader["EntityTypeID"];
                                EntityID = (int)reader["EntityID"];

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
        public static async Task<int> AddNewPaymentDetails(int PaymentID, int EntityTypeID, 
            int EntityID)
        {
            int InsertedID = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                   await connection.OpenAsync();

                    string query = @"INSERT INTO PaymentDetails(PaymentID, EntityTypeID, EntityID)    
                                       VALUES (@PaymentID, @EntityTypeID, @EntityID)          
                                         SELECT SCOPE_IDENTITY();";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);
                        command.Parameters.AddWithValue("@EntityTypeID", EntityTypeID);
                        command.Parameters.AddWithValue("@EntityID", EntityID);


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
        public static async Task<bool> UpdatePaymentDetails(int PaymentDetailID, int PaymentID, int EntityTypeID, int EntityID)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @"Update PaymentDetails SET PaymentID = @PaymentID,EntityTypeID = @EntityTypeID,EntityID = @EntityID

                                    WHERE PaymentDetailID= @PaymentDetailID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@PaymentDetailID", PaymentDetailID);
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);
                        command.Parameters.AddWithValue("@EntityTypeID", EntityTypeID);
                        command.Parameters.AddWithValue("@EntityID", EntityID);


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
        public static async Task<DataTable> GetListPaymentDetails()
        {
            DataTable dtList = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SP_GetListPaymentDetails", connection))
                    {
                        command.CommandType= CommandType.StoredProcedure;
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
        public static async Task<bool> DeletePaymentDetails(int PaymentDetailID)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @" Delete From PaymentDetails Where PaymentDetailID = @PaymentDetailID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentDetailID", PaymentDetailID);


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
        public static async Task<bool> IsPaymentDetailsExisteByID(int PaymentDetailID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();
                    string query = @" Select Found = 1 From PaymentDetails Where PaymentDetailID = @PaymentDetailID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentDetailID", PaymentDetailID);


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



        public static bool GetPaymentDetailsInfoByEntityID(int EntityID, int EntityTypeID, ref int PaymentDetailID, ref int PaymentID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * from PaymentDetails Where EntityID=@EntityID and EntityTypeID=@EntityTypeID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EntityID", EntityID);
                        command.Parameters.AddWithValue("@EntityTypeID", EntityTypeID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                PaymentID = (int)reader["PaymentID"];
                                PaymentDetailID = (int)reader["PaymentDetailID"];

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