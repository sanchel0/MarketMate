using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MarcaDAL : ICrud<MarcaBE>
    {
        public void Insert(MarcaBE entity)
        {
            throw new NotImplementedException();
        }

        public void Update(MarcaBE entity)
        {
            throw new NotImplementedException();
        }
        
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<MarcaBE> GetAll(params IList[] parametros)
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
            throw new NotImplementedException();
        }

        public List<MarcaBE> ConvertToEntity(SqlDataReader reader)
        {
            List<MarcaBE> marcas = new List<MarcaBE>();

            while (reader.Read())
            {
                MarcaBE marca = new MarcaBE(
                            reader["Nombre"].ToString()
                        );
                marca.Codigo = Convert.ToInt32(reader["Codigo"]);

                marcas.Add(marca);
            }

            return marcas;
        }
    }
}
