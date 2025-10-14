 
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

    public class clsMemberSubscriptionsDataAccess
    {

        public static bool GetMemberSubscriptionsInfoByID(int SubscriptionID, ref int PlanID, ref int MemberID,
            ref DateTime StartDate, ref DateTime EndDate, ref bool IsActive, ref byte SubscriptionStatus, ref int CreatedByUserID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From MemberSubscriptions Where SubscriptionID = @SubscriptionID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SubscriptionID", SubscriptionID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;
                                MemberID = (int)reader["MemberID"];
                                PlanID = (int)reader["PlanID"];
                                StartDate = (DateTime)reader["StartDate"];
                                EndDate = (DateTime)reader["EndDate"];
                                IsActive = (bool)reader["IsActive"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                SubscriptionStatus = (byte)reader["SubscriptionStatus"];

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
     
        public static async Task<int> AddNewMemberSubscriptions(int PlanID, int MemberID
          , byte SubscriptionStatus, int CreatedByUserID,bool IsActive)
        {
            int InsertedID = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                   await connection.OpenAsync();


                    using (SqlCommand command = new SqlCommand("SP_AddNewMemberSubscriptions", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MemberID", MemberID);
                        command.Parameters.AddWithValue("@PlanID", PlanID);
                        command.Parameters.AddWithValue("@SubscriptionStatus", SubscriptionStatus);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        command.Parameters.AddWithValue("@IsActive", IsActive);



                        SqlParameter outputIdParam = new SqlParameter("@NewSubscriptionID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(outputIdParam);
                        await command.ExecuteNonQueryAsync();
                        InsertedID = (int)command.Parameters["@NewSubscriptionID"].Value;
                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
            }

            return InsertedID;

        }

        public static async Task<bool> UpdateMemberSubscriptions(int SubscriptionID, int PlanID, int MemberID,
            DateTime StartDate, DateTime EndDate, bool IsActive, byte SubscriptionStatus, int CreatedByUserID)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SP_UpdateMemberSubscriptions", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MemberID", MemberID);
                        command.Parameters.AddWithValue("@SubscriptionID", SubscriptionID);
                        command.Parameters.AddWithValue("@PlanID", PlanID);
                        command.Parameters.AddWithValue("@StartDate", StartDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@SubscriptionStatus", SubscriptionStatus);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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

        public static async Task<DataTable> GetListMemberSubscriptionsByMemberID(int MemberID)
        {
            DataTable dtList = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                   await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SP_GetMemberSubscriptionsByMemberID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MemberID", MemberID);

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

            return dtList;

        }
      
        public static async Task<bool> DeleteMemberSubscriptions(int SubscriptionID)
        {
            int RowsAffected = -1;

            try
            {


                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @" Delete From MemberSubscriptions Where SubscriptionID = @SubscriptionID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SubscriptionID", SubscriptionID);

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
    
        public static async Task<bool> IsMemberSubscriptionsExisteByID(int SubscriptionID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @" Select Found = 1 From MemberSubscriptions Where SubscriptionID = @SubscriptionID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SubscriptionID", SubscriptionID);


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

        public static async Task<bool> ChangeMemberSubscriptionsActive(int SubscriptionID, bool IsActive)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @"
			 Update MemberSubscriptions SET IsActive = @IsActive
                                   WHERE SubscriptionID= @SubscriptionID
Update Members SET IsActive =@IsActive where MemberID=( select MemberSubscriptions.MemberID
from MemberSubscriptions where SubscriptionID =@SubscriptionID)
";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@SubscriptionID", SubscriptionID);
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

        public static async Task<bool> IsMembersHasActiveSubscription(int MemberID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @" 
select Found=1 from MemberSubscriptions where MemberID=@MemberID and IsActive=1";


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




    }
}