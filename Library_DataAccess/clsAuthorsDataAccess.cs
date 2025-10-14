 
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

    public class clsAuthorsDataAccess
    {

public static bool GetAuthorsInfoByID(int AutherID,ref string Name,ref string BIi)
    {
        bool IsFound  = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From Authors Where AutherID = @AutherID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AutherID", AutherID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                Name = (string)(reader["Name"] == System.DBNull.Value ? "" : reader["Name"]);
                                BIi = (string)(reader["BIi"] == System.DBNull.Value ? "" : reader["BIi"]);

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
        public static async Task<int> AddNewAuthors(string Name,string BIi)
    {
        int InsertedID  = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                   await connection.OpenAsync();

                    string query = @"INSERT INTO Authors(Name, BIi)
                                   
                                       VALUES (@Name, @BIi) 
                
                                SELECT SCOPE_IDENTITY();";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@BIi", BIi);


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

            return InsertedID ;
          
    }public static async Task< bool> UpdateAuthors(int AutherID,string Name, string BIi)
    {
        int RowsAffected  = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @"Update Authors SET Name = @Name,BIi = @BIi

                                    WHERE AutherID= @AutherID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@AutherID", AutherID);
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@BIi", BIi);


                        RowsAffected =await command.ExecuteNonQueryAsync();



                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
            }

            return (RowsAffected != -1 ) ;
          
    }
        public static async Task<DataTable> GetListAuthors()
    {
        DataTable dtList = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @" Select * From Authors";


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

            return dtList ;
          
    }
        public static async Task<bool> DeleteAuthors(string Name)
        {
            int RowsAffected = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();
                    string query = @" Delete From Authors Where Name = @Name";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", Name);
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

        public static async Task<bool> IsAuthorsExisteByID(int AutherID)
    {
        bool IsFound  = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();
                    string query = @" Select Found = 1 From Authors Where AutherID = @AutherID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AutherID", AutherID);

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

        return IsFound ;
          
    }



        public static bool GetAutherInfoByName(string Name, ref int AutherID,ref string BIi)
        {

            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();
                    string query = "select * from Authors where Name= @Name";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", Name);



                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                // The record was found
                                isFound = true;

                                AutherID = (int)reader["AutherID"];
                                BIi = (string)(reader["BIi"] == System.DBNull.Value ? "" : reader["BIi"]);

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