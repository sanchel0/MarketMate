using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Collections;
using System.Threading;

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
                new SqlParameter("@MetodoPago", (int)ticket.MetodoPago),
                new SqlParameter("@TipoTarjeta", (object)(ticket.TipoTarjeta != null ? (int)ticket.TipoTarjeta : (object)DBNull.Value)),
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

        public List<TicketBE> GetAll(params IList[] parametros)
        {
            throw new NotImplementedException();
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
    }
}
