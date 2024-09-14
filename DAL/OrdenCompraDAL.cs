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
    public class OrdenCompraDAL
    {
        public void Insert(OrdenCompraBE ordenCompra)
        {
            string queryOrden = @"  INSERT INTO OrdenesCompra (FechaEmision, FechaLimiteEntrega, CUIT, NumeroSolicitud, NumeroCotizacion, Estado, Total, NumeroTransferencia) 
                                    VALUES (@FechaEmision, @FechaLimiteEntrega, @CUIT, @NumeroSolicitud, @NumeroCotizacion, @Estado, @Total, @NumeroTransferencia);
                                    SELECT SCOPE_IDENTITY();";

            SqlParameter[] parametersOrden = new SqlParameter[]
            {
                new SqlParameter("@FechaEmision", ordenCompra.FechaEmision),
                new SqlParameter("@FechaLimiteEntrega", ordenCompra.FechaLimiteEntrega),
                new SqlParameter("@CUIT", ordenCompra.Proveedor.CUIT),
                new SqlParameter("@NumeroSolicitud", ordenCompra.SolicitudCotizacion.NumeroSolicitud),
                new SqlParameter("@NumeroCotizacion", ordenCompra.NumeroCotizacion),
                new SqlParameter("@Estado", ordenCompra.Estado),
                new SqlParameter("@Total", ordenCompra.Total),
                new SqlParameter("@NumeroTransferencia", DBNull.Value)
            };

            int numeroOrden = Convert.ToInt32(ConnectionDB.ExecuteScalar(queryOrden, CommandType.Text, parametersOrden));
            ordenCompra.NumeroOrden = numeroOrden;

            InsertarDetallesOrdenCompra(numeroOrden, ordenCompra.Detalles);
        }

        public void Update(OrdenCompraBE ordenCompra)
        {
            string queryOrden = @"UPDATE OrdenesCompra
                          SET FechaEmision = @FechaEmision,
                              FechaLimiteEntrega = @FechaLimiteEntrega,
                              CUIT = @CUIT,
                              NumeroSolicitud = @NumeroSolicitud,
                              NumeroCotizacion = @NumeroCotizacion,
                              Estado = @Estado,
                              Total = @Total,
                              NumeroTransferencia = @NumeroTransferencia
                          WHERE NumeroOrden = @NumeroOrden";

            SqlParameter[] parametersOrden = new SqlParameter[]
            {
                new SqlParameter("@FechaEmision", ordenCompra.FechaEmision),
                new SqlParameter("@FechaLimiteEntrega", ordenCompra.FechaLimiteEntrega),
                new SqlParameter("@CUIT", ordenCompra.Proveedor.CUIT),
                new SqlParameter("@NumeroSolicitud", ordenCompra.SolicitudCotizacion.NumeroSolicitud),
                new SqlParameter("@NumeroCotizacion", ordenCompra.NumeroCotizacion),
                new SqlParameter("@Estado", ordenCompra.Estado),//Esta si se modificaría
                new SqlParameter("@Total", ordenCompra.Total),
                new SqlParameter("@NumeroTransferencia", ordenCompra.NumeroTransferencia),//Este si es importante
                new SqlParameter("@NumeroOrden", ordenCompra.NumeroOrden)
            };

            ConnectionDB.ExecuteNonQuery(queryOrden, CommandType.Text, parametersOrden);
        }

        private void InsertarDetallesOrdenCompra(int numeroOrden, List<DetalleOrdenBE> detalles)
        {
            string queryDetalle = @"INSERT INTO DetallesOrdenCompra (NumeroOrden, CodigoProducto, CantidadSolicitada, PrecioUnitario, SubTotal) 
                                    VALUES (@NumeroOrden, @CodigoProducto, @CantidadSolicitada, @PrecioUnitario, @SubTotal)";

            foreach (var detalle in detalles)
            {
                SqlParameter[] parametersDetalle = new SqlParameter[]
                {
                    new SqlParameter("@NumeroOrden", numeroOrden),
                    new SqlParameter("@CodigoProducto", detalle.Producto.Codigo),
                    new SqlParameter("@CantidadSolicitada", detalle.CantidadSolicitada),
                    new SqlParameter("@PrecioUnitario", detalle.PrecioUnitario),
                    new SqlParameter("@SubTotal", detalle.SubTotal)
                };

                ConnectionDB.ExecuteNonQuery(queryDetalle, CommandType.Text, parametersDetalle);
            }
        }

        private List<OrdenCompraBE> Get(string whereClause = "")
        {
            string commandText = @"
                    SELECT o.NumeroOrden, o.FechaEmision, o.FechaLimiteEntrega, o.CUIT, 
                           o.NumeroSolicitud, o.NumeroCotizacion, o.Estado, o.Total, 
                           o.NumeroTransferencia
                    FROM OrdenesCompra o";

            if (!string.IsNullOrEmpty(whereClause))
            {
                commandText += " WHERE " + whereClause;
            }

            List<OrdenCompraBE> ordenes = new List<OrdenCompraBE>();

            try
            {
                using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.Text))
                {
                    ordenes = ConvertToEntity(reader);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener las órdenes de compra", ex);
            }

            return ordenes;
        }

        public List<OrdenCompraBE> GetAll()
        {
            return Get();
        }

        public OrdenCompraBE GetById(int id)
        {
            List<OrdenCompraBE> ordenes = Get($"o.NumeroOrden = {id};");
            return ordenes.FirstOrDefault();
        }

        public List<OrdenCompraBE> ConvertToEntity(SqlDataReader reader)
        {
            List<OrdenCompraBE> ordenes = new List<OrdenCompraBE>();

            ProveedorDAL proveedorDAL = new ProveedorDAL();
            SolicitudCotizacionDAL solicitudCotizacionDAL = new SolicitudCotizacionDAL();

            while (reader.Read())
            {
                OrdenCompraBE orden = new OrdenCompraBE
                {
                    NumeroOrden = Convert.ToInt32(reader["NumeroOrden"]),
                    FechaEmision = Convert.ToDateTime(reader["FechaEmision"]),
                    FechaLimiteEntrega = Convert.ToDateTime(reader["FechaLimiteEntrega"]),
                    Proveedor = proveedorDAL.GetById(reader["CUIT"].ToString()),
                    SolicitudCotizacion = solicitudCotizacionDAL.GetById(Convert.ToInt32(reader["NumeroSolicitud"])),
                    NumeroCotizacion = Convert.ToInt32(reader["NumeroCotizacion"]),
                    Estado = reader["Estado"].ToString(),
                    Total = Convert.ToDecimal(reader["Total"]),
                    NumeroTransferencia = Convert.ToInt32(reader["NumeroTransferencia"]),
                    Detalles = GetDetallesOrden(Convert.ToInt32(reader["NumeroOrden"]))
                };

                ordenes.Add(orden);
            }

            return ordenes;
        }

        private List<DetalleOrdenBE> GetDetallesOrden(int numeroOrden)
        {
            string query = @"
                    SELECT 
                        do.CodigoProducto, 
                        do.CantidadSolicitada, 
                        do.PrecioUnitario, 
                        do.SubTotal
                    FROM 
                        DetallesOrdenCompra do
                    WHERE 
                        do.NumeroOrden = @NumeroOrden";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NumeroOrden", numeroOrden)
            };

            List<DetalleOrdenBE> detalles = new List<DetalleOrdenBE>();

            try
            {
                using (SqlDataReader reader = ConnectionDB.ExecuteReader(query, CommandType.Text, parameters))
                {
                    ProductoDAL productoDAL = new ProductoDAL();
                    while (reader.Read())
                    {
                        DetalleOrdenBE detalle = new DetalleOrdenBE(
                            productoDAL.GetById(reader["CodigoProducto"].ToString()),
                            Convert.ToInt32(reader["CantidadSolicitada"]),
                            Convert.ToDecimal(reader["PrecioUnitario"])
                        )
                        {
                            SubTotal = Convert.ToDecimal(reader["SubTotal"])
                        };
                        detalles.Add(detalle);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los detalles de la orden de compra.", ex);
            }

            return detalles;
        }
    }
}
