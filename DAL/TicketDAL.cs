﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Collections;
using System.Threading;
using System.Data.Common;
using Services;

namespace DAL
{
    public class TicketDAL : ITicketDAL
    {
        public void Insert(TicketBE ticket)
        {
            string query = @"INSERT INTO Tickets (NumeroTransaccionBancaria, MetodoPago, TipoTarjeta, NumeroTarjeta, AliasMP, Fecha, Monto, DniCliente)
                             VALUES (@NumeroTransaccionBancaria, @MetodoPago, @TipoTarjeta, @NumeroTarjeta, @AliasMP, @Fecha, @Monto, @DniCliente);
                             SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NumeroTransaccionBancaria", DBNull.Value),
                new SqlParameter("@MetodoPago", DBNull.Value),
                new SqlParameter("@TipoTarjeta", DBNull.Value),
                new SqlParameter("@NumeroTarjeta", DBNull.Value),
                new SqlParameter("@AliasMP", DBNull.Value),
                new SqlParameter("@Fecha", DBNull.Value),
                new SqlParameter("@Monto", ticket.Monto),
                new SqlParameter("@DniCliente", ticket.Cliente.Dni)
            };
            int numTicket = Convert.ToInt32(ConnectionDB.ExecuteScalar(query, CommandType.Text, parameters));
            ticket.NumeroTicket = numTicket;
        }

        public void Update(TicketBE ticket)
        {
            string query = @"UPDATE Tickets
                     SET NumeroTransaccionBancaria = @NumeroTransaccionBancaria,
                         MetodoPago = @MetodoPago,
                         TipoTarjeta = @TipoTarjeta,
                         NumeroTarjeta = @NumeroTarjeta,
                         AliasMP = @AliasMP,
                         Fecha = @Fecha
                     WHERE NumeroTicket = @NumeroTicket";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NumeroTransaccionBancaria", (object)ticket.NumeroTransaccion ?? DBNull.Value),
                new SqlParameter("@MetodoPago", ticket.MetodoPago.ToString()),
                new SqlParameter("@TipoTarjeta", ticket.TipoTarjeta != null ? ticket.TipoTarjeta.ToString() : (object)DBNull.Value),
                new SqlParameter("@NumeroTarjeta", (object)ticket.NumeroTarjeta ?? DBNull.Value),
                new SqlParameter("@AliasMP", string.IsNullOrEmpty(ticket.AliasMP) ? DBNull.Value : (object)ticket.AliasMP),
                new SqlParameter("@Fecha", ticket.Fecha.Date),
                new SqlParameter("@NumeroTicket", ticket.NumeroTicket)
            };

            ConnectionDB.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public void InsertDetallesVenta(TicketBE ticket)
        {
            foreach (var detalle in ticket.Detalles)
            {
                string query = @"INSERT INTO DetallesVenta (NumeroTicket, CodigoProducto, Cantidad, PrecioUnitario, SubTotal)
                         VALUES (@NumeroTicket, @CodigoProducto, @Cantidad, @PrecioUnitario, @SubTotal)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@NumeroTicket", ticket.NumeroTicket),
                    new SqlParameter("@CodigoProducto", detalle.Producto.Codigo),
                    new SqlParameter("@Cantidad", detalle.Cantidad),
                    new SqlParameter("@PrecioUnitario", detalle.PrecioUnitario),
                    new SqlParameter("@SubTotal", detalle.SubTotal)
                };

                ConnectionDB.ExecuteNonQuery(query, CommandType.Text, parameters);
            }
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<TicketBE> GetAll()
        {
            string commandText = @"SELECT
                                    t.NumeroTicket,
                                    t.NumeroTransaccionBancaria,
                                    t.MetodoPago,
                                    t.TipoTarjeta,
                                    t.NumeroTarjeta,
                                    t.AliasMP,
                                    t.Fecha,
                                    t.Monto,
                                    t.DniCliente,
                                    c.Nombre AS NombreCliente,
                                    c.Apellido AS ApellidoCliente,
                                    c.Correo AS CorreoCliente,
                                    c.Telefono AS TelefonoCliente
                                FROM
                                    Tickets t
                                INNER JOIN
                                    Clientes c ON t.DniCliente = c.Dni;";

            List<TicketBE> tickets = new List<TicketBE>();

            try
            {
                using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.Text))
                {
                    tickets = ConvertToEntity(reader);
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener tickets");
            }

            return tickets;
        }

        public TicketBE GetById(string id)
        {
            throw new NotImplementedException();
        }

        public int GetLastTransactionNumber()
        {
            string commandText = "SP_ObtenerUltimoNumeroTransaccionBancaria";
            int num = 0;

            using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.StoredProcedure))
            {
                if (reader.Read())
                {
                    num = reader.IsDBNull(reader.GetOrdinal("NumeroTransaccionBancaria")) ? 0 : reader.GetInt32(reader.GetOrdinal("NumeroTransaccionBancaria"));
                }
            }

            return num;
        }

        public List<TicketBE> ConvertToEntity(SqlDataReader reader)
        {
            List<TicketBE> tickets = new List<TicketBE>();

            while (reader.Read())
            {
                TicketBE ticket = new TicketBE
                {
                    NumeroTicket = Convert.ToInt32(reader["NumeroTicket"]),
                    NumeroTransaccion = reader["NumeroTransaccionBancaria"] as int?,
                    MetodoPago = (MetodoPago)Enum.Parse(typeof(MetodoPago), reader["MetodoPago"].ToString()),
                    TipoTarjeta = reader["TipoTarjeta"] != DBNull.Value ? (TipoTarjeta)Enum.Parse(typeof(TipoTarjeta), reader["TipoTarjeta"].ToString()) : (TipoTarjeta?)null,
                    NumeroTarjeta = reader["NumeroTarjeta"] != DBNull.Value ? (int?)Convert.ToInt32(reader["NumeroTarjeta"]) : null,
                    AliasMP = reader["AliasMP"] as string,
                    Fecha = Convert.ToDateTime(reader["Fecha"]),
                    Monto = Convert.ToDecimal(reader["Monto"]),
                    Cliente = new ClienteBE(
                        reader["DniCliente"] as string,
                        reader["NombreCliente"] as string,
                        reader["ApellidoCliente"] as string,
                        CryptoManager.Decrypt(reader["CorreoCliente"] as string),
                        Convert.ToInt32(reader["TelefonoCliente"])
                    )
                };
                ticket.Detalles = GetDetalleByTicketId( ticket.NumeroTicket );
                tickets.Add(ticket);
            }

            return tickets;
        }

        public List<DetalleVentaBE> GetDetalleByTicketId(int ticketId)
        {
            string commandText = @"
        SELECT dv.NumeroTicket, dv.CodigoProducto, dv.Cantidad, dv.PrecioUnitario, dv.SubTotal,
               p.CodigoProducto, p.Nombre, p.Stock, p.StockMinimo, p.StockMaximo, p.Precio,
               p.CodigoCategoria, c.Nombre as NombreCategoria, c.Descripcion as DescripcionCategoria,
               p.CodigoMarca, m.Nombre as NombreMarca
        FROM DetallesVenta dv
        INNER JOIN Productos p ON dv.CodigoProducto = p.CodigoProducto
        INNER JOIN Categorias c ON p.CodigoCategoria = c.CodigoCategoria
        INNER JOIN Marcas m ON p.CodigoMarca = m.CodigoMarca
        WHERE dv.NumeroTicket = @NumeroTicket;";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@NumeroTicket", SqlDbType.Int) { Value = ticketId }
            };

            SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.Text, parameters);
            List<DetalleVentaBE> detalles = ConvertToDetalles(reader);

            return detalles;
        }

        private List<DetalleVentaBE> ConvertToDetalles(SqlDataReader reader)
        {
            List<DetalleVentaBE> detalles = new List<DetalleVentaBE>();

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
                    Convert.ToInt32(reader["StockMinimo"]),
                    Convert.ToInt32(reader["StockMaximo"]),
                    categoria,
                    marca,
                    Convert.ToDecimal(reader["Precio"])
                )
                {
                    Codigo = (string)reader["CodigoProducto"]
                };
                
                DetalleVentaBE detalle = new DetalleVentaBE
                (
                    producto,
                    Convert.ToInt32(reader["Cantidad"]),
                    Convert.ToDecimal(reader["PrecioUnitario"])
                );
                detalle.SubTotal = Convert.ToDecimal(reader["SubTotal"]);

                detalles.Add(detalle);
            }

            return detalles;
        }
    }
}
