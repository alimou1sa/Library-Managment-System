
using Library_Manegment_System;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;


namespace Library_DataAccessLayer
{

    public class clsLoanesDataAccess
    {

        public static bool GetLoanesInfoByID(int LoanID, ref int CopyID, ref int MemberID, ref int LoanByUserID,

            ref DateTime LoanDate, ref DateTime DueDate, ref DateTime ReturnDate, ref int ReturnByUserID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From Loanes Where LoanID = @LoanID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LoanID", LoanID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                CopyID = (int)reader["CopyID"];
                                MemberID = (int)reader["MemberID"];
                                LoanByUserID = (int)reader["LoanByUserID"];
                                LoanDate = (DateTime)reader["LoanDate"];
                                DueDate = (DateTime)reader["DueDate"];



                                if (reader["ReturnDate"] != DBNull.Value)
                                {
                                    ReturnDate = (DateTime)reader["ReturnDate"];
                                }
                                else
                                {
                                    ReturnDate = DateTime.MinValue;
                                }

                                if (reader["ReturnByUserID"] != DBNull.Value)
                                {
                                    ReturnByUserID = (int)reader["ReturnByUserID"];
                                }
                                else
                                {
                                    ReturnByUserID = -1;
                                }

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

        public static async Task<int> AddNewBorrowBook(int CopyID, int MemberID, int LoanByUserID,
      DateTime DueDate, byte CopyStatus, byte ReservationStatus)
        {
            int InsertedID = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SP_AddNewBorrowBook", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CopyID", CopyID);
                        command.Parameters.AddWithValue("@MemberID", MemberID);
                        command.Parameters.AddWithValue("@LoanByUserID", LoanByUserID);
                        command.Parameters.AddWithValue("@DueDate", DueDate);
                        command.Parameters.AddWithValue("@LoanDate", DateTime.Now);
                        command.Parameters.AddWithValue("@CopyStatus", CopyStatus);
                        command.Parameters.AddWithValue("@ReservationStatus", ReservationStatus);

                        SqlParameter outputIdParam = new SqlParameter("@NewLoanID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(outputIdParam);
                        await command.ExecuteNonQueryAsync();
                        InsertedID = (int)command.Parameters["@NewLoanID"].Value;

                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
            }

            return InsertedID;

        }

        public static async Task<bool> UpdateLoanes(int LoanID, int CopyID, int MemberID, int LoanByUserID,
        DateTime LoanDate, DateTime DueDate, DateTime ReturnDate, int ReturnByUserID)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                  await connection.OpenAsync();

                    string query = @"Update Loanes SET CopyID = @CopyID,MemberID = @MemberID,LoanByUserID = @LoanByUserID
              ,LoanDate = @LoanDate,DueDate = @DueDate,ReturnDate = @ReturnDate,ReturnByUserID = @ReturnByUserID

                                    WHERE LoanID= @LoanID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@LoanID", LoanID);
                        command.Parameters.AddWithValue("@CopyID", CopyID);
                        command.Parameters.AddWithValue("@MemberID", MemberID);
                        command.Parameters.AddWithValue("@LoanByUserID", LoanByUserID);
                        command.Parameters.AddWithValue("@LoanDate", LoanDate);
                        command.Parameters.AddWithValue("@DueDate", DueDate);



                        if (ReturnDate != DateTime.MinValue)
                            command.Parameters.AddWithValue("@ReturnDate", ReturnDate);
                        else
                            command.Parameters.AddWithValue("@ReturnDate", System.DBNull.Value);

                        if (ReturnByUserID == -1)

                            command.Parameters.AddWithValue("@ReturnByUserID", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ReturnByUserID", ReturnByUserID);


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

        public static async Task<int> ReturnBook(int LoanID,
            int ReturnByUserID,byte CopyStatus,int PaymentTypeID,byte PaymentStatus)
        {
            int InsertedID = -1;
            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("SP_ReturnBook", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@LoanID", LoanID);

                        command.Parameters.AddWithValue("@ReturnByUserID", ReturnByUserID);
                        command.Parameters.AddWithValue("@CopyStatus", CopyStatus);
                        if(PaymentTypeID == -1)
                            command.Parameters.AddWithValue("@PaymentTypeID", DBNull.Value);
                        else
                        command.Parameters.AddWithValue("@PaymentTypeID", PaymentTypeID);

                        if(PaymentStatus==0)
                        command.Parameters.AddWithValue("@PaymentStatus", DBNull.Value);
                        else
                        command.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);


                        SqlParameter outputIdParam = new SqlParameter("@PaymentDetailsID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(outputIdParam);
                        await command.ExecuteNonQueryAsync();
                        InsertedID = (int)command.Parameters["@PaymentDetailsID"].Value;



                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
            }

            return InsertedID;

        }



        public static async Task<DataTable> GetListLoanes()
        {
            DataTable dtList = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SP_GetListLoanes", connection))
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
   
        public static async Task<bool> DeleteLoanes(int LoanID)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();


                    string query = @" Delete From Loanes Where LoanID = @LoanID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LoanID", LoanID);


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
    
        public static async Task<bool> IsLoanesExisteByID(int LoanID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();


                    string query = @" Select Found = 1 From Loanes Where LoanID = @LoanID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LoanID", LoanID);


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

        public static async Task<bool> IsLoanesBorrowedeByLoanID(int LoanID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @"


				 SELECT TOP (1) 1 AS Found,*
FROM   Loanes INNER JOIN
             BookCopies ON Loanes.CopyID = BookCopies.CopyID
			 where LoanID=@LoanID and Loanes.ReturnByUserID is null";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LoanID", LoanID);


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