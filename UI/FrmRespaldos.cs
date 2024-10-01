using BE;
using BLL;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmRespaldos : Form
    {
        BackupRestoreBLL backupRestoreBLL;
        public FrmRespaldos()
        {
            InitializeComponent();
            backupRestoreBLL = new BackupRestoreBLL();
        }

        private void FrmRespaldos_Load(object sender, EventArgs e)
        {

        }

        private void picBackup_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Seleccionar la carpeta";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = folderBrowserDialog.SelectedPath;
                    txtBackupPath.Text = folderPath;
                }
            }
        }

        private void picRestore_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Backup Files (*.bak)|*.bak|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    if (!filePath.EndsWith(".bak", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("El archivo debe tener la extensión .bak", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    txtRestorePath.Text = filePath;
                }
            }
        }

        private void btnAplicarB_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBackupPath.Text != string.Empty)
                {
                    backupRestoreBLL.Backup(txtBackupPath.Text);
                    EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Respaldos, Operacion.Backup));
                    MessageBox.Show("Backup realizado exitosamente.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAplicarR_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRestorePath.Text != string.Empty)
                {
                    backupRestoreBLL.Restore(txtRestorePath.Text);
                    EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Respaldos, Operacion.Restore));
                    MessageBox.Show("Restore realizado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
