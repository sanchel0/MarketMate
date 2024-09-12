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
            this.btnAsignarPrecio = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtNumCoti = new System.Windows.Forms.TextBox();
            this.txtCiut = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblNumCoti = new System.Windows.Forms.Label();
            this.lblCuit = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.dgvProdsCoti = new System.Windows.Forms.DataGridView();
            this.lblProds = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnRegistrarProv = new System.Windows.Forms.Button();
            this.btnProcesarPago = new System.Windows.Forms.Button();
            this.btnSelectCoti = new System.Windows.Forms.Button();
            this.dgvProvs = new System.Windows.Forms.DataGridView();
            this.lblProvs = new System.Windows.Forms.Label();
            this.dtpFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.lblFechaEntrega = new System.Windows.Forms.Label();
            this.btnFinalizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdsOrden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdsCoti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProvs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProdsOrden
            // 
            this.dgvProdsOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdsOrden.Location = new System.Drawing.Point(381, 103);
            this.dgvProdsOrden.Name = "dgvProdsOrden";
            this.dgvProdsOrden.Size = new System.Drawing.Size(318, 150);
            this.dgvProdsOrden.TabIndex = 0;
            // 
            // btnAsignarPrecio
            // 
            this.btnAsignarPrecio.Location = new System.Drawing.Point(274, 257);
            this.btnAsignarPrecio.Name = "btnAsignarPrecio";
            this.btnAsignarPrecio.Size = new System.Drawing.Size(91, 23);
            this.btnAsignarPrecio.TabIndex = 1;
            this.btnAsignarPrecio.Text = "Asignar Precio";
            this.btnAsignarPrecio.UseVisualStyleBackColor = true;
            this.btnAsignarPrecio.Click += new System.EventHandler(this.btnAsignarPrecio_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(411, 274);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // txtNumCoti
            // 
            this.txtNumCoti.Location = new System.Drawing.Point(152, 43);
            this.txtNumCoti.Name = "txtNumCoti";
            this.txtNumCoti.Size = new System.Drawing.Size(100, 20);
            this.txtNumCoti.TabIndex = 3;
            // 
            // txtCiut
            // 
            this.txtCiut.Location = new System.Drawing.Point(488, 393);
            this.txtCiut.Name = "txtCiut";
            this.txtCiut.Size = new System.Drawing.Size(100, 20);
            this.txtCiut.TabIndex = 4;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(122, 259);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 5;
            // 
            // lblNumCoti
            // 
            this.lblNumCoti.AutoSize = true;
            this.lblNumCoti.Location = new System.Drawing.Point(32, 46);
            this.lblNumCoti.Name = "lblNumCoti";
            this.lblNumCoti.Size = new System.Drawing.Size(114, 13);
            this.lblNumCoti.TabIndex = 6;
            this.lblNumCoti.Text = "Numero de Cotizacion:";
            // 
            // lblCuit
            // 
            this.lblCuit.AutoSize = true;
            this.lblCuit.Location = new System.Drawing.Point(378, 396);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(104, 13);
            this.lblCuit.TabIndex = 7;
            this.lblCuit.Text = "CUIT del Proveedor:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(35, 262);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(81, 13);
            this.lblPrecio.TabIndex = 8;
            this.lblPrecio.Text = "Ingresar Precio:";
            // 
            // dgvProdsCoti
            // 
            this.dgvProdsCoti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdsCoti.Location = new System.Drawing.Point(35, 101);
            this.dgvProdsCoti.Name = "dgvProdsCoti";
            this.dgvProdsCoti.Size = new System.Drawing.Size(330, 150);
            this.dgvProdsCoti.TabIndex = 9;
            // 
            // lblProds
            // 
            this.lblProds.AutoSize = true;
            this.lblProds.Location = new System.Drawing.Point(32, 87);
            this.lblProds.Name = "lblProds";
            this.lblProds.Size = new System.Drawing.Size(122, 13);
            this.lblProds.TabIndex = 10;
            this.lblProds.Text = "Productos de Cotizacion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(378, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Productos de Orden";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(608, 259);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(91, 23);
            this.btnQuitar.TabIndex = 12;
            this.btnQuitar.Text = "Quitar Producto";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnRegistrarProv
            // 
            this.btnRegistrarProv.Location = new System.Drawing.Point(437, 385);
            this.btnRegistrarProv.Name = "btnRegistrarProv";
            this.btnRegistrarProv.Size = new System.Drawing.Size(105, 35);
            this.btnRegistrarProv.TabIndex = 13;
            this.btnRegistrarProv.Text = "Completar Registro de Proveedor";
            this.btnRegistrarProv.UseVisualStyleBackColor = true;
            this.btnRegistrarProv.Click += new System.EventHandler(this.btnRegistrarProv_Click);
            // 
            // btnProcesarPago
            // 
            this.btnProcesarPago.Location = new System.Drawing.Point(530, 441);
            this.btnProcesarPago.Name = "btnProcesarPago";
            this.btnProcesarPago.Size = new System.Drawing.Size(88, 23);
            this.btnProcesarPago.TabIndex = 14;
            this.btnProcesarPago.Text = "Procesar Pago";
            this.btnProcesarPago.UseVisualStyleBackColor = true;
            this.btnProcesarPago.Click += new System.EventHandler(this.btnProcesarPago_Click);
            // 
            // btnSelectCoti
            // 
            this.btnSelectCoti.Location = new System.Drawing.Point(258, 35);
            this.btnSelectCoti.Name = "btnSelectCoti";
            this.btnSelectCoti.Size = new System.Drawing.Size(76, 38);
            this.btnSelectCoti.TabIndex = 15;
            this.btnSelectCoti.Text = "Seleccionar Cotizacion";
            this.btnSelectCoti.UseVisualStyleBackColor = true;
            // 
            // dgvProvs
            // 
            this.dgvProvs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProvs.Location = new System.Drawing.Point(38, 314);
            this.dgvProvs.Name = "dgvProvs";
            this.dgvProvs.Size = new System.Drawing.Size(327, 150);
            this.dgvProvs.TabIndex = 16;
            // 
            // lblProvs
            // 
            this.lblProvs.AutoSize = true;
            this.lblProvs.Location = new System.Drawing.Point(35, 298);
            this.lblProvs.Name = "lblProvs";
            this.lblProvs.Size = new System.Drawing.Size(67, 13);
            this.lblProvs.TabIndex = 17;
            this.lblProvs.Text = "Proveedores";
            // 
            // dtpFechaEntrega
            // 
            this.dtpFechaEntrega.Location = new System.Drawing.Point(488, 43);
            this.dtpFechaEntrega.Name = "dtpFechaEntrega";
            this.dtpFechaEntrega.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaEntrega.TabIndex = 18;
            // 
            // lblFechaEntrega
            // 
            this.lblFechaEntrega.AutoSize = true;
            this.lblFechaEntrega.Location = new System.Drawing.Point(378, 46);
            this.lblFechaEntrega.Name = "lblFechaEntrega";
            this.lblFechaEntrega.Size = new System.Drawing.Size(95, 13);
            this.lblFechaEntrega.TabIndex = 19;
            this.lblFechaEntrega.Text = "Fecha de Entrega:";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(624, 441);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizar.TabIndex = 20;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // FrmGenerarOrdenCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 489);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.lblFechaEntrega);
            this.Controls.Add(this.dtpFechaEntrega);
            this.Controls.Add(this.lblProvs);
            this.Controls.Add(this.dgvProvs);
            this.Controls.Add(this.btnSelectCoti);
            this.Controls.Add(this.btnProcesarPago);
            this.Controls.Add(this.btnRegistrarProv);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProds);
            this.Controls.Add(this.dgvProdsCoti);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblCuit);
            this.Controls.Add(this.lblNumCoti);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtCiut);
            this.Controls.Add(this.txtNumCoti);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnAsignarPrecio);
            this.Controls.Add(this.dgvProdsOrden);
            this.Name = "FrmGenerarOrdenCompra";
            this.Text = "FrmGenerarOrdenCompra";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdsOrden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdsCoti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProvs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProdsOrden;
        private System.Windows.Forms.Button btnAsignarPrecio;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtNumCoti;
        private System.Windows.Forms.TextBox txtCiut;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblNumCoti;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.DataGridView dgvProdsCoti;
        private System.Windows.Forms.Label lblProds;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnRegistrarProv;
        private System.Windows.Forms.Button btnProcesarPago;
        private System.Windows.Forms.Button btnSelectCoti;
        private System.Windows.Forms.DataGridView dgvProvs;
        private System.Windows.Forms.Label lblProvs;
        private System.Windows.Forms.DateTimePicker dtpFechaEntrega;
        private System.Windows.Forms.Label lblFechaEntrega;
        private System.Windows.Forms.Button btnFinalizar;
    }
}