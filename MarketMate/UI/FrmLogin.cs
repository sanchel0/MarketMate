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
    public partial class FrmLogin : Form
    {
        private static int loginAttempts = 0;
        private const int maxLoginAttempts = 3;
        UsuarioBLL userBLL;

        public FrmLogin()
        {
            InitializeComponent();
            userBLL = new UsuarioBLL();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                var res = userBLL.Login(txtUsername.Text, txtPassword.Text);
                FrmMain frmMain = new FrmMain();
                frmMain.Show();
                this.Hide();
            }
            catch (LoginException ex)
            {
                switch (ex.ErrorType)
                {
                    case LoginErrorType.SessionAlreadyStarted:
                        MessageBox.Show("Ya hay una sesión iniciada.");
                        break;
                    case LoginErrorType.InvalidUsername:
                        MessageBox.Show("El nombre de usuario proporcionado no existe.");
                        break;
                    case LoginErrorType.InvalidPassword:
                        MessageBox.Show("La contraseña proporcionada es incorrecta.");
                        loginAttempts++;

                        if (loginAttempts >= maxLoginAttempts)
                        {
                            userBLL.Bloquear(txtUsername.Text);
                            MessageBox.Show("El usuario ha sido bloqueado debido a múltiples intentos fallidos.");
                            loginAttempts = 0;
                        }
                        break;
                    case LoginErrorType.UserBlocked:
                        MessageBox.Show("El usuario está bloqueado.");
                        break;
                    case LoginErrorType.UserInactive:
                        MessageBox.Show("El usuario está inactivo.");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error: " + ex.Message);
            }
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
