 
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

    public class clsUsersDataAccess
    {

        public static bool GetUsersInfoByID(int UserID, ref int PersonID, ref string UserName, ref string Password,
            ref bool IsActive, ref string JobTitle, ref int Permissions, ref double Salary)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();
                   
                    using (SqlCommand command = new SqlCommand("SP_GetUsersInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", UserID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                PersonID = (int)reader["PersonID"];
                                UserName = (string)(reader["UserName"] == System.DBNull.Value ? "" : reader["UserName"]);
                                Password = (string)(reader["Password"] == System.DBNull.Value ? "" : reader["Password"]);
                                IsActive = (bool)reader["IsActive"];
                                JobTitle = (string)reader["JobTitle"];
                                Permissions = (int)reader["Permissions"];
                                Salary = Convert.ToDouble(reader["Salary"]);
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
        public static async Task<int> AddNewUsers(int PersonID, string UserName, string Password, bool IsActive,
            string JobTitle, int Permissions, double Salary)
        {
            int InsertedID = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SP_AddNewUsers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@JobTitle", JobTitle);
                        command.Parameters.AddWithValue("@Permissions", Permissions);
                        command.Parameters.AddWithValue("@Salary", Salary);


                        SqlParameter outputIdParam = new SqlParameter("@NewUserID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(outputIdParam);
                        await command.ExecuteNonQueryAsync();
                         InsertedID = (int)command.Parameters["@NewUserID"].Value;

                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
            }

            return InsertedID;

        }
        public static async Task<bool> UpdateUsers(int UserID, int PersonID, string UserName, string Password, bool IsActive,
            string JobTitle, int Permissions, double Salary)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();
              

                    using (SqlCommand command = new SqlCommand("SP_UpdateUsers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@JobTitle", JobTitle);
                        command.Parameters.AddWithValue("@Permissions", Permissions);
                        command.Parameters.AddWithValue("@Salary", Salary);

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

        public static async Task<DataTable> GetListUsers()
        {
            DataTable dtList = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                   await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("SP_GetListUsers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
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
        public static async Task<bool> DeleteUsers(int UserID)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SP_DeleteUsers", connection))
                    {
                        command.CommandType= CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", UserID);

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

        public static async Task<bool> IsUsersExisteByID(int UserID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand("SP_IsUsersExisteByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", UserID);

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


        public static bool GetUserInfoByUsernameAndPassword(string UserName, string Password, ref int UserID, ref int PersonID,
           ref bool IsActive, ref string JobTitle, ref int Permissions, ref double Salary)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetUserInfoByUsernameAndPassword", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", UserName);
                    command.Parameters.AddWithValue("@Password", Password);


                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // The record was found
                            isFound = true;
                            UserID = (int)reader["UserID"];
                            PersonID = (int)reader["PersonID"];
                            UserName = (string)reader["UserName"];
                            Password = (string)reader["Password"];
                            IsActive = (bool)reader["IsActive"];
                            JobTitle = (string)reader["JobTitle"];
                            Permissions = (int)reader["Permissions"];
                            Salary = Convert.ToDouble(reader["Salary"]);

                        }
                        else
                        {
                            // The record was not found
                            isFound = false;
                        }

                        reader.Close();


                    }
                    catch (SqlException ex)
                    {
                        clsErrorEventLog.LogError(ex.Message);

                        isFound = false;
                    }
                }
            }

            return isFound;
        }



        public static bool GetUsersInfoByPersonID(int PersonID, ref int UserID, ref string UserName, ref string Password,
    ref bool IsActive, ref string JobTitle, ref int Permissions, ref double Salary)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From Users Where PersonID = @PersonID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                UserID = (int)reader["UserID"];
                                UserName = (string)(reader["UserName"] == System.DBNull.Value ? "" : reader["UserName"]);
                                Password = (string)(reader["Password"] == System.DBNull.Value ? "" : reader["Password"]);
                                IsActive = (bool)reader["IsActive"];
                                JobTitle = (string)reader["JobTitle"];
                                Permissions = (int)reader["Permissions"];
                                Salary = Convert.ToDouble(reader["Salary"]);

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


        public static async Task<bool> IsUserExist(string UserName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "SELECT Found=1 FROM Users WHERE UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
               await  connection.OpenAsync();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);

                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        public static async Task< bool> IsUserExistForPersonID(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "SELECT Found=1 FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
               await connection.OpenAsync();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);

                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }




    }
}