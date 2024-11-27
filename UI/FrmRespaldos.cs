using BE;
using BLL;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    [DesignerCategory("Form")]
    public partial class FrmRespaldos : BaseFormObserver
    {
        BackupRestoreBLL backupRestoreBLL;
        public FrmRespaldos()
        {
            InitializeComponent();
            backupRestoreBLL = new BackupRestoreBLL();
        }

        private void FrmRespaldos_Load(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(this.Width, this.Height);

            // Capturar la imagen del formulario y sus controles
            this.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));

            // Guardar la imagen en la ubicación deseada
            bmp.Save($@"C:\Users\user\Desktop\Forms\{this.Name}.png", ImageFormat.Png);
        }

        private void picBackup_Click(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    folderBrowserDialog.Description = "Select Folder";

                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        string folderPath = folderBrowserDialog.SelectedPath;
                        txtBackupPath.Text = folderPath;
                    }
                }
            }
            catch (ValidationException ex)
            {
                string errorMessage = GetTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
            catch (DatabaseException ex)
            {
                string errorMessage = GetTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void picRestore_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Backup Files (*.bak)|*.bak|All Files (*.*)|*.*";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;

                        if (!filePath.EndsWith(".bak", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show(GetTranslation(ValidationErrorType.InvalidBakExtension), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        txtRestorePath.Text = filePath;
                    }
                }
            }
            catch (ValidationException ex)
            {
                string errorMessage = GetTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
            catch (DatabaseException ex)
            {
                string errorMessage = GetTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    MessageBox.Show(GetTranslation(SuccessType.OperationSuccess));
                }
            }
            catch (ValidationException ex)
            {
                string errorMessage = GetTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
            catch (DatabaseException ex)
            {
                string errorMessage = GetTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
            catch (Exception ex)
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
                    MessageBox.Show(GetTranslation(SuccessType.OperationSuccess));
                }
            }
            catch (ValidationException ex)
            {
                string errorMessage = GetTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
            catch (DatabaseException ex)
            {
                string errorMessage = GetTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
