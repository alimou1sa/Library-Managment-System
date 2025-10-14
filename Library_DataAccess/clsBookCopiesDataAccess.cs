 
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

    public class clsBookCopiesDataAccess
    {

        public static bool GetBookCopiesInfoByID(int CopyID,ref int BookID,ref byte Status)
    {
        bool IsFound  = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From BookCopies Where CopyID = @CopyID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CopyID", CopyID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                BookID = (int)reader["BookID"];
                                Status = (byte)reader["Status"];

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

        return IsFound ;
          
    }

        public static async Task<int> AddNewBookCopies(int BookID, byte Status)
        {
            int InsertedID = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                   await connection.OpenAsync();

                    string query = @"INSERT INTO BookCopies(BookID, Status)
                                   
                                       VALUES (@BookID, @Status) 
                
                                SELECT SCOPE_IDENTITY();";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookID", BookID);
                        command.Parameters.AddWithValue("@Status", Status);


                        object Result = command.ExecuteScalar();

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

        public static async Task<bool> UpdateBookCopies(int CopyID,int BookID, byte Status)
    {
        int RowsAffected  = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @"Update BookCopies SET BookID = @BookID,Status = @Status

                                    WHERE CopyID= @CopyID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@CopyID", CopyID);
                        command.Parameters.AddWithValue("@BookID", BookID);
                        command.Parameters.AddWithValue("@Status", Status);


                        RowsAffected = command.ExecuteNonQuery();



                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);


            }

            return (RowsAffected != -1 ) ;
          
    }
      
        public static async Task<DataTable> GetListBookCopies(int BookID)
    {
        DataTable dtList = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                 await  connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SP_GetListBookCopies", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BookID", BookID);

                        using (SqlDataReader reader =await  command.ExecuteReaderAsync())
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

            return dtList ;
          
    }
        
        public static async Task<bool> DeleteBookCopies(int CopyID)
    {
        int RowsAffected  = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @" Delete From BookCopies Where CopyID = @CopyID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CopyID", CopyID);


                        RowsAffected = command.ExecuteNonQuery();



                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);


            }

            return (RowsAffected != -1 ) ;
          
    }
        
        public static async Task<bool> IsBookCopiesExisteByID(int CopyID)
    {
        bool IsFound  = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @" Select Found = 1 From BookCopies Where CopyID = @CopyID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CopyID", CopyID);


                        using (SqlDataReader reader = command.ExecuteReader())
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

        return IsFound ;
          
    }

        public static async Task<int >GetNumberOfAllBookCopies(int BookID)
        {

            int Num = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"select COUNT(BookCopies.CopyID) From BookCopies  where BookCopies.BookID=@BookID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookID", BookID);

            try
            {

                await connection.OpenAsync();


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

        public static async Task<int> GetNumberOfAvailableBookCopies(int BookID,byte Status)
        {

            int Num = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"select COUNT(BookCopies.CopyID) From BookCopies  where BookCopies.BookID=@BookID and BookCopies.Status=@Status;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookID", BookID);
            command.Parameters.AddWithValue("@Status", Status);

            try
            {
                await connection.OpenAsync();


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

        public static async Task<bool> DeleteBookCopiesByBooKID (int BookID)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {

                    await connection.OpenAsync();


                    string query = @" DELETE FROM [dbo].[BookCopies]
                                   WHERE  BookID=@BookID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookID", BookID);


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

        public static async Task<int> GetCopyIDForAvailableBookCopies(int BookID)
        {

            int Num = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"
			 select top(1) BookCopies.CopyID from BookCopies where BookCopies.Status=1 and BooKID=@BooKID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookID", BookID);

            try
            {

                await connection.OpenAsync();


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

        public static async Task<bool> IsBookCopiesExisteByBookID(int BookID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {

                    await connection.OpenAsync();


                    string query = @" Select top(1) Found = 1 From BookCopies Where BookID = @BookID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookID", BookID);


                        using (SqlDataReader reader = command.ExecuteReader())
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