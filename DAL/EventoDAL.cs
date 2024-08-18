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
            string query = @"INSERT INTO Eventos (Username, Fecha, Hora, Modulo, Criticidad) 
                            VALUES (@Username, @Fecha, @Hora, @Modulo, @Criticidad)";

            SqlParameter[] parametersEventos = new SqlParameter[]
            {
                new SqlParameter("@Username", SessionManager.GetUser().Username),
                new SqlParameter("@Fecha", entity.Fecha),
                new SqlParameter("@Hora", entity.Hora),
                new SqlParameter("@Modulo", entity.Modulo),
                new SqlParameter("@Criticidad", entity.Criticidad)
            };

            ConnectionDB.ExecuteNonQuery(query, CommandType.Text, parametersEventos);
        }
    }
}
