using Library_DataAccessLayer;
using Library_Manegment_System;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_DataAccess.Global_classes
{
    public class clsDataAccessHelper
    {
        public static async Task<DataTable> GetListAsync(string StoredProCedures)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProCedures, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                            else
                                dt = null;
                        }

                    }

                }

            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
                dt = null;
            }
            return dt;
        }

        public static async Task<DataTable> GetListAsync<T>(string StoredProCedures,string parameterName, T Value)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProCedures, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue($"@{parameterName}", (object)Value ?? DBNull.Value );
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                            else
                                dt = null;
                        }

                    }

                }

            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
                dt = null;
            }
            return dt;
        }

        public static async Task<DataTable> GetListAsync<T1,T2>(string StoredProCedures, string ParametrName1,
            T1 Value1,string parameterName2,T2 Value2)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProCedures, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue($"@{ParametrName1}", (object)Value1 ?? DBNull.Value);
                        cmd.Parameters.AddWithValue($"@{parameterName2}", (object)Value2 ?? DBNull.Value);
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                                dt.Load(reader);
                            else
                                dt = null;
                        }

                    }

                }

            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
                dt = null;
            }
            return dt;
        }

        public static async Task<bool> DeleteAsync<T>(string StoredProCedures,string parameterName, T Value)
        {
            bool IsRowsAffected = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(StoredProCedures, connection))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        await connection.OpenAsync();
                        cmd.Parameters.AddWithValue($"@{parameterName}", Value);
                        IsRowsAffected = (await cmd.ExecuteNonQueryAsync() > 0);
                    }
                }

            }
            catch (SqlException ex)
            {
                clsErrorEventLog.LogError(ex.Message);
                IsRowsAffected = false;
            }
            return IsRowsAffected;
        }

        public static async Task<bool> IsExistsAsync<T>(string StoredProCedures, string parameterName, T Value)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProCedures, connection))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        await connection.OpenAsync();


                        cmd.Parameters.AddWithValue($"@{parameterName}", Value);

                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };

                        cmd.Parameters.Add(returnParameter);
                        await cmd.ExecuteNonQueryAsync();

                        IsFound = (int)returnParameter.Value == 1;

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

        public static async Task<bool> IsExistsAsync<T1,T2>(string StoredProCedures, string parameterName1, T1 Value1, string parameterName2, T2 Value2)
        {
            bool IsFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProCedures, connection))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        await connection.OpenAsync();


                        cmd.Parameters.AddWithValue($"@{parameterName1}", Value1);
                        cmd.Parameters.AddWithValue($"@{parameterName2}", Value2);

                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };

                        cmd.Parameters.Add(returnParameter);
                        await cmd.ExecuteNonQueryAsync();

                        IsFound = (int)returnParameter.Value == 1;

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
