using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class TicketDAL : ITicketDAL
    {
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<TicketBE> GetAll()
        {
            throw new NotImplementedException();
        }

        public TicketBE GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(TicketBE entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TicketBE entity)
        {
            throw new NotImplementedException();
        }

        public int GetLastTransactionNumber()
        {
            string commandText = "SP_ObtenerUltimoNumeroTransaccionBancaria";
            int num = 0;
            
            using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText))
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
