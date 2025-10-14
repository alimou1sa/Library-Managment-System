 
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

    public class clsPublishersDataAccess
    {

        public static bool GetPublishersInfoByID(int PublisherID, ref string Name, ref string Address, ref string Phone)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From Publishers Where PublisherID = @PublisherID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PublisherID", PublisherID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                Name = (string)(reader["Name"] == System.DBNull.Value ? "" : reader["Name"]);
                                Address = (string)(reader["Address"] == System.DBNull.Value ? "" : reader["Address"]);
                                Phone = (string)(reader["Phone"] == System.DBNull.Value ? "" : reader["Phone"]);

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
        public static async Task<int> AddNewPublishers(string Name, string Address, string Phone)
        {
            int InsertedID = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();


                    string query = @"INSERT INTO Publishers(Name, Address, Phone)
                                   
                                       VALUES (@Name, @Address, @Phone) 
                
                                SELECT SCOPE_IDENTITY();";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", Name);

                        if (string.IsNullOrEmpty(Address))
                        {
                            command.Parameters.AddWithValue("@Address", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Address", Address);

                        }
                        if (string.IsNullOrEmpty(Phone))
                        {
                            command.Parameters.AddWithValue("@Phone", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Phone", Phone);

                        }

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
        public static async Task<bool> UpdatePublishers(int PublisherID, string Name, string Address, string Phone)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @"Update Publishers SET Name = @Name,Address = @Address,Phone = @Phone

                                    WHERE PublisherID= @PublisherID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@PublisherID", PublisherID);
                        command.Parameters.AddWithValue("@Name", Name);

                        if (string.IsNullOrEmpty(Address))
                        {
                            command.Parameters.AddWithValue("@Address", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Address", Address);

                        }
                        if (string.IsNullOrEmpty(Phone))
                        {
                            command.Parameters.AddWithValue("@Phone", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Phone", Phone);

                        }

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
        public static async Task<DataTable> GetListPublishers()
        {
            DataTable dtList = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();


                    string query = @" Select * From Publishers";


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
        public static async Task<bool> DeletePublishers(string  Name)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();
                    string query = @" Delete From Publishers Where Name = @Name";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", Name);
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
        public static async Task<bool> IsPublishersExisteByID(int PublisherID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                   await connection.OpenAsync();

                    string query = @" Select Found = 1 From Publishers Where PublisherID = @PublisherID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PublisherID", PublisherID);


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

        public static bool GetPublisherInfoByName(string Name, ref int PublisherID, ref string Address, ref string Phone)
        {

            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();
                    string query = "select * from Publishers where Name=@Name";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", Name);



                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                // The record was found
                                isFound = true;

                                PublisherID = (int)reader["PublisherID"];
                                Address = (string)(reader["Address"] == System.DBNull.Value ? "" : reader["Address"]);
                                Phone = (string)(reader["Phone"] == System.DBNull.Value ? "" : reader["Phone"]);
                            }
                            else
                            {
                                // The record was not found
                                isFound = false;
                            }


                        }


                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);

                isFound = false;
            }

            return isFound;
        }


    }
}