using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;
using BLL;
using GUI;

namespace UI
{
    public partial class FrmCambiarClave : Form
    {
        UsuarioBLL usuarioBLL;
        public FrmCambiarClave()
        {
            InitializeComponent();
            usuarioBLL = new UsuarioBLL();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtCurrentPassword.Text) || !string.IsNullOrWhiteSpace(txtNewPassword.Text) || !string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                {
                    if (!CompararClaves(txtNewPassword.Text, txtConfirmPassword.Text))
                    {
                        this.DialogResult = DialogResult.Cancel;
                        throw new Exception("Las contraseñas no coinciden. Por favor, inténtelo de nuevo.");
                    }
                    else
                    {
                        string inputPassword = CryptoManager.HashPassword(txtCurrentPassword.Text);
                        UsuarioBE user = SessionManager.GetUser();
                
                        if(!usuarioBLL.VerificarPassword(inputPassword, user.Password))
                        {
                            this.DialogResult = DialogResult.Cancel;
                            throw new Exception("La contraseña actual ingresada no es correcta. Por favor, vuelva a intentarlo.");
                        }
                        else
                        {
                            string newPassword = CryptoManager.HashPassword(txtNewPassword.Text);
                            user.Password = newPassword;
                            usuarioBLL.Update(user);

                            MessageBox.Show("Clave cambiada con Éxito.");
                            //FrmMain.cambioClaveRealizado = true;
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                    }
                }

                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                    throw new Exception("Por favor complete todos los campos.");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private bool CompararClaves(string pNewPassword, string pConfirmPassword)
        {
            return pNewPassword == pConfirmPassword;
        }

        private void FrmCambiarClave_Load(object sender, EventArgs e)
        {

        }
    }
}
