 
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

public static bool GetUsersInfoByID(int UserID,ref int PersonID,ref string UserName,ref string Password,
    ref bool IsActive,ref string JobTitle,ref int Permissions,ref double Salary)
    {
        bool IsFound  = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From Users Where UserID = @UserID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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

        return IsFound ;
          
    }
        public static int AddNewUsers(int PersonID,string UserName,string Password,bool IsActive,
            string JobTitle, int Permissions, double Salary)
    {
        int InsertedID  = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO Users(PersonID, UserName, Password, IsActive, JobTitle,Permissions,Salary)
                                   
                                       VALUES (@PersonID, @UserName, @Password, @IsActive,@JobTitle ,@Permissions ,@Salary) 
                
                                SELECT SCOPE_IDENTITY();";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@JobTitle", JobTitle);
                        command.Parameters.AddWithValue("@Permissions", Permissions);
                        command.Parameters.AddWithValue("@Salary", Salary);

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
          
    }
        public static bool UpdateUsers(int UserID,int PersonID, string UserName, string Password, bool IsActive, 
            string JobTitle, int Permissions, double Salary)
    {
        int RowsAffected  = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @"Update Users SET PersonID = @PersonID,UserName = @UserName,Password = @Password,IsActive
= @IsActive,JobTitle = @JobTitle,Permissions = @Permissions,Salary = @Salary

                                    WHERE UserID= @UserID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@JobTitle", JobTitle);
                        command.Parameters.AddWithValue("@Permissions", Permissions);
                        command.Parameters.AddWithValue("@Salary", Salary);

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
        public static DataTable GetListUsers()
    {
        DataTable dtList = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @"

SELECT Users.UserID, Users.UserName, Users.Password, Users.IsActive, Users.JobTitle,  People.FirstName + ' ' + People.SecondName + ' ' +ISNULL(dbo.People.ThirdName, '')   + ' ' + People.LastName AS FullName,
Users.Permissions, Users.Salary, People.NationalNo, People.DateOfBirth, 
CASE WHEN People.Gendor = 0 THEN 'Male' ELSE 'Female' END AS GendorCaption, People.Email, Countries.CountryName,People.Phone
FROM   Users INNER JOIN
             People ON Users.PersonID = People.PersonID INNER JOIN
             Countries ON People.NationalityCountryID = Countries.CountryID


";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
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
        public static bool DeleteUsers(int UserID)
    {
        int RowsAffected  = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Delete From Users Where UserID = @UserID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);


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
        
        public static bool IsUsersExisteByID(int UserID)
    {
        bool IsFound  = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select Found = 1 From Users Where UserID = @UserID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);


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


        public static bool GetUserInfoByUsernameAndPassword( string UserName, string Password,ref int UserID,ref int PersonID, 
           ref bool IsActive, ref string JobTitle, ref int Permissions, ref double Salary)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "SELECT * FROM Users WHERE Username = @Username and Password=@Password;";

            SqlCommand command = new SqlCommand(query, connection);

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
            finally
            {
                connection.Close();
            }

            return isFound;
        }



        public static bool GetUsersInfoByPersonID(int PersonID, ref int UserID,  ref string UserName, ref string Password,
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


        public static bool IsUserExist(string UserName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "SELECT Found=1 FROM Users WHERE UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
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


        public static bool IsUserExistForPersonID(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "SELECT Found=1 FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
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