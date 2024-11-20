namespace UI
{
    partial class FrmClientes
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
            this.dgvClientes = new UI.CustomDataGridView();
            this.grpDatosCliente = new System.Windows.Forms.GroupBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.grpSerializacion = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new UI.CustomButton();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.lstClientes = new System.Windows.Forms.ListBox();
            this.btnSerializar = new UI.CustomButton();
            this.btnDeserializar = new UI.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.grpDatosCliente.SuspendLayout();
            this.grpSerializacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblModo
            // 
            this.lblModo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblModo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblModo.Location = new System.Drawing.Point(164, 265);
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
            this.btnSalir.Location = new System.Drawing.Point(676, 265);
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
            this.btnCancelar.Location = new System.Drawing.Point(595, 265);
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
            this.btnEliminar.Location = new System.Drawing.Point(433, 265);
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
            this.btnAgregar.Location = new System.Drawing.Point(271, 265);
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
            this.btnModificar.Location = new System.Drawing.Point(352, 265);
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
            this.btnAplicar.Location = new System.Drawing.Point(514, 265);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 23);
            this.btnAplicar.TabIndex = 52;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // dgvClientes
            // 
            this.dgvClientes.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(49, 33);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.Size = new System.Drawing.Size(434, 177);
            this.dgvClientes.TabIndex = 59;
            this.dgvClientes.SelectionChanged += new System.EventHandler(this.dgvClientes_SelectionChanged);
            // 
            // grpDatosCliente
            // 
            this.grpDatosCliente.BackColor = System.Drawing.Color.White;
            this.grpDatosCliente.Controls.Add(this.txtTel);
            this.grpDatosCliente.Controls.Add(this.lblTelefono);
            this.grpDatosCliente.Controls.Add(this.lblDni);
            this.grpDatosCliente.Controls.Add(this.txtDni);
            this.grpDatosCliente.Controls.Add(this.txtCorreo);
            this.grpDatosCliente.Controls.Add(this.txtApellido);
            this.grpDatosCliente.Controls.Add(this.txtNombre);
            this.grpDatosCliente.Controls.Add(this.lblCorreo);
            this.grpDatosCliente.Controls.Add(this.lblApellido);
            this.grpDatosCliente.Controls.Add(this.lblNombre);
            this.grpDatosCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.grpDatosCliente.Location = new System.Drawing.Point(550, 33);
            this.grpDatosCliente.Name = "grpDatosCliente";
            this.grpDatosCliente.Size = new System.Drawing.Size(201, 177);
            this.grpDatosCliente.TabIndex = 60;
            this.grpDatosCliente.TabStop = false;
            this.grpDatosCliente.Text = "Cliente";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(83, 129);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(100, 21);
            this.txtTel.TabIndex = 14;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(15, 132);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(55, 15);
            this.lblTelefono.TabIndex = 13;
            this.lblTelefono.Text = "Telefono";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDni.Location = new System.Drawing.Point(43, 26);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(28, 15);
            this.lblDni.TabIndex = 12;
            this.lblDni.Text = "DNI";
            // 
            // txtDni
            // 
            this.txtDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDni.Location = new System.Drawing.Point(83, 24);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(100, 21);
            this.txtDni.TabIndex = 10;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(83, 102);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(100, 21);
            this.txtCorreo.TabIndex = 8;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(83, 76);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 21);
            this.txtApellido.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(83, 50);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 21);
            this.txtNombre.TabIndex = 6;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.Location = new System.Drawing.Point(28, 105);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(44, 15);
            this.lblCorreo.TabIndex = 2;
            this.lblCorreo.Text = "Correo";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.Location = new System.Drawing.Point(19, 79);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(51, 15);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(20, 53);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(52, 15);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // grpSerializacion
            // 
            this.grpSerializacion.Controls.Add(this.btnLimpiar);
            this.grpSerializacion.Controls.Add(this.txtRuta);
            this.grpSerializacion.Controls.Add(this.lstClientes);
            this.grpSerializacion.Controls.Add(this.btnSerializar);
            this.grpSerializacion.Controls.Add(this.btnDeserializar);
            this.grpSerializacion.Location = new System.Drawing.Point(49, 326);
            this.grpSerializacion.Name = "grpSerializacion";
            this.grpSerializacion.Size = new System.Drawing.Size(702, 220);
            this.grpSerializacion.TabIndex = 61;
            this.grpSerializacion.TabStop = false;
            this.grpSerializacion.Text = "Serialización";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLimpiar.Location = new System.Drawing.Point(547, 183);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(137, 23);
            this.btnLimpiar.TabIndex = 62;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(22, 185);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.ReadOnly = true;
            this.txtRuta.Size = new System.Drawing.Size(518, 20);
            this.txtRuta.TabIndex = 65;
            // 
            // lstClientes
            // 
            this.lstClientes.FormattingEnabled = true;
            this.lstClientes.Location = new System.Drawing.Point(222, 19);
            this.lstClientes.Name = "lstClientes";
            this.lstClientes.Size = new System.Drawing.Size(462, 160);
            this.lstClientes.TabIndex = 64;
            // 
            // btnSerializar
            // 
            this.btnSerializar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnSerializar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSerializar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSerializar.Location = new System.Drawing.Point(22, 55);
            this.btnSerializar.Name = "btnSerializar";
            this.btnSerializar.Size = new System.Drawing.Size(190, 23);
            this.btnSerializar.TabIndex = 63;
            this.btnSerializar.Text = "Serializar";
            this.btnSerializar.UseVisualStyleBackColor = true;
            this.btnSerializar.Click += new System.EventHandler(this.btnSerializar_Click);
            // 
            // btnDeserializar
            // 
            this.btnDeserializar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnDeserializar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeserializar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeserializar.Location = new System.Drawing.Point(22, 117);
            this.btnDeserializar.Name = "btnDeserializar";
            this.btnDeserializar.Size = new System.Drawing.Size(190, 23);
            this.btnDeserializar.TabIndex = 62;
            this.btnDeserializar.Text = "Deserializar";
            this.btnDeserializar.UseVisualStyleBackColor = true;
            this.btnDeserializar.Click += new System.EventHandler(this.btnDeserializar_Click);
            // 
            // FrmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(786, 558);
            this.Controls.Add(this.grpSerializacion);
            this.Controls.Add(this.grpDatosCliente);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.lblModo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAplicar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmClientes";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.FrmClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.grpDatosCliente.ResumeLayout(false);
            this.grpDatosCliente.PerformLayout();
            this.grpSerializacion.ResumeLayout(false);
            this.grpSerializacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblModo;
        private System.Windows.Forms.GroupBox grpDatosCliente;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox grpSerializacion;
        private System.Windows.Forms.ListBox lstClientes;
        private System.Windows.Forms.TextBox txtRuta;
        private CustomButton btnSalir;
        private CustomButton btnCancelar;
        private CustomButton btnEliminar;
        private CustomButton btnAgregar;
        private CustomButton btnModificar;
        private CustomButton btnAplicar;
        private CustomDataGridView dgvClientes;
        private CustomButton btnSerializar;
        private CustomButton btnDeserializar;
        private CustomButton btnLimpiar;
    }
}