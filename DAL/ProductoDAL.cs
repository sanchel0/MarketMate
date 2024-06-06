using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductoDAL : ICrud<ProductoBE>
    {
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<ProductoBE> GetAll()//ObtenerProductosConCategorias
        {
            string commandText = "SP_ObtenerProductosConCategorias";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NombreTabla", SqlDbType.NVarChar, 50){Value = "Usuarios"}
            };

            List<ProductoBE> productos = new List<ProductoBE>();

            try
            {
                using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, parameters))
                {
                    productos = ConvertToEntity(reader);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener usuarios", ex);
            }

            return productos;
        }

        public ProductoBE GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProductoBE entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductoBE entity)
        {
            throw new NotImplementedException();
        }

        public List<ProductoBE> ConvertToEntity(SqlDataReader reader)
        {
            List<ProductoBE> productos = new List<ProductoBE>();

            while (reader.Read())
            {
                ProductoBE producto = new ProductoBE(
                            reader["NombreProducto"].ToString(),
                            Convert.ToInt32(reader["Stock"]),
                            new CategoriaBE(
                                reader["NombreCategoria"].ToString(),
                                reader["DescripcionCategoria"].ToString()
                            ),
                            Convert.ToDecimal(reader["Costo"]),
                            Convert.ToDecimal(reader["Precio"])
                        );
                producto.Codigo = Convert.ToInt32(reader["Codigo"]);

                productos.Add(producto);
            }

            return productos;
        }
    }
}
