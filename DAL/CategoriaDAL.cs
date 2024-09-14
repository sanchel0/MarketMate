using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DAL
{
    public class CategoriaDAL : ICrud<CategoriaBE>
    {
        public void Insert(CategoriaBE entity)
        {
            string query = @"INSERT INTO Categorias (Nombre, Descripcion)
                     VALUES (@Nombre, @Descripcion)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Nombre", entity.Nombre),
                new SqlParameter("@Descripcion", entity.Descripcion)
            };

            ConnectionDB.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public void Update(CategoriaBE entity)
        {
            string commandText = @"UPDATE Categorias 
                           SET Nombre = @Nombre, Descripcion = @Descripcion
                           WHERE CodigoCategoria = @Codigo";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Codigo", entity.Codigo),
                new SqlParameter("@Nombre", entity.Nombre),
                new SqlParameter("@Descripcion", entity.Descripcion)
            };

            ConnectionDB.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }

        public void Delete(string id)
        {
            string commandText = "DELETE FROM Categorias WHERE CodigoCategoria = @Codigo";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Codigo", SqlDbType.Int) { Value = id }
            };

            ConnectionDB.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }

        public List<CategoriaBE> GetAll()
        {
            string commandText = "SP_Consultar";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NombreTabla", SqlDbType.NVarChar, 50){Value = "Categorias"}
            };

            List<CategoriaBE> categorias = new List<CategoriaBE>();

            try
            {
                using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.StoredProcedure, parameters))
                {
                    categorias = ConvertToEntity(reader);
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener categorias");
            }

            return categorias;
        }

        public CategoriaBE GetById(string id)
        {
            string commandText = "SP_Consultar";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NombreTabla", SqlDbType.NVarChar, 50){Value = "Categorias"},
                new SqlParameter("@CampoID", SqlDbType.NVarChar, 50) { Value = "CodigoCategoria" },
                new SqlParameter("@ValorID", SqlDbType.NVarChar, 1000) { Value = id }
            };

            SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.StoredProcedure, parameters);
            List<CategoriaBE> categorias = ConvertToEntity(reader);

            return categorias.FirstOrDefault();
        }

        public List<CategoriaBE> ConvertToEntity(SqlDataReader reader)
        {
            List<CategoriaBE> categorias = new List<CategoriaBE>();

            while (reader.Read())
            {
                CategoriaBE categoria = new CategoriaBE(
                            reader["Nombre"].ToString(),
                            reader["Descripcion"].ToString()
                        );
                categoria.Codigo = reader["CodigoCategoria"].ToString();

                categorias.Add(categoria);
            }

            return categorias;
        }
    }
}
