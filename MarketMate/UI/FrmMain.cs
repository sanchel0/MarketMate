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

namespace GUI
{
    public partial class FrmMain : Form
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

        public void ValidarForm()
        {
            this.subItemLogin.Enabled = !SessionManager.IsLogged();
            this.subItemLogout.Enabled = SessionManager.IsLogged();

            if (SessionManager.IsLogged())
                this.toolStripStatusLabel1.Text = $"[Usuario: {SessionManager.GetUser().Username}]";
            else
                this.toolStripStatusLabel1.Text = "[Sesión no iniciada]";

            this.itemAdmin.Enabled = SessionManager.IsInRole(Rol.Admin);
            this.itemMaestros.Enabled = SessionManager.IsInRole(Rol.Admin);
            this.itemUsuario.Enabled = SessionManager.IsInRole(Rol.Admin) || SessionManager.IsInRole(Rol.Cajero);
            this.itemVentas.Enabled = SessionManager.IsInRole(Rol.Cajero);
            this.itemCompras.Enabled = false;
            this.itemReportes.Enabled = false;
            this.itemAyuda.Enabled = false;
        }

        private void AddEvents(ToolStripMenuItem menuItem)
        {
            menuItem.MouseEnter += (sender, e) => MenuItem_MouseEnter(sender, e, menuItem);
            menuItem.MouseLeave += (sender, e) => MenuItem_MouseLeave(sender, e, menuItem);
            menuItem.DropDownOpened += (sender, e) => MenuItem_DropDownOpened(sender, e, menuItem);
            menuItem.DropDownClosed += (sender, e) => MenuItem_DropDownClosed(sender, e, menuItem);
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

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();

            if(cambioClaveRealizado == true)
            {
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
    }
}
