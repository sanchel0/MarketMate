using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace DAL
{
    public class ConnectionDB
    {
        //internal static string connectionString = @"Data Source=DESKTOP-185VSTQ;Initial Catalog=MarketMateDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        internal static string connectionString = $"Data Source={Environment.MachineName};Initial Catalog=MarketMateDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        //internal static string connectionString = @"Data Source=DESKTOP-185VSTQ;Initial Catalog=MarketMateDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";

        public static void ChangeDatabase(string dbName)
        {
            //connectionString = $@"Data Source=090L7PC06-73534;Initial Catalog={dbName};Integrated Security=True;";
            connectionString = $"Data Source={Environment.MachineName};Initial Catalog={dbName};Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        }

        public static int ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    using (SqlCommand command = new SqlCommand(commandText, connection, transaction))
                    {
                        try
                        {
                            command.CommandType = commandType;
                            if (parameters != null)
                            {
                                command.Parameters.AddRange(parameters);
                            }
                            int rowsAffected = command.ExecuteNonQuery();
                            transaction.Commit();
                            return rowsAffected;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception(ex.Message);
                            //throw new DatabaseException(DatabaseErrorType.ExecuteNonQueryError);
                        }
                    }
                }
            }
        }

        public static SqlDataReader ExecuteReader(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(commandText, connection);

            command.CommandType = commandType;

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            try
            {
                connection.Open();
                return command.ExecuteReader(CommandBehavior.CloseConnection);// Cuando se utiliza CommandBehavior.CloseConnection con ExecuteReader, la conexión se cierra automáticamente cuando se cierra el SqlDataReader devuelto.
            }
            catch (Exception)
            {
                connection.Close();
                throw new DatabaseException(DatabaseErrorType.ExecuteReaderError);
            }
        }
        public static object ExecuteScalar(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    using (SqlCommand command = new SqlCommand(commandText, connection, transaction))
                    {
                        try
                        {
                            command.CommandType = commandType;
                            if (parameters != null)
                            {
                                command.Parameters.AddRange(parameters);
                            }
                            object result = command.ExecuteScalar();
                            transaction.Commit();
                            return result;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw new DatabaseException(DatabaseErrorType.ExecuteScalarError);
                        }
                    }
                }
            }
        }
    }
}
