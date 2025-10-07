 
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

    public class clsPaymentsDataAccess
    {

        public static bool GetPaymentsInfoByID(int PaymentID, ref int PaymentTypeID, ref int MemberID, ref double Amount, ref byte PaymentStatus, ref int CreateByUserID, ref DateTime PaymentDate)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From Payments Where PaymentID = @PaymentID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                PaymentTypeID = (int)reader["PaymentTypeID"];
                                MemberID = (int)reader["MemberID"];
                                Amount = Convert.ToDouble(reader["Amount"]);
                                PaymentStatus = (byte)reader["PaymentStatus"];
                                CreateByUserID = (int)reader["CreateByUserID"];
                                PaymentDate = (DateTime)reader["PaymentDate"];

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
        public static async Task<int> AddNewPayments(int PaymentTypeID, int MemberID, double Amount, byte PaymentStatus, int CreateByUserID, DateTime PaymentDate)
        {
            int InsertedID = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO Payments(PaymentTypeID, MemberID, Amount, PaymentStatus, CreateByUserID, PaymentDate)
                                   
                                       VALUES (@PaymentTypeID, @MemberID, @Amount, @PaymentStatus, @CreateByUserID, @PaymentDate) 
                
                                SELECT SCOPE_IDENTITY();";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentTypeID", PaymentTypeID);
                        command.Parameters.AddWithValue("@MemberID", MemberID);
                        command.Parameters.AddWithValue("@Amount", Amount);
                        command.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
                        command.Parameters.AddWithValue("@CreateByUserID", CreateByUserID);
                        command.Parameters.AddWithValue("@PaymentDate", PaymentDate);


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

            return InsertedID;

        }
        public static async Task<bool> UpdatePayments(int PaymentID, int PaymentTypeID, int MemberID, double Amount, byte PaymentStatus, int CreateByUserID, DateTime PaymentDate)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @"Update Payments SET PaymentTypeID = @PaymentTypeID,MemberID = @MemberID,Amount = @Amount,PaymentStatus = @PaymentStatus,CreateByUserID = @CreateByUserID,PaymentDate = @PaymentDate

                                    WHERE PaymentID= @PaymentID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@PaymentID", PaymentID);
                        command.Parameters.AddWithValue("@PaymentTypeID", PaymentTypeID);
                        command.Parameters.AddWithValue("@MemberID", MemberID);
                        command.Parameters.AddWithValue("@Amount", Amount);
                        command.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
                        command.Parameters.AddWithValue("@CreateByUserID", CreateByUserID);
                        command.Parameters.AddWithValue("@PaymentDate", PaymentDate);


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
        public static async Task<DataTable> GetListPayments()
        {
            DataTable dtList = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @"
SELECT PaymentDetails.PaymentDetailID,Payments.PaymentID, PaymentTypes.TypeName, People.FirstName+' '+ People.SecondName+' '+ People.ThirdName+' '+
People.LastName as FullName, Members.LibraryCardNumber, Payments.Amount, 
CASE WHEN Payments.PaymentStatus = 1 THEN 'Pending'
WHEN Payments.PaymentStatus = 2 THEN 'Paid'
WHEN Payments.PaymentStatus = 3 THEN 'Refunded'
WHEN Payments.PaymentStatus = 4 THEN 'Cancelled'
 ELSE 'Pending' END AS PaymentStatus, Users.UserName, Payments.PaymentDate, 
             PaymentEntities.EntityName, PaymentDetails.EntityID
FROM   PaymentDetails INNER JOIN
             Payments ON PaymentDetails.PaymentID = Payments.PaymentID INNER JOIN
             PaymentEntities ON PaymentDetails.EntityTypeID = PaymentEntities.EntityTypeID INNER JOIN
             PaymentTypes ON Payments.PaymentTypeID = PaymentTypes.PaymentTypeID INNER JOIN
             Members ON Payments.MemberID = Members.MemberID INNER JOIN
             People ON Members.PersonID = People.PersonID INNER JOIN
             Users ON Payments.CreateByUserID = Users.UserID AND People.PersonID = Users.PersonID";


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

            return dtList;

        }
        public static async Task<bool> DeletePayments(int PaymentID)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Delete From Payments Where PaymentID = @PaymentID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);


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
        public static async Task<bool> IsPaymentsExisteByID(int PaymentID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select Found = 1 From Payments Where PaymentID = @PaymentID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);


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