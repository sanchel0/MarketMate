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
using BE;
using UI;
using BLL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    [DesignerCategory("Form")]
    public partial class FrmMain : BaseFormObserver
    {
        UsuarioBLL usuarioBLL;
        private Form activeForm = null;
        private bool logoutFormOpened;
        internal static bool cambioClaveRealizado;

        public FrmMain()
        {
            InitializeComponent();

            AddEvents(itemAdmin);
            AddEvents(itemMaestros);
            AddEvents(itemUsuario);
            AddEvents(itemVentas);
            AddEvents(itemCompras);
            AddEvents(itemReportes);
            AddEvents(itemAyuda);
            cambioClaveRealizado = false;
            usuarioBLL = new UsuarioBLL();

            ValidarForm();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (cambioClaveRealizado == true)
            {
                cambioClaveRealizado = false;
                this.Close();

            }
        }

        private void Module_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = sender as ToolStripMenuItem;

            if (clickedItem != null)
            {
                Modulo module;
                switch (clickedItem.Name)
                {
                    /*case "itemAdmin":
                        module = Modulo.Admin;
                        break;
                    case "itemMaestros":
                        module = Modulo.Maestros;
                        break;*/
                    case "itemUsuario":
                        module = Modulo.Usuario;
                        break;
                    case "itemVentas":
                        module = Modulo.Ventas;
                        break;
                    case "itemCompras":
                        module = Modulo.Compras;
                        break;
                    case "itemReportes":
                        module = Modulo.Reportes;
                        break;
                    /*case "itemAyuda":
                        module = Modulo.Ayuda;
                        break;*/
                    default:
                        module = Modulo.None;
                        break;
                }

                SessionManager.CurrentModule = module;
            }
        }

        public void ValidarForm()
        {
            try
            {
                if (SessionManager.IsLogged())
                    this.ssrLabelUsername.Text = $"[Username: {SessionManager.GetUser().Username}]";
                else
                    this.ssrLabelUsername.Text = "[Sesión no iniciada]";

                /*this.itemAdmin.Enabled = SessionManager.IsInRole(Rol.Admin);
                this.itemMaestros.Enabled = SessionManager.IsInRole(Rol.Admin);
                this.itemUsuario.Enabled = SessionManager.IsInRole(Rol.Admin) || SessionManager.IsInRole(Rol.Cajero);
                this.itemVentas.Enabled = SessionManager.IsInRole(Rol.Cajero);
                this.itemCompras.Enabled = false;*/
                this.itemReportes.Enabled = false;
                this.itemAyuda.Enabled = false;

                //List<PermisoSimple> patentes = ObtenerPermisosSimplesDeRolRecursivo(SessionManager.GetUser().Rol);

                foreach (ToolStripMenuItem menu in this.mnsMain.Items)
                {
                    HabilitarMenuSegunPermisos(menu);
                }

                this.subItemLogin.Enabled = !SessionManager.IsLogged();
                this.subItemLogout.Enabled = SessionManager.IsLogged();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool HabilitarMenuSegunPermisos(ToolStripMenuItem menuItem)
        {
            bool subMenuHabilitado = false;

            // Verificar si el menú tiene permisos asociados usando el Name
            if (MapPermisoMenu.MapeoPermisos.TryGetValue(menuItem.Name, out Patente permiso))
            {
                menuItem.Enabled = SessionManager.GetInstance().IsInRole(permiso);
                subMenuHabilitado = menuItem.Enabled; // Actualiza el estado del menú según los permisos
            }

            // Recorrer recursivamente los submenús
            foreach (ToolStripItem subItem in menuItem.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                {
                    bool subItemHabilitado = HabilitarMenuSegunPermisos(subMenuItem);
                    subMenuHabilitado = subMenuHabilitado || subItemHabilitado; // Actualiza el estado del menú padre
                }
            }

            // Habilita o deshabilita el menú padre según el estado de los submenús
            menuItem.Enabled = subMenuHabilitado;

            return subMenuHabilitado; // Devuelve el estado del menú padre
        }

        private void AddEvents(ToolStripMenuItem menuItem)
        {
            menuItem.MouseEnter += (sender, e) => MenuItem_MouseEnter(sender, e, menuItem);
            menuItem.MouseLeave += (sender, e) => MenuItem_MouseLeave(sender, e, menuItem);
            menuItem.DropDownOpened += (sender, e) => MenuItem_DropDownOpened(sender, e, menuItem);
            menuItem.DropDownClosed += (sender, e) => MenuItem_DropDownClosed(sender, e, menuItem);
            menuItem.Click += Module_Click;
        }

        private void MenuItem_MouseEnter(object sender, EventArgs e, ToolStripMenuItem menuItem)
        {
            menuItem.ForeColor = Color.Black;
        }

        private void MenuItem_MouseLeave(object sender, EventArgs e, ToolStripMenuItem menuItem)
        {
            if (!menuItem.DropDown.Visible)
            {
                menuItem.ForeColor = Color.White;
            }
        }

        private void MenuItem_DropDownOpened(object sender, EventArgs e, ToolStripMenuItem menuItem)
        {
            menuItem.ForeColor = Color.Black;
        }

        private void MenuItem_DropDownClosed(object sender, EventArgs e, ToolStripMenuItem menuItem)
        {
            menuItem.ForeColor = Color.White;
        }

        private void subItemGestionUsuarios_Click(object sender, EventArgs e)
        {
            FrmGestionUsuarios frmGestionUsuarios = new FrmGestionUsuarios();
            OpenChildForm(frmGestionUsuarios);
        }

        private void subItemGestionPerfiles_Click(object sender, EventArgs e)
        {
            FrmGestionPerfiles frmGestionPerfiles = new FrmGestionPerfiles();
            OpenChildForm(frmGestionPerfiles);
        }

        private void subItemGestionIdiomas_Click(object sender, EventArgs e)
        {

        }

        private void subItemCambiarClave_Click(object sender, EventArgs e)
        {
            FrmCambiarClave frmCambiarClave = new FrmCambiarClave();
            //OpenChildForm(frmCambiarClave);
            //frmCambiarClave.ShowDialog();
            if (frmCambiarClave.ShowDialog() == DialogResult.OK)
            {
                usuarioBLL.Logout();
                cambioClaveRealizado = true;
                this.Close();
            }
        }

        private void subItemLogout_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();

            if (!logoutFormOpened)
            {
                logoutFormOpened = true;

                FrmLogout frmLogout = new FrmLogout();

                if (frmLogout.ShowDialog() == DialogResult.OK)
                {
                    usuarioBLL.Logout();

                    this.Close();

                    FrmLogin frmLogin = new FrmLogin();
                    frmLogin.Show();
                }

                logoutFormOpened = false;
            }
        }

        private void subItemLogin_Click(object sender, EventArgs e)
        {
            /*if (!subItemLogin.Enabled)
                MessageBox.Show("No puedes iniciar sesión nuevamente porque ya tienes una sesión activa. Cierra la sesión actual para continuar.");*/
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();

            if(cambioClaveRealizado == true)
            {
                usuarioBLL.Logout();
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();
            }
            else
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    if (!logoutFormOpened)
                    {
                        using (FrmLogout frmLogout = new FrmLogout())
                        {
                            if (frmLogout.ShowDialog() != DialogResult.OK)
                            {
                                e.Cancel = true;
                            }
                            else
                            {
                                usuarioBLL.Logout();
                                FrmLogin frmLogin = new FrmLogin();
                                frmLogin.Show();
                            }
                        }
                    }
                }
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;

            childForm.MdiParent = this;

            childForm.Show();
        }

        private void subItemGenerarTicket_Click(object sender, EventArgs e)
        {
            FrmGenerarTicket frmGenerarTicket = new FrmGenerarTicket();
            OpenChildForm(frmGenerarTicket);
        }

        private void subItemCambiarIdioma_Click(object sender, EventArgs e)
        {
            FrmCambiarIdioma frmCambiarIdioma = new FrmCambiarIdioma();
            OpenChildForm(frmCambiarIdioma);
        }

        private void subItemClientes_Click(object sender, EventArgs e)
        {
            FrmClientes frmClientes = new FrmClientes();
            OpenChildForm(frmClientes);
        }

        private void subItemProveedores_Click(object sender, EventArgs e)
        {
            FrmProveedores f = new FrmProveedores();
            OpenChildForm(f);
        }

        private void subItemProductos_Click(object sender, EventArgs e)
        {
            FrmProductos frmProductos = new FrmProductos();
            OpenChildForm(frmProductos);
        }

        private void subItemCategorias_Click(object sender, EventArgs e)
        {
            FrmCategorias f = new FrmCategorias();
            OpenChildForm(f);
        }

        private void subItemTickets_Click(object sender, EventArgs e)
        {
            FrmTickets f = new FrmTickets();
            OpenChildForm(f);
        }

        private void subItemAuditoriaEventos_Click(object sender, EventArgs e)
        {
            FrmAuditoriaEventos f = new FrmAuditoriaEventos();
            OpenChildForm(f);
        }

        private void subItemGenerarSolicitudCotizacion_Click(object sender, EventArgs e)
        {
            FrmGenerarSolicitudCotizacion f = new FrmGenerarSolicitudCotizacion();
            OpenChildForm(f);
        }

        private void subItemGenerarOrdenCompra_Click(object sender, EventArgs e)
        {
            FrmGenerarOrdenCompra f = new FrmGenerarOrdenCompra();
            OpenChildForm(f);
        }

        private void subItemRecepcion_Click(object sender, EventArgs e)
        {
            FrmRecepcion f = new FrmRecepcion();
            OpenChildForm(f);
        }

        private void subItemRespaldos_Click(object sender, EventArgs e)
        {
            FrmRespaldos f = new FrmRespaldos();
            OpenChildForm(f);
        }

        private void subItemAuditoriaCambios_Click(object sender, EventArgs e)
        {
            FrmAuditoriaCambios f = new FrmAuditoriaCambios();
            OpenChildForm(f);
        }

        private void subItemOrdenes_Click(object sender, EventArgs e)
        {
            FrmOrdenes f = new FrmOrdenes();
            OpenChildForm(f);
        }

        private void subItemRotacionProductos_Click(object sender, EventArgs e)
        {
            FrmRotacionProductos f = new FrmRotacionProductos();
            OpenChildForm(f);
        }

        private void gestionUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmAyuda f = new FrmAyuda();
        }

        private void respaldosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAyuda f = new FrmAyuda("Respaldos");
            OpenChildForm(f);
        }
    }
}
