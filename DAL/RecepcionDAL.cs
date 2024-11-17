using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DAL
{
    public class RecepcionDAL : IRecepcionDAL
    {
        public void Insert(RecepcionBE recepcion)
        {
            string queryRecepcion = @"
            INSERT INTO Recepciones (NumeroOrden, FechaRecepcion, NumeroFactura, MontoFactura, FechaFactura) 
            VALUES (@NumeroOrden, @FechaRecepcion, @NumeroFactura, @MontoFactura, @FechaFactura);
            SELECT SCOPE_IDENTITY();";

            SqlParameter[] parametersRecepcion = new SqlParameter[]
            {
            new SqlParameter("@NumeroOrden", recepcion.Orden.NumeroOrden),
            new SqlParameter("@FechaRecepcion", recepcion.FechaRecepcion),
            new SqlParameter("@NumeroFactura", recepcion.NumeroFactura),
            new SqlParameter("@MontoFactura", recepcion.MontoFactura),
            new SqlParameter("@FechaFactura", recepcion.FechaFactura)
            };

            int numeroRecepcion = Convert.ToInt32(ConnectionDB.ExecuteScalar(queryRecepcion, CommandType.Text, parametersRecepcion));
            //InsertarDetallesRecepcion(numeroRecepcion, recepcion.Detalles);
        }

        public void Update(RecepcionBE recepcion)
        {
            string queryRecepcion = @"
            UPDATE Recepciones
            SET NumeroOrden = @NumeroOrden,
                FechaRecepcion = @FechaRecepcion,
                NumeroFactura = @NumeroFactura,
                MontoFactura = @MontoFactura,
                FechaFactura = @FechaFactura
            WHERE NumeroRecepcion = @NumeroRecepcion";

            SqlParameter[] parametersRecepcion = new SqlParameter[]
            {
            new SqlParameter("@NumeroOrden", recepcion.Orden.NumeroOrden),
            new SqlParameter("@FechaRecepcion", recepcion.FechaRecepcion),
            new SqlParameter("@NumeroFactura", recepcion.NumeroFactura),
            new SqlParameter("@MontoFactura", recepcion.MontoFactura),
            new SqlParameter("@FechaFactura", recepcion.FechaFactura),
            new SqlParameter("@NumeroRecepcion", recepcion.NumeroRecepcion)
            };

            ConnectionDB.ExecuteNonQuery(queryRecepcion, CommandType.Text, parametersRecepcion);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void InsertarDetallesRecepcion(int numeroRecepcion, List<DetalleRecepcionBE> detalles)
        {
            string queryDetalle = @"
            INSERT INTO DetallesRecepcion (NumeroRecepcion, CodigoProducto, CantidadRecibida) 
            VALUES (@NumeroRecepcion, @CodigoProducto, @CantidadRecibida)";

            foreach (var detalle in detalles)
            {
                SqlParameter[] parametersDetalle = new SqlParameter[]
                {
                new SqlParameter("@NumeroRecepcion", numeroRecepcion),
                new SqlParameter("@CodigoProducto", detalle.Producto.Codigo),
                new SqlParameter("@CantidadRecibida", detalle.CantidadRecibida)
                };

                ConnectionDB.ExecuteNonQuery(queryDetalle, CommandType.Text, parametersDetalle);
            }
        }

        public List<RecepcionBE> GetRecepcionesPorOrden(int numeroOrden)
        {
            List<RecepcionBE> recepciones = new List<RecepcionBE>();

            string query = @"
                            SELECT r.NumeroRecepcion, r.FechaRecepcion, r.NumeroFactura, 
                                   r.MontoFactura, r.FechaFactura, 
                                   p.CodigoProducto, p.Nombre, d.CantidadRecibida
                            FROM Recepciones r
                            INNER JOIN DetallesRecepcion d ON r.NumeroRecepcion = d.NumeroRecepcion
                            INNER JOIN Productos p ON d.CodigoProducto = p.CodigoProducto
                            WHERE r.NumeroOrden = @NumeroOrden";
            SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@NumeroOrden", numeroOrden)
                };

            try
            {
                using (SqlDataReader reader = ConnectionDB.ExecuteReader(query, CommandType.Text, parameter))
                {
                    recepciones = ConvertToEntity(reader);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener las recepciones", ex);
            }

            return recepciones;
        }

        private List<RecepcionBE> Get(string whereClause = "")
        {
            string commandText = @"
            SELECT r.NumeroRecepcion, r.NumeroOrden, r.FechaRecepcion, r.EstadoRecepcion, 
                   r.NumeroFactura, r.MontoFactura, r.FechaFactura
            FROM Recepciones r";

            if (!string.IsNullOrEmpty(whereClause))
            {
                commandText += " WHERE " + whereClause;
            }

            List<RecepcionBE> recepciones = new List<RecepcionBE>();

            try
            {
                using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.Text))
                {
                    recepciones = ConvertToEntity(reader);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener las recepciones", ex);
            }

            return recepciones;
        }

        public List<RecepcionBE> GetAll()
        {
            return Get();
        }

        public RecepcionBE GetById(string id)
        {
            List<RecepcionBE> recepciones = Get($"r.NumeroRecepcion = {id};");
            return recepciones.FirstOrDefault();
        }

        private List<RecepcionBE> ConvertToEntity(SqlDataReader reader)
        {
            List<RecepcionBE> recepciones = new List<RecepcionBE>();

            OrdenCompraDAL ordenCompraDAL = new OrdenCompraDAL();

            while (reader.Read())
            {
                int numR = Convert.ToInt32(reader["NumeroRecepcion"]);
                RecepcionBE recepcion = new RecepcionBE
                (
                    ordenCompraDAL.GetById(reader["NumeroOrden"].ToString()),
                    Convert.ToDateTime(reader["FechaRecepcion"]),
                    Convert.ToInt32(reader["NumeroFactura"]),
                    Convert.ToDecimal(reader["MontoFactura"]),
                    Convert.ToDateTime(reader["FechaFactura"])
                )
                {
                    NumeroRecepcion = numR,
                    Detalles = GetDetallesRecepcion(numR)
                };

                recepciones.Add(recepcion);
            }

            return recepciones;
        }

        private List<DetalleRecepcionBE> GetDetallesRecepcion(int numeroRecepcion)
        {
            string query = @"
                            SELECT 
                                dr.CodigoProducto, 
                                dr.CantidadRecibida
                            FROM 
                                DetallesRecepcion dr
                            WHERE 
                                dr.NumeroRecepcion = @NumeroRecepcion";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NumeroRecepcion", numeroRecepcion)
            };

            List<DetalleRecepcionBE> detalles = new List<DetalleRecepcionBE>();

            try
            {
                using (SqlDataReader reader = ConnectionDB.ExecuteReader(query, CommandType.Text, parameters))
                {
                    ProductoDAL productoDAL = new ProductoDAL();
                    while (reader.Read())
                    {
                        ProductoBE producto = productoDAL.GetById(reader["CodigoProducto"].ToString());

                        DetalleRecepcionBE detalle = new DetalleRecepcionBE(
                            Convert.ToInt32(reader["CantidadRecibida"]),
                            producto
                        );

                        detalles.Add(detalle);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los detalles de la recepción.", ex);
            }

            return detalles;
        }
    }
}
