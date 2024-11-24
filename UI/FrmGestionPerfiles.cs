using BE;
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
    public partial class FrmGestionPerfiles : BaseFormObserver
    {
        PermisoBLL _permisoBLL;
        List<PermisoSimple> _patentes;
        List<PermisoCompuesto> _familias;
        List<PermisoCompuesto> _roles;
        List<PermisoCompuesto> _familiasParaMostrar;
        List<PermisoCompuesto> _rolesParaMostrar;
        PermisoCompuesto _basicFamily;

        Tipo _tipo;
        TreeView _tvwActual = null;
        ComboBox _cboActual = null;
        Modo _modoActual;
        bool _deseleccionando = false;

        public FrmGestionPerfiles()
        {
            InitializeComponent();
            _permisoBLL = new PermisoBLL();


            rdoRol.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            rdoFam.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            cboRoles.SelectedIndexChanged += new EventHandler(cboRoles_SelectedIndexChanged);
            cboFamilias.SelectedIndexChanged += new EventHandler(cboFamilias_SelectedIndexChanged);
            rdoRol.Checked = true;
            tvwPermisosFamilia.BeforeSelect += new TreeViewCancelEventHandler(treeView_BeforeSelect);

            _patentes = _permisoBLL.GetAllPatentes();

            CambiarModo(Modo.Consulta);
            TranslateEntityList(_patentes, Translation);
        }

        private void FrmGestionPerfiles_Load(object sender, EventArgs e)
        {
            _basicFamily = _familiasParaMostrar.FirstOrDefault(f => f.Nombre == "Usuario" || f.Nombre == "User");
        }

        private void treeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                e.Cancel = true;
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                if (((RadioButton)sender) == rdoRol)
                {
                    _tipo = Tipo.Rol;
                    _tvwActual = tvwPermisosRol;
                    _cboActual = cboRoles;
                    tvwPermisosFamilia.Nodes.Clear();
                    ControlHelper.EnableControls(pnlRol);
                    ControlHelper.DisableControls(pnlFam);
                    if (_modoActual == Modo.Agregar && _tipo == Tipo.Rol && _basicFamily != null)
                    {
                        TreeNode nodoUsuarios = new TreeNode(_basicFamily.Nombre);
                        nodoUsuarios.Tag = _basicFamily;
                        AgregarPermisosATreeNode(_basicFamily.Hijos, nodoUsuarios);
                        _tvwActual.Nodes.Add(nodoUsuarios);
                        nodoUsuarios.ForeColor = Color.Gray;
                    }
                }
                else if (((RadioButton)sender) == rdoFam)
                {
                    _tipo = Tipo.Familia;
                    _tvwActual = tvwPermisosFamilia;
                    _cboActual = cboFamilias;
                    tvwPermisosRol.Nodes.Clear();
                    ControlHelper.EnableControls(pnlFam);
                    ControlHelper.DisableControls(pnlRol);
                }
            }
        }

        private void cboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRoles.SelectedItem != null)
            {
                PermisoCompuesto selectedRol = (PermisoCompuesto)cboRoles.SelectedItem;
                CargarPermisosEnTreeView(selectedRol.Hijos, tvwPermisosRol);
            }
        }

        private void cboFamilias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFamilias.SelectedItem != null)
            {
                PermisoCompuesto selectedFamilia = (PermisoCompuesto)cboFamilias.SelectedItem;
                CargarPermisosEnTreeView(selectedFamilia.Hijos, tvwPermisosFamilia);
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                Permiso permiso = null;
                if (lstPermisos.SelectedItem != null)
                {
                    permiso = lstPermisos.SelectedItem as PermisoSimple;
                }
                else if (lstFamilias.SelectedItem != null)
                {
                    permiso = lstFamilias.SelectedItem as PermisoCompuesto;
                }
                else
                {
                    throw new ValidationException(ValidationErrorType.NoSelection);
                }

                if (!NodeExistsInTreeView(permiso, _tvwActual))
                {
                    TreeNode rootNode = new TreeNode(permiso.Nombre);
                    rootNode.Tag = permiso;
                    AgregarPermisosATreeNode(permiso.Hijos, rootNode);
                    _tvwActual.Nodes.Add(rootNode);
                }
                else
                {
                    throw new ValidationException(ValidationErrorType.PermissionAlreadyAssigned);
                }
            }
            catch(ValidationException ex)
            {
                string errorMessage = GetTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_tvwActual.SelectedNode != null)
                {
                    Permiso permiso = (Permiso)_tvwActual.SelectedNode.Tag;
                    if (permiso.Nombre != _basicFamily.Nombre)
                    {
                        _tvwActual.SelectedNode.Remove();
                    }
                    else
                    {
                        throw new ValidationException(ValidationErrorType.CannotRemoveBasicFamily);
                    }
                }
                else
                {
                    throw new ValidationException(ValidationErrorType.NoSelection);
                }
            }
            catch (ValidationException ex)
            {
                string errorMessage = GetTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
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

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = GetTranslation(SuccessType.OperationSuccess);
                switch (_modoActual)
                {
                    case Modo.Agregar:
                        AplicarAgregar();
                        if(_tipo == Tipo.Rol)
                            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Perfiles, Operacion.RegistrarRol));
                        else
                            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Perfiles, Operacion.RegistrarFamilia));
                        break;
                    case Modo.Modificar:
                        AplicarModificar();
                        if (_tipo == Tipo.Rol)
                            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Perfiles, Operacion.ModificarRol));
                        else
                            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Perfiles, Operacion.ModificarFamilia));
                        break;
                    case Modo.Eliminar:
                        AplicarEliminar();
                        if (_tipo == Tipo.Rol)
                            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Perfiles, Operacion.EliminarRol));
                        else
                            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Perfiles, Operacion.EliminarFamilia));
                        break;
                }
                MessageBox.Show(mensaje);
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
            finally { CambiarModo(Modo.Consulta); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _tvwActual.Nodes.Clear();
            if (_cboActual.SelectedItem != null)
                CargarPermisosEnTreeView(((PermisoCompuesto)_cboActual.SelectedItem).Hijos, _tvwActual);

            CambiarModo(Modo.Consulta);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CambiarModo(Modo nuevoModo)
        {
            _modoActual = nuevoModo;
            lblModo.Text = GetTranslation(_modoActual);

            switch (_modoActual)
            {
                case Modo.Consulta:
                    UpdateLists();
                    ControlHelper.EnableControls(cboRoles, cboFamilias, btnAgregar, btnModificar, btnEliminar);
                    ControlHelper.DisableControls(txtFamilia, txtRol, btnAsignar, btnQuitar, btnCancelar, btnAplicar);
                    txtFamilia.Clear();
                    txtRol.Clear();
                    ControlHelper.LoadListBox(lstPermisos, _patentes);
                    ControlHelper.LoadListBox(lstFamilias, _familiasParaMostrar);
                    ControlHelper.LoadComboBox(cboRoles, _rolesParaMostrar);
                    ControlHelper.LoadComboBox(cboFamilias, _familiasParaMostrar);
                    break;
                case Modo.Agregar:
                    ControlHelper.EnableControls(txtFamilia, txtRol, btnAsignar, btnQuitar, btnCancelar, btnAplicar);
                    ControlHelper.DisableControls(cboRoles, cboFamilias, btnModificar, btnEliminar);
                    _tvwActual.Nodes.Clear();
                    if (_tipo == Tipo.Rol && _basicFamily != null)
                    {
                        // Agregar la familia "Usuarios" al TreeView
                        TreeNode nodoUsuarios = new TreeNode(_basicFamily.Nombre);
                        nodoUsuarios.Tag = _basicFamily;
                        AgregarPermisosATreeNode(_basicFamily.Hijos, nodoUsuarios);
                        _tvwActual.Nodes.Add(nodoUsuarios);
                        nodoUsuarios.ForeColor = Color.Gray; // Opcional: Cambiar color para indicar que no se puede quitar
                    }
                    break;
                case Modo.Modificar:
                    ControlHelper.EnableControls(btnAsignar, btnQuitar, btnCancelar, btnAplicar);
                    ControlHelper.DisableControls(txtFamilia, txtRol, btnAgregar, btnEliminar);
                    break;
                case Modo.Eliminar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar);
                    ControlHelper.DisableControls(btnAsignar, btnQuitar, btnAgregar, btnModificar);
                    break;
            }
        }

        private bool AplicarAgregar()
        {
            if (string.IsNullOrWhiteSpace(txtRol.Text) && string.IsNullOrWhiteSpace(txtFamilia.Text))
                throw new ValidationException(ValidationErrorType.IncompleteFields);

            /*if (_permisoBLL.Existe(_familias, txtFamilia.Text) || _permisoBLL.Existe(_roles, txtRol.Text))
                throw new ValidationException(ValidationErrorType.DuplicateName);*/
            if (TreeViewIsEmpty(_tvwActual))
                throw new ValidationException(ValidationErrorType.EmptyTreeView);

            PermisoCompuesto permisoCompuesto;
            if (_tipo == Tipo.Rol)
            {
                if (TreeViewHasRequiredNodes(_tvwActual))
                    permisoCompuesto = new PermisoCompuesto(txtRol.Text, TipoPermiso.Rol);
                else
                    throw new Exception("Error.");
            }
            else
            {
                permisoCompuesto = new PermisoCompuesto(txtFamilia.Text, TipoPermiso.Familia);
            }

            AsignarPermisosDeTreeView(_tvwActual, permisoCompuesto);
            _permisoBLL.Create(permisoCompuesto);

            return true;
        }

        private bool TreeViewHasRequiredNodes(TreeView treeView)
        {
            bool hasUserNode = false;
            int nodeCount = 0;

            foreach (TreeNode node in treeView.Nodes)
            {
                if (node.Text.Equals("User", StringComparison.OrdinalIgnoreCase) || node.Text.Equals("Usuario", StringComparison.OrdinalIgnoreCase))
                {
                    hasUserNode = true;
                }
                nodeCount++;
            }

            // Verificar que hay más de un nodo y que uno de ellos es el nodo "User" o "Usuario"
            return hasUserNode && nodeCount > 1;
        }

        private bool AplicarModificar()
        {
            if (_cboActual.SelectedItem != null)
            {
                if (TreeViewIsEmpty(_tvwActual))
                    throw new ValidationException(ValidationErrorType.EmptyTreeView);

                PermisoCompuesto permisoModificado = (PermisoCompuesto)_cboActual.SelectedItem;
                permisoModificado.Hijos.Clear();
                AsignarPermisosDeTreeView(_tvwActual, permisoModificado);
                
                _permisoBLL.Update(permisoModificado);
                return true;
            }
            else
            {
                throw new ValidationException(ValidationErrorType.NoSelection);
            }
        }

        private bool AplicarEliminar()
        {
            if (_cboActual.SelectedItem != null)
            {
                PermisoCompuesto permisoCompuesto = (PermisoCompuesto)_cboActual.SelectedItem;
                _permisoBLL.Delete(permisoCompuesto);
                return true;
            }
            else
            {
                throw new ValidationException(ValidationErrorType.NoSelection);
            }
        }

        private void CargarPermisosEnTreeView(List<Permiso> listaPermisos, TreeView treeView)
        {
            treeView.Nodes.Clear();

            foreach (Permiso permiso in listaPermisos)
            {
                TreeNode nodoPermiso = new TreeNode(permiso.Nombre);
                nodoPermiso.Tag = permiso;

                if (permiso is PermisoCompuesto permisoCompuesto && permisoCompuesto.Hijos.Count > 0)
                {
                    AgregarHijosAlNodo(permisoCompuesto.Hijos, nodoPermiso);
                }

                treeView.Nodes.Add(nodoPermiso);
            }
        }

        private void AgregarHijosAlNodo(List<Permiso> listaHijos, TreeNode nodoPadre)
        {
            foreach (Permiso hijo in listaHijos)
            {
                TreeNode nodoHijo = new TreeNode(hijo.Nombre);
                nodoHijo.Tag = hijo;

                if (hijo is PermisoCompuesto permisoCompuesto && permisoCompuesto.Hijos.Count > 0)
                {
                    AgregarHijosAlNodo(permisoCompuesto.Hijos, nodoHijo);
                }

                nodoPadre.Nodes.Add(nodoHijo);
            }
        }

        private bool NodeExistsInTreeView(Permiso permiso, TreeView treeView)
        {
            foreach (TreeNode existingNode in treeView.Nodes)
            {
                if (NodeExists(existingNode, permiso))
                {
                    return true;
                }
            }
            return false;
        }

        private bool NodeExists(TreeNode treeNode, Permiso permiso)
        {
            if (treeNode.Tag is Permiso && ((Permiso)treeNode.Tag).Codigo == permiso.Codigo)
            {
                return true;
            }

            foreach (TreeNode childNode in treeNode.Nodes)
            {
                if (NodeExists(childNode, permiso))
                {
                    return true;
                }
            }

            return false;
        }

        private void AsignarPermisosDeTreeView(TreeView tvw, PermisoCompuesto obj)
        {
            foreach (TreeNode node in tvw.Nodes)
            {
                _permisoBLL.AsignarPermiso(obj, (Permiso)node.Tag);
            }
        }

        private void AgregarPermisosATreeNode(List<Permiso> permisos, TreeNode parentNode)
        {
            foreach (var permiso in permisos)
            {
                TreeNode childNode = new TreeNode(permiso.Nombre);
                childNode.Tag = permiso;
                parentNode.Nodes.Add(childNode);

                if (permiso.Hijos != null && permiso.Hijos.Count > 0)
                {
                    AgregarPermisosATreeNode(permiso.Hijos, childNode);
                }
            }
        }

        private void UpdateLists()
        {
            try
            {
                _familias = _permisoBLL.GetAllFamilias();
                _roles = _permisoBLL.GetAllRoles();
                _familiasParaMostrar = _familias.Select(f => new PermisoCompuesto(f)).ToList();
                _rolesParaMostrar = _roles.Select(r => new PermisoCompuesto(r)).ToList();

                TranslateEntityList(_familiasParaMostrar, Translation);
                TranslateEntityList(_rolesParaMostrar, Translation);

                TranslatePermissionList(_familiasParaMostrar, Translation);
                TranslatePermissionList(_rolesParaMostrar, Translation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void TranslatePermissionList(List<PermisoCompuesto> permissions, Dictionary<string, string> permissionTranslations)
        {
            foreach (var permission in permissions)
            {
                TranslatePermission(permission, permissionTranslations);
            }
        }

        private void TranslatePermission(Permiso permission, Dictionary<string, string> permissionTranslations)
        {
            if (permission == null)
                return;

            if (permission is PermisoSimple patente)
            {
                if (permissionTranslations.TryGetValue(patente.Nombre, out var translatedNombre))
                {
                    patente.Nombre = translatedNombre;
                }
            }
            else if (permission is PermisoCompuesto compuesto)
            {
                if (permissionTranslations.TryGetValue(compuesto.Nombre, out var translatedNombre))
                {
                    compuesto.Nombre = translatedNombre;
                }

                foreach (var child in compuesto.Hijos)
                {
                    TranslatePermission(child, permissionTranslations);
                }
            }
        }

        public PermisoCompuesto TranslateToSpanish(PermisoCompuesto entity, PermisoCompuesto originalEntity)
        {
            var p = new PermisoCompuesto(
                entity.Nombre,
                entity.Tipo
            );

            foreach (var hijo in entity.Hijos)
            {
                if (hijo is PermisoCompuesto permisoCompuestoHijo)
                {
                    p.Hijos.Add(new PermisoCompuesto(permisoCompuestoHijo));
                }
                else if (hijo is PermisoSimple permisoSimpleHijo)
                {
                    p.Hijos.Add(new PermisoSimple(permisoSimpleHijo.Nombre, permisoSimpleHijo.Tipo));
                }
            }

            return p;
        }

        private void lstPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_deseleccionando)
            {
                _deseleccionando = true;
                lstFamilias.ClearSelected();
                _deseleccionando = false;
            }
        }

        private void lstFamilias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_deseleccionando && lstFamilias.SelectedItem != null)
            {
                PermisoCompuesto permisoCompuesto = lstFamilias.SelectedItem as PermisoCompuesto;

                if (permisoCompuesto != null)
                {
                    CargarPermisosEnTreeView(permisoCompuesto.Hijos, tvwPermisosFam);
                }
                _deseleccionando = true;
                lstPermisos.ClearSelected();
                _deseleccionando = false;
            }
        }

        private bool TreeViewIsEmpty(TreeView treeView)
        {
            return treeView.Nodes.Count == 0;
        }
    }
}
