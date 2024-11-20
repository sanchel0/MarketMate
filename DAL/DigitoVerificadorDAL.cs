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
        public string[] GetTableNames()
        {
            return new string[] { "Categorias", "Clientes", "DetallesOrdenCompra", "DetallesRecepcion", "DetallesSolicitud", "DetallesVenta", "OrdenesCompra", "Productos", "Proveedores", "ProveedoresSolicitudes", "Recepciones", "SolicitudesCotizacion", "Tickets" }; // O generar dinámicamente
        }

        public List<string[]> GetTableData(string tableName)
        {
            string query = $"SELECT * FROM {tableName}";
            var tableData = new List<string[]>();

            using (var reader = ConnectionDB.ExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    var row = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader[i].ToString();
                    }
                    tableData.Add(row);
                }
            }

            return tableData;
        }

        public void Insert(DigitoVerificadorBE dv)
        {
            string commandText = "INSERT INTO DigitosVerificadores(Tabla, DVH, DVV) VALUES (@TableName, @DVH, @DVV)";
            SqlParameter[] parameters = {
            new SqlParameter("@TableName", dv.TableName),
            new SqlParameter("@DVH", dv.DVH),
            new SqlParameter("@DVV", dv.DVV)
        };

            ConnectionDB.ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }

        public void Update(DigitoVerificadorBE dv)
        {
            string commandText = "UPDATE DigitosVerificadores SET DVH = @DVH, DVV = @DVV WHERE Tabla = @TableName";
            SqlParameter[] parameters = {
            new SqlParameter("@TableName", dv.TableName),
            new SqlParameter("@DVH", dv.DVH),
            new SqlParameter("@DVV", dv.DVV)
        };

            int rowsAffected = ConnectionDB.ExecuteNonQuery(commandText, CommandType.Text, parameters);
            if (rowsAffected == 0)
            {
                Insert(dv);
            }
        }

        public void DeleteAllDVs()
        {
            string commandText = "DELETE FROM DigitosVerificadores";
            ConnectionDB.ExecuteNonQuery(commandText, CommandType.Text, null);
        }

        public DigitoVerificadorBE GetStoredDV()
        {
            string query = "SELECT DVH, DVV FROM DigitosVerificadores";
            var dvhBuilder = new StringBuilder();
            var dvvBuilder = new StringBuilder();

            using (var reader = ConnectionDB.ExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    dvhBuilder.Append(reader["DVH"].ToString());
                    dvvBuilder.Append(reader["DVV"].ToString());
                }
            }

            return new DigitoVerificadorBE(string.Empty, dvhBuilder.ToString(), dvvBuilder.ToString());
        }
        /*public List<DigitoVerificadorBE> calculatedDVs;
        string[] tableNames;
        public DigitoVerificadorDAL()
        {
            calculatedDVs = new List<DigitoVerificadorBE>();
            tableNames = new string[1] { "Categorias" };
        }
        
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
        }*/
    }
}
