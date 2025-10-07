 
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

    public class clsPaymentTypesDataAccess
    {

public static bool GetPaymentTypesInfoByID(int PaymentTypeID,ref string TypeName,ref string Description)
    {
        bool IsFound  = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From PaymentTypes Where PaymentTypeID = @PaymentTypeID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentTypeID", PaymentTypeID);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                TypeName = (string)(reader["TypeName"] == System.DBNull.Value ? "" : reader["TypeName"]);
                                Description = (string)(reader["Description"] == System.DBNull.Value ? "" : reader["Description"]);

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
        public static async Task<int> AddNewPaymentTypes(string TypeName,string Description)
    {
        int InsertedID  = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO PaymentTypes(TypeName, Description)
                                   
                                       VALUES (@TypeName, @Description) 
                
                                SELECT SCOPE_IDENTITY();";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TypeName", TypeName);

                        if (string.IsNullOrEmpty(Description))
                        {
                            command.Parameters.AddWithValue("@Description", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Description", Description);

                        }

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
        public static async Task<bool> UpdatePaymentTypes(int PaymentTypeID,string TypeName, string Description)
    {
        int RowsAffected  = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @"Update PaymentTypes SET TypeName = @TypeName,Description = @Description

                                    WHERE PaymentTypeID= @PaymentTypeID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@PaymentTypeID", PaymentTypeID);
                        command.Parameters.AddWithValue("@TypeName", TypeName);

                        if (string.IsNullOrEmpty(Description))
                        {
                            command.Parameters.AddWithValue("@Description", System.DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Description", Description);

                        }

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
        public static async Task<DataTable> GetListPaymentTypes()
    {
        DataTable dtList = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From PaymentTypes";


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
        public static async Task<bool> DeletePaymentTypes(int PaymentTypeID)
    {
        int RowsAffected  = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Delete From PaymentTypes Where PaymentTypeID = @PaymentTypeID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentTypeID", PaymentTypeID);


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
        public static async Task<bool> IsPaymentTypesExisteByID(int PaymentTypeID)
    {
        bool IsFound  = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select Found = 1 From PaymentTypes Where PaymentTypeID = @PaymentTypeID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PaymentTypeID", PaymentTypeID);


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


        public static bool GetPaymentTypesInfoByTypeName(string TypeName,ref  int PaymentTypeID, ref string Description)
        {
            bool IsFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    connection.Open();

                    string query = @" Select * From PaymentTypes Where TypeName = @TypeName";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TypeName", TypeName);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                PaymentTypeID = (int)reader["PaymentTypeID"];
                                Description = (string)(reader["Description"] == System.DBNull.Value ? "" : reader["Description"]);

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