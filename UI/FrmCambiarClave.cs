﻿using BE;
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

namespace UI
{
    [DesignerCategory("Form")]
    public partial class FrmCambiarClave : BaseFormObserver
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
                ControlHelper.ValidateNotEmpty(txtCurrentPassword, txtNewPassword, txtConfirmPassword);
                if (!CompararClaves(txtNewPassword.Text, txtConfirmPassword.Text))
                {
                    this.DialogResult = DialogResult.Cancel;
                    throw new ValidationException(ValidationErrorType.CurrentPasswordMismatch);
                }
                else
                {
                    string inputPassword = CryptoManager.HashPassword(txtCurrentPassword.Text);
                    UsuarioBE user = SessionManager.GetUser();

                    if (!usuarioBLL.VerificarPassword(inputPassword, user.Password))
                    {
                        this.DialogResult = DialogResult.Cancel;
                        throw new ValidationException(ValidationErrorType.PasswordChangeMismatch);
                    }
                    else
                    {
                        string newPassword = CryptoManager.HashPassword(txtNewPassword.Text);
                        user.Password = newPassword;
                        usuarioBLL.Update(user);
                        EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Usuario, Operacion.CambiarClave));
                        string mensaje = GetTranslation(SuccessType.OperationSuccess);
                        MessageBox.Show(mensaje);
                        //FrmMain.cambioClaveRealizado = true;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
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

        private bool CompararClaves(string pNewPassword, string pConfirmPassword)
        {
            return pNewPassword == pConfirmPassword;
        }

        private void FrmCambiarClave_Load(object sender, EventArgs e)
        {

        }
    }
}
