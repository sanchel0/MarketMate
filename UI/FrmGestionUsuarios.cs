using System;
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
using System.Runtime.InteropServices;
using Services;

namespace UI
{
    [DesignerCategory("Form")]
    public partial class FrmGestionUsuarios : BaseFormObserver
    {
        UsuarioBLL usuarioBLL;
        List<UsuarioBE> usuarios;
        List<UsuarioBE> usuariosParaMostrar;
        List<PermisoCompuesto> roles;
        private Modo modoActual;
        PermisoBLL permisoBLL;
        //FamiliaBLL familiaBLL;
        public FrmGestionUsuarios()
        {
            InitializeComponent();
            usuarioBLL = new UsuarioBLL();
            permisoBLL = new PermisoBLL();
            usuarios = usuarioBLL.GetAll();
            InicializarRadioButtons();
            dgvUsuarios.RowPrePaint += dgvUsuarios_RowPrePaint;
            CambiarModo(Modo.Consulta);


            roles = permisoBLL.GetAllRoles();
            LoadComboBox();
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

        private void btnActivarDesactivar_Click(object sender, EventArgs e)
        {
            if(btnActivarDesactivar.Text == Modo.Activar.ToString())
                CambiarModo(Modo.Activar);
            else
                CambiarModo(Modo.Desactivar);
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            CambiarModo(Modo.Desbloquear);
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = Translation.GetEnumTranslation(SuccessType.OperationSuccess);
                switch (modoActual)
                {
                    case Modo.Agregar:
                        if (AplicarAgregar()){}
                        EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Usuario, Operacion.RegistrarUsuario));
                        CambiarModo(Modo.Consulta);
                        break;
                    case Modo.Modificar:
                        if (AplicarModificar()) {}
                        EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Usuario, Operacion.ModificarUsuario));
                        CambiarModo(Modo.Consulta);
                        break;
                    case Modo.Desactivar:
                        if (AplicarDesactivar()) {}
                        EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Usuario, Operacion.DesactivarUsuario));
                        CambiarModo(Modo.Consulta);
                        break;
                    case Modo.Activar:
                        if (AplicarActivar()) {}
                        EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Usuario, Operacion.ActivarUsuario));
                        CambiarModo(Modo.Consulta);
                        break;
                    case Modo.Desbloquear:
                        if (AplicarDesbloquear()) {}
                        EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Usuario, Operacion.DesbloquearUsuario));
                        CambiarModo(Modo.Consulta);
                        break;
                    case Modo.Consulta:
                        AplicarConsulta();
                        break;
                }
                MessageBox.Show(mensaje);
            }
            catch (ValidationException ex)
            {
                string errorMessage = Translation.GetEnumTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
            catch (DatabaseException ex)
            {
                string errorMessage = Translation.GetEnumTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
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
            ControlHelper.ValidateNotEmpty(txtDni, txtNombre, txtApellido, txtCorreo, cboRol);

            UsuarioBE usuario = new UsuarioBE(txtDni.Text, txtNombre.Text, txtApellido.Text, txtCorreo.Text, (PermisoCompuesto)cboRol.SelectedItem, int.Parse(txtBloqueo.Text) == 1, int.Parse(txtActivo.Text) == 1);
            
            usuarioBLL.Insert(usuario);

            return true;
        }

        private bool AplicarModificar()
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                ControlHelper.ValidateNotEmpty(txtNombre, txtApellido, txtCorreo, cboRol);

                UsuarioBE usuarioModificado = (UsuarioBE)dgvUsuarios.SelectedRows[0].DataBoundItem;

                usuarioModificado.Nombre = txtNombre.Text;
                usuarioModificado.Apellido = txtApellido.Text;
                usuarioModificado.Correo = txtCorreo.Text;
                usuarioModificado.Rol = (PermisoCompuesto)cboRol.SelectedItem;

                int selectedIndex = dgvUsuarios.SelectedRows[0].Index;
                UsuarioBE usuarioOriginal = usuarios[selectedIndex];

                usuarios[selectedIndex] = TranslateToSpanish(usuarioModificado, usuarioOriginal);

                usuarioBLL.Update(usuarios[selectedIndex]);

                txtDni.Enabled = true;

                return true;
            }
            else
            {
                throw new ValidationException(ValidationErrorType.NoSelection);
            }
        }

        private bool AplicarDesactivar()
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
                throw new ValidationException(ValidationErrorType.NoSelection);

            UsuarioBE usuario = (UsuarioBE)dgvUsuarios.SelectedRows[0].DataBoundItem;

            usuarioBLL.DesactivarUsuario(usuario);
            MessageBox.Show("Usuario desactivado con éxito.");

            return true;
        }

        private bool AplicarActivar()
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
                throw new ValidationException(ValidationErrorType.NoSelection);

            UsuarioBE usuario = (UsuarioBE)dgvUsuarios.SelectedRows[0].DataBoundItem;

            usuarioBLL.ActivarUsuario(usuario);
            MessageBox.Show("Usuario activado con éxito.");

            return true;
        }

        private bool AplicarDesbloquear()
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
                throw new ValidationException(ValidationErrorType.NoSelection);

            UsuarioBE usuario = (UsuarioBE)dgvUsuarios.SelectedRows[0].DataBoundItem;

            usuarioBLL.DesbloquearUsuario(usuario);
            MessageBox.Show("Usuario desbloqueado con éxito.");

            return true;
        }

        private void AplicarConsulta()
        {
            var resultados = usuariosParaMostrar;

            if (!string.IsNullOrEmpty(txtDni.Text))
                resultados = resultados.Where(u => u.Dni == txtDni.Text).ToList();

            if (!string.IsNullOrEmpty(txtNombre.Text))
                resultados = resultados.Where(u => u.Nombre == txtNombre.Text).ToList();

            if (!string.IsNullOrEmpty(txtApellido.Text))
                resultados = resultados.Where(u => u.Apellido == txtApellido.Text).ToList();

            if (!string.IsNullOrEmpty(txtCorreo.Text))
                resultados = resultados.Where(u => u.Correo == txtCorreo.Text).ToList();

            if (cboRol.SelectedItem != null)
                resultados = resultados.Where(u => u.Rol.Nombre == ((PermisoCompuesto)cboRol.SelectedItem).Nombre).ToList();

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
                    datosFiltrados = usuariosParaMostrar;
                }
                else if (rdoBloqueados.Checked)
                {
                    datosFiltrados = usuariosParaMostrar.Where(u => u.Bloqueo).ToList();
                }
                else if (rdoActivos.Checked)
                {
                    datosFiltrados = usuariosParaMostrar.Where(u => u.Activo).ToList();
                }
            }
            else
            {
                datosFiltrados = datos;
            }

            ControlHelper.UpdateGrid(dgvUsuarios, datosFiltrados, "Idioma", "Rol", "Password", "Bloqueo", "Activo", "Active", "Blocked");
        }

        private void UpdateGrid()
        {
            usuarios = usuarioBLL.GetAll();
            usuariosParaMostrar = usuarios.Select(u => new UsuarioBE(u)).ToList();

            TranslateEntityList(usuariosParaMostrar, Translation.Entities);

            ControlHelper.UpdateGrid(dgvUsuarios, usuariosParaMostrar, "Idioma", "Rol", "Password", "Bloqueo", "Activo", "Active", "Blocked");
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

        public UsuarioBE TranslateToSpanish(UsuarioBE entity, UsuarioBE originalEntity)
        {
            var translatedUser = new UsuarioBE(
                entity.Dni,
                entity.Nombre,
                entity.Apellido,
                entity.Correo,
                originalEntity.Rol,
                originalEntity.Bloqueo,
                originalEntity.Activo
            );

            translatedUser.Username = originalEntity.Username;
            translatedUser.Password = originalEntity.Password;
            translatedUser.Idioma = originalEntity.Idioma;

            return translatedUser;
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
            lblMensaje.Text = Translation.GetEnumTranslation(modoActual);

            switch (modoActual)
            {
                case Modo.Consulta:
                    UpdateGrid();
                    ResetRadioButtons();
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
                    LockButtons(btnAgregar);
                    txtBloqueo.Text = "0";
                    txtActivo.Text = "1";
                    break;
                case Modo.Modificar:
                    LockRadioButtons(rdoTodos);
                    LockButtons(btnModificar);
                    txtDni.Enabled = false;
                    break;
                case Modo.Desactivar:
                case Modo.Activar:
                    LockRadioButtons(/*rdoActivos*/);
                    LockButtons(btnActivarDesactivar);
                    grpDatosUsuario.Enabled = false;
                    break;
                case Modo.Desbloquear:
                    LockRadioButtons(rdoBloqueados);
                    LockButtons(btnDesbloquear);
                    grpDatosUsuario.Enabled = false;
                    break;
            }
        }

        private void LoadComboBox()
        {
            TranslateEntityList(roles, Translation.Entities);
            ControlHelper.LoadComboBox(cboRol, roles);
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

                if (usuario.Activo)
                    btnActivarDesactivar.Text = Modo.Desactivar.ToString();
                else
                    btnActivarDesactivar.Text = Modo.Activar.ToString();
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