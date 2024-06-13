using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;

namespace DAL
{
    public class ProductoDAL : ICrud<ProductoBE>
    {
        public void Insert(ProductoBE entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductoBE producto)
        {
            string query = @"UPDATE Productos 
                     SET Nombre = @Nombre, 
                         Stock = @Stock, 
                         CodigoCategoria = @CodigoCategoria, 
                         Costo = @Costo, 
                         Precio = @Precio, 
                         CodigoMarca = @CodigoMarca
                     WHERE Codigo = @Codigo";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Nombre", producto.Nombre),
                new SqlParameter("@Stock", producto.Stock),
                new SqlParameter("@CodigoCategoria", producto.Categoria.Codigo),
                new SqlParameter("@Costo", producto.Costo),
                new SqlParameter("@Precio", producto.Precio),
                new SqlParameter("@CodigoMarca", producto.Marca.Codigo),
                new SqlParameter("@Codigo", producto.Codigo)
            };

            ConnectionDB.ExecuteNonQuery(query, CommandType.Text, parameters);
        }
        
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<ProductoBE> GetAll(params IList[] parametros)
        {
            List<CategoriaBE> categorias = parametros.OfType<List<CategoriaBE>>().FirstOrDefault();
            List<MarcaBE> marcas = parametros.OfType<List<MarcaBE>>().FirstOrDefault();

            string commandText = "SP_Consultar";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NombreTabla", SqlDbType.NVarChar, 50){Value = "Productos"}
            };

            List<ProductoBE> productos = new List<ProductoBE>();

            try
            {
                using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.StoredProcedure, parameters))
                {
                    productos = ConvertToEntity(reader, categorias, marcas);
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener categorias");
            }

            return productos;
        }
        /**public List<ProductoBE> GetAll()//ObtenerProductosConCategorias
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
        }*/

        public ProductoBE GetById(string id)
        {
            throw new NotImplementedException();
        }

        public List<ProductoBE> ConvertToEntity(SqlDataReader reader, List<CategoriaBE> categorias, List<MarcaBE> marcas)
        {
            if (reader == null || categorias == null || marcas == null)
            {
                throw new ArgumentNullException();
            }
            List<ProductoBE> productos = new List<ProductoBE>();

            while (reader.Read())
            {
                ProductoBE producto = new ProductoBE(
                            reader["Nombre"].ToString(),
                            Convert.ToInt32(reader["Stock"]),
                            categorias.FirstOrDefault(c => c.Codigo == (int)reader["CodigoCategoria"]),
                            marcas.FirstOrDefault(m => m.Codigo == (int)reader["CodigoMarca"]),
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
