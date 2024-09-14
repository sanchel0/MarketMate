using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public class MarcaDAL : ICrud<MarcaBE>
    {
        public void Insert(MarcaBE entity)
        {
            string query = @"INSERT INTO Marcas (Nombre) VALUES (@Nombre)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Nombre", entity.Nombre)
            };

            ConnectionDB.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public void Update(MarcaBE entity)
        {
            string commandText = "UPDATE Marcas SET Nombre = @Nombre WHERE CodigoMarca = @Codigo";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Codigo", entity.Codigo),
                new SqlParameter("@Nombre", entity.Nombre)
            };

            ConnectionDB.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }

        public void Delete(string id)
        {
            string commandText = "DELETE FROM Marcas WHERE CodigoMarca = @Codigo";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Codigo", SqlDbType.Int) { Value = id }
            };

            ConnectionDB.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }

        public List<MarcaBE> GetAll()
        {
            string commandText = "SP_Consultar";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NombreTabla", SqlDbType.NVarChar, 50){Value = "Marcas"}
            };

            List<MarcaBE> marcas = new List<MarcaBE>();

            try
            {
                using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.StoredProcedure, parameters))
                {
                    marcas = ConvertToEntity(reader);
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener marcas");
            }

            return marcas;
        }

        public MarcaBE GetById(string id)
        {
            string commandText = "SP_Consultar";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NombreTabla", SqlDbType.NVarChar, 50){Value = "Marcas"},
                new SqlParameter("@CampoID", SqlDbType.NVarChar, 50) { Value = "CodigoMarca" },
                new SqlParameter("@ValorID", SqlDbType.NVarChar, 1000) { Value = id }
            };

            List<MarcaBE> marcas = new List<MarcaBE>();

            try
            {
                using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.StoredProcedure, parameters))
                {
                    marcas = ConvertToEntity(reader);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener la marca", ex);
            }

            return marcas.FirstOrDefault();
        }

        public List<MarcaBE> ConvertToEntity(SqlDataReader reader)
        {
            List<MarcaBE> marcas = new List<MarcaBE>();

            while (reader.Read())
            {
                MarcaBE marca = new MarcaBE(
                            reader["Nombre"].ToString()
                );
                marca.Codigo = reader["CodigoMarca"].ToString();

                marcas.Add(marca);
            }

            return marcas;
        }
    }
}
