using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BackupRestoreBLL
    {
        private BackupRestoreDAL backupRestoreDAL;

        public BackupRestoreBLL()
        {
            backupRestoreDAL = new BackupRestoreDAL();
        }

        public void Backup(string path)
        {
            backupRestoreDAL.Backup(path);
        }

        public void Restore(string path)
        {
            backupRestoreDAL.Restore(path);
        }
    }
}
