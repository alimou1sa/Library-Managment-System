 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Library_Manegment_System;
using Library_DataAccess.Global_classes;
using System.Collections;


namespace Library_DataAccessLayer
{

    public class clsBooksDataAccess
    {

        public static bool GetBooksInfoByID(int BookID, ref string Title, ref string ISBN, ref int GenreID,
            ref int PublisherID, ref DateTime YearPublished, ref string AdditionalDetails, ref int CategoryID
            , ref int AuthorID, ref double BookPrice)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From Books Where BookID = @BookID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookID", BookID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                Title = (string)(reader["Title"] == System.DBNull.Value ? "" : reader["Title"]);
                                ISBN = (string)(reader["ISBN"] == System.DBNull.Value ? "" : reader["ISBN"]);
                                GenreID = (int)reader["GenreID"];
                                PublisherID = (int)reader["PublisherID"];
                                YearPublished = (DateTime)reader["YearPublished"];
                                AdditionalDetails = (string)(reader["AdditionalDetails"] == System.DBNull.Value ? "" : reader["AdditionalDetails"]);
                                CategoryID = (int)reader["CategoryID"];
                                AuthorID = (int)reader["AuthorID"];
                                BookPrice = Convert.ToDouble(reader["BookPrice"]);

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


        public static async Task<int> AddNewBooksAndCopies(string Title, string ISBN, int GenreID, int PublisherID, DateTime
YearPublished, string AdditionalDetails, int CategoryID, int AuthorID, double BookPrice,short NumberOfCopies,byte Status)
        {
            int newBookID = -1;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {
               await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand("SP_AddNewBookAndCopies", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;


                    // Add parameters
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@ISBN", ISBN);
                    command.Parameters.AddWithValue("@GenreID", GenreID);
                    command.Parameters.AddWithValue("@PublisherID", PublisherID);
                    command.Parameters.AddWithValue("@YearPublished", YearPublished);
                    command.Parameters.AddWithValue("@NumberOfCopies", NumberOfCopies);
                    command.Parameters.AddWithValue("@Status", Status);

                    if (string.IsNullOrEmpty(AdditionalDetails))
                    {
                        command.Parameters.AddWithValue("@AdditionalDetails", System.DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@AdditionalDetails", AdditionalDetails);

                    }


                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    command.Parameters.AddWithValue("@AuthorID", AuthorID);
                    command.Parameters.AddWithValue("@BookPrice", BookPrice);

                    SqlParameter outputIdParam = new SqlParameter("@NewBookID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(outputIdParam);

                   await command.ExecuteNonQueryAsync();
                    newBookID = (int)command.Parameters["@NewBookID"].Value;

                }

            }
            return newBookID;

        }


        public static async Task< bool> UpdateBooks(int BookID, string Title, string ISBN, int GenreID,
            int PublisherID, DateTime YearPublished, string AdditionalDetails, int CategoryID, int AuthorID,
            double BookPrice)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                   await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SP_UpdateBooks", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BookID", BookID);
                        command.Parameters.AddWithValue("@Title", Title);
                        command.Parameters.AddWithValue("@ISBN", ISBN);
                        command.Parameters.AddWithValue("@GenreID", GenreID);
                        command.Parameters.AddWithValue("@PublisherID", PublisherID);
                        command.Parameters.AddWithValue("@YearPublished", YearPublished);

                        if (string.IsNullOrEmpty(AdditionalDetails))
                        {
                            command.Parameters.AddWithValue("@AdditionalDetails", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@AdditionalDetails", AdditionalDetails);
                        }
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);
                        command.Parameters.AddWithValue("@AuthorID", AuthorID);
                        command.Parameters.AddWithValue("@BookPrice", BookPrice);

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
     
        public static async Task<DataTable> GetListBooks()
        {
            DataTable dtList = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SP_GetListBooks", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader =await  command.ExecuteReaderAsync())
                        {

                            if (reader.HasRows)
                                dtList.Load(reader);
                            else
                                dtList = null;
                            
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

        public static async Task< bool> DeleteBooks(int BookID)
        {
            int RowsAffected = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SP_DeleteBooks", connection))
                    {
                        command.CommandType= CommandType.StoredProcedure;
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
     
        public static async Task<bool> IsBooksExisteByID(int BookID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("SP_IsBooksExisteByID", connection))
                    {
                        command .CommandType= CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BookID", BookID);

                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(returnParameter);
                        await command.ExecuteNonQueryAsync();

                        IsFound = (int)returnParameter.Value == 1;
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

        public static bool GetBooksInfoByISBN(string ISBN, ref int BookID, ref string Title, ref int GenreID,
    ref int PublisherID, ref DateTime YearPublished, ref string AdditionalDetails, ref int CategoryID
    , ref int AuthorID, ref double BookPrice)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From Books Where ISBN=@ISBN";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ISBN", ISBN);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                Title = (string)(reader["Title"] == System.DBNull.Value ? "" : reader["Title"]);
                                BookID = (int)reader["BookID"];
                                GenreID = (int)reader["GenreID"];
                                PublisherID = (int)reader["PublisherID"];
                                YearPublished = (DateTime)reader["YearPublished"];
                                AdditionalDetails = (string)(reader["AdditionalDetails"] == System.DBNull.Value ? "" : reader["AdditionalDetails"]);
                                CategoryID = (int)reader["CategoryID"];
                                AuthorID = (int)reader["AuthorID"];
                                BookPrice = Convert.ToDouble(reader["BookPrice"]);

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
       
        public static bool IsBooksExisteByISBN(string ISBN)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select Found = 1 From Books Where ISBN = @ISBN";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ISBN", ISBN);


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