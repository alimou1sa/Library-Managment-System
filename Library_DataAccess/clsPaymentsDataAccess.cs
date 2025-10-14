 
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

    public class clsPaymentsDataAccess
    {

        public static bool GetPaymentsInfoByID(int PaymentID, ref int PaymentTypeID, ref int MemberID, ref double Amount, ref byte PaymentStatus, ref int CreateByUserID, ref DateTime PaymentDate)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From Payments Where PaymentID = @PaymentID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                PaymentTypeID = (int)reader["PaymentTypeID"];
                                MemberID = (int)reader["MemberID"];
                                Amount = Convert.ToDouble(reader["Amount"]);
                                PaymentStatus = (byte)reader["PaymentStatus"];
                                CreateByUserID = (int)reader["CreateByUserID"];
                                PaymentDate = (DateTime)reader["PaymentDate"];

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
      
        public static async Task<int> AddNewPayments(int PaymentTypeID, int MemberID, double Amount, byte PaymentStatus, int CreateByUserID, DateTime PaymentDate)
        {
            int InsertedID = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @"INSERT INTO Payments(PaymentTypeID, MemberID, Amount, PaymentStatus, CreateByUserID, PaymentDate)
                                   
                                       VALUES (@PaymentTypeID, @MemberID, @Amount, @PaymentStatus, @CreateByUserID, @PaymentDate) 
                
                                SELECT SCOPE_IDENTITY();";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentTypeID", PaymentTypeID);
                        command.Parameters.AddWithValue("@MemberID", MemberID);
                        command.Parameters.AddWithValue("@Amount", Amount);
                        command.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
                        command.Parameters.AddWithValue("@CreateByUserID", CreateByUserID);
                        command.Parameters.AddWithValue("@PaymentDate", PaymentDate);


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
      
        public static async Task<bool> UpdatePayments(int PaymentID, int PaymentTypeID, int MemberID, double Amount, byte PaymentStatus, int CreateByUserID, DateTime PaymentDate)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                  await  connection.OpenAsync();

                    string query = @"Update Payments SET PaymentTypeID = @PaymentTypeID,MemberID = @MemberID,Amount = @Amount,PaymentStatus = @PaymentStatus,CreateByUserID = @CreateByUserID,PaymentDate = @PaymentDate

                                    WHERE PaymentID= @PaymentID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@PaymentID", PaymentID);
                        command.Parameters.AddWithValue("@PaymentTypeID", PaymentTypeID);
                        command.Parameters.AddWithValue("@MemberID", MemberID);
                        command.Parameters.AddWithValue("@Amount", Amount);
                        command.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
                        command.Parameters.AddWithValue("@CreateByUserID", CreateByUserID);
                        command.Parameters.AddWithValue("@PaymentDate", PaymentDate);


                        RowsAffected = await command.ExecuteNonQueryAsync();



                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
            }

            return (RowsAffected != -1);

        }
     
        public static async Task<DataTable> GetListPayments()
        {
            DataTable dtList = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();


                    using (SqlCommand command = new SqlCommand("SP_GetListPayments", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
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
     
        public static async Task<bool> DeletePayments(int PaymentID)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @" Delete From Payments Where PaymentID = @PaymentID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);


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
     
        public static async Task<bool> IsPaymentsExisteByID(int PaymentID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @" Select Found = 1 From Payments Where PaymentID = @PaymentID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);


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
  
    }
}