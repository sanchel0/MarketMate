﻿namespace UI
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
            this.dgvProductos = new UI.CustomDataGridView();
            this.dgvProveedores = new UI.CustomDataGridView();
            this.btnSeleccionarProd = new UI.CustomButton();
            this.btnRegistroInicial = new UI.CustomButton();
            this.btnFinalizar = new UI.CustomButton();
            this.btnSalir = new UI.CustomButton();
            this.lblProd = new System.Windows.Forms.Label();
            this.lblProdsSelect = new System.Windows.Forms.Label();
            this.lblCant = new System.Windows.Forms.Label();
            this.txtCant = new System.Windows.Forms.TextBox();
            this.dgvProductosSeleccionados = new UI.CustomDataGridView();
            this.btnQuitarProd = new UI.CustomButton();
            this.lblProv = new System.Windows.Forms.Label();
            this.lblProvsSelect = new System.Windows.Forms.Label();
            this.dgvProveedoresSeleccionados = new UI.CustomDataGridView();
            this.btnSeleccionarProv = new UI.CustomButton();
            this.btnQuitarProv = new UI.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosSeleccionados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedoresSeleccionados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(30, 28);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(294, 150);
            this.dgvProductos.TabIndex = 0;
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvProveedores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Location = new System.Drawing.Point(372, 28);
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.Size = new System.Drawing.Size(294, 150);
            this.dgvProveedores.TabIndex = 1;
            // 
            // btnSeleccionarProd
            // 
            this.btnSeleccionarProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnSeleccionarProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarProd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
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
            this.btnRegistroInicial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnRegistroInicial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistroInicial.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegistroInicial.Location = new System.Drawing.Point(573, 188);
            this.btnRegistroInicial.Name = "btnRegistroInicial";
            this.btnRegistroInicial.Size = new System.Drawing.Size(93, 42);
            this.btnRegistroInicial.TabIndex = 3;
            this.btnRegistroInicial.Text = "Registro Inicial de Proveedor";
            this.btnRegistroInicial.UseVisualStyleBackColor = true;
            this.btnRegistroInicial.Click += new System.EventHandler(this.btnRegistroInicial_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFinalizar.Location = new System.Drawing.Point(487, 426);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(98, 23);
            this.btnFinalizar.TabIndex = 4;
            this.btnFinalizar.Text = "Finalizar Solicitud";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.Location = new System.Drawing.Point(591, 426);
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
            // lblProdsSelect
            // 
            this.lblProdsSelect.AutoSize = true;
            this.lblProdsSelect.Location = new System.Drawing.Point(27, 227);
            this.lblProdsSelect.Name = "lblProdsSelect";
            this.lblProdsSelect.Size = new System.Drawing.Size(128, 13);
            this.lblProdsSelect.TabIndex = 7;
            this.lblProdsSelect.Text = "Productos Seleccionados";
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
            // txtCant
            // 
            this.txtCant.Location = new System.Drawing.Point(85, 186);
            this.txtCant.Name = "txtCant";
            this.txtCant.Size = new System.Drawing.Size(100, 20);
            this.txtCant.TabIndex = 9;
            // 
            // dgvProductosSeleccionados
            // 
            this.dgvProductosSeleccionados.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvProductosSeleccionados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductosSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductosSeleccionados.Location = new System.Drawing.Point(30, 243);
            this.dgvProductosSeleccionados.Name = "dgvProductosSeleccionados";
            this.dgvProductosSeleccionados.Size = new System.Drawing.Size(294, 150);
            this.dgvProductosSeleccionados.TabIndex = 10;
            // 
            // btnQuitarProd
            // 
            this.btnQuitarProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnQuitarProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarProd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
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
            this.lblProv.Location = new System.Drawing.Point(369, 12);
            this.lblProv.Name = "lblProv";
            this.lblProv.Size = new System.Drawing.Size(67, 13);
            this.lblProv.TabIndex = 12;
            this.lblProv.Text = "Proveedores";
            // 
            // lblProvsSelect
            // 
            this.lblProvsSelect.AutoSize = true;
            this.lblProvsSelect.Location = new System.Drawing.Point(369, 227);
            this.lblProvsSelect.Name = "lblProvsSelect";
            this.lblProvsSelect.Size = new System.Drawing.Size(140, 13);
            this.lblProvsSelect.TabIndex = 14;
            this.lblProvsSelect.Text = "Proveedores Seleccionados";
            // 
            // dgvProveedoresSeleccionados
            // 
            this.dgvProveedoresSeleccionados.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvProveedoresSeleccionados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProveedoresSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedoresSeleccionados.Location = new System.Drawing.Point(372, 243);
            this.dgvProveedoresSeleccionados.Name = "dgvProveedoresSeleccionados";
            this.dgvProveedoresSeleccionados.Size = new System.Drawing.Size(294, 150);
            this.dgvProveedoresSeleccionados.TabIndex = 13;
            // 
            // btnSeleccionarProv
            // 
            this.btnSeleccionarProv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnSeleccionarProv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarProv.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSeleccionarProv.Location = new System.Drawing.Point(372, 183);
            this.btnSeleccionarProv.Name = "btnSeleccionarProv";
            this.btnSeleccionarProv.Size = new System.Drawing.Size(123, 23);
            this.btnSeleccionarProv.TabIndex = 15;
            this.btnSeleccionarProv.Text = "Seleccionar Proveedor";
            this.btnSeleccionarProv.UseVisualStyleBackColor = true;
            this.btnSeleccionarProv.Click += new System.EventHandler(this.btnSeleccionarProv_Click);
            // 
            // btnQuitarProv
            // 
            this.btnQuitarProv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnQuitarProv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarProv.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuitarProv.Location = new System.Drawing.Point(372, 399);
            this.btnQuitarProv.Name = "btnQuitarProv";
            this.btnQuitarProv.Size = new System.Drawing.Size(98, 23);
            this.btnQuitarProv.TabIndex = 16;
            this.btnQuitarProv.Text = "Quitar Proveedor";
            this.btnQuitarProv.UseVisualStyleBackColor = true;
            this.btnQuitarProv.Click += new System.EventHandler(this.btnQuitarProv_Click);
            // 
            // FrmGenerarSolicitudCotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(711, 484);
            this.Controls.Add(this.btnQuitarProv);
            this.Controls.Add(this.btnSeleccionarProv);
            this.Controls.Add(this.lblProvsSelect);
            this.Controls.Add(this.dgvProveedoresSeleccionados);
            this.Controls.Add(this.lblProv);
            this.Controls.Add(this.btnQuitarProd);
            this.Controls.Add(this.dgvProductosSeleccionados);
            this.Controls.Add(this.txtCant);
            this.Controls.Add(this.lblCant);
            this.Controls.Add(this.lblProdsSelect);
            this.Controls.Add(this.lblProd);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.btnRegistroInicial);
            this.Controls.Add(this.btnSeleccionarProd);
            this.Controls.Add(this.dgvProveedores);
            this.Controls.Add(this.dgvProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmGenerarSolicitudCotizacion";
            this.Text = "Generar Solicitud Cotizacion";
            this.Load += new System.EventHandler(this.FrmGenerarSolicitudCotizacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosSeleccionados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedoresSeleccionados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblProd;
        private System.Windows.Forms.Label lblProdsSelect;
        private System.Windows.Forms.Label lblCant;
        private System.Windows.Forms.TextBox txtCant;
        private System.Windows.Forms.Label lblProv;
        private System.Windows.Forms.Label lblProvsSelect;
        private CustomDataGridView dgvProductos;
        private CustomDataGridView dgvProveedores;
        private CustomButton btnSeleccionarProd;
        private CustomButton btnRegistroInicial;
        private CustomButton btnFinalizar;
        private CustomButton btnSalir;
        private CustomDataGridView dgvProductosSeleccionados;
        private CustomButton btnQuitarProd;
        private CustomDataGridView dgvProveedoresSeleccionados;
        private CustomButton btnSeleccionarProv;
        private CustomButton btnQuitarProv;
    }
}