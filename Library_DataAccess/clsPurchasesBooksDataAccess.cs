 
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

    public class clsPurchasesBooksDataAccess
    {

public static bool GetPurchasesBooksInfoByID(int PurchaseID,ref int BookID,ref int MemberID,ref int CopiesPurchased,
    ref double TotalPrice,ref DateTime PurchaseDate,ref int CreateByUserID)
    {
        bool IsFound  = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From PurchasesBooks Where PurchaseID = @PurchaseID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PurchaseID", PurchaseID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                BookID = (int)reader["BookID"];
                                MemberID = (int)reader["MemberID"];
                                CopiesPurchased = (int)reader["CopiesPurchased"];
                                TotalPrice = Convert.ToDouble(reader["TotalPrice"]);
                                PurchaseDate = (DateTime)reader["PurchaseDate"];
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
        public static int AddNewPurchasesBooks(int BookID,int MemberID,int CopiesPurchased, double TotalPrice,DateTime PurchaseDate,int CreateByUserID)
    {
        int InsertedID  = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO PurchasesBooks(BookID, MemberID, CopiesPurchased, TotalPrice, PurchaseDate, CreateByUserID)
                                   
                                       VALUES (@BookID, @MemberID, @CopiesPurchased, @TotalPrice, @PurchaseDate, @CreateByUserID) 
                
                                SELECT SCOPE_IDENTITY();";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookID", BookID);
                        command.Parameters.AddWithValue("@MemberID", MemberID);
                        command.Parameters.AddWithValue("@CopiesPurchased", CopiesPurchased);
                        command.Parameters.AddWithValue("@TotalPrice", TotalPrice);
                        command.Parameters.AddWithValue("@PurchaseDate", PurchaseDate);
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
        public static bool UpdatePurchasesBooks(int PurchaseID,int BookID, int MemberID, int CopiesPurchased, double TotalPrice, DateTime PurchaseDate, int CreateByUserID)
    {
        int RowsAffected  = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @"Update PurchasesBooks SET BookID = @BookID,MemberID = @MemberID,CopiesPurchased = @CopiesPurchased,TotalPrice = @TotalPrice,PurchaseDate = @PurchaseDate,CreateByUserID = @CreateByUserID

                                    WHERE PurchaseID= @PurchaseID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@PurchaseID", PurchaseID);
                        command.Parameters.AddWithValue("@BookID", BookID);
                        command.Parameters.AddWithValue("@MemberID", MemberID);
                        command.Parameters.AddWithValue("@CopiesPurchased", CopiesPurchased);
                        command.Parameters.AddWithValue("@TotalPrice", TotalPrice);
                        command.Parameters.AddWithValue("@PurchaseDate", PurchaseDate);
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
          
    }
        public static DataTable GetListPurchasesBooks()
    {
        DataTable dtList = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @"

SELECT PurchasesBooks.PurchaseID, PurchasesBooks.BookID, Books.Title, Books.ISBN, Categories.CategoryName, PurchasesBooks.MemberID, People.FirstName + ' ' + People.SecondName + ' ' + ISNULL(People.ThirdName, '') + ' ' + People.LastName AS FullName, 
             Members.LibraryCardNumber, PurchasesBooks.CopiesPurchased, PurchasesBooks.TotalPrice, PurchasesBooks.PurchaseDate, PurchasesBooks.CreateByUserID
FROM   PurchasesBooks INNER JOIN
             Books ON PurchasesBooks.BookID = Books.BookID INNER JOIN
             Members ON PurchasesBooks.MemberID = Members.MemberID INNER JOIN
             People ON Members.PersonID = People.PersonID INNER JOIN
             Categories ON Books.CategoryID = Categories.CategoryID";


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
        public static bool DeletePurchasesBooks(int PurchaseID)
    {
        int RowsAffected  = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Delete From PurchasesBooks Where PurchaseID = @PurchaseID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PurchaseID", PurchaseID);


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
        public static bool IsPurchasesBooksExisteByID(int PurchaseID)
    {
        bool IsFound  = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select Found = 1 From PurchasesBooks Where PurchaseID = @PurchaseID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PurchaseID", PurchaseID);


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
   }
}