 
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

    public class clsLoanesDataAccess
    {

        public static bool GetLoanesInfoByID(int LoanID, ref int CopyID, ref int MemberID, ref int LoanByUserID,

            ref DateTime LoanDate, ref DateTime DueDate, ref DateTime ReturnDate, ref int ReturnByUserID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From Loanes Where LoanID = @LoanID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LoanID", LoanID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                CopyID = (int)reader["CopyID"];
                                MemberID = (int)reader["MemberID"];
                                LoanByUserID = (int)reader["LoanByUserID"];
                                LoanDate = (DateTime)reader["LoanDate"];
                                DueDate = (DateTime)reader["DueDate"];



                                if (reader["ReturnDate"] != DBNull.Value)
                                {
                                    ReturnDate = (DateTime)reader["ReturnDate"];
                                }
                                else
                                {
                                    ReturnDate = DateTime.MinValue;
                                }

                                if (reader["ReturnByUserID"] != DBNull.Value)
                                {
                                    ReturnByUserID = (int)reader["ReturnByUserID"];
                                }
                                else
                                {
                                    ReturnByUserID = -1;
                                }

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





        public static async Task<int> AddNewLoanes(int CopyID, int MemberID, int LoanByUserID, DateTime LoanDate,
            DateTime DueDate, DateTime ReturnDate, int ReturnByUserID)

        {
            int InsertedID = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO Loanes(CopyID, MemberID, LoanByUserID, LoanDate, DueDate, ReturnDate, ReturnByUserID)
                                   
                                       VALUES (@CopyID, @MemberID, @LoanByUserID, @LoanDate, @DueDate, @ReturnDate, @ReturnByUserID) 
                
                                SELECT SCOPE_IDENTITY();";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CopyID", CopyID);
                        command.Parameters.AddWithValue("@MemberID", MemberID);
                        command.Parameters.AddWithValue("@LoanByUserID", LoanByUserID);
                        command.Parameters.AddWithValue("@LoanDate", LoanDate);
                        command.Parameters.AddWithValue("@DueDate", DueDate);

                        if (ReturnDate != DateTime.MinValue)
                            command.Parameters.AddWithValue("@ReturnDate", ReturnDate);
                        else
                            command.Parameters.AddWithValue("@ReturnDate", System.DBNull.Value);

                        if (ReturnByUserID == -1)

                            command.Parameters.AddWithValue("@ReturnByUserID", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ReturnByUserID", ReturnByUserID);


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
        public static async Task<bool> UpdateLoanes(int LoanID, int CopyID, int MemberID, int LoanByUserID,
        DateTime LoanDate, DateTime DueDate, DateTime ReturnDate, int ReturnByUserID)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @"Update Loanes SET CopyID = @CopyID,MemberID = @MemberID,LoanByUserID = @LoanByUserID
              ,LoanDate = @LoanDate,DueDate = @DueDate,ReturnDate = @ReturnDate,ReturnByUserID = @ReturnByUserID

                                    WHERE LoanID= @LoanID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@LoanID", LoanID);
                        command.Parameters.AddWithValue("@CopyID", CopyID);
                        command.Parameters.AddWithValue("@MemberID", MemberID);
                        command.Parameters.AddWithValue("@LoanByUserID", LoanByUserID);
                        command.Parameters.AddWithValue("@LoanDate", LoanDate);
                        command.Parameters.AddWithValue("@DueDate", DueDate);



                        if (ReturnDate != DateTime.MinValue)
                            command.Parameters.AddWithValue("@ReturnDate", ReturnDate);
                        else
                            command.Parameters.AddWithValue("@ReturnDate", System.DBNull.Value);

                        if (ReturnByUserID == -1)

                            command.Parameters.AddWithValue("@ReturnByUserID", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ReturnByUserID", ReturnByUserID);


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
        public static async Task<DataTable> GetListLoanes()
        {
            DataTable dtList = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @"


			 			 SELECT LoanBooks_View_1.LoanID, LoanBooks_View_1.CopyID, LoanBooks_View_1.BookID, LoanBooks_View_1.Title,
			 LoanBooks_View_1.ISBN, LoanBooks_View_1.UserName as LoanByUser, LoanBooks_View_1.IsMemberActive, 
             LoanBooks_View_1.LibraryCardNumber, LoanBooks_View_1.FullName, Users.UserName AS ReturnByUser, LoanBooks_View_1.LoanDate,
			 LoanBooks_View_1.DueDate, LoanBooks_View_1.ReturnDate,
			  CASE WHEN   LoanBooks_View_1.ReturnDate is Null THEN 'NO' 
	 ELSE 'Yes' END AS IsReturn
FROM   LoanBooks_View_1 LEFT OUTER JOIN
             Users ON Users.UserID = LoanBooks_View_1.ReturnByUserID";


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
        public static async Task<bool> DeleteLoanes(int LoanID)
        {
            int RowsAffected = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Delete From Loanes Where LoanID = @LoanID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LoanID", LoanID);


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
        public static async Task<bool> IsLoanesExisteByID(int LoanID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select Found = 1 From Loanes Where LoanID = @LoanID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LoanID", LoanID);


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

        public static async Task<bool> IsLoanesBorrowedeByLoanID(int LoanID)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @"


				 SELECT TOP (1) 1 AS Found,*
FROM   Loanes INNER JOIN
             BookCopies ON Loanes.CopyID = BookCopies.CopyID
			 where LoanID=@LoanID and Loanes.ReturnByUserID is null";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LoanID", LoanID);


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