using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClienteDAL : ICrud<ClienteBE>
    {
        public void Insert(ClienteBE cliente)
        {
            string query = @"INSERT INTO Clientes (Dni, Nombre, Apellido, Correo, Telefono)
                         VALUES (@Dni, @Nombre, @Apellido, @Correo, @Telefono)";
            CommandType commandType = CommandType.Text;

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Dni", cliente.Dni),
            new SqlParameter("@Nombre", cliente.Nombre),
            new SqlParameter("@Apellido", cliente.Apellido),
            new SqlParameter("@Correo", cliente.Correo),
            new SqlParameter("@Telefono", cliente.Telefono)
            };

            ConnectionDB.ExecuteNonQuery(query, commandType, parameters);
        }

        public void Update(ClienteBE entity)
        {
            throw new NotImplementedException();
        }
        
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<ClienteBE> GetAll(params IList[] parametros)
        {
            throw new NotImplementedException();
        }

        public ClienteBE GetById(string pId)
        {
            string commandText = "SP_Consultar";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NombreTabla", SqlDbType.NVarChar, 50){Value = "Clientes"},
                new SqlParameter("@CampoID", SqlDbType.NVarChar, 50) { Value = "Dni" },
                new SqlParameter("@ValorID", SqlDbType.NVarChar, 1000) { Value = pId }
            };

            SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.StoredProcedure, parameters);
            List<ClienteBE> clientes = ConvertToEntity(reader);

            return clientes.FirstOrDefault();
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
                    reader["Correo"].ToString(),
                    Convert.ToInt32(reader["Telefono"])
                );

                clientes.Add(cliente);
            }

            //reader.Close();
            return clientes;
        }
    }
}
