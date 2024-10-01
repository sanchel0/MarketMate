using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BackupRestoreDAL
    {
        private string _databaseName;

        public BackupRestoreDAL()
        {
            _databaseName = "MarketMateDB";
        }

        public void Backup(string path)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                throw new DirectoryNotFoundException("El directorio especificado no existe.");
            }

            string backupFileName = $"BCK_{DateTime.Now:ddMMyy_HHmm}.bak";
            string fullPath = Path.Combine(path, backupFileName);

            string query = $"BACKUP DATABASE [{_databaseName}] TO DISK = '{fullPath}' WITH FORMAT, MEDIANAME = 'DbBackup', NAME = 'Full Backup of {_databaseName}'";

            ExecuteNonQuery(query);
        }

        /*public void Restore(string path)
        {
            // Verifica si el archivo de respaldo existe
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("El archivo de respaldo especificado no existe.");
            }
            ConnectionDB.ChangeDBToMaster();
            ExecuteNonQuery("ALTER DATABASE");
            // Prepara el comando de restauración
            string query = $"USE master; RESTORE DATABASE [{_databaseName}] FROM DISK = '{path}' WITH REPLACE";

            // Ejecuta el comando
            ExecuteNonQuery(query);
        }*/
        public void Restore(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("El archivo de respaldo especificado no existe.");
            }

            ConnectionDB.ChangeDatabase("master");

            ExecuteNonQuery($"ALTER DATABASE [{_databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");

            try
            {
                string query = $"RESTORE DATABASE [{_databaseName}] FROM DISK = '{path}' WITH REPLACE";
                ExecuteNonQuery(query);
            }
            finally
            {
                // Volver a modo multiusuario
                ExecuteNonQuery($"ALTER DATABASE [{_databaseName}] SET MULTI_USER");
                ConnectionDB.ChangeDatabase(_databaseName);
            }
        }


        private void ExecuteNonQuery(string commandText)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionDB.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error al ejecutar el comando SQL: {ex.Message}", ex);
                    }
                }
            }
        }
    }
}
