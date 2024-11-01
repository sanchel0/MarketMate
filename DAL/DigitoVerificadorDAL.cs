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
        public List<DigitoVerificadorBE> calculatedDVs;
        string[] tableNames;
        public DigitoVerificadorDAL()
        {
            calculatedDVs = new List<DigitoVerificadorBE>();
            tableNames = new string[1] { "Categorias" };
        }
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
        

        public void Update(string tableName)
        {
            DigitoVerificadorBE dv = GenerateTableDV(tableName);

            string commandText = "UPDATE DigitosVerificadores SET DVH = @DVH, DVV = @DVV WHERE Tabla = @TableName";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DVH", dv.DVH),
                new SqlParameter("@DVV", dv.DVV),
                new SqlParameter("@TableName", dv.TableName)
            };

            ConnectionDB.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }

        public void Update(DigitoVerificadorBE dv)
        {
            //DigitoVerificadorBE dv = GenerateTableDV(tableName);

            string commandText = "UPDATE DigitosVerificadores SET DVH = @DVH, DVV = @DVV WHERE Tabla = @TableName";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DVH", dv.DVH),
                new SqlParameter("@DVV", dv.DVV),
                new SqlParameter("@TableName", dv.TableName)
            };

            ConnectionDB.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }

        public void RecalculateAllDVs()
        {
            string commandDelete = "DELETE FROM DigitosVerificadores";

            ConnectionDB.ExecuteNonQuery(commandDelete, CommandType.Text, null);

            string commandText = "INSERT INTO DigitosVerificadores(Tabla, DVH, DVV) VALUES (@TableName, @DVH, @DVV)";

            foreach (var tableName in tableNames)
            {
                DigitoVerificadorBE dv = GenerateTableDV(tableName);

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TableName", tableName),
                    new SqlParameter("@DVH", dv.DVH),
                    new SqlParameter("@DVV", dv.DVV),
                };

                ConnectionDB.ExecuteNonQuery(commandText, CommandType.Text, parameters);
            }
        }

        public bool CompareDV()
        {
            //DigitoVerificadorBE calculatedDV = GenerateTotalTablesDVs();
            DigitoVerificadorBE calculatedDV = GenerateTotalTablesDVs();

            string query = "SELECT DVH, DVV FROM DigitosVerificadores";
            StringBuilder dbDVHs = new StringBuilder();
            StringBuilder dbDVVs = new StringBuilder();

            using (var reader = ConnectionDB.ExecuteReader(query, CommandType.Text))
            {
                if (!reader.HasRows) return false;

                while (reader.Read())
                {
                    dbDVHs.Append(reader["DVH"].ToString());
                    dbDVVs.Append(reader["DVV"].ToString());
                }
            }

            DigitoVerificadorBE storedDV = new DigitoVerificadorBE(
                string.Empty, 
                CryptoManager.Hash(dbDVHs.ToString()),
                CryptoManager.Hash(dbDVVs.ToString())
            );

            return storedDV.DVH == calculatedDV.DVH && storedDV.DVV == calculatedDV.DVV;
        }

        private DigitoVerificadorBE GenerateTableDV(string tableName)
        {
            StringBuilder DVH = new StringBuilder();
            StringBuilder DVV = new StringBuilder();

            CalculateDV(tableName, DVH, DVV);//Devuelve el DVH y DVV de una sola tabla

            return new DigitoVerificadorBE(
                            tableName, 
                            CryptoManager.Hash(DVH.ToString()),
                            CryptoManager.Hash(DVV.ToString())
             );
        }

        private DigitoVerificadorBE GenerateTotalTablesDVs()
        {
            StringBuilder totalDVHs = new StringBuilder();
            StringBuilder totalDVVs = new StringBuilder();

            foreach (string tableName in tableNames)
            {
                StringBuilder tableDVHs = new StringBuilder();
                StringBuilder tableDVVs = new StringBuilder();
                CalculateDV(tableName, tableDVHs, tableDVVs);
                DigitoVerificadorBE dv = new DigitoVerificadorBE(tableName, CryptoManager.Hash(tableDVHs.ToString()), CryptoManager.Hash(tableDVVs.ToString()));
                calculatedDVs.Add(dv);
                /*totalDVHs.Append(CryptoManager.Hash(tableDVHs.ToString()));
                totalDVVs.Append(CryptoManager.Hash(tableDVVs.ToString()));*/
                totalDVHs.Append(dv.DVH);
                totalDVVs.Append(dv.DVV);
            }

            return new DigitoVerificadorBE(
                string.Empty,
                CryptoManager.Hash(totalDVHs.ToString()),
                CryptoManager.Hash(totalDVVs.ToString())
            );
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
    }
}
