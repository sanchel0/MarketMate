using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace DAL
{
    public class ClienteDAL : ICrud<ClienteBE>
    {
        public void Insert(ClienteBE cliente)
        {
            string query = @"INSERT INTO Clientes (Dni, Nombre, Apellido, Correo, Telefono)
                         VALUES (@Dni, @Nombre, @Apellido, @Correo, @Telefono)";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Dni", cliente.Dni),
            new SqlParameter("@Nombre", cliente.Nombre),
            new SqlParameter("@Apellido", cliente.Apellido),
            new SqlParameter("@Correo", cliente.Correo),
            new SqlParameter("@Telefono", cliente.Telefono)
            };

            ConnectionDB.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public void Update(ClienteBE entity)
        {
            string commandText = "UPDATE Clientes SET Nombre = @Nombre, Apellido = @Apellido, Correo = @Correo, Telefono = @Telefono WHERE Dni = @DNI";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DNI", entity.Dni),
                new SqlParameter("@Nombre", entity.Nombre),
                new SqlParameter("@Apellido", entity.Apellido),
                new SqlParameter("@Correo", entity.Correo),
                new SqlParameter("@Telefono", entity.Telefono)
            };

            ConnectionDB.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }
        
        public void Delete(string pDni)
        {
            string commandText = "UPDATE Clientes SET Act_B = 1 WHERE Dni = @DNI";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DNI", SqlDbType.Char, 8) { Value = pDni }
            };

            ConnectionDB.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }

        public List<ClienteBE> GetAll()
        {
            string commandText = "SP_Consultar";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NombreTabla", SqlDbType.NVarChar, 50){Value = "Clientes"}
            };

            List<ClienteBE> clientes = new List<ClienteBE>();

            using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.StoredProcedure, parameters))
            {
                clientes = ConvertToEntity(reader);
            }

            return clientes;
        }

        public ClienteBE GetById(string pDni)
        {
            string commandText = "SP_Consultar";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NombreTabla", SqlDbType.NVarChar, 50){Value = "Clientes"},
                new SqlParameter("@CampoID", SqlDbType.NVarChar, 50) { Value = "DNI" },
                new SqlParameter("@ValorID", SqlDbType.NVarChar, 1000) { Value = pDni }
            };

            SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.StoredProcedure, parameters);
            List<ClienteBE> clientes = ConvertToEntity(reader);

            return clientes.FirstOrDefault();
        }

        public static bool ExisteDNI(string dni)
        {
            string query = "SELECT COUNT(*) FROM Clientes WHERE Dni = @Dni";
            SqlParameter parametro = new SqlParameter("@Dni", dni);
            int count = Convert.ToInt32(ConnectionDB.ExecuteScalar(query, CommandType.Text, new[] { parametro }));
            return count > 0;
        }

        public List<ClienteBE> ConvertToEntity(SqlDataReader reader)
        {
            List<ClienteBE> clientes = new List<ClienteBE>();

            while (reader.Read())
            {
                ClienteBE cliente = new ClienteBE(
                    reader["Dni"].ToString(),
                    reader["Nombre"].ToString(),
                    reader["Apellido"].ToString(),
                    CryptoManager.Decrypt(reader["Correo"].ToString()),
                    Convert.ToInt32(reader["Telefono"])
                );
                cliente.ActB = Convert.ToBoolean(reader["Act_B"]);

                clientes.Add(cliente);
            }

            return clientes;
        }
    }
}
