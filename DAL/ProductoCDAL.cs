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
    public class ProductoCDAL
    {
        public void Insert(ProductoC entity)
        {
            string query = @"INSERT INTO Productos_C (CodProd, Fecha, Hora, Nombre, Stock, Act) 
                    VALUES (@CodProd, @Fecha, @Hora, @Nombre, @Stock, @Act)";

            SqlParameter[] parametersProductos = new SqlParameter[]
            {
                new SqlParameter("@CodProd", entity.Producto.Codigo),
                new SqlParameter("@Fecha", entity.Fecha.Date),
                new SqlParameter("@Hora", entity.Hora.TimeOfDay),
                new SqlParameter("@Nombre", entity.Nombre),
                new SqlParameter("@Stock", entity.Stock),
                new SqlParameter("@Act", entity.Act),
            };

            ConnectionDB.ExecuteNonQuery(query, CommandType.Text, parametersProductos);
        }

        public void Activate(int cambioID)
        {
            string query = "UPDATE Productos_C SET Act = 1 WHERE CambioID = @CambioID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CambioID", cambioID)
            };

            ConnectionDB.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public List<ProductoC> GetCambiosFiltrados(int? codProd, DateTime? fechaInicio, DateTime? fechaFin, string nombre)
        {
            string commandText = "SP_ConsultarProductosC";

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (codProd.HasValue)
            {
                parameters.Add(new SqlParameter("@CodProd", SqlDbType.Int) { Value = codProd.Value });
            }

            if (fechaInicio.HasValue)
            {
                parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date) { Value = fechaInicio.Value });
            }

            if (fechaFin.HasValue)
            {
                parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date) { Value = fechaFin.Value });
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar, 50) { Value = nombre });
            }

            List<ProductoC> productos = new List<ProductoC>();

            using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.StoredProcedure, parameters.ToArray()))
            {
                productos = ConvertToProductoC(reader);
            }

            return productos;
        }

        public List<ProductoC> ConvertToProductoC(SqlDataReader reader)
        {
            List<ProductoC> productos = new List<ProductoC>();

            while (reader.Read())
            {
                DateTime fecha = Convert.ToDateTime(reader["Fecha"]).Date;
                TimeSpan hora = (TimeSpan)reader["Hora"];
                string nombre = reader["Nombre"].ToString();
                int stock = Convert.ToInt32(reader["Stock"]);
                bool activo = Convert.ToBoolean(reader["Act"]);

                ProductoBE producto = new ProductoDAL().GetById(reader["CodProd"].ToString());

                ProductoC productoC = new ProductoC(fecha, DateTime.Today.Add(hora), nombre, stock, activo, producto);
                productos.Add(productoC);
            }

            return productos;
        }
    }
}
