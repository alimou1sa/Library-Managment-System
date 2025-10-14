 
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

    public class clsReservationsDataAccess
    {

        public static bool GetReservationsInfoByID(int ReservationID, ref int MemberID, ref int BookID, ref DateTime ReservationDate, ref byte Status, ref int CreateByUserID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetReservationsInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ReservationID", ReservationID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                MemberID = (int)reader["MemberID"];
                                BookID = (int)reader["BookID"];
                                ReservationDate = (DateTime)reader["ReservationDate"];
                                Status = (byte)reader["Status"];
                                CreateByUserID = (int)reader["CreateByUserID"];

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

        public static async Task<int> AddNewReservations(int MemberID, int BookID, DateTime ReservationDate, byte Status, int CreateByUserID)
        {
            int InsertedID = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SP_AddNewReservations", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MemberID", MemberID);
                        command.Parameters.AddWithValue("@BookID", BookID);
                        command.Parameters.AddWithValue("@ReservationDate", ReservationDate);
                        command.Parameters.AddWithValue("@Status", Status);
                        command.Parameters.AddWithValue("@CreateByUserID", CreateByUserID);


                        SqlParameter outputIdParam = new SqlParameter("@NewReservationID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(outputIdParam);
                        await command.ExecuteNonQueryAsync();
                        InsertedID = (int)command.Parameters["@NewReservationID"].Value;

                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
            }

            return InsertedID;

        }
      
        public static async Task<bool> UpdateReservations(int ReservationID,int MemberID, int BookID, DateTime ReservationDate, byte Status, int CreateByUserID)
    {
        int RowsAffected  = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SP_UpdateReservations", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ReservationID", ReservationID);
                        command.Parameters.AddWithValue("@MemberID", MemberID);
                        command.Parameters.AddWithValue("@BookID", BookID);
                        command.Parameters.AddWithValue("@ReservationDate", ReservationDate);
                        command.Parameters.AddWithValue("@Status", Status);
                        command.Parameters.AddWithValue("@CreateByUserID", CreateByUserID);


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
     
        public static async Task< DataTable> GetListReservations()
    {
        DataTable dtList = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                   await connection.OpenAsync();


                    using (SqlCommand command = new SqlCommand("SP_GetListReservations", connection))
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

            return dtList ;
          
    }
      
        public static async Task<bool> DeleteReservations(int ReservationID)
    {
        int RowsAffected  = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                   await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SP_DeleteReservations", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ReservationID", ReservationID);
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
     
        public static async Task<bool> IsReservationsExisteByBookIDAndMemberID(int BookID,int MemberID)
    {
        bool IsFound  = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("SP_IsReservationsExisteByBookIDAndMemberID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BookID", BookID);
                        command.Parameters.AddWithValue("@MemberID", MemberID);

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

        return IsFound ;
          
    }

        public static bool GetReservationsInfoByBookID(int BookID, ref int ReservationID, ref int MemberID,  ref DateTime ReservationDate, ref byte Status, ref int CreateByUserID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" select top(1)* from Reservations where Reservations.BookID=@BookID
and Reservations.Status=1
				 order by ReservationDate asc
";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookID", BookID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                MemberID = (int)reader["MemberID"];
                                ReservationID = (int)reader["ReservationID"];
                                ReservationDate = (DateTime)reader["ReservationDate"];
                                Status = (byte)reader["Status"];
                                CreateByUserID = (int)reader["CreateByUserID"];

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

        public static async Task<bool> IsThereReservationsForThisBook(int BookID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    await connection.OpenAsync();

                    string query = @" 
			 select top (1) Found=1 from Reservations where Reservations.BookID=@BookID
and Status=1 ";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookID", BookID);

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

        public static bool GetActiveReservationsInfoByBookIDAndMemberID(int MemberID,int BookID,ref int ReservationID,  
            ref DateTime ReservationDate, ref byte Status, ref int CreateByUserID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @"select * from Reservations where BookID=@BookID 
and MemberID=@MemberID and Status=1";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookID", BookID);
                        command.Parameters.AddWithValue("@MemberID", MemberID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                ReservationID = (int)reader["ReservationID"];
                                ReservationDate = (DateTime)reader["ReservationDate"];
                                Status = (byte)reader["Status"];
                                CreateByUserID = (int)reader["CreateByUserID"];

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