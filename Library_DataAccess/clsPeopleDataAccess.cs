 
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

    public class clsPeopleDataAccess
    {

        public static bool GetPeopleInfoByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)


        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From People Where PersonID = @PersonID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                NationalNo = (string)(reader["NationalNo"] == System.DBNull.Value ? "" : reader["NationalNo"]);
                                FirstName = (string)(reader["FirstName"] == System.DBNull.Value ? "" : reader["FirstName"]);
                                SecondName = (string)(reader["SecondName"] == System.DBNull.Value ? "" : reader["SecondName"]);
                                ThirdName = (string)(reader["ThirdName"] == System.DBNull.Value ? "" : reader["ThirdName"]);
                                LastName = (string)(reader["LastName"] == System.DBNull.Value ? "" : reader["LastName"]);
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Gendor = (byte)reader["Gendor"];
                                Address = (string)(reader["Address"] == System.DBNull.Value ? "" : reader["Address"]);
                                Phone = (string)(reader["Phone"] == System.DBNull.Value ? "" : reader["Phone"]);
                                Email = (string)(reader["Email"] == System.DBNull.Value ? "" : reader["Email"]);
                                NationalityCountryID = (int)reader["NationalityCountryID"];
                                ImagePath = (string)(reader["ImagePath"] == System.DBNull.Value ? "" : reader["ImagePath"]);

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

        public static async Task<int> AddNewPeople(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, byte Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int InsertedID = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SP_AddNewPerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@SecondName", SecondName);

                        if (string.IsNullOrEmpty(ThirdName))
                        {
                            command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ThirdName", ThirdName);

                        }
                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        command.Parameters.AddWithValue("@Gendor", Gendor);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@Phone", Phone);

                        if (string.IsNullOrEmpty(Email))
                        {
                            command.Parameters.AddWithValue("@Email", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Email", Email);

                        }
                        command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

                        if (string.IsNullOrEmpty(ImagePath))
                        {
                            command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ImagePath", ImagePath);

                        }


                        SqlParameter outputIdParam = new SqlParameter("@NewPersonID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(outputIdParam);
                        await command.ExecuteNonQueryAsync();
                        InsertedID = (int)command.Parameters["@NewPersonID"].Value;

                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
            }

            return InsertedID;

        }
        public static async Task<bool> UpdatePeople(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, byte Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();


                    string query = @"Update People SET NationalNo = @NationalNo,FirstName = @FirstName,SecondName = @SecondName,ThirdName = @ThirdName,LastName = @LastName,DateOfBirth = @DateOfBirth,Gendor = @Gendor,Address = @Address,Phone = @Phone,Email = @Email,NationalityCountryID = @NationalityCountryID,ImagePath = @ImagePath

                                    WHERE PersonID= @PersonID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);
                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@SecondName", SecondName);

                        if (string.IsNullOrEmpty(ThirdName))
                        {
                            command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ThirdName", ThirdName);

                        }
                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        command.Parameters.AddWithValue("@Gendor", Gendor);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@Phone", Phone);

                        if (string.IsNullOrEmpty(Email))
                        {
                            command.Parameters.AddWithValue("@Email", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Email", Email);

                        }
                        command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

                        if (string.IsNullOrEmpty(ImagePath))
                        {
                            command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ImagePath", ImagePath);

                        }

                        RowsAffected = command.ExecuteNonQuery();



                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
            }

            return (RowsAffected != -1);

        }
        public static async Task<DataTable> GetListPeople()
        {
            DataTable dtList = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();


                    using (SqlCommand command = new SqlCommand("SP_GetListPeople", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

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

            return dtList;

        }
        public static async Task<bool> DeletePeople(int PersonID)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();


                    string query = @" Delete From People Where PersonID = @PersonID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);
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
      
        
        public static async Task<bool> IsPeopleExisteByID(int PersonID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();


                    string query = @" Select Found = 1 From People Where PersonID = @PersonID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);


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


        public static async Task<bool> IsPeopleExisteByNationalNo(string NationalNo)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();


                    string query = @" Select Found = 1 From People Where NationalNo = @NationalNo";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);


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



       
        
        
        
        public static bool GetPeopleInfoByNationalNo(string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)


        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From People Where NationalNo = @NationalNo";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                PersonID = (int)(reader["PersonID"] == System.DBNull.Value ? "" : reader["PersonID"]);
                                FirstName = (string)(reader["FirstName"] == System.DBNull.Value ? "" : reader["FirstName"]);
                                SecondName = (string)(reader["SecondName"] == System.DBNull.Value ? "" : reader["SecondName"]);
                                ThirdName = (string)(reader["ThirdName"] == System.DBNull.Value ? "" : reader["ThirdName"]);
                                LastName = (string)(reader["LastName"] == System.DBNull.Value ? "" : reader["LastName"]);
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Gendor = (byte)reader["Gendor"];
                                Address = (string)(reader["Address"] == System.DBNull.Value ? "" : reader["Address"]);
                                Phone = (string)(reader["Phone"] == System.DBNull.Value ? "" : reader["Phone"]);
                                Email = (string)(reader["Email"] == System.DBNull.Value ? "" : reader["Email"]);
                                NationalityCountryID = (int)reader["NationalityCountryID"];
                                ImagePath = (string)(reader["ImagePath"] == System.DBNull.Value ? "" : reader["ImagePath"]);

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