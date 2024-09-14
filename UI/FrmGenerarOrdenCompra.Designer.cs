namespace UI
{
    partial class FrmGenerarOrdenCompra
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
            this.dgvProdsOrden = new System.Windows.Forms.DataGridView();
            this.btnSeleccionarProd = new System.Windows.Forms.Button();
            this.cboNumSoli = new System.Windows.Forms.ComboBox();
            this.txtNumCoti = new System.Windows.Forms.TextBox();
            this.txtProvSelect = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblNumCoti = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.dgvProdsSoli = new System.Windows.Forms.DataGridView();
            this.lblProds = new System.Windows.Forms.Label();
            this.lblProdsSelect = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnRegistrarProv = new System.Windows.Forms.Button();
            this.btnProcesarPago = new System.Windows.Forms.Button();
            this.btnSeleccionarSoli = new System.Windows.Forms.Button();
            this.dgvProvs = new System.Windows.Forms.DataGridView();
            this.lblProvs = new System.Windows.Forms.Label();
            this.dtpFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.lblFechaEntrega = new System.Windows.Forms.Label();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.lblProvSelect = new System.Windows.Forms.Label();
            this.lblNumSolicitud = new System.Windows.Forms.Label();
            this.txtSolicitud = new System.Windows.Forms.TextBox();
            this.txtCant = new System.Windows.Forms.TextBox();
            this.lblCant = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdsOrden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdsSoli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProvs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProdsOrden
            // 
            this.dgvProdsOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdsOrden.Location = new System.Drawing.Point(398, 278);
            this.dgvProdsOrden.Name = "dgvProdsOrden";
            this.dgvProdsOrden.Size = new System.Drawing.Size(330, 150);
            this.dgvProdsOrden.TabIndex = 0;
            // 
            // btnSeleccionarProd
            // 
            this.btnSeleccionarProd.Location = new System.Drawing.Point(610, 204);
            this.btnSeleccionarProd.Name = "btnSeleccionarProd";
            this.btnSeleccionarProd.Size = new System.Drawing.Size(118, 23);
            this.btnSeleccionarProd.TabIndex = 1;
            this.btnSeleccionarProd.Text = "Seleccionar Producto";
            this.btnSeleccionarProd.UseVisualStyleBackColor = true;
            this.btnSeleccionarProd.Click += new System.EventHandler(this.btnSeleccionarProd_Click);
            // 
            // cboNumSoli
            // 
            this.cboNumSoli.FormattingEnabled = true;
            this.cboNumSoli.Location = new System.Drawing.Point(151, 63);
            this.cboNumSoli.Name = "cboNumSoli";
            this.cboNumSoli.Size = new System.Drawing.Size(200, 21);
            this.cboNumSoli.TabIndex = 2;
            this.cboNumSoli.SelectedIndexChanged += new System.EventHandler(this.cboNumSoli_SelectedIndexChanged);
            // 
            // txtNumCoti
            // 
            this.txtNumCoti.Location = new System.Drawing.Point(151, 138);
            this.txtNumCoti.Name = "txtNumCoti";
            this.txtNumCoti.Size = new System.Drawing.Size(200, 20);
            this.txtNumCoti.TabIndex = 3;
            // 
            // txtProvSelect
            // 
            this.txtProvSelect.Location = new System.Drawing.Point(38, 456);
            this.txtProvSelect.Name = "txtProvSelect";
            this.txtProvSelect.ReadOnly = true;
            this.txtProvSelect.Size = new System.Drawing.Size(186, 20);
            this.txtProvSelect.TabIndex = 4;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(485, 204);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 5;
            // 
            // lblNumCoti
            // 
            this.lblNumCoti.AutoSize = true;
            this.lblNumCoti.Location = new System.Drawing.Point(31, 141);
            this.lblNumCoti.Name = "lblNumCoti";
            this.lblNumCoti.Size = new System.Drawing.Size(114, 13);
            this.lblNumCoti.TabIndex = 6;
            this.lblNumCoti.Text = "Numero de Cotizacion:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(398, 207);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(81, 13);
            this.lblPrecio.TabIndex = 8;
            this.lblPrecio.Text = "Ingresar Precio:";
            // 
            // dgvProdsSoli
            // 
            this.dgvProdsSoli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdsSoli.Location = new System.Drawing.Point(398, 46);
            this.dgvProdsSoli.Name = "dgvProdsSoli";
            this.dgvProdsSoli.Size = new System.Drawing.Size(330, 150);
            this.dgvProdsSoli.TabIndex = 9;
            // 
            // lblProds
            // 
            this.lblProds.AutoSize = true;
            this.lblProds.Location = new System.Drawing.Point(395, 32);
            this.lblProds.Name = "lblProds";
            this.lblProds.Size = new System.Drawing.Size(113, 13);
            this.lblProds.TabIndex = 10;
            this.lblProds.Text = "Productos de Solicitud";
            // 
            // lblProdsSelect
            // 
            this.lblProdsSelect.AutoSize = true;
            this.lblProdsSelect.Location = new System.Drawing.Point(395, 262);
            this.lblProdsSelect.Name = "lblProdsSelect";
            this.lblProdsSelect.Size = new System.Drawing.Size(249, 13);
            this.lblProdsSelect.TabIndex = 11;
            this.lblProdsSelect.Text = "Productos Seleccionados para la Orden de Compra";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(637, 434);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(91, 23);
            this.btnQuitar.TabIndex = 12;
            this.btnQuitar.Text = "Quitar Producto";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnRegistrarProv
            // 
            this.btnRegistrarProv.Location = new System.Drawing.Point(257, 440);
            this.btnRegistrarProv.Name = "btnRegistrarProv";
            this.btnRegistrarProv.Size = new System.Drawing.Size(105, 35);
            this.btnRegistrarProv.TabIndex = 13;
            this.btnRegistrarProv.Text = "Completar Registro de Proveedor";
            this.btnRegistrarProv.UseVisualStyleBackColor = true;
            this.btnRegistrarProv.Click += new System.EventHandler(this.btnRegistrarProv_Click);
            // 
            // btnProcesarPago
            // 
            this.btnProcesarPago.Location = new System.Drawing.Point(559, 480);
            this.btnProcesarPago.Name = "btnProcesarPago";
            this.btnProcesarPago.Size = new System.Drawing.Size(88, 23);
            this.btnProcesarPago.TabIndex = 14;
            this.btnProcesarPago.Text = "Procesar Pago";
            this.btnProcesarPago.UseVisualStyleBackColor = true;
            this.btnProcesarPago.Click += new System.EventHandler(this.btnProcesarPago_Click);
            // 
            // btnSeleccionarSoli
            // 
            this.btnSeleccionarSoli.Location = new System.Drawing.Point(220, 99);
            this.btnSeleccionarSoli.Name = "btnSeleccionarSoli";
            this.btnSeleccionarSoli.Size = new System.Drawing.Size(131, 23);
            this.btnSeleccionarSoli.TabIndex = 15;
            this.btnSeleccionarSoli.Text = "Seleccionar Solicitud";
            this.btnSeleccionarSoli.UseVisualStyleBackColor = true;
            this.btnSeleccionarSoli.Click += new System.EventHandler(this.btnSeleccionarSoli_Click);
            // 
            // dgvProvs
            // 
            this.dgvProvs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProvs.Location = new System.Drawing.Point(32, 278);
            this.dgvProvs.Name = "dgvProvs";
            this.dgvProvs.Size = new System.Drawing.Size(330, 150);
            this.dgvProvs.TabIndex = 16;
            this.dgvProvs.SelectionChanged += new System.EventHandler(this.dgvProvs_SelectionChanged);
            // 
            // lblProvs
            // 
            this.lblProvs.AutoSize = true;
            this.lblProvs.Location = new System.Drawing.Point(32, 262);
            this.lblProvs.Name = "lblProvs";
            this.lblProvs.Size = new System.Drawing.Size(125, 13);
            this.lblProvs.TabIndex = 17;
            this.lblProvs.Text = "Proveedores de Solicitud";
            // 
            // dtpFechaEntrega
            // 
            this.dtpFechaEntrega.Location = new System.Drawing.Point(151, 176);
            this.dtpFechaEntrega.Name = "dtpFechaEntrega";
            this.dtpFechaEntrega.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaEntrega.TabIndex = 18;
            // 
            // lblFechaEntrega
            // 
            this.lblFechaEntrega.AutoSize = true;
            this.lblFechaEntrega.Location = new System.Drawing.Point(50, 176);
            this.lblFechaEntrega.Name = "lblFechaEntrega";
            this.lblFechaEntrega.Size = new System.Drawing.Size(95, 13);
            this.lblFechaEntrega.TabIndex = 19;
            this.lblFechaEntrega.Text = "Fecha de Entrega:";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(653, 480);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizar.TabIndex = 20;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // lblProvSelect
            // 
            this.lblProvSelect.AutoSize = true;
            this.lblProvSelect.Location = new System.Drawing.Point(35, 440);
            this.lblProvSelect.Name = "lblProvSelect";
            this.lblProvSelect.Size = new System.Drawing.Size(124, 13);
            this.lblProvSelect.TabIndex = 21;
            this.lblProvSelect.Text = "Proveedor Seleccionado";
            // 
            // lblNumSolicitud
            // 
            this.lblNumSolicitud.AutoSize = true;
            this.lblNumSolicitud.Location = new System.Drawing.Point(40, 66);
            this.lblNumSolicitud.Name = "lblNumSolicitud";
            this.lblNumSolicitud.Size = new System.Drawing.Size(105, 13);
            this.lblNumSolicitud.TabIndex = 23;
            this.lblNumSolicitud.Text = "Numero de Solicitud:";
            // 
            // txtSolicitud
            // 
            this.txtSolicitud.Location = new System.Drawing.Point(344, 527);
            this.txtSolicitud.Name = "txtSolicitud";
            this.txtSolicitud.Size = new System.Drawing.Size(200, 20);
            this.txtSolicitud.TabIndex = 22;
            // 
            // txtCant
            // 
            this.txtCant.Location = new System.Drawing.Point(485, 230);
            this.txtCant.Name = "txtCant";
            this.txtCant.Size = new System.Drawing.Size(100, 20);
            this.txtCant.TabIndex = 25;
            // 
            // lblCant
            // 
            this.lblCant.AutoSize = true;
            this.lblCant.Location = new System.Drawing.Point(427, 232);
            this.lblCant.Name = "lblCant";
            this.lblCant.Size = new System.Drawing.Size(52, 13);
            this.lblCant.TabIndex = 24;
            this.lblCant.Text = "Cantidad:";
            // 
            // FrmGenerarOrdenCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 559);
            this.Controls.Add(this.txtCant);
            this.Controls.Add(this.lblCant);
            this.Controls.Add(this.lblNumSolicitud);
            this.Controls.Add(this.txtSolicitud);
            this.Controls.Add(this.lblProvSelect);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.lblFechaEntrega);
            this.Controls.Add(this.dtpFechaEntrega);
            this.Controls.Add(this.lblProvs);
            this.Controls.Add(this.dgvProvs);
            this.Controls.Add(this.btnSeleccionarSoli);
            this.Controls.Add(this.btnProcesarPago);
            this.Controls.Add(this.btnRegistrarProv);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.lblProdsSelect);
            this.Controls.Add(this.lblProds);
            this.Controls.Add(this.dgvProdsSoli);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblNumCoti);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtProvSelect);
            this.Controls.Add(this.txtNumCoti);
            this.Controls.Add(this.cboNumSoli);
            this.Controls.Add(this.btnSeleccionarProd);
            this.Controls.Add(this.dgvProdsOrden);
            this.Name = "FrmGenerarOrdenCompra";
            this.Text = "FrmGenerarOrdenCompra";
            this.Load += new System.EventHandler(this.FrmGenerarOrdenCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdsOrden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdsSoli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProvs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProdsOrden;
        private System.Windows.Forms.Button btnSeleccionarProd;
        private System.Windows.Forms.ComboBox cboNumSoli;
        private System.Windows.Forms.TextBox txtNumCoti;
        private System.Windows.Forms.TextBox txtProvSelect;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblNumCoti;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.DataGridView dgvProdsSoli;
        private System.Windows.Forms.Label lblProds;
        private System.Windows.Forms.Label lblProdsSelect;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnRegistrarProv;
        private System.Windows.Forms.Button btnProcesarPago;
        private System.Windows.Forms.Button btnSeleccionarSoli;
        private System.Windows.Forms.DataGridView dgvProvs;
        private System.Windows.Forms.Label lblProvs;
        private System.Windows.Forms.DateTimePicker dtpFechaEntrega;
        private System.Windows.Forms.Label lblFechaEntrega;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Label lblProvSelect;
        private System.Windows.Forms.Label lblNumSolicitud;
        private System.Windows.Forms.TextBox txtSolicitud;
        private System.Windows.Forms.TextBox txtCant;
        private System.Windows.Forms.Label lblCant;
    }
}