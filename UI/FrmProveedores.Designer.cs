namespace UI
{
    partial class FrmProveedores
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
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.cboTipoCuenta = new System.Windows.Forms.ComboBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.lblTel = new System.Windows.Forms.Label();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.lblAlias = new System.Windows.Forms.Label();
            this.lblBanco = new System.Windows.Forms.Label();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.txtCBU = new System.Windows.Forms.TextBox();
            this.txtNumCuenta = new System.Windows.Forms.TextBox();
            this.lblCBU = new System.Windows.Forms.Label();
            this.lblNumCuenta = new System.Windows.Forms.Label();
            this.lblTipoCuenta = new System.Windows.Forms.Label();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.lblDir = new System.Windows.Forms.Label();
            this.lblCUIT = new System.Windows.Forms.Label();
            this.txtCUIT = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtRS = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblRS = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.dgvProveedores = new UI.CustomDataGridView();
            this.lblModo = new System.Windows.Forms.Label();
            this.btnSalir = new UI.CustomButton();
            this.btnCancelar = new UI.CustomButton();
            this.btnEliminar = new UI.CustomButton();
            this.btnAgregar = new UI.CustomButton();
            this.btnModificar = new UI.CustomButton();
            this.btnAplicar = new UI.CustomButton();
            this.grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDatos
            // 
            this.grpDatos.BackColor = System.Drawing.Color.White;
            this.grpDatos.Controls.Add(this.cboTipoCuenta);
            this.grpDatos.Controls.Add(this.txtTel);
            this.grpDatos.Controls.Add(this.lblTel);
            this.grpDatos.Controls.Add(this.txtAlias);
            this.grpDatos.Controls.Add(this.lblAlias);
            this.grpDatos.Controls.Add(this.lblBanco);
            this.grpDatos.Controls.Add(this.txtBanco);
            this.grpDatos.Controls.Add(this.txtCBU);
            this.grpDatos.Controls.Add(this.txtNumCuenta);
            this.grpDatos.Controls.Add(this.lblCBU);
            this.grpDatos.Controls.Add(this.lblNumCuenta);
            this.grpDatos.Controls.Add(this.lblTipoCuenta);
            this.grpDatos.Controls.Add(this.txtDir);
            this.grpDatos.Controls.Add(this.lblDir);
            this.grpDatos.Controls.Add(this.lblCUIT);
            this.grpDatos.Controls.Add(this.txtCUIT);
            this.grpDatos.Controls.Add(this.txtCorreo);
            this.grpDatos.Controls.Add(this.txtRS);
            this.grpDatos.Controls.Add(this.txtNombre);
            this.grpDatos.Controls.Add(this.lblCorreo);
            this.grpDatos.Controls.Add(this.lblRS);
            this.grpDatos.Controls.Add(this.lblNombre);
            this.grpDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.grpDatos.Location = new System.Drawing.Point(525, 12);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(322, 330);
            this.grpDatos.TabIndex = 69;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Proveedor";
            // 
            // cboTipoCuenta
            // 
            this.cboTipoCuenta.FormattingEnabled = true;
            this.cboTipoCuenta.Location = new System.Drawing.Point(110, 212);
            this.cboTipoCuenta.Name = "cboTipoCuenta";
            this.cboTipoCuenta.Size = new System.Drawing.Size(186, 23);
            this.cboTipoCuenta.TabIndex = 27;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(110, 104);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(187, 21);
            this.txtTel.TabIndex = 26;
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTel.Location = new System.Drawing.Point(49, 107);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(55, 15);
            this.lblTel.TabIndex = 25;
            this.lblTel.Text = "Telefono";
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(110, 294);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(187, 21);
            this.txtAlias.TabIndex = 24;
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlias.Location = new System.Drawing.Point(71, 297);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(33, 15);
            this.lblAlias.TabIndex = 23;
            this.lblAlias.Text = "Alias";
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanco.Location = new System.Drawing.Point(62, 187);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(42, 15);
            this.lblBanco.TabIndex = 22;
            this.lblBanco.Text = "Banco";
            // 
            // txtBanco
            // 
            this.txtBanco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBanco.Location = new System.Drawing.Point(110, 185);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(187, 21);
            this.txtBanco.TabIndex = 21;
            // 
            // txtCBU
            // 
            this.txtCBU.Location = new System.Drawing.Point(110, 267);
            this.txtCBU.Name = "txtCBU";
            this.txtCBU.Size = new System.Drawing.Size(187, 21);
            this.txtCBU.TabIndex = 20;
            // 
            // txtNumCuenta
            // 
            this.txtNumCuenta.Location = new System.Drawing.Point(110, 241);
            this.txtNumCuenta.Name = "txtNumCuenta";
            this.txtNumCuenta.Size = new System.Drawing.Size(187, 21);
            this.txtNumCuenta.TabIndex = 19;
            // 
            // lblCBU
            // 
            this.lblCBU.AutoSize = true;
            this.lblCBU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCBU.Location = new System.Drawing.Point(72, 270);
            this.lblCBU.Name = "lblCBU";
            this.lblCBU.Size = new System.Drawing.Size(32, 15);
            this.lblCBU.TabIndex = 17;
            this.lblCBU.Text = "CBU";
            // 
            // lblNumCuenta
            // 
            this.lblNumCuenta.AutoSize = true;
            this.lblNumCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumCuenta.Location = new System.Drawing.Point(10, 244);
            this.lblNumCuenta.Name = "lblNumCuenta";
            this.lblNumCuenta.Size = new System.Drawing.Size(94, 15);
            this.lblNumCuenta.TabIndex = 16;
            this.lblNumCuenta.Text = "Numero Cuenta";
            // 
            // lblTipoCuenta
            // 
            this.lblTipoCuenta.AutoSize = true;
            this.lblTipoCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoCuenta.Location = new System.Drawing.Point(31, 215);
            this.lblTipoCuenta.Name = "lblTipoCuenta";
            this.lblTipoCuenta.Size = new System.Drawing.Size(73, 15);
            this.lblTipoCuenta.TabIndex = 15;
            this.lblTipoCuenta.Text = "Tipo Cuenta";
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(110, 158);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(187, 21);
            this.txtDir.TabIndex = 14;
            // 
            // lblDir
            // 
            this.lblDir.AutoSize = true;
            this.lblDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDir.Location = new System.Drawing.Point(45, 161);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(59, 15);
            this.lblDir.TabIndex = 13;
            this.lblDir.Text = "Direccion";
            // 
            // lblCUIT
            // 
            this.lblCUIT.AutoSize = true;
            this.lblCUIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCUIT.Location = new System.Drawing.Point(70, 22);
            this.lblCUIT.Name = "lblCUIT";
            this.lblCUIT.Size = new System.Drawing.Size(34, 15);
            this.lblCUIT.TabIndex = 12;
            this.lblCUIT.Text = "CUIT";
            // 
            // txtCUIT
            // 
            this.txtCUIT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCUIT.Location = new System.Drawing.Point(110, 20);
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.Size = new System.Drawing.Size(187, 21);
            this.txtCUIT.TabIndex = 10;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(110, 131);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(187, 21);
            this.txtCorreo.TabIndex = 8;
            // 
            // txtRS
            // 
            this.txtRS.Location = new System.Drawing.Point(110, 72);
            this.txtRS.Name = "txtRS";
            this.txtRS.Size = new System.Drawing.Size(187, 21);
            this.txtRS.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(110, 46);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(187, 21);
            this.txtNombre.TabIndex = 6;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.Location = new System.Drawing.Point(60, 134);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(44, 15);
            this.lblCorreo.TabIndex = 2;
            this.lblCorreo.Text = "Correo";
            // 
            // lblRS
            // 
            this.lblRS.AutoSize = true;
            this.lblRS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRS.Location = new System.Drawing.Point(24, 75);
            this.lblRS.Name = "lblRS";
            this.lblRS.Size = new System.Drawing.Size(80, 15);
            this.lblRS.TabIndex = 1;
            this.lblRS.Text = "Razon Social";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(52, 49);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(52, 15);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvProveedores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Location = new System.Drawing.Point(12, 12);
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.Size = new System.Drawing.Size(500, 299);
            this.dgvProveedores.TabIndex = 68;
            // 
            // lblModo
            // 
            this.lblModo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblModo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblModo.Location = new System.Drawing.Point(258, 361);
            this.lblModo.Name = "lblModo";
            this.lblModo.Size = new System.Drawing.Size(97, 23);
            this.lblModo.TabIndex = 67;
            this.lblModo.Text = "Modo";
            this.lblModo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.Location = new System.Drawing.Point(770, 361);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 66;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelar.Location = new System.Drawing.Point(689, 361);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 65;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminar.Location = new System.Drawing.Point(527, 361);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 64;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgregar.Location = new System.Drawing.Point(365, 361);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 63;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnModificar.Location = new System.Drawing.Point(446, 361);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 62;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAplicar.Location = new System.Drawing.Point(608, 361);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 23);
            this.btnAplicar.TabIndex = 61;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // FrmProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(859, 393);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.dgvProveedores);
            this.Controls.Add(this.lblModo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAplicar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmProveedores";
            this.Text = "Proveedores";
            this.Load += new System.EventHandler(this.FrmProveedores_Load);
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Label lblDir;
        private System.Windows.Forms.Label lblCUIT;
        private System.Windows.Forms.TextBox txtCUIT;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtRS;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblRS;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblModo;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.Label lblAlias;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.TextBox txtCBU;
        private System.Windows.Forms.TextBox txtNumCuenta;
        private System.Windows.Forms.Label lblCBU;
        private System.Windows.Forms.Label lblNumCuenta;
        private System.Windows.Forms.Label lblTipoCuenta;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.ComboBox cboTipoCuenta;
        private CustomDataGridView dgvProveedores;
        private CustomButton btnSalir;
        private CustomButton btnCancelar;
        private CustomButton btnEliminar;
        private CustomButton btnAgregar;
        private CustomButton btnModificar;
        private CustomButton btnAplicar;
    }
}