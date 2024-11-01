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
    public class ProductoDAL : IProductoDAL
    {
        public void Insert(ProductoBE entity)
        {
            string query = @"
                INSERT INTO Productos (Nombre, Stock, StockMinimo, StockMaximo, CodigoCategoria, Marca, Precio, PorcentajeIVA)
                VALUES (@Nombre, @Stock, @StockMinimo, @StockMaximo, @CodigoCategoria, @Marca, @Precio, @PorcentajeIVA)";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Nombre", entity.Nombre),
            new SqlParameter("@Stock", entity.Stock),
            new SqlParameter("@StockMinimo", entity.StockMinimo),
            new SqlParameter("@StockMaximo", entity.StockMaximo),
            new SqlParameter("@CodigoCategoria", entity.Categoria.Codigo),
            new SqlParameter("@Marca", entity.Marca),
            new SqlParameter("@Precio", entity.Precio),
            new SqlParameter("@PorcentajeIVA", entity.PorcentajeIVA)
            };

            ConnectionDB.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public void Update(ProductoBE entity)
        {
            string query = @"
                 UPDATE Productos 
                 SET Nombre = @Nombre, 
                     Stock = @Stock,
                     StockMinimo = @StockMinimo,
                     StockMaximo = @StockMaximo,
                     CodigoCategoria = @CodigoCategoria, 
                     Marca = @Marca,
                     Precio = @Precio,
                    PorcentajeIVA = @PorcentajeIVA
                 WHERE CodigoProducto = @CodigoProducto";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Nombre", entity.Nombre),
            new SqlParameter("@Stock", entity.Stock),
            new SqlParameter("@StockMinimo", entity.StockMinimo),
            new SqlParameter("@StockMaximo", entity.StockMaximo),
            new SqlParameter("@CodigoCategoria", entity.Categoria.Codigo),
            new SqlParameter("@Marca", entity.Marca),
            new SqlParameter("@Precio", entity.Precio),
            new SqlParameter("@PorcentajeIVA", entity.Precio),
            new SqlParameter("@CodigoProducto", entity.Codigo)
            };

            ConnectionDB.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public void Delete(string id)
        {
            string commandText = @"
                UPDATE Productos 
                SET Act_B = 1 
                WHERE CodigoProducto = @CodigoProducto";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@CodigoProducto", SqlDbType.Int) { Value = id }
            };

            ConnectionDB.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }

        public List<ProductoBE> GetProductosConStockMinimo()
        {
            return Get("p.Stock >= p.StockMinimo AND p.Act_B = 0");
        }

        public List<ProductoBE> GetAll()
        {
            return Get();
        }

        public List<ProductoBE> GetProductosActivos()
        {
            return Get("p.Act_B = 0");
        }

        public List<ProductoBE> Get(string whereClause = "")
        {
            string commandText = @"
                        SELECT p.CodigoProducto, p.Nombre, p.Stock, p.StockMinimo, p.StockMaximo, p.Precio, p.PorcentajeIVA,
                               p.CodigoCategoria, c.Nombre as NombreCategoria, c.Descripcion as DescripcionCategoria,
                               p.Marca
                        FROM Productos p
                        INNER JOIN Categorias c ON p.CodigoCategoria = c.CodigoCategoria";

            if (!string.IsNullOrEmpty(whereClause))
            {
                commandText += " WHERE " + whereClause;
            }

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
            List<ProductoBE> productos = Get($"p.CodigoProducto = {int.Parse(id)};");

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

                ProductoBE producto = new ProductoBE(
                    reader["Nombre"].ToString(),
                    Convert.ToInt32(reader["Stock"]),
                    Convert.ToInt32(reader["StockMinimo"]),
                    Convert.ToInt32(reader["StockMaximo"]),
                    categoria,
                    reader["Marca"].ToString(),
                    Convert.ToDecimal(reader["Precio"]),
                    Convert.ToDecimal(reader["PorcentajeIVA"])
                )
                {
                    Codigo = reader["CodigoProducto"].ToString()
                };
                //La sintaxis que ves dentro de las llaves {} es conocida como inicialización de propiedades en C#. Esta forma de inicializar propiedades es útil cuando deseas asignar valores a las propiedades de un objeto después de su creación, sin necesidad de usar un constructor específico para eso.
                //producto.Codigo = reader["Codigo"].ToString();
                productos.Add(producto);
            }

            return productos;
        }
    }
}
