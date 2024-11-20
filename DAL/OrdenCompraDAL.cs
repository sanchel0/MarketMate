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
    public class OrdenCompraDAL : IOrdenCompraDAL
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

            //InsertarDetallesOrdenCompra(numeroOrden, ordenCompra.Detalles);
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
                new SqlParameter("@NumeroTransferencia", ordenCompra.NumeroTransferencia),
                new SqlParameter("@NumeroOrden", ordenCompra.NumeroOrden)
            };

            ConnectionDB.ExecuteNonQuery(queryOrden, CommandType.Text, parametersOrden);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCantidadRecibidaDetalle(int numOrden, DetalleOrdenBE detalle)
        {
            string queryOrden = @"
                UPDATE [dbo].[DetallesOrdenCompra]
                SET CantidadRecibida = @CantidadRecibida
                WHERE NumeroOrden = @NumeroOrden AND CodigoProducto = @CodigoProducto";

            SqlParameter[] parametersOrden = new SqlParameter[]
            {
                new SqlParameter("@CantidadRecibida", detalle.CantidadRecibida),
                new SqlParameter("@NumeroOrden", numOrden),
                new SqlParameter("@CodigoProducto", detalle.Producto.Codigo)
            };

            ConnectionDB.ExecuteNonQuery(queryOrden, CommandType.Text, parametersOrden);
        }

        public void InsertarDetallesOrdenCompra(int numeroOrden, List<DetalleOrdenBE> detalles)
        {
            string queryDetalle = @"INSERT INTO DetallesOrdenCompra (NumeroOrden, CodigoProducto, CantidadSolicitada, CantidadRecibida, PrecioUnitario, SubTotal, PorcentajeIVA, TotalConIVA) 
                                    VALUES (@NumeroOrden, @CodigoProducto, @CantidadSolicitada, @CantidadRecibida, @PrecioUnitario, @SubTotal, @PorcentajeIVA, @TotalConIVA)";

            foreach (var detalle in detalles)
            {
                SqlParameter[] parametersDetalle = new SqlParameter[]
                {
                    new SqlParameter("@NumeroOrden", numeroOrden),
                    new SqlParameter("@CodigoProducto", detalle.Producto.Codigo),
                    new SqlParameter("@CantidadSolicitada", detalle.CantidadSolicitada),
                    new SqlParameter("@CantidadRecibida", detalle.CantidadRecibida),
                    new SqlParameter("@PrecioUnitario", detalle.PrecioUnitario),
                    new SqlParameter("@SubTotal", detalle.SubTotal),
                    new SqlParameter("@PorcentajeIVA", detalle.PorcentajeIVA),
                    new SqlParameter("@TotalConIVA", detalle.TotalConIVA)
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
        
        public List<OrdenCompraBE> GetAllPendientes()
        {
            return Get($"o.Estado = 'Pendiente';");
        }

        public OrdenCompraBE GetById(string id)
        {
            List<OrdenCompraBE> ordenes = Get($"o.NumeroOrden = {id};");
            return ordenes.FirstOrDefault();
        }

        private List<OrdenCompraBE> ConvertToEntity(SqlDataReader reader)
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
                    SolicitudCotizacion = solicitudCotizacionDAL.GetById(reader["NumeroSolicitud"].ToString()),
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
                        do.CantidadRecibida,
                        do.PrecioUnitario, 
                        do.SubTotal,
                        do.PorcentajeIVA,
                        do.TotalConIVA
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
                            Convert.ToDecimal(reader["PrecioUnitario"]),
                            Convert.ToDecimal(reader["PorcentajeIVA"])
                        )
                        {
                            CantidadRecibida = Convert.ToInt32(reader["CantidadRecibida"]),
                            SubTotal = Convert.ToDecimal(reader["SubTotal"]),
                            TotalConIVA = Convert.ToDecimal(reader["TotalConIVA"])
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
