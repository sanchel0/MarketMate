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
    public class EventoDAL
    {
        public void Insert(Evento entity)
        {
            string query = @"INSERT INTO Eventos (Username, Fecha, Hora, Modulo, Operacion, Criticidad) 
                            VALUES (@Username, @Fecha, @Hora, @Modulo, @Operacion, @Criticidad)";

            SqlParameter[] parametersEventos = new SqlParameter[]
            {
                new SqlParameter("@Username", SessionManager.GetUser().Username),
                new SqlParameter("@Fecha", entity.Fecha),
                new SqlParameter("@Hora", entity.Hora.ToString(@"hh\:mm\:ss")),
                new SqlParameter("@Modulo", entity.Modulo.ToString()),
                new SqlParameter("@Operacion", entity.Operacion.ToString()),
                new SqlParameter("@Criticidad", entity.Criticidad)
            };

            ConnectionDB.ExecuteNonQuery(query, CommandType.Text, parametersEventos);
        }

        public List<Evento> GetEventosFiltrados(string username, DateTime? fechaInicio, DateTime? fechaFin, string modulo, string operacion, int? criticidad)
        {
            string commandText = "SP_ConsultarEventos";

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(username))
            {
                parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar, 50) { Value = username });
            }

            if (fechaInicio.HasValue)
            {
                parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date) { Value = fechaInicio.Value });
            }

            if (fechaFin.HasValue)
            {
                parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date) { Value = fechaFin.Value });
            }

            if (!string.IsNullOrEmpty(modulo))
            {
                parameters.Add(new SqlParameter("@Modulo", SqlDbType.NVarChar, 50) { Value = modulo });
            }

            if (!string.IsNullOrEmpty(operacion))
            {
                parameters.Add(new SqlParameter("@Operacion", SqlDbType.NVarChar, 100) { Value = operacion });
            }

            if (criticidad.HasValue)
            {
                parameters.Add(new SqlParameter("@Criticidad", SqlDbType.Int) { Value = criticidad.Value });
            }

            List<Evento> eventos = new List<Evento>();

            using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.StoredProcedure, parameters.ToArray()))
            {
                eventos = ConvertToEventoEntity(reader);
            }

            return eventos;
        }

        public List<Evento> ConvertToEventoEntity(SqlDataReader reader)
        {
            List<Evento> eventos = new List<Evento>();

            while (reader.Read())
            {
                string username = reader["Username"].ToString();
                UsuarioDAL usuarioDAL = new UsuarioDAL();
                Modulo modulo = (Modulo)Enum.Parse(typeof(Modulo), reader["Modulo"].ToString());
                Operacion operacion = (Operacion)Enum.Parse(typeof(Operacion), reader["Operacion"].ToString());

                Evento evento = new Evento
                (
                    usuarioDAL.GetByUsername(username),
                    modulo,
                    operacion
                );
                evento.Fecha = Convert.ToDateTime(reader["Fecha"]).Date;
                TimeSpan hora = (TimeSpan)reader["Hora"];
                evento.Hora = DateTime.Today.Add(hora);
                evento.Criticidad = Convert.ToInt32(reader["Criticidad"]);
                eventos.Add(evento);
            }

            return eventos;
        }
    }
}
