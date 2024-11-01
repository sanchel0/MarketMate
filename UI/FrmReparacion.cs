using BE;
using BLL;
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
    public partial class FrmReparacion : Form
    {
        List<DigitoVerificadorBE> list;
        public FrmReparacion(List<DigitoVerificadorBE> l)
        {
            InitializeComponent();
            list = new List<DigitoVerificadorBE>();
            list = l;
        }

        private void btnRecalcular_Click(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.OK;
            new DigitoVerificadorBLL().RecalculateDVs(list);
            Close();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.OK;
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
                    new BackupRestoreBLL().Restore(filePath);
                }
            }
            Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmReparacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void FrmReparacion_Load(object sender, EventArgs e)
        {

        }
    }
}
