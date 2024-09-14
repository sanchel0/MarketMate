using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace DAL
{
    public class SolicitudCotizacionDAL
    {
        public void Insert(SolicitudCotizacionBE solicitud)
        {
            string query = @"INSERT INTO SolicitudesCotizacion (FechaSolicitud) 
                     VALUES (@FechaSolicitud);
                     SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FechaSolicitud", solicitud.FechaSolicitud)
            };

            int numeroSolicitud = Convert.ToInt32(ConnectionDB.ExecuteScalar(query, CommandType.Text, parameters));
            solicitud.NumeroSolicitud = numeroSolicitud;

            InsertarDetallesSolicitud(numeroSolicitud, solicitud.Detalles);

            InsertarProveedoresSolicitud(numeroSolicitud, solicitud.Proveedores);
        }

        private void InsertarDetallesSolicitud(int numeroSolicitud, List<DetalleSolicitudBE> detalles)
        {
            string query = @"INSERT INTO DetallesSolicitud (NumeroSolicitud, CodigoProducto, Cantidad) 
                     VALUES (@NumeroSolicitud, @CodigoProducto, @Cantidad)";

            foreach (var detalle in detalles)
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@NumeroSolicitud", numeroSolicitud),
                    new SqlParameter("@CodigoProducto", detalle.Producto.Codigo),
                    new SqlParameter("@Cantidad", detalle.Cantidad)
                };

                ConnectionDB.ExecuteNonQuery(query, CommandType.Text, parameters);
            }
        }

        private void InsertarProveedoresSolicitud(int numeroSolicitud, List<ProveedorBE> proveedores)
        {
            string query = @"INSERT INTO ProveedoresSolicitudes (NumeroSolicitud, CUIT) 
                     VALUES (@NumeroSolicitud, @CUIT)";

            foreach (var proveedor in proveedores)
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@NumeroSolicitud", numeroSolicitud),
                    new SqlParameter("@CUIT", proveedor.CUIT)
                };

                ConnectionDB.ExecuteNonQuery(query, CommandType.Text, parameters);
            }
        }

        private List<SolicitudCotizacionBE> Get(string whereClause = "")
        {
            string commandText = @"SELECT 
                              s.NumeroSolicitud, 
                              s.FechaSolicitud 
                           FROM 
                              SolicitudesCotizacion s";

            if (!string.IsNullOrEmpty(whereClause))
            {
                commandText += " WHERE " + whereClause;
            }

            List<SolicitudCotizacionBE> solicitudes = new List<SolicitudCotizacionBE>();

            try
            {
                using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.Text))
                {
                    solicitudes = ConvertToEntity(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las solicitudes de cotización.", ex);
            }

            return solicitudes;
        }

        public List<SolicitudCotizacionBE> GetAll()
        {
            return Get();
        }

        public SolicitudCotizacionBE GetById(int id)
        {
            List<SolicitudCotizacionBE> solicitudes = Get($"s.NumeroSolicitud = {id}");

            return solicitudes.FirstOrDefault();
        }

        public List<int> GetAllIds()
        {
            string commandText = @"SELECT NumeroSolicitud FROM SolicitudesCotizacion;";

            List<int> solicitudIds = new List<int>();

            try
            {
                using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.Text))
                {
                    while (reader.Read())
                    {
                        solicitudIds.Add(Convert.ToInt32(reader["NumeroSolicitud"]));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener los IDs de las solicitudes de cotización.", ex);
            }

            return solicitudIds;
        }

        public List<SolicitudCotizacionBE> ConvertToEntity(SqlDataReader reader)
        {
            List<SolicitudCotizacionBE> solicitudes = new List<SolicitudCotizacionBE>();

            while (reader.Read())
            {
                ProveedorDAL proveedorDAL = new ProveedorDAL();
                int num = Convert.ToInt32(reader["NumeroSolicitud"]);
                SolicitudCotizacionBE solicitud = new SolicitudCotizacionBE
                {
                    NumeroSolicitud = num,
                    FechaSolicitud = Convert.ToDateTime(reader["FechaSolicitud"]),
                    Detalles = GetDetallesSolicitud(num),
                    Proveedores = GetProveedores(num)
                };
                solicitudes.Add(solicitud);
            }

            return solicitudes;
        }

        private List<DetalleSolicitudBE> GetDetallesSolicitud(int numeroSolicitud)
        {
            string query = @"
                            SELECT 
                                ds.CodigoProducto,
                                ds.Cantidad,
                            FROM 
                                DetallesSolicitud ds
                            WHERE 
                                ds.NumeroSolicitud = @NumeroSolicitud";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NumeroSolicitud", numeroSolicitud)
            };

            List<DetalleSolicitudBE> detalles = new List<DetalleSolicitudBE>();

            try
            {
                using (SqlDataReader reader = ConnectionDB.ExecuteReader(query, CommandType.Text, parameters))
                {
                    ProductoDAL productoDAL = new ProductoDAL();
                    while (reader.Read())
                    {
                        DetalleSolicitudBE detalle = new DetalleSolicitudBE
                        {
                            Producto = productoDAL.GetById((string)reader["CodigoProducto"]),
                            Cantidad = Convert.ToInt32(reader["Cantidad"])
                        };
                        detalles.Add(detalle);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los detalles de la solicitud.", ex);
            }

            return detalles;
        }

        private List<ProveedorBE> GetProveedores(int numeroSolicitud)
        {
            string query = @"
                            SELECT 
                                ps.CUIT
                            FROM 
                                ProveedoresSolicitudes  ps
                            WHERE 
                                ps.NumeroSolicitud = @NumeroSolicitud";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NumeroSolicitud", numeroSolicitud)
            };

            List<ProveedorBE> proveedores = new List<ProveedorBE>();

            try
            {
                using (SqlDataReader reader = ConnectionDB.ExecuteReader(query, CommandType.Text, parameters))
                {
                    ProveedorDAL proveedorDAL = new ProveedorDAL();
                    while (reader.Read())
                    {
                        ProveedorBE proveedor = proveedorDAL.GetById((string)reader["CUIT"]);
                        proveedores.Add(proveedor);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los proveedores de la solicitud.", ex);
            }

            return proveedores;
        }

    }
}
