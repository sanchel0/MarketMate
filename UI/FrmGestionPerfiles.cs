using BE;
using BLL;
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
    public partial class FrmGestionPerfiles : Form
    {
        PermisoBLL _permisoBLL;
        List<PermisoSimple> _patentes;
        List<PermisoCompuesto> _familias;
        List<PermisoCompuesto> _roles;
        Tipo _tipo;
        TreeView _tvwActual = null;
        ComboBox _cboActual = null;
        Modo _modoActual;
        bool _deseleccionando = false;

        public FrmGestionPerfiles()
        {
            InitializeComponent();
            _permisoBLL = new PermisoBLL();
            _patentes = _permisoBLL.GetAllPatentes();
            _familias = _permisoBLL.GetAllFamilias();
            _roles = _permisoBLL.GetAllRoles();

            rdoRol.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            rdoFam.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            cboRoles.SelectedIndexChanged += new EventHandler(cboRoles_SelectedIndexChanged);
            cboFamilias.SelectedIndexChanged += new EventHandler(cboFamilias_SelectedIndexChanged);
            rdoRol.Checked = true;
            tvwPermisosFamilia.BeforeSelect += new TreeViewCancelEventHandler(treeView_BeforeSelect);
        }

        private void FrmGestionPerfiles_Load(object sender, EventArgs e)
        {

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
                MessageBox.Show("Selecciona un elemento de la lista.");
            }

            if (!NodeExistsInTreeView(permiso, _tvwActual))
            {
                TreeNode rootNode = new TreeNode(permiso.Nombre);
                rootNode.Tag = permiso;
                AgregarPermisosATreeView(permiso.Hijos, rootNode);
                _tvwActual.Nodes.Add(rootNode);
            }
            else
            {
                MessageBox.Show("El permiso seleccionado ya está asignado.");
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (_tvwActual.SelectedNode != null)
            {
                _tvwActual.SelectedNode.Remove();
            }
            else
            {
                MessageBox.Show("Selecciona el elemento que desea quitar.");
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
                string mensaje = string.Empty;
                switch (_modoActual)
                {
                    case Modo.Agregar:
                        if (AplicarAgregar()) { mensaje = $"{_tipo} Agregado con Éxito"; }
                        break;
                    case Modo.Modificar:
                        if (AplicarModificar()) { mensaje = $"{_tipo} Modificado con Éxito"; }
                        break;
                    case Modo.Eliminar:
                        if (AplicarEliminar()) { mensaje = $"{_tipo} Eliminado con Éxito"; }
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
            this.Close();
        }

        private void CambiarModo(Modo nuevoModo)
        {
            _modoActual = nuevoModo;
            switch (_modoActual)
            {
                case Modo.Consulta:
                    ControlHelper.EnableControls(cboRoles, cboFamilias, btnAgregar, btnModificar, btnEliminar, btnCancelar);
                    ControlHelper.DisableControls(txtFamilia, txtRol, btnAsignar, btnQuitar, btnCancelar, btnAplicar);
                    ControlHelper.SetLabelMessage(lblModo, "Consulta");
                    txtFamilia.Clear();
                    txtRol.Clear();
                    ControlHelper.LoadListBox(lstPermisos, _patentes);
                    ControlHelper.LoadListBox(lstFamilias, _familias);
                    ControlHelper.LoadComboBox(cboRoles, _roles);
                    ControlHelper.LoadComboBox(cboFamilias, _familias);
                    break;
                case Modo.Agregar:
                    ControlHelper.EnableControls(txtFamilia, txtRol, btnAsignar, btnQuitar, btnCancelar, btnAplicar);
                    ControlHelper.DisableControls(cboRoles, cboFamilias, btnModificar, btnEliminar);
                    ControlHelper.SetLabelMessage(lblModo, "Agregar");
                    _tvwActual.Nodes.Clear();
                    break;
                case Modo.Modificar:
                    ControlHelper.EnableControls(btnAsignar, btnQuitar, btnCancelar, btnAplicar);
                    ControlHelper.DisableControls(txtFamilia, txtRol, btnAgregar, btnEliminar);
                    ControlHelper.SetLabelMessage(lblModo, "Modificar");
                    break;
                case Modo.Eliminar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar);
                    ControlHelper.DisableControls(btnAsignar, btnQuitar, btnAgregar, btnModificar);
                    ControlHelper.SetLabelMessage(lblModo, "Eliminar");
                    break;
            }
        }

        private bool AplicarAgregar()
        {
            if (string.IsNullOrWhiteSpace(txtRol.Text) && string.IsNullOrWhiteSpace(txtFamilia.Text))
                throw new Exception("Por favor complete el campo.");

            if (_permisoBLL.ExisteFamilia(_familias, txtFamilia.Text))
            {
                MessageBox.Show("Ya existe una familia con el mismo nombre.", "Nombre Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            PermisoCompuesto permisoCompuesto;
            if (_tipo == Tipo.Rol)
            {
                permisoCompuesto = new PermisoCompuesto(txtRol.Text, TipoPermiso.Rol);
            }
            else
            {
                permisoCompuesto = new PermisoCompuesto(txtFamilia.Text, TipoPermiso.Familia);
            }

            AsignarPermisosDeTreeView(_tvwActual, permisoCompuesto);
            _permisoBLL.Create(permisoCompuesto);

            return true;
        }

        private bool AplicarModificar()
        {
            if (_cboActual.SelectedItem != null)
            {
                PermisoCompuesto permisoCompuesto = (PermisoCompuesto)_cboActual.SelectedItem;
                permisoCompuesto.Hijos.Clear();
                AsignarPermisosDeTreeView(_tvwActual, permisoCompuesto);
                _permisoBLL.Update(permisoCompuesto);
                return true;
            }
            else
            {
                throw new Exception("Seleccione un elemento del combobox.");
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
                throw new Exception("Seleccione un elemento del combobox.");
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

        private void AgregarPermisosATreeView(List<Permiso> permisos, TreeNode parentNode)
        {
            foreach (var permiso in permisos)
            {
                TreeNode childNode = new TreeNode(permiso.Nombre);
                childNode.Tag = permiso;
                parentNode.Nodes.Add(childNode);

                if (permiso.Hijos != null && permiso.Hijos.Count > 0)
                {
                    AgregarPermisosATreeView(permiso.Hijos, childNode);
                }
            }
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
    }
}
