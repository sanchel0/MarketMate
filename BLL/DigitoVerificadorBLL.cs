using BE;
using DAL;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DigitoVerificadorBLL
    {
        DigitoVerificadorDAL _dal;
        private List<DigitoVerificadorBE> _calculatedDVs;
        private string adminUsername;

        public DigitoVerificadorBLL()
        {
            _dal = new DigitoVerificadorDAL();
            _calculatedDVs = new List<DigitoVerificadorBE>();
            adminUsername = string.Empty;
        }

        public void Update(string tableName)
        {
            DigitoVerificadorBE dv = GenerateTableDV(tableName);
            _dal.Update(dv);
        }

        public void RecalculateAllDVs()
        {
            var recalculatedDVs = new List<DigitoVerificadorBE>();

            foreach (string tableName in _dal.GetTableNames())
            {
                DigitoVerificadorBE dv = GenerateTableDV(tableName);
                recalculatedDVs.Add(dv);
            }

            _dal.DeleteAllDVs(); // Limpiar registros actuales
            foreach (var dv in recalculatedDVs)
            {
                _dal.Insert(dv); // Insertar los nuevos cálculos
            }
        }

        public void RecalculateDVs()
        {
            foreach (DigitoVerificadorBE dv in _calculatedDVs)
            {
                _dal.Update(dv);
            }
            EventoBLL.Insert(new Evento(new UsuarioBE(adminUsername), Modulo.DigitoVerificador, Operacion.RecalcularDVs));
        }

        public void VerifyDV(string username)
        {
            if (!CompareDV())
            {
                UsuarioBLL userBLL = new UsuarioBLL();
                if (userBLL.IsAdmin(username))
                {
                    adminUsername = username;
                    throw new DVException(DVErrorType.Admin);
                }
                throw new DVException(DVErrorType.NoAdmin);
            }
        }

        public bool CompareDV()
        {
            DigitoVerificadorBE calculatedDV = GenerateTotalTablesDVs();
            DigitoVerificadorBE storedDV = _dal.GetStoredDV();
            storedDV.DVH = CryptoManager.Hash(storedDV.DVH);
            storedDV.DVV = CryptoManager.Hash(storedDV.DVV);

            return storedDV.DVH == calculatedDV.DVH && storedDV.DVV == calculatedDV.DVV;
        }
        /*public bool VerifyDV()
        {
            DigitoVerificadorBE calculatedDV = GenerateTotalTablesDVs();
            DigitoVerificadorBE storedDV = _dal.GetStoredDV();

            return storedDV.DVH == calculatedDV.DVH && storedDV.DVV == calculatedDV.DVV;
        }*/

        private DigitoVerificadorBE GenerateTableDV(string tableName)
        {
            var (dvhData, dvvData) = CalculateDV(tableName);
            return new DigitoVerificadorBE(
                tableName,
                CryptoManager.Hash(dvhData),
                CryptoManager.Hash(dvvData)
            );
        }

        private DigitoVerificadorBE GenerateTotalTablesDVs()
        {
            var totalDVHs = new StringBuilder();
            var totalDVVs = new StringBuilder();
            _calculatedDVs.Clear();

            foreach (string tableName in _dal.GetTableNames())
            {
                var (tableDVHs, tableDVVs) = CalculateDV(tableName);
                var tableDV = new DigitoVerificadorBE(
                    tableName,
                    CryptoManager.Hash(tableDVHs),
                    CryptoManager.Hash(tableDVVs)
                );

                _calculatedDVs.Add(tableDV);
                totalDVHs.Append(tableDV.DVH);
                totalDVVs.Append(tableDV.DVV);
            }

            return new DigitoVerificadorBE(
                string.Empty,
                CryptoManager.Hash(totalDVHs.ToString()),
                CryptoManager.Hash(totalDVVs.ToString())
            );
        }

        private (string dvhData, string dvvData) CalculateDV(string tableName)
        {
            var data = _dal.GetTableData(tableName);

            var dvhBuilder = new StringBuilder();
            var dvvColumns = new Dictionary<int, StringBuilder>();

            foreach (var row in data)
            {
                var rowConcat = string.Concat(row);
                dvhBuilder.Append(rowConcat);

                for (int i = 0; i < row.Length; i++)
                {
                    if (!dvvColumns.ContainsKey(i))
                    {
                        dvvColumns[i] = new StringBuilder();
                    }
                    dvvColumns[i].Append(row[i]);
                }
            }

            var dvvBuilder = new StringBuilder();
            foreach (var columnData in dvvColumns.Values)
            {
                dvvBuilder.Append(columnData);
            }

            return (dvhBuilder.ToString(), dvvBuilder.ToString());
        }
        /*public static void Update(string tableName)
        {
            new DigitoVerificadorDAL().Update(tableName);
        }

        public void RecalculateDVs(List<DigitoVerificadorBE> list)
        {
            foreach (DigitoVerificadorBE dv in list)
            {
                dal.Update(dv);
            }
            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.DigitoVerificador, Operacion.RecalcularDVs));
        }

        public void RecalculateAllDVs()
        {
            dal.RecalculateAllDVs();
        }

        public void VerifyDV(string username)
        {
            if (!dal.CompareDV())
            {
                UsuarioBLL userBLL = new UsuarioBLL();
                if (userBLL.IsAdmin(username))
                    throw new DVException(DVErrorType.Admin);
                throw new DVException(DVErrorType.NoAdmin);
            }
        }

        public List<DigitoVerificadorBE> GetCalculatedDVs()
        {
            return dal.calculatedDVs;
        }*/
    }
}
