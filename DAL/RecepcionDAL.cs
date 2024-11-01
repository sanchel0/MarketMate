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
    public class RecepcionDAL
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
            InsertarDetallesRecepcion(numeroRecepcion, recepcion.Detalles);
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

        private void InsertarDetallesRecepcion(int numeroRecepcion, List<DetalleRecepcionBE> detalles)
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

        public RecepcionBE GetById(int id)
        {
            List<RecepcionBE> recepciones = Get($"r.NumeroRecepcion = {id};");
            return recepciones.FirstOrDefault();
        }

        public List<RecepcionBE> ConvertToEntity(SqlDataReader reader)
        {
            List<RecepcionBE> recepciones = new List<RecepcionBE>();

            OrdenCompraDAL ordenCompraDAL = new OrdenCompraDAL();

            while (reader.Read())
            {
                int numR = Convert.ToInt32(reader["NumeroRecepcion"]);
                RecepcionBE recepcion = new RecepcionBE
                (
                    ordenCompraDAL.GetById(Convert.ToInt32(reader["NumeroOrden"])),
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
