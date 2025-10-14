 
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

    public class clsMembersDataAccess
    {

        public static bool GetMembersInfoByID(int MemberID, ref int PersonID, ref bool IsActive
            , ref string LibraryCardNumber, ref int LastSubscriptionID, ref int CreatedByUserID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From Members Where MemberID = @MemberID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MemberID", MemberID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                PersonID = (int)reader["PersonID"];
                                IsActive = (bool)reader["IsActive"];
                                LibraryCardNumber = (string)(reader["LibraryCardNumber"] == System.DBNull.Value ? "" : reader["LibraryCardNumber"]);
                                CreatedByUserID = (int)reader["CreatedByUserID"];

                                LastSubscriptionID = (int)(reader["LastSubscriptionID"] == DBNull.Value ? -1 : reader["LastSubscriptionID"]);
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
     
        public static async Task<int> AddNewMembers(int PersonID, bool IsActive, string LibraryCardNumber, int LastSubscriptionID, int CreatedByUserID)
        {
            int InsertedID = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                   await connection.OpenAsync();


                    using (SqlCommand command = new SqlCommand("SP_AddNewMembers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@LibraryCardNumber", LibraryCardNumber);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        if (LastSubscriptionID == -1)
                            command.Parameters.AddWithValue("@LastSubscriptionID", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@LastSubscriptionID", LastSubscriptionID);

                        SqlParameter outputIdParam = new SqlParameter("@NewMemberID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(outputIdParam);
                        await command.ExecuteNonQueryAsync();
                        InsertedID = (int)command.Parameters["@NewMemberID"].Value;

                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
            }

            return InsertedID;

        }
   
        public static async Task<bool> UpdateMembers(int MemberID, int PersonID, bool IsActive, string LibraryCardNumber,
            int LastSubscriptionID, int CreatedByUserID)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();


                    string query = @"Update Members SET PersonID = @PersonID,IsActive =
@IsActive,LibraryCardNumber = @LibraryCardNumber,CreatedByUserID = @CreatedByUserID,LastSubscriptionID=@LastSubscriptionID

                                    WHERE MemberID= @MemberID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@MemberID", MemberID);
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@LibraryCardNumber", LibraryCardNumber);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


                        if (LastSubscriptionID == -1)
                            command.Parameters.AddWithValue("@LastSubscriptionID", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@LastSubscriptionID", LastSubscriptionID);
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

        public static async Task<DataTable> GetListMembers()
        {
            DataTable dtList = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();


                    using (SqlCommand command = new SqlCommand("SP_GetListMembers", connection))
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
      
   
        public static async Task<bool> DeleteMembers(int MemberID)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SP_DeleteMembers", connection))
                    {
                        command.CommandType= CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MemberID", MemberID);
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
     
        public static async Task<bool> IsMembersExisteByID(int MemberID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();


                    string query = @" Select Found = 1 From Members Where MemberID = @MemberID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MemberID", MemberID);


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
        public static async Task<bool> IsMembersExisteByLCN(string LibraryCardNumber)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();
                    string query = @" Select Found = 1 From Members Where LibraryCardNumber = @LibraryCardNumber";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LibraryCardNumber", LibraryCardNumber);


                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
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

        public static async Task<bool> IsMembersExisteByPersonID(int PersonID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @" 
			 Select Found = 1 From Members Where PersonID=@PersonID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);


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

        public static bool GetMembersInfoByLCN(string LibraryCardNumber, ref int MemberID,
            ref int PersonID, ref bool IsActive, ref int LastSubscriptionID, ref int CreatedByUserID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From Members Where LibraryCardNumber = @LibraryCardNumber";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LibraryCardNumber", LibraryCardNumber);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                MemberID = (int)reader["MemberID"];
                                PersonID = (int)reader["PersonID"];
                                IsActive = (bool)reader["IsActive"];
                                LibraryCardNumber = (string)(reader["LibraryCardNumber"] == System.DBNull.Value ? "" : reader["LibraryCardNumber"]);
                                LastSubscriptionID = (int)(reader["LastSubscriptionID"] == DBNull.Value ? -1 : reader["LastSubscriptionID"]);
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

        public static async Task<bool> ChangeIsMembersActive(int MemberID, bool IsActive)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();


                    string query = @" Update Members SET IsActive =@IsActive where MemberID=@MemberID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@MemberID", MemberID);
                        command.Parameters.AddWithValue("@IsActive", IsActive);



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

        public static async Task<bool> UpdateLastSubscriptionID(int MemberID, int LastSubscriptionID)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @" Update Members SET LastSubscriptionID =@LastSubscriptionID 
where MemberID=@MemberID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@MemberID", MemberID);
                        if (LastSubscriptionID == -1)
                            command.Parameters.AddWithValue("@LastSubscriptionID", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@LastSubscriptionID", LastSubscriptionID);




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





    }
}