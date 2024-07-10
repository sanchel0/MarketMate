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
            this.pnlRdos = new System.Windows.Forms.Panel();
            this.rdoMarca = new System.Windows.Forms.RadioButton();
            this.rdoProducto = new System.Windows.Forms.RadioButton();
            this.rdoCat = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.lblModo = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.grpDatosProducto = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCategorias = new System.Windows.Forms.ComboBox();
            this.cboMarcas = new System.Windows.Forms.ComboBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtNombreProd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpDatosCategoria = new System.Windows.Forms.GroupBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtNombreCat = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvCategorias = new System.Windows.Forms.DataGridView();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            this.grpDatosMarca = new System.Windows.Forms.GroupBox();
            this.txtNombreMarca = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlMarca = new System.Windows.Forms.Panel();
            this.pnlCategoria = new System.Windows.Forms.Panel();
            this.pnlProducto = new System.Windows.Forms.Panel();
            this.pnlRdos.SuspendLayout();
            this.grpDatosProducto.SuspendLayout();
            this.grpDatosCategoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            this.grpDatosMarca.SuspendLayout();
            this.pnlMarca.SuspendLayout();
            this.pnlCategoria.SuspendLayout();
            this.pnlProducto.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRdos
            // 
            this.pnlRdos.Controls.Add(this.rdoMarca);
            this.pnlRdos.Controls.Add(this.rdoProducto);
            this.pnlRdos.Controls.Add(this.rdoCat);
            this.pnlRdos.Location = new System.Drawing.Point(533, 35);
            this.pnlRdos.Name = "pnlRdos";
            this.pnlRdos.Size = new System.Drawing.Size(261, 28);
            this.pnlRdos.TabIndex = 47;
            // 
            // rdoMarca
            // 
            this.rdoMarca.AutoSize = true;
            this.rdoMarca.Location = new System.Drawing.Point(202, 5);
            this.rdoMarca.Name = "rdoMarca";
            this.rdoMarca.Size = new System.Drawing.Size(55, 17);
            this.rdoMarca.TabIndex = 25;
            this.rdoMarca.TabStop = true;
            this.rdoMarca.Text = "Marca";
            this.rdoMarca.UseVisualStyleBackColor = true;
            // 
            // rdoProducto
            // 
            this.rdoProducto.AutoSize = true;
            this.rdoProducto.Location = new System.Drawing.Point(3, 5);
            this.rdoProducto.Name = "rdoProducto";
            this.rdoProducto.Size = new System.Drawing.Size(68, 17);
            this.rdoProducto.TabIndex = 23;
            this.rdoProducto.TabStop = true;
            this.rdoProducto.Text = "Producto";
            this.rdoProducto.UseVisualStyleBackColor = true;
            // 
            // rdoCat
            // 
            this.rdoCat.AutoSize = true;
            this.rdoCat.Location = new System.Drawing.Point(98, 5);
            this.rdoCat.Name = "rdoCat";
            this.rdoCat.Size = new System.Drawing.Size(70, 17);
            this.rdoCat.TabIndex = 24;
            this.rdoCat.TabStop = true;
            this.rdoCat.Text = "Categoria";
            this.rdoCat.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(436, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 15);
            this.label8.TabIndex = 46;
            this.label8.Text = "Gestionar para:";
            // 
            // lblModo
            // 
            this.lblModo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblModo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblModo.Location = new System.Drawing.Point(359, 558);
            this.lblModo.Name = "lblModo";
            this.lblModo.Size = new System.Drawing.Size(97, 23);
            this.lblModo.TabIndex = 58;
            this.lblModo.Text = "Modo";
            this.lblModo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(871, 558);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 57;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(790, 558);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 56;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(628, 558);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 55;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(466, 558);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 54;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(547, 558);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 53;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(709, 558);
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
            this.grpDatosProducto.Controls.Add(this.label6);
            this.grpDatosProducto.Controls.Add(this.label5);
            this.grpDatosProducto.Controls.Add(this.cboCategorias);
            this.grpDatosProducto.Controls.Add(this.cboMarcas);
            this.grpDatosProducto.Controls.Add(this.txtPrecio);
            this.grpDatosProducto.Controls.Add(this.label4);
            this.grpDatosProducto.Controls.Add(this.txtCosto);
            this.grpDatosProducto.Controls.Add(this.txtStock);
            this.grpDatosProducto.Controls.Add(this.txtNombreProd);
            this.grpDatosProducto.Controls.Add(this.label3);
            this.grpDatosProducto.Controls.Add(this.label2);
            this.grpDatosProducto.Controls.Add(this.label1);
            this.grpDatosProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.grpDatosProducto.Location = new System.Drawing.Point(91, 217);
            this.grpDatosProducto.Name = "grpDatosProducto";
            this.grpDatosProducto.Size = new System.Drawing.Size(213, 196);
            this.grpDatosProducto.TabIndex = 61;
            this.grpDatosProducto.TabStop = false;
            this.grpDatosProducto.Text = "Producto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(36, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "Marca";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Categoria";
            // 
            // cboCategorias
            // 
            this.cboCategorias.FormattingEnabled = true;
            this.cboCategorias.Location = new System.Drawing.Point(95, 77);
            this.cboCategorias.Name = "cboCategorias";
            this.cboCategorias.Size = new System.Drawing.Size(101, 23);
            this.cboCategorias.TabIndex = 16;
            // 
            // cboMarcas
            // 
            this.cboMarcas.FormattingEnabled = true;
            this.cboMarcas.Location = new System.Drawing.Point(95, 106);
            this.cboMarcas.Name = "cboMarcas";
            this.cboMarcas.Size = new System.Drawing.Size(100, 23);
            this.cboMarcas.TabIndex = 15;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(95, 162);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 21);
            this.txtPrecio.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Precio";
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(95, 135);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(100, 21);
            this.txtCosto.TabIndex = 8;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(95, 50);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(100, 21);
            this.txtStock.TabIndex = 7;
            // 
            // txtNombreProd
            // 
            this.txtNombreProd.Location = new System.Drawing.Point(95, 24);
            this.txtNombreProd.Name = "txtNombreProd";
            this.txtNombreProd.Size = new System.Drawing.Size(100, 21);
            this.txtNombreProd.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Costo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Stock";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // grpDatosCategoria
            // 
            this.grpDatosCategoria.BackColor = System.Drawing.Color.Transparent;
            this.grpDatosCategoria.Controls.Add(this.txtDesc);
            this.grpDatosCategoria.Controls.Add(this.txtNombreCat);
            this.grpDatosCategoria.Controls.Add(this.label10);
            this.grpDatosCategoria.Controls.Add(this.label11);
            this.grpDatosCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.grpDatosCategoria.Location = new System.Drawing.Point(100, 215);
            this.grpDatosCategoria.Name = "grpDatosCategoria";
            this.grpDatosCategoria.Size = new System.Drawing.Size(209, 201);
            this.grpDatosCategoria.TabIndex = 62;
            this.grpDatosCategoria.TabStop = false;
            this.grpDatosCategoria.Text = "Categoria";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(8, 79);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(179, 106);
            this.txtDesc.TabIndex = 7;
            // 
            // txtNombreCat
            // 
            this.txtNombreCat.Location = new System.Drawing.Point(87, 21);
            this.txtNombreCat.Name = "txtNombreCat";
            this.txtNombreCat.Size = new System.Drawing.Size(100, 21);
            this.txtNombreCat.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(5, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 15);
            this.label10.TabIndex = 1;
            this.label10.Text = "Descripcion";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(24, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Nombre";
            // 
            // dgvCategorias
            // 
            this.dgvCategorias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCategorias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorias.Location = new System.Drawing.Point(1, 0);
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.Size = new System.Drawing.Size(399, 188);
            this.dgvCategorias.TabIndex = 19;
            this.dgvCategorias.SelectionChanged += new System.EventHandler(this.dgvCategorias_SelectionChanged);
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(3, 0);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(538, 188);
            this.dgvProductos.TabIndex = 20;
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.Location = new System.Drawing.Point(3, 0);
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.Size = new System.Drawing.Size(209, 188);
            this.dgvMarcas.TabIndex = 63;
            this.dgvMarcas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarcas_CellContentClick);
            this.dgvMarcas.SelectionChanged += new System.EventHandler(this.dgvMarcas_SelectionChanged);
            // 
            // grpDatosMarca
            // 
            this.grpDatosMarca.BackColor = System.Drawing.Color.Transparent;
            this.grpDatosMarca.Controls.Add(this.txtNombreMarca);
            this.grpDatosMarca.Controls.Add(this.label9);
            this.grpDatosMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.grpDatosMarca.Location = new System.Drawing.Point(3, 211);
            this.grpDatosMarca.Name = "grpDatosMarca";
            this.grpDatosMarca.Size = new System.Drawing.Size(209, 65);
            this.grpDatosMarca.TabIndex = 63;
            this.grpDatosMarca.TabStop = false;
            this.grpDatosMarca.Text = "Marca";
            // 
            // txtNombreMarca
            // 
            this.txtNombreMarca.Location = new System.Drawing.Point(83, 24);
            this.txtNombreMarca.Name = "txtNombreMarca";
            this.txtNombreMarca.Size = new System.Drawing.Size(100, 21);
            this.txtNombreMarca.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Nombre";
            // 
            // pnlMarca
            // 
            this.pnlMarca.Controls.Add(this.dgvMarcas);
            this.pnlMarca.Controls.Add(this.grpDatosMarca);
            this.pnlMarca.Location = new System.Drawing.Point(971, 113);
            this.pnlMarca.Name = "pnlMarca";
            this.pnlMarca.Size = new System.Drawing.Size(216, 419);
            this.pnlMarca.TabIndex = 7;
            // 
            // pnlCategoria
            // 
            this.pnlCategoria.Controls.Add(this.grpDatosCategoria);
            this.pnlCategoria.Controls.Add(this.dgvCategorias);
            this.pnlCategoria.Location = new System.Drawing.Point(562, 113);
            this.pnlCategoria.Name = "pnlCategoria";
            this.pnlCategoria.Size = new System.Drawing.Size(403, 419);
            this.pnlCategoria.TabIndex = 0;
            // 
            // pnlProducto
            // 
            this.pnlProducto.Controls.Add(this.grpDatosProducto);
            this.pnlProducto.Controls.Add(this.dgvProductos);
            this.pnlProducto.Location = new System.Drawing.Point(12, 113);
            this.pnlProducto.Name = "pnlProducto";
            this.pnlProducto.Size = new System.Drawing.Size(544, 419);
            this.pnlProducto.TabIndex = 0;
            // 
            // FrmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 593);
            this.Controls.Add(this.pnlMarca);
            this.Controls.Add(this.pnlCategoria);
            this.Controls.Add(this.pnlProducto);
            this.Controls.Add(this.lblModo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.pnlRdos);
            this.Controls.Add(this.label8);
            this.Name = "FrmProductos";
            this.Text = "FrmProductos";
            this.Load += new System.EventHandler(this.FrmProductos_Load);
            this.pnlRdos.ResumeLayout(false);
            this.pnlRdos.PerformLayout();
            this.grpDatosProducto.ResumeLayout(false);
            this.grpDatosProducto.PerformLayout();
            this.grpDatosCategoria.ResumeLayout(false);
            this.grpDatosCategoria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            this.grpDatosMarca.ResumeLayout(false);
            this.grpDatosMarca.PerformLayout();
            this.pnlMarca.ResumeLayout(false);
            this.pnlCategoria.ResumeLayout(false);
            this.pnlProducto.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlRdos;
        private System.Windows.Forms.RadioButton rdoProducto;
        private System.Windows.Forms.RadioButton rdoCat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblModo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.GroupBox grpDatosProducto;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtNombreProd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpDatosCategoria;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtNombreCat;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboCategorias;
        private System.Windows.Forms.ComboBox cboMarcas;
        private System.Windows.Forms.DataGridView dgvCategorias;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridView dgvMarcas;
        private System.Windows.Forms.GroupBox grpDatosMarca;
        private System.Windows.Forms.TextBox txtNombreMarca;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rdoMarca;
        private System.Windows.Forms.Panel pnlMarca;
        private System.Windows.Forms.Panel pnlCategoria;
        private System.Windows.Forms.Panel pnlProducto;
    }
}