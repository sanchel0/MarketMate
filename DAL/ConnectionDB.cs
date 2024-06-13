using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConnectionDB
    {
        //private static string connectionString = @"Data Source=090L7PC19-71045;Initial Catalog=DBMarketMate;Integrated Security=True;";
        private static string connectionString = @"Data Source=DESKTOP-185VSTQ\SQLEXPRESS;Initial Catalog=DBMarketMate;Integrated Security=True";
        /*public static SqlConnection AbrirConexion()
        {
            SqlConnection conexion = new SqlConnection(connectionString);
            conexion.Open();
            return conexion;
        }

        public static void CerrarConexion(SqlConnection conexion)
        {
            if (conexion != null && conexion.State != System.Data.ConnectionState.Closed)
            {
                conexion.Close();
            }
        }*/

        /*public static int ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    command.Parameters.AddRange(parameters);
                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }*/

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
                            command.Parameters.AddRange(parameters);
                            int rowsAffected = command.ExecuteNonQuery();
                            transaction.Commit();
                            return rowsAffected;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("Error al ejecutar la consulta en la base de datos.", ex);
                        }
                    }
                }
            }
        }
        
        /*public static SqlDataReader ExecuteReader(string commandText, SqlParameter[] parameters = null)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(commandText, connection);

            command.CommandType = CommandType.StoredProcedure;
            
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);//Cuando se utiliza CommandBehavior.CloseConnection con ExecuteReader, la conexión se cierra automáticamente cuando se cierra el SqlDataReader devuelto.
        }*/
        public static SqlDataReader ExecuteReader(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(commandText, connection);

            command.CommandType = commandType;

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);//Cuando se utiliza CommandBehavior.CloseConnection con ExecuteReader, la conexión se cierra automáticamente cuando se cierra el SqlDataReader devuelto.
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
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("Error al ejecutar la consulta en la base de datos.", ex);
                        }
                    }
                }
            }
        }

        /*public static SqlDataReader ExecuteReader(string commandText, SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(commandText, connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);

            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                command.Transaction = transaction;

                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                // Commit de la transacción si no hay errores
                transaction.Commit();

                return reader;
            }
            catch (Exception ex)
            {
                // Rollback de la transacción en caso de error
                transaction.Rollback();
                throw new Exception("Error al ejecutar la consulta en la base de datos.", ex);
            }
        }*/
    }
}
