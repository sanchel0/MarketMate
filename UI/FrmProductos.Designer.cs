namespace UI
{
    partial class FrmProductos
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
            this.lblModo = new System.Windows.Forms.Label();
            this.btnSalir = new UI.CustomButton();
            this.btnCancelar = new UI.CustomButton();
            this.btnEliminar = new UI.CustomButton();
            this.btnAgregar = new UI.CustomButton();
            this.btnModificar = new UI.CustomButton();
            this.btnAplicar = new UI.CustomButton();
            this.grpDatosProducto = new System.Windows.Forms.GroupBox();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.lblIVA = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.cboCategorias = new System.Windows.Forms.ComboBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.lblMin = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.dgvProductos = new UI.CustomDataGridView();
            this.grpDatosProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblModo
            // 
            this.lblModo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblModo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblModo.Location = new System.Drawing.Point(463, 310);
            this.lblModo.Name = "lblModo";
            this.lblModo.Size = new System.Drawing.Size(97, 23);
            this.lblModo.TabIndex = 58;
            this.lblModo.Text = "Modo";
            this.lblModo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.Location = new System.Drawing.Point(975, 310);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 57;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelar.Location = new System.Drawing.Point(894, 310);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 56;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminar.Location = new System.Drawing.Point(732, 310);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 55;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgregar.Location = new System.Drawing.Point(570, 310);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 54;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnModificar.Location = new System.Drawing.Point(651, 310);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 53;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAplicar.Location = new System.Drawing.Point(813, 310);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 23);
            this.btnAplicar.TabIndex = 52;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // grpDatosProducto
            // 
            this.grpDatosProducto.BackColor = System.Drawing.Color.Transparent;
            this.grpDatosProducto.Controls.Add(this.txtIVA);
            this.grpDatosProducto.Controls.Add(this.lblIVA);
            this.grpDatosProducto.Controls.Add(this.txtMarca);
            this.grpDatosProducto.Controls.Add(this.txtMax);
            this.grpDatosProducto.Controls.Add(this.lblMarca);
            this.grpDatosProducto.Controls.Add(this.lblCategoria);
            this.grpDatosProducto.Controls.Add(this.lblMax);
            this.grpDatosProducto.Controls.Add(this.cboCategorias);
            this.grpDatosProducto.Controls.Add(this.txtMin);
            this.grpDatosProducto.Controls.Add(this.lblMin);
            this.grpDatosProducto.Controls.Add(this.txtPrecio);
            this.grpDatosProducto.Controls.Add(this.lblPrecio);
            this.grpDatosProducto.Controls.Add(this.txtStock);
            this.grpDatosProducto.Controls.Add(this.txtNombre);
            this.grpDatosProducto.Controls.Add(this.lblStock);
            this.grpDatosProducto.Controls.Add(this.lblNombre);
            this.grpDatosProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.grpDatosProducto.Location = new System.Drawing.Point(834, 12);
            this.grpDatosProducto.Name = "grpDatosProducto";
            this.grpDatosProducto.Size = new System.Drawing.Size(216, 259);
            this.grpDatosProducto.TabIndex = 61;
            this.grpDatosProducto.TabStop = false;
            this.grpDatosProducto.Text = "Producto";
            // 
            // txtIVA
            // 
            this.txtIVA.Location = new System.Drawing.Point(109, 212);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.Size = new System.Drawing.Size(100, 21);
            this.txtIVA.TabIndex = 25;
            // 
            // lblIVA
            // 
            this.lblIVA.AutoSize = true;
            this.lblIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIVA.Location = new System.Drawing.Point(68, 215);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(24, 15);
            this.lblIVA.TabIndex = 24;
            this.lblIVA.Text = "IVA";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(109, 159);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(100, 21);
            this.txtMarca.TabIndex = 23;
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(109, 100);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(100, 21);
            this.txtMax.TabIndex = 22;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(50, 159);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(42, 15);
            this.lblMarca.TabIndex = 18;
            this.lblMarca.Text = "Marca";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(32, 130);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(60, 15);
            this.lblCategoria.TabIndex = 17;
            this.lblCategoria.Text = "Categoria";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMax.Location = new System.Drawing.Point(7, 103);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(85, 15);
            this.lblMax.TabIndex = 21;
            this.lblMax.Text = "Stock Máximo";
            // 
            // cboCategorias
            // 
            this.cboCategorias.FormattingEnabled = true;
            this.cboCategorias.Location = new System.Drawing.Point(109, 127);
            this.cboCategorias.Name = "cboCategorias";
            this.cboCategorias.Size = new System.Drawing.Size(101, 23);
            this.cboCategorias.TabIndex = 16;
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(110, 73);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(100, 21);
            this.txtMin.TabIndex = 20;
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMin.Location = new System.Drawing.Point(10, 76);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(82, 15);
            this.lblMin.TabIndex = 19;
            this.lblMin.Text = "Stock Mínimo";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(109, 185);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 21);
            this.txtPrecio.TabIndex = 14;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(50, 188);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(42, 15);
            this.lblPrecio.TabIndex = 13;
            this.lblPrecio.Text = "Precio";
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(110, 46);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(100, 21);
            this.txtStock.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(110, 20);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 21);
            this.txtNombre.TabIndex = 6;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(56, 49);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(37, 15);
            this.lblStock.TabIndex = 1;
            this.lblStock.Text = "Stock";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(41, 23);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(52, 15);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // dgvProductos
            // 
            this.dgvProductos.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(12, 12);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(696, 244);
            this.dgvProductos.TabIndex = 20;
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);
            // 
            // FrmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1073, 366);
            this.Controls.Add(this.grpDatosProducto);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.lblModo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAplicar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmProductos";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.FrmProductos_Load);
            this.grpDatosProducto.ResumeLayout(false);
            this.grpDatosProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblModo;
        private System.Windows.Forms.GroupBox grpDatosProducto;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cboCategorias;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.Label lblIVA;
        private CustomButton btnSalir;
        private CustomButton btnCancelar;
        private CustomButton btnEliminar;
        private CustomButton btnAgregar;
        private CustomButton btnModificar;
        private CustomButton btnAplicar;
        private CustomDataGridView dgvProductos;
    }
}