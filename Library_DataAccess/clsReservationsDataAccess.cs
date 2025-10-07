 
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

public static bool GetReservationsInfoByID(int ReservationID,ref int MemberID,ref int BookID, ref DateTime ReservationDate,ref byte Status,ref int CreateByUserID)
    {
        bool IsFound  = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From Reservations Where ReservationID = @ReservationID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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

        return IsFound ;
          
    }
     
        
        
        
        
        public static int AddNewReservations(int MemberID,int BookID, DateTime ReservationDate,byte Status,int CreateByUserID)
    {
        int InsertedID  = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO Reservations(MemberID, BookID, ReservationDate, Status, CreateByUserID)
                                   
                                       VALUES (@MemberID, @BookID, @ReservationDate, @Status, @CreateByUserID) 
                
                                SELECT SCOPE_IDENTITY();";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MemberID", MemberID);
                        command.Parameters.AddWithValue("@BookID", BookID);
                        command.Parameters.AddWithValue("@ReservationDate", ReservationDate);
                        command.Parameters.AddWithValue("@Status", Status);
                        command.Parameters.AddWithValue("@CreateByUserID", CreateByUserID);


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
        public static bool UpdateReservations(int ReservationID,int MemberID, int BookID, DateTime ReservationDate, byte Status, int CreateByUserID)
    {
        int RowsAffected  = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @"Update Reservations SET MemberID = @MemberID,BookID = @BookID,ReservationDate = @ReservationDate,Status = @Status,CreateByUserID = @CreateByUserID

                                    WHERE ReservationID= @ReservationID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@ReservationID", ReservationID);
                        command.Parameters.AddWithValue("@MemberID", MemberID);
                        command.Parameters.AddWithValue("@BookID", BookID);
                        command.Parameters.AddWithValue("@ReservationDate", ReservationDate);
                        command.Parameters.AddWithValue("@Status", Status);
                        command.Parameters.AddWithValue("@CreateByUserID", CreateByUserID);


                        RowsAffected = command.ExecuteNonQuery();



                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
            }

            return (RowsAffected != -1 ) ;
          
    }public static DataTable GetListReservations()
    {
        DataTable dtList = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" 

SELECT Reservations.ReservationID, Reservations.ReservationDate, 
             CASE WHEN Reservations.Status = 2 THEN 'Conver To Borrowing' WHEN Reservations.Status = 3 THEN 'Cancelled' 
			 WHEN Reservations.Status = 1 THEN 'Reserved' ELSE 'Cancelled' END AS ReservationsStatus, 
			 Books.Title, Books.ISBN, Books.BookID, Users.UserName, 
             Members.MemberID, Members.LibraryCardNumber, Members.IsActive as IsMemberActive
FROM   Reservations INNER JOIN
             Books ON Reservations.BookID = Books.BookID INNER JOIN
             Users ON Reservations.CreateByUserID = Users.UserID INNER JOIN
             Members ON Reservations.MemberID = Members.MemberID";


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
        public static bool DeleteReservations(int ReservationID)
    {
        int RowsAffected  = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Delete From Reservations Where ReservationID = @ReservationID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ReservationID", ReservationID);


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
        public static bool IsReservationsExisteByBookIDAndMemberID(int BookID,int MemberID)
    {
        bool IsFound  = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" 
			 select top (1) Found=1 from Reservations where Reservations.BookID=@BookID 
and Status=1 and MemberID=@MemberID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookID", BookID);
                        command.Parameters.AddWithValue("@MemberID", MemberID);

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


        public static bool IsThereReservationsForThisBook(int BookID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" 
			 select top (1) Found=1 from Reservations where Reservations.BookID=@BookID
and Status=1 ";


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



        public static bool GetActiveReservationsInfoByBookIDAndMemberID(int MemberID,int BookID,ref int ReservationID,  
            ref DateTime ReservationDate, ref byte Status, ref int CreateByUserID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @"select * from Reservations where BookID=@BookID and MemberID=@MemberID and Status=1";


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