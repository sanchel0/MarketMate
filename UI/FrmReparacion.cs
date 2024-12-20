﻿using BE;
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
    [DesignerCategory("Form")]
    public partial class FrmReparacion : BaseFormObserver
    {
        DigitoVerificadorBLL dv;
        public FrmReparacion(DigitoVerificadorBLL bll)
        {
            InitializeComponent();
            dv = new DigitoVerificadorBLL();
            dv = bll;
        }

        private void btnRecalcular_Click(object sender, EventArgs e)
        {
            try
            {
                //DialogResult = DialogResult.OK;
                dv.RecalculateDVs();
                MessageBox.Show(GetTranslation(SuccessType.OperationSuccess));
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
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
                            MessageBox.Show( GetTranslation(ValidationErrorType.InvalidBakExtension), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        new BackupRestoreBLL().Restore(filePath);
                    }
                }
                MessageBox.Show(GetTranslation(SuccessType.OperationSuccess));
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
