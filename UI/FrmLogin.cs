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
using BE;

namespace UI
{
    [DesignerCategory("Form")]
    public partial class FrmLogin : BaseFormObserver
    {
        private static int loginAttempts = 0;
        private const int maxLoginAttempts = 3;
        UsuarioBLL userBLL;
        EventoBLL _eventoBLL;
        public FrmLogin()
        {
            InitializeComponent();
            userBLL = new UsuarioBLL();
            _eventoBLL = new EventoBLL();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                ControlHelper.ValidateNotEmpty(txtUsername, txtPassword);

                var res = userBLL.Login(txtUsername.Text, txtPassword.Text);
                _eventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Usuario, Operacion.Login));
                FrmMain frmMain = new FrmMain();
                frmMain.Show();
                Hide();
            }
            catch (LoginException ex)
            {
                string errorMessage = Translation.GetEnumTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
                switch (ex.ErrorType)
                {
                    /*case LoginErrorType.SessionAlreadyStarted:
                        MessageBox.Show("Ya hay una sesión iniciada.");
                        break;
                    case LoginErrorType.InvalidUsername:
                        MessageBox.Show("El nombre de usuario proporcionado no existe.");
                        break;*/
                    case LoginErrorType.InvalidPassword:
                        loginAttempts++;

                        if (loginAttempts >= maxLoginAttempts)
                        {
                            userBLL.Bloquear(txtUsername.Text);
                            errorMessage = Translation.GetEnumTranslation(LoginErrorType.MaxLoginAttemptsExceeded);
                            MessageBox.Show(errorMessage);
                            loginAttempts = 0;
                        }
                        break;
                    /*case LoginErrorType.UserBlocked:
                        MessageBox.Show("El usuario está bloqueado.");
                        break;
                    case LoginErrorType.UserInactive:
                        MessageBox.Show("El usuario está inactivo.");
                        break;*/
                }
            }
            catch (ValidationException ex)
            {
                string errorMessage = Translation.GetEnumTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error desconocido: " + ex.Message);
            }
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
