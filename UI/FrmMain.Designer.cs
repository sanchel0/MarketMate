namespace GUI
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.itemAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemGestionUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemGestionPerfiles = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemAuditoriaEventos = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemRespaldos = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMaestros = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemInventario = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemCategorias = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemMarcas = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.itemUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemCambiarClave = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemCambiarIdioma = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.itemVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemGenerarTicket = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemGenerarSolicitudCotizacion = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemGenerarOrdenCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemRecepcion = new System.Windows.Forms.ToolStripMenuItem();
            this.itemReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemTickets = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.ssrUsername = new System.Windows.Forms.StatusStrip();
            this.ssrLabelUsername = new System.Windows.Forms.ToolStripStatusLabel();
            this.subItemAuditoriaCambios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsMain.SuspendLayout();
            this.ssrUsername.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsMain
            // 
            this.mnsMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.mnsMain.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemAdmin,
            this.itemMaestros,
            this.itemUsuario,
            this.itemVentas,
            this.itemCompras,
            this.itemReportes,
            this.itemAyuda});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Padding = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.mnsMain.Size = new System.Drawing.Size(1336, 36);
            this.mnsMain.TabIndex = 0;
            this.mnsMain.Text = "menuStrip1";
            // 
            // itemAdmin
            // 
            this.itemAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subItemGestionUsuarios,
            this.subItemGestionPerfiles,
            this.subItemAuditoriaEventos,
            this.subItemRespaldos});
            this.itemAdmin.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.itemAdmin.ForeColor = System.Drawing.Color.White;
            this.itemAdmin.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.itemAdmin.Margin = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.itemAdmin.Name = "itemAdmin";
            this.itemAdmin.Size = new System.Drawing.Size(65, 24);
            this.itemAdmin.Text = "Admin";
            // 
            // subItemGestionUsuarios
            // 
            this.subItemGestionUsuarios.AutoSize = false;
            this.subItemGestionUsuarios.BackColor = System.Drawing.Color.White;
            this.subItemGestionUsuarios.ForeColor = System.Drawing.Color.Black;
            this.subItemGestionUsuarios.Name = "subItemGestionUsuarios";
            this.subItemGestionUsuarios.Padding = new System.Windows.Forms.Padding(0);
            this.subItemGestionUsuarios.Size = new System.Drawing.Size(189, 24);
            this.subItemGestionUsuarios.Text = "Gestion Usuarios";
            this.subItemGestionUsuarios.Click += new System.EventHandler(this.subItemGestionUsuarios_Click);
            // 
            // subItemGestionPerfiles
            // 
            this.subItemGestionPerfiles.Name = "subItemGestionPerfiles";
            this.subItemGestionPerfiles.Size = new System.Drawing.Size(218, 24);
            this.subItemGestionPerfiles.Text = "Gestion Perfiles";
            this.subItemGestionPerfiles.Click += new System.EventHandler(this.subItemGestionPerfiles_Click);
            // 
            // subItemAuditoriaEventos
            // 
            this.subItemAuditoriaEventos.Name = "subItemAuditoriaEventos";
            this.subItemAuditoriaEventos.Size = new System.Drawing.Size(218, 24);
            this.subItemAuditoriaEventos.Text = "Auditoria De Eventos";
            this.subItemAuditoriaEventos.Click += new System.EventHandler(this.subItemAuditoriaEventos_Click);
            // 
            // subItemRespaldos
            // 
            this.subItemRespaldos.Name = "subItemRespaldos";
            this.subItemRespaldos.Size = new System.Drawing.Size(218, 24);
            this.subItemRespaldos.Text = "Respaldos";
            this.subItemRespaldos.Click += new System.EventHandler(this.subItemRespaldos_Click);
            // 
            // itemMaestros
            // 
            this.itemMaestros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subItemClientes,
            this.subItemInventario,
            this.subItemProveedores,
            this.subItemAuditoriaCambios});
            this.itemMaestros.ForeColor = System.Drawing.Color.White;
            this.itemMaestros.Margin = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.itemMaestros.Name = "itemMaestros";
            this.itemMaestros.Size = new System.Drawing.Size(81, 24);
            this.itemMaestros.Text = "Maestros";
            // 
            // subItemClientes
            // 
            this.subItemClientes.Name = "subItemClientes";
            this.subItemClientes.Size = new System.Drawing.Size(225, 24);
            this.subItemClientes.Text = "Clientes";
            this.subItemClientes.Click += new System.EventHandler(this.subItemClientes_Click);
            // 
            // subItemInventario
            // 
            this.subItemInventario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subItemProductos,
            this.subItemCategorias,
            this.subItemMarcas});
            this.subItemInventario.Name = "subItemInventario";
            this.subItemInventario.Size = new System.Drawing.Size(225, 24);
            this.subItemInventario.Text = "Inventario";
            // 
            // subItemProductos
            // 
            this.subItemProductos.Name = "subItemProductos";
            this.subItemProductos.Size = new System.Drawing.Size(180, 24);
            this.subItemProductos.Text = "Productos";
            this.subItemProductos.Click += new System.EventHandler(this.subItemProductos_Click);
            // 
            // subItemCategorias
            // 
            this.subItemCategorias.Name = "subItemCategorias";
            this.subItemCategorias.Size = new System.Drawing.Size(180, 24);
            this.subItemCategorias.Text = "Categorias";
            this.subItemCategorias.Click += new System.EventHandler(this.subItemCategorias_Click);
            // 
            // subItemMarcas
            // 
            this.subItemMarcas.Name = "subItemMarcas";
            this.subItemMarcas.Size = new System.Drawing.Size(180, 24);
            this.subItemMarcas.Text = "Marcas";
            this.subItemMarcas.Click += new System.EventHandler(this.subItemMarcas_Click);
            // 
            // subItemProveedores
            // 
            this.subItemProveedores.Name = "subItemProveedores";
            this.subItemProveedores.Size = new System.Drawing.Size(225, 24);
            this.subItemProveedores.Text = "Proveedores";
            this.subItemProveedores.Click += new System.EventHandler(this.subItemProveedores_Click);
            // 
            // itemUsuario
            // 
            this.itemUsuario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subItemCambiarClave,
            this.subItemCambiarIdioma,
            this.subItemLogout,
            this.subItemLogin});
            this.itemUsuario.ForeColor = System.Drawing.Color.White;
            this.itemUsuario.Margin = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.itemUsuario.Name = "itemUsuario";
            this.itemUsuario.Size = new System.Drawing.Size(71, 24);
            this.itemUsuario.Text = "Usuario";
            // 
            // subItemCambiarClave
            // 
            this.subItemCambiarClave.Name = "subItemCambiarClave";
            this.subItemCambiarClave.Size = new System.Drawing.Size(185, 24);
            this.subItemCambiarClave.Text = "Cambiar Clave";
            this.subItemCambiarClave.Click += new System.EventHandler(this.subItemCambiarClave_Click);
            // 
            // subItemCambiarIdioma
            // 
            this.subItemCambiarIdioma.Name = "subItemCambiarIdioma";
            this.subItemCambiarIdioma.Size = new System.Drawing.Size(185, 24);
            this.subItemCambiarIdioma.Text = "Cambiar Idioma";
            this.subItemCambiarIdioma.Click += new System.EventHandler(this.subItemCambiarIdioma_Click);
            // 
            // subItemLogout
            // 
            this.subItemLogout.Name = "subItemLogout";
            this.subItemLogout.Size = new System.Drawing.Size(185, 24);
            this.subItemLogout.Text = "Logout";
            this.subItemLogout.Click += new System.EventHandler(this.subItemLogout_Click);
            // 
            // subItemLogin
            // 
            this.subItemLogin.Name = "subItemLogin";
            this.subItemLogin.Size = new System.Drawing.Size(185, 24);
            this.subItemLogin.Text = "Login";
            this.subItemLogin.Click += new System.EventHandler(this.subItemLogin_Click);
            // 
            // itemVentas
            // 
            this.itemVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subItemGenerarTicket});
            this.itemVentas.ForeColor = System.Drawing.Color.White;
            this.itemVentas.Margin = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.itemVentas.Name = "itemVentas";
            this.itemVentas.Size = new System.Drawing.Size(64, 24);
            this.itemVentas.Text = "Ventas";
            // 
            // subItemGenerarTicket
            // 
            this.subItemGenerarTicket.ForeColor = System.Drawing.Color.Black;
            this.subItemGenerarTicket.Name = "subItemGenerarTicket";
            this.subItemGenerarTicket.Size = new System.Drawing.Size(173, 24);
            this.subItemGenerarTicket.Text = "Generar Ticket";
            this.subItemGenerarTicket.Click += new System.EventHandler(this.subItemGenerarTicket_Click);
            // 
            // itemCompras
            // 
            this.itemCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subItemGenerarSolicitudCotizacion,
            this.subItemGenerarOrdenCompra,
            this.subItemRecepcion});
            this.itemCompras.ForeColor = System.Drawing.Color.White;
            this.itemCompras.Margin = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.itemCompras.Name = "itemCompras";
            this.itemCompras.Size = new System.Drawing.Size(80, 24);
            this.itemCompras.Text = "Compras";
            // 
            // subItemGenerarSolicitudCotizacion
            // 
            this.subItemGenerarSolicitudCotizacion.Name = "subItemGenerarSolicitudCotizacion";
            this.subItemGenerarSolicitudCotizacion.Size = new System.Drawing.Size(266, 24);
            this.subItemGenerarSolicitudCotizacion.Text = "Generar Solicitud Cotizacion";
            this.subItemGenerarSolicitudCotizacion.Click += new System.EventHandler(this.subItemGenerarSolicitudCotizacion_Click);
            // 
            // subItemGenerarOrdenCompra
            // 
            this.subItemGenerarOrdenCompra.Name = "subItemGenerarOrdenCompra";
            this.subItemGenerarOrdenCompra.Size = new System.Drawing.Size(266, 24);
            this.subItemGenerarOrdenCompra.Text = "Generar Orden de Compra";
            this.subItemGenerarOrdenCompra.Click += new System.EventHandler(this.subItemGenerarOrdenCompra_Click);
            // 
            // subItemRecepcion
            // 
            this.subItemRecepcion.Name = "subItemRecepcion";
            this.subItemRecepcion.Size = new System.Drawing.Size(266, 24);
            this.subItemRecepcion.Text = "Recepcion";
            this.subItemRecepcion.Click += new System.EventHandler(this.subItemRecepcion_Click);
            // 
            // itemReportes
            // 
            this.itemReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subItemTickets});
            this.itemReportes.ForeColor = System.Drawing.Color.White;
            this.itemReportes.Margin = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.itemReportes.Name = "itemReportes";
            this.itemReportes.Size = new System.Drawing.Size(80, 24);
            this.itemReportes.Text = "Reportes";
            // 
            // subItemTickets
            // 
            this.subItemTickets.Name = "subItemTickets";
            this.subItemTickets.Size = new System.Drawing.Size(123, 24);
            this.subItemTickets.Text = "Tickets";
            this.subItemTickets.Click += new System.EventHandler(this.subItemTickets_Click);
            // 
            // itemAyuda
            // 
            this.itemAyuda.ForeColor = System.Drawing.Color.White;
            this.itemAyuda.Margin = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.itemAyuda.Name = "itemAyuda";
            this.itemAyuda.Size = new System.Drawing.Size(63, 24);
            this.itemAyuda.Text = "Ayuda";
            // 
            // ssrUsername
            // 
            this.ssrUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.ssrUsername.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssrLabelUsername});
            this.ssrUsername.Location = new System.Drawing.Point(0, 704);
            this.ssrUsername.Name = "ssrUsername";
            this.ssrUsername.Size = new System.Drawing.Size(1336, 22);
            this.ssrUsername.TabIndex = 2;
            this.ssrUsername.Text = "statusStrip1";
            // 
            // ssrLabelUsername
            // 
            this.ssrLabelUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.ssrLabelUsername.Name = "ssrLabelUsername";
            this.ssrLabelUsername.Size = new System.Drawing.Size(38, 17);
            this.ssrLabelUsername.Text = "status";
            // 
            // subItemAuditoriaCambios
            // 
            this.subItemAuditoriaCambios.Name = "subItemAuditoriaCambios";
            this.subItemAuditoriaCambios.Size = new System.Drawing.Size(225, 24);
            this.subItemAuditoriaCambios.Text = "Auditoria De Cambios";
            this.subItemAuditoriaCambios.Click += new System.EventHandler(this.subItemAuditoriaCambios_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(1336, 726);
            this.Controls.Add(this.ssrUsername);
            this.Controls.Add(this.mnsMain);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnsMain;
            this.Name = "FrmMain";
            this.Text = "MarketMate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.ssrUsername.ResumeLayout(false);
            this.ssrUsername.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem itemReportes;
        private System.Windows.Forms.ToolStripMenuItem itemAyuda;
        private System.Windows.Forms.ToolStripMenuItem itemAdmin;
        private System.Windows.Forms.ToolStripMenuItem subItemGestionUsuarios;
        private System.Windows.Forms.ToolStripMenuItem itemMaestros;
        private System.Windows.Forms.ToolStripMenuItem itemUsuario;
        private System.Windows.Forms.ToolStripMenuItem itemVentas;
        private System.Windows.Forms.ToolStripMenuItem subItemGenerarTicket;
        private System.Windows.Forms.ToolStripMenuItem itemCompras;
        private System.Windows.Forms.ToolStripMenuItem subItemGestionPerfiles;
        private System.Windows.Forms.ToolStripMenuItem subItemClientes;
        private System.Windows.Forms.ToolStripMenuItem subItemProveedores;
        private System.Windows.Forms.ToolStripMenuItem subItemCambiarClave;
        private System.Windows.Forms.ToolStripMenuItem subItemCambiarIdioma;
        private System.Windows.Forms.ToolStripMenuItem subItemLogout;
        private System.Windows.Forms.ToolStripMenuItem subItemLogin;
        private System.Windows.Forms.StatusStrip ssrUsername;
        private System.Windows.Forms.ToolStripStatusLabel ssrLabelUsername;
        private System.Windows.Forms.ToolStripMenuItem subItemInventario;
        private System.Windows.Forms.ToolStripMenuItem subItemProductos;
        private System.Windows.Forms.ToolStripMenuItem subItemCategorias;
        private System.Windows.Forms.ToolStripMenuItem subItemMarcas;
        private System.Windows.Forms.ToolStripMenuItem subItemTickets;
        private System.Windows.Forms.ToolStripMenuItem subItemAuditoriaEventos;
        private System.Windows.Forms.ToolStripMenuItem subItemGenerarSolicitudCotizacion;
        private System.Windows.Forms.ToolStripMenuItem subItemGenerarOrdenCompra;
        private System.Windows.Forms.ToolStripMenuItem subItemRecepcion;
        private System.Windows.Forms.ToolStripMenuItem subItemRespaldos;
        private System.Windows.Forms.ToolStripMenuItem subItemAuditoriaCambios;
    }
}

