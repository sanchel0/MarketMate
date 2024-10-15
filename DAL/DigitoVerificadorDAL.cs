using BE;
using Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DigitoVerificadorDAL
    {
        /*public void Insert(DigitoVerificadorBE entity)
        {
            string query = @"INSERT INTO DV (DVH, DVV) VALUES (@DVH, @DVV)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DVH", entity.DVH),
                new SqlParameter("@DVV", entity.DVV)
            };

            ConnectionDB.ExecuteNonQuery(query, CommandType.Text, parameters);
        }*/

        public void Update()
        {
            DigitoVerificadorBE dv = GenerateDV();

            string commandText = "UPDATE DigitoVerificador SET DVH = @DVH, DVV = @DVV WHERE DigitoVerificadorID = 'X'";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DVH", dv.DVH),
                new SqlParameter("@DVV", dv.DVV)
            };

            ConnectionDB.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }

        public bool CompareDV()
        {
            DigitoVerificadorBE dv = GenerateDV();

            string query = "SELECT * FROM DigitoVerificador";
            DigitoVerificadorBE dvBD = new DigitoVerificadorBE(null, null);
            using (SqlDataReader reader = ConnectionDB.ExecuteReader(query, CommandType.Text))
            {
                if (!reader.HasRows)
                    return false;

                while (reader.Read())
                {
                    dvBD.DVH = reader["DVH"].ToString();
                    dvBD.DVV = reader["DVV"].ToString();
                }
            }
            return (dvBD.DVH == dv.DVH && dvBD.DVV == dv.DVV);
        }

        private DigitoVerificadorBE GenerateDV()
        {
            StringBuilder DVHs = new StringBuilder();
            StringBuilder DVVs = new StringBuilder();

            string[] tableNames = new string[2] { "Eventos", "Marcas" };//16 tablas transaccionales

            foreach (string tableName in tableNames)
            {
                CalculateDV(tableName, DVHs, DVVs);
            }

            //string h = "";
            DigitoVerificadorBE dv = new DigitoVerificadorBE(
                            CryptoManager.Hash(DVHs.ToString()),
                            CryptoManager.Hash(DVVs.ToString())
             );

            return dv;
        }

        private void CalculateDV(string tableName, StringBuilder DVHs, StringBuilder DVVs)
        {
            string query = $"SELECT * FROM {tableName}";

            using (SqlDataReader reader = ConnectionDB.ExecuteReader(query, CommandType.Text))
            {
                Dictionary<int, StringBuilder> columnSums = new Dictionary<int, StringBuilder>();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    columnSums[i] = new StringBuilder();
                }

                while (reader.Read())
                {
                    StringBuilder concatenatedRowValues = new StringBuilder();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (reader.GetValue(i) != DBNull.Value)
                        {
                            concatenatedRowValues.Append(reader.GetValue(i).ToString());
                            columnSums[i].Append(reader.GetValue(i).ToString());
                        }
                    }
                    DVHs.Append(concatenatedRowValues);
                }

                foreach (var sum in columnSums.Values)
                {
                    DVVs.Append(sum.ToString());
                }
            }
        }
        /*public decimal Calcular(Dictionary<int, List<decimal>> dict)
        {
            decimal sum = 0;
            foreach (var values in dict.Values)
            {
                foreach (var value in values)
                {
                    sum = sum + value;
                }
            }
            return sum;
        }

        public string Calcular(List<decimal> list)
        {
            decimal sum = 0;
            foreach (var num in list)
            {
                sum = sum + num;
            }
            return CryptoManager.Hash(sum.ToString());
        }

        public string GenerarDV<T>(T entity)
        {
            return null;
        }*/
    }
}
