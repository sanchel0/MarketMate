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
            string query = @"
                    INSERT INTO Productos (Nombre, Stock, CodigoCategoria, CodigoMarca, Costo, Precio)
                    VALUES (@Nombre, @Stock, @CodigoCategoria, @CodigoMarca, @Costo, @Precio)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Nombre", entity.Nombre),
                new SqlParameter("@Stock", entity.Stock),
                new SqlParameter("@CodigoCategoria", entity.Categoria.Codigo),
                new SqlParameter("@CodigoMarca", entity.Marca.Codigo),
                new SqlParameter("@Costo", entity.Costo),
                new SqlParameter("@Precio", entity.Precio)
            };

            ConnectionDB.ExecuteNonQuery(query, CommandType.Text, parameters);
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
            string commandText = "DELETE FROM Productos WHERE Codigo = @Codigo";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Codigo", SqlDbType.Int) { Value = id }
            };

            ConnectionDB.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }

        public List<ProductoBE> GetAll()
        {
            string commandText = @"
                            SELECT p.Codigo, p.Nombre, p.Stock, p.Costo, p.Precio,
                                   p.CodigoCategoria, c.Nombre as NombreCategoria, c.Descripcion as DescripcionCategoria,
                                   p.CodigoMarca, m.Nombre as NombreMarca
                            FROM Productos p
                            INNER JOIN Categorias c ON p.CodigoCategoria = c.Codigo
                            INNER JOIN Marcas m ON p.CodigoMarca = m.Codigo";

            List<ProductoBE> productos = new List<ProductoBE>();

            try
            {
                using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.Text))
                {
                    productos = ConvertToEntity(reader);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener los productos", ex);
            }

            return productos;
        }

        /*public List<ProductoBE> GetAll(params IList[] parametros)
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
        }*/
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
            string commandText = @"
                            SELECT p.Codigo, p.Nombre, p.Stock, p.Costo, p.Precio,
                                   p.CodigoCategoria, c.Nombre as NombreCategoria, c.Descripcion as DescripcionCategoria,
                                   p.CodigoMarca, m.Nombre as NombreMarca
                            FROM Productos p
                            INNER JOIN Categorias c ON p.CodigoCategoria = c.Codigo
                            INNER JOIN Marcas m ON p.CodigoMarca = m.Codigo
                            WHERE p.Codigo = @Codigo;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Codigo", SqlDbType.Int) { Value = id }
            };

            SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.Text, parameters);
            List<ProductoBE> productos = ConvertToEntity(reader);

            return productos.FirstOrDefault();
        }

        public List<ProductoBE> ConvertToEntity(SqlDataReader reader)
        {
            List<ProductoBE> productos = new List<ProductoBE>();

            while (reader.Read())
            {
                CategoriaBE categoria = new CategoriaBE(
                    reader["NombreCategoria"].ToString(),
                    reader["DescripcionCategoria"].ToString()
                );

                categoria.Codigo = reader["CodigoCategoria"].ToString();

                MarcaBE marca = new MarcaBE(
                    reader["NombreMarca"].ToString()
                );
                marca.Codigo = reader["CodigoMarca"].ToString();

                ProductoBE producto = new ProductoBE(
                    reader["Nombre"].ToString(),
                    Convert.ToInt32(reader["Stock"]),
                    categoria,
                    marca,
                    Convert.ToDecimal(reader["Costo"]),
                    Convert.ToDecimal(reader["Precio"])
                );
                producto.Codigo = reader["Codigo"].ToString();

                productos.Add(producto);
            }

            return productos;
        }
    }
}
