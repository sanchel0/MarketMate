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
            throw new NotImplementedException();
        }

        public void Update(CategoriaBE entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<CategoriaBE> GetAll(params IList[] parametros)
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
            throw new NotImplementedException();
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
                categoria.Codigo = Convert.ToInt32(reader["Codigo"]);

                categorias.Add(categoria);
            }

            return categorias;
        }
    }
}
