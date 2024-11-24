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
using UI;
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
        DigitoVerificadorBLL dv;
        public FrmLogin()
        {
            InitializeComponent();
            userBLL = new UsuarioBLL();
            _eventoBLL = new EventoBLL();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            SessionManager.CurrentModule = Modulo.Usuario;
            /*txtUsername.Text = "11111111Santy";
            txtPassword.Text = "11111111Bravo";*/
            txtUsername.Text = "44444444John";
            txtPassword.Text = "44444444Bravo";
            /*txtUsername.Text = "33333333Juan";
            txtPassword.Text = "33333333Bravo";*/
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                ControlHelper.ValidateNotEmpty(txtUsername, txtPassword);
                string username = txtUsername.Text;
                
                dv = new DigitoVerificadorBLL();
                dv.VerifyDV(username);
                MessageBox.Show("Exito.");//SUCCESSSSSSSS

                var res = userBLL.Login(txtUsername.Text, txtPassword.Text);
                
                FrmMain frmMain = new FrmMain();
                frmMain.Show();
                Hide();
            }
            catch (DVException ex)
            {
                if (ex.ErrorType == DVErrorType.Admin)
                {
                    /*string errorMessage = Translation.GetEnumTranslation(ex.ErrorType);
                    MessageBox.Show(errorMessage);*/
                    MessageBox.Show("Hay inconsistencias en la base de datos. Admin.");
                    FrmReparacion frmR = new FrmReparacion(dv);
                    Hide();
                    if (frmR.ShowDialog() == DialogResult.OK)
                    {
                        Show();
                    }
                }
                else
                {
                    //string errorMessage = Translation.GetEnumTranslation(ex.ErrorType);
                    MessageBox.Show("Hay inconsistencias en la base de datos.");//AGREGAR ENUM DE ERRO TYPE DV---------------
                }
            }
            catch (LoginException ex)
            {
                string errorMessage = GetTranslation(ex.ErrorType);
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
                            errorMessage = GetTranslation(LoginErrorType.MaxLoginAttemptsExceeded);
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
                string errorMessage = GetTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
