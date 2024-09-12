namespace UI
{
    partial class FrmGenerarSolicitudCotizacion
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
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.btnSeleccionarProd = new System.Windows.Forms.Button();
            this.btnRegistroInicial = new System.Windows.Forms.Button();
            this.btnProcesarPago = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblProd = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCant = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvProductosSeleccionados = new System.Windows.Forms.DataGridView();
            this.btnQuitarProd = new System.Windows.Forms.Button();
            this.lblProv = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosSeleccionados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(30, 28);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(294, 150);
            this.dgvProductos.TabIndex = 0;
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Location = new System.Drawing.Point(402, 28);
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.Size = new System.Drawing.Size(279, 212);
            this.dgvProveedores.TabIndex = 1;
            // 
            // btnSeleccionarProd
            // 
            this.btnSeleccionarProd.Location = new System.Drawing.Point(205, 184);
            this.btnSeleccionarProd.Name = "btnSeleccionarProd";
            this.btnSeleccionarProd.Size = new System.Drawing.Size(119, 23);
            this.btnSeleccionarProd.TabIndex = 2;
            this.btnSeleccionarProd.Text = "Seleccionar Producto";
            this.btnSeleccionarProd.UseVisualStyleBackColor = true;
            this.btnSeleccionarProd.Click += new System.EventHandler(this.btnSeleccionarProd_Click);
            // 
            // btnRegistroInicial
            // 
            this.btnRegistroInicial.Location = new System.Drawing.Point(588, 246);
            this.btnRegistroInicial.Name = "btnRegistroInicial";
            this.btnRegistroInicial.Size = new System.Drawing.Size(93, 42);
            this.btnRegistroInicial.TabIndex = 3;
            this.btnRegistroInicial.Text = "Registro Inicial de Proveedor";
            this.btnRegistroInicial.UseVisualStyleBackColor = true;
            this.btnRegistroInicial.Click += new System.EventHandler(this.btnRegistroInicial_Click);
            // 
            // btnProcesarPago
            // 
            this.btnProcesarPago.Location = new System.Drawing.Point(515, 425);
            this.btnProcesarPago.Name = "btnProcesarPago";
            this.btnProcesarPago.Size = new System.Drawing.Size(85, 23);
            this.btnProcesarPago.TabIndex = 4;
            this.btnProcesarPago.Text = "Procesar Pago";
            this.btnProcesarPago.UseVisualStyleBackColor = true;
            this.btnProcesarPago.Click += new System.EventHandler(this.btnProcesarPago_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(606, 425);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblProd
            // 
            this.lblProd.AutoSize = true;
            this.lblProd.Location = new System.Drawing.Point(27, 12);
            this.lblProd.Name = "lblProd";
            this.lblProd.Size = new System.Drawing.Size(55, 13);
            this.lblProd.TabIndex = 6;
            this.lblProd.Text = "Productos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Productos Seleccionados";
            // 
            // lblCant
            // 
            this.lblCant.AutoSize = true;
            this.lblCant.Location = new System.Drawing.Point(27, 188);
            this.lblCant.Name = "lblCant";
            this.lblCant.Size = new System.Drawing.Size(52, 13);
            this.lblCant.TabIndex = 8;
            this.lblCant.Text = "Cantidad:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 186);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 9;
            // 
            // dgvProductosSeleccionados
            // 
            this.dgvProductosSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductosSeleccionados.Location = new System.Drawing.Point(30, 243);
            this.dgvProductosSeleccionados.Name = "dgvProductosSeleccionados";
            this.dgvProductosSeleccionados.Size = new System.Drawing.Size(294, 150);
            this.dgvProductosSeleccionados.TabIndex = 10;
            // 
            // btnQuitarProd
            // 
            this.btnQuitarProd.Location = new System.Drawing.Point(30, 399);
            this.btnQuitarProd.Name = "btnQuitarProd";
            this.btnQuitarProd.Size = new System.Drawing.Size(92, 23);
            this.btnQuitarProd.TabIndex = 11;
            this.btnQuitarProd.Text = "Quitar Producto";
            this.btnQuitarProd.UseVisualStyleBackColor = true;
            this.btnQuitarProd.Click += new System.EventHandler(this.btnQuitarProd_Click);
            // 
            // lblProv
            // 
            this.lblProv.AutoSize = true;
            this.lblProv.Location = new System.Drawing.Point(399, 9);
            this.lblProv.Name = "lblProv";
            this.lblProv.Size = new System.Drawing.Size(67, 13);
            this.lblProv.TabIndex = 12;
            this.lblProv.Text = "Proveedores";
            // 
            // FrmGenerarSolicitudCotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 484);
            this.Controls.Add(this.lblProv);
            this.Controls.Add(this.btnQuitarProd);
            this.Controls.Add(this.dgvProductosSeleccionados);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblCant);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblProd);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnProcesarPago);
            this.Controls.Add(this.btnRegistroInicial);
            this.Controls.Add(this.btnSeleccionarProd);
            this.Controls.Add(this.dgvProveedores);
            this.Controls.Add(this.dgvProductos);
            this.Name = "FrmGenerarSolicitudCotizacion";
            this.Text = "FrmGenerarSolicitudCotizacion";
            this.Load += new System.EventHandler(this.FrmGenerarSolicitudCotizacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosSeleccionados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.Button btnSeleccionarProd;
        private System.Windows.Forms.Button btnRegistroInicial;
        private System.Windows.Forms.Button btnProcesarPago;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblProd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCant;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgvProductosSeleccionados;
        private System.Windows.Forms.Button btnQuitarProd;
        private System.Windows.Forms.Label lblProv;
    }
}