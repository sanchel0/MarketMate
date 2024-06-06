﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;
using System.Linq.Expressions;
using System.Net;

namespace UI
{
    public partial class FrmGestionUsuarios : Form
    {
        UsuarioBLL usuarioBLL;
        private List<UsuarioBE> usuarios;
        private Modo modoActual;

        public FrmGestionUsuarios()
        {
            InitializeComponent();
            usuarioBLL = new UsuarioBLL();
            usuarios = usuarioBLL.GetAll();
            InicializarRadioButtons();
            dgvUsuarios.RowPrePaint += dgvUsuarios_RowPrePaint;
            CambiarModo(Modo.Consulta);

            if (cboRol.Items.Count == 0)
            {
                var roles = Enum.GetValues(typeof(Rol)).Cast<Rol>();

                foreach (var rol in roles)
                {
                    cboRol.Items.Add(rol);
                }
            }
        }

        private void InicializarRadioButtons()
        {
            rdoTodos.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            rdoBloqueados.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            rdoActivos.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            dgvUsuarios.SelectionChanged += new EventHandler(dgvUsuarios_SelectionChanged);
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                UpdateGridConFiltro();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CambiarModo(Modo.Agregar);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            CambiarModo(Modo.Modificar);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CambiarModo(Modo.Eliminar);
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            CambiarModo(Modo.Desbloquear);
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = string.Empty;
                switch (modoActual)
                {
                    case Modo.Agregar:
                        if (AplicarAgregar()){ mensaje = "Usuario Agregado con Éxito"; }
                        CambiarModo(Modo.Consulta);
                        break;
                    case Modo.Modificar:
                        if (AplicarModificar()) { mensaje = "Usuario Modificado con Éxito";}
                        CambiarModo(Modo.Consulta);
                        break;
                    case Modo.Eliminar:
                        if (AplicarEliminar()) { mensaje = "Usuario Eliminado con Éxito"; }
                        CambiarModo(Modo.Consulta);
                        break;
                    case Modo.Desbloquear:
                        if (AplicarDesbloquear()) { mensaje = "Usuario Desbloqueado con Éxito"; }
                        CambiarModo(Modo.Consulta);
                        break;
                    case Modo.Consulta:
                        AplicarConsulta();
                        break;
                }

                if (mensaje != string.Empty)
                {
                    MessageBox.Show(mensaje);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CambiarModo(Modo.Consulta);

            btnCancelar.Enabled = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmGestionarUsuarios_Load(object sender, EventArgs e)
        {
            
        }

        private bool AplicarAgregar()
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text) || cboRol.SelectedItem == null)
            {
                MessageBox.Show("Por favor complete todos los campos.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (usuarioBLL.VerificarDni(usuarios, txtDni.Text))
            {
                MessageBox.Show("Ya existe un usuario con el mismo DNI.", "DNI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            UsuarioBE usuario = new UsuarioBE(txtDni.Text, txtNombre.Text, txtApellido.Text, txtCorreo.Text, (Rol)cboRol.SelectedItem, int.Parse(txtBloqueo.Text) == 1, int.Parse(txtActivo.Text) == 1);
            usuario.Username = usuarioBLL.GenerateUsername(usuario);
            usuario.Password = usuarioBLL.GeneratePassword(usuario);
            usuarioBLL.Insert(usuario);

            return true;
            //usuarios.Add(usuario);
        }

        private bool AplicarModificar()
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                UsuarioBE usuario = (UsuarioBE)dgvUsuarios.SelectedRows[0].DataBoundItem;
                //int indice = usuarios.IndexOf(usuario);

                //usuario.Dni = txtDni.Text;
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.Correo = txtCorreo.Text;
                //usuario.Rol = (Rol)cboRol.SelectedItem;
                //usuario.Bloqueo = int.Parse(txtBloqueo.Text) == 1;
                //usuario.Activo = int.Parse(txtActivo.Text) == 1;

                usuarioBLL.Update(usuario);

                //usuarios[indice] = usuario;

                txtDni.Enabled = true;
                cboRol.Enabled = true;

                return true;
            }
            else
            {
                throw new Exception("Seleccione un usuario de la grilla.");
            }
        }

        private bool AplicarEliminar()
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                UsuarioBE usuario = (UsuarioBE)dgvUsuarios.SelectedRows[0].DataBoundItem;

                if(usuario.Activo == true)
                {
                    usuarioBLL.Delete(usuario.Dni);

                    return true;
                }
                else
                {
                    MessageBox.Show("El usuario seleccionado ya está inactivo.");
                    return false;
                }
                
            }
            else
            {
                MessageBox.Show("Seleccione un usuario de la grilla.");
                return false;
            }
        }

        private bool AplicarDesbloquear()
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                UsuarioBE usuario = (UsuarioBE)dgvUsuarios.SelectedRows[0].DataBoundItem;

                if (usuario.Bloqueo == true)
                {
                    usuarioBLL.Desbloquear(usuario);

                    return true;
                }
                else
                {
                    MessageBox.Show("El usuario seleccionado no está bloqueado.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario de la grilla.");
                return false;
            }
        }

        private void AplicarConsulta()
        {
            var resultados = usuarios;

            if (!string.IsNullOrEmpty(txtDni.Text))
                resultados = resultados.Where(u => u.Dni == txtDni.Text).ToList();

            if (!string.IsNullOrEmpty(txtNombre.Text))
                resultados = resultados.Where(u => u.Nombre == txtNombre.Text).ToList();

            if (!string.IsNullOrEmpty(txtApellido.Text))
                resultados = resultados.Where(u => u.Apellido == txtApellido.Text).ToList();

            if (!string.IsNullOrEmpty(txtCorreo.Text))
                resultados = resultados.Where(u => u.Correo == txtCorreo.Text).ToList();

            if (cboRol.SelectedItem != null)
                resultados = resultados.Where(u => u.Rol == (Rol)cboRol.SelectedItem).ToList();

            if (!string.IsNullOrEmpty(txtBloqueo.Text))
                resultados = resultados.Where(u => u.Bloqueo == (int.Parse(txtBloqueo.Text) == 1)).ToList();

            if (!string.IsNullOrEmpty(txtActivo.Text))
                resultados = resultados.Where(u => u.Activo == (int.Parse(txtActivo.Text) == 1)).ToList();

            UpdateGridConFiltro(resultados);
        }

        private void UpdateGridConFiltro(List<UsuarioBE> datos = null)
        {
            List<UsuarioBE> datosFiltrados = new List<UsuarioBE>();
            
            if (datos == null)
            {
                if (rdoTodos.Checked)
                {
                    datosFiltrados = usuarios;
                }
                else if (rdoBloqueados.Checked)
                {
                    datosFiltrados = usuarios.Where(u => u.Bloqueo).ToList();
                }
                else if (rdoActivos.Checked)
                {
                    datosFiltrados = usuarios.Where(u => u.Activo).ToList();
                }
            }
            else
            {
                datosFiltrados = datos;
            }

            ControlHelper.UpdateGrid(dgvUsuarios, datosFiltrados, "Password", "Bloqueo", "Activo");
        }

        private void LockButtons(Button button = null)
        {
            foreach (Control control in pnlBtns.Controls)
            {
                if(button != null)
                {
                    if (control != button)
                    {
                        ((Button)control).Enabled = false;
                    }
                }
                
            }
            btnAplicar.Enabled = true;
            btnCancelar.Enabled = true;
            btnSalir.Enabled = true;
        }

        private void ResetButtons()
        {
            foreach (Control control in pnlBtns.Controls)
            {
                ((Button)control).Enabled = true;
            }

            btnCancelar.Enabled = false;
        }

        private void LockRadioButtons(RadioButton radioButton = null)
        {
            foreach (Control control in pnlRdos.Controls)
            {
                ((RadioButton)control).Enabled = false;
            }
            if (radioButton != null)
            {
                radioButton.Checked = true;
            }
        }

        private void ResetRadioButtons()
        {
            rdoTodos.Enabled = true;
            rdoActivos.Enabled = true;
            rdoBloqueados.Enabled = true;
            rdoTodos.Checked = true;
        }

        private void CambiarModo(Modo nuevoModo)
        {
            modoActual = nuevoModo;

            switch (modoActual)
            {
                case Modo.Consulta:
                    ResetRadioButtons();
                    MostrarMensaje("Consulta");
                    ResetButtons();
                    grpDatosUsuario.Enabled = true;
                    usuarios = usuarioBLL.GetAll();
                    UpdateGridConFiltro();
                    txtBloqueo.Clear();
                    txtActivo.Clear();
                    txtDni.Enabled = true;
                    cboRol.Enabled = true;
                    break;
                case Modo.Agregar:
                    LockRadioButtons(rdoTodos);
                    MostrarMensaje("Agregar");
                    LockButtons(btnAgregar);
                    txtBloqueo.Text = "0";
                    txtActivo.Text = "1";
                    break;
                case Modo.Modificar:
                    LockRadioButtons(rdoTodos);
                    MostrarMensaje("Modificar");
                    LockButtons(btnModificar);
                    txtDni.Enabled = false;
                    cboRol.Enabled = false;
                    break;
                case Modo.Eliminar:
                    LockRadioButtons(rdoActivos);
                    MostrarMensaje("Eliminar");
                    LockButtons(btnEliminar);
                    grpDatosUsuario.Enabled = false;
                    break;
                case Modo.Desbloquear:
                    LockRadioButtons(rdoBloqueados);
                    MostrarMensaje("Desbloquear");
                    LockButtons(btnDesbloquear);
                    grpDatosUsuario.Enabled = false;
                    break;
            }
        }

        private void MostrarMensaje(string mensaje)
        {
            string mensajeCompleto = $"Modo {mensaje}";
            lblMensaje.Text = mensajeCompleto;
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvUsuarios.SelectedRows[0];
                UsuarioBE usuario = (UsuarioBE)selectedRow.DataBoundItem;

                txtDni.Text = usuario.Dni;
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                txtCorreo.Text = usuario.Correo;
                cboRol.SelectedItem = usuario.Rol;
                txtBloqueo.Text = usuario.Bloqueo ? "1" : "0";
                txtActivo.Text = usuario.Activo ? "1" : "0";
            }
        }

        private void dgvUsuarios_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];

                var usuario = (UsuarioBE)row.DataBoundItem;

                if (!usuario.Activo)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
    }
}