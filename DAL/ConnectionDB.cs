﻿using System;
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
        private static string connectionString = @"Data Source=090L7PC19-71045;Initial Catalog=DBMarketMate;Integrated Security=True;";

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

        public static int ExecuteNonQuery(string commandText, CommandType commandType, SqlParameter[] parameters)
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
        }

        public static SqlDataReader ExecuteReader(string commandText, SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(commandText, connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);//Cuando se utiliza CommandBehavior.CloseConnection con ExecuteReader, la conexión se cierra automáticamente cuando se cierra el SqlDataReader devuelto.
        }

        /*public static SqlDataReader ExecuteReader(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(commandText, connection);

            command.CommandType = commandType;
            command.Parameters.AddRange(parameters);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);//Cuando se utiliza CommandBehavior.CloseConnection con ExecuteReader, la conexión se cierra automáticamente cuando se cierra el SqlDataReader devuelto.
        }*/
    }
}