namespace UI
{
    partial class FrmGestionUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestionUsuarios));
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnDesbloquear = new System.Windows.Forms.Button();
            this.btnActivarDesactivar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.grpDatosUsuario = new System.Windows.Forms.GroupBox();
            this.cboRol = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtActivo = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtBloqueo = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoTodos = new System.Windows.Forms.RadioButton();
            this.rdoBloqueados = new System.Windows.Forms.RadioButton();
            this.rdoActivos = new System.Windows.Forms.RadioButton();
            this.pnlRdos = new System.Windows.Forms.Panel();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.pnlBtns = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.grpDatosUsuario.SuspendLayout();
            this.pnlRdos.SuspendLayout();
            this.pnlBtns.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(21, 40);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(641, 202);
            this.dgvUsuarios.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(3, 184);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 28);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(3, 155);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 28);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnAplicar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.ForeColor = System.Drawing.Color.White;
            this.btnAplicar.Location = new System.Drawing.Point(3, 126);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(90, 28);
            this.btnAplicar.TabIndex = 4;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = false;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnDesbloquear
            // 
            this.btnDesbloquear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnDesbloquear.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDesbloquear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesbloquear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesbloquear.ForeColor = System.Drawing.Color.White;
            this.btnDesbloquear.Location = new System.Drawing.Point(3, 97);
            this.btnDesbloquear.Name = "btnDesbloquear";
            this.btnDesbloquear.Size = new System.Drawing.Size(90, 28);
            this.btnDesbloquear.TabIndex = 5;
            this.btnDesbloquear.Text = "Desbloquear";
            this.btnDesbloquear.UseVisualStyleBackColor = false;
            this.btnDesbloquear.Click += new System.EventHandler(this.btnDesbloquear_Click);
            // 
            // btnActivarDesactivar
            // 
            this.btnActivarDesactivar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnActivarDesactivar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnActivarDesactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivarDesactivar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivarDesactivar.ForeColor = System.Drawing.Color.White;
            this.btnActivarDesactivar.Location = new System.Drawing.Point(3, 68);
            this.btnActivarDesactivar.Name = "btnActivarDesactivar";
            this.btnActivarDesactivar.Size = new System.Drawing.Size(90, 28);
            this.btnActivarDesactivar.TabIndex = 6;
            this.btnActivarDesactivar.Text = "Desactivar";
            this.btnActivarDesactivar.UseVisualStyleBackColor = false;
            this.btnActivarDesactivar.Click += new System.EventHandler(this.btnActivarDesactivar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnModificar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.Location = new System.Drawing.Point(3, 39);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 28);
            this.btnModificar.TabIndex = 7;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(3, 10);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(90, 28);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // grpDatosUsuario
            // 
            this.grpDatosUsuario.BackColor = System.Drawing.Color.Ivory;
            this.grpDatosUsuario.Controls.Add(this.cboRol);
            this.grpDatosUsuario.Controls.Add(this.label7);
            this.grpDatosUsuario.Controls.Add(this.txtActivo);
            this.grpDatosUsuario.Controls.Add(this.txtDni);
            this.grpDatosUsuario.Controls.Add(this.txtBloqueo);
            this.grpDatosUsuario.Controls.Add(this.txtCorreo);
            this.grpDatosUsuario.Controls.Add(this.txtApellido);
            this.grpDatosUsuario.Controls.Add(this.txtNombre);
            this.grpDatosUsuario.Controls.Add(this.label6);
            this.grpDatosUsuario.Controls.Add(this.label5);
            this.grpDatosUsuario.Controls.Add(this.label4);
            this.grpDatosUsuario.Controls.Add(this.label3);
            this.grpDatosUsuario.Controls.Add(this.label2);
            this.grpDatosUsuario.Controls.Add(this.label1);
            this.grpDatosUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.grpDatosUsuario.Location = new System.Drawing.Point(21, 248);
            this.grpDatosUsuario.Name = "grpDatosUsuario";
            this.grpDatosUsuario.Size = new System.Drawing.Size(201, 230);
            this.grpDatosUsuario.TabIndex = 9;
            this.grpDatosUsuario.TabStop = false;
            this.grpDatosUsuario.Text = "Usuario";
            // 
            // cboRol
            // 
            this.cboRol.FormattingEnabled = true;
            this.cboRol.Location = new System.Drawing.Point(83, 128);
            this.cboRol.Name = "cboRol";
            this.cboRol.Size = new System.Drawing.Size(100, 23);
            this.cboRol.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(43, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "DNI";
            // 
            // txtActivo
            // 
            this.txtActivo.Enabled = false;
            this.txtActivo.Location = new System.Drawing.Point(83, 181);
            this.txtActivo.Name = "txtActivo";
            this.txtActivo.Size = new System.Drawing.Size(100, 21);
            this.txtActivo.TabIndex = 11;
            // 
            // txtDni
            // 
            this.txtDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDni.Location = new System.Drawing.Point(83, 24);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(100, 21);
            this.txtDni.TabIndex = 10;
            // 
            // txtBloqueo
            // 
            this.txtBloqueo.Enabled = false;
            this.txtBloqueo.Location = new System.Drawing.Point(83, 155);
            this.txtBloqueo.Name = "txtBloqueo";
            this.txtBloqueo.Size = new System.Drawing.Size(100, 21);
            this.txtBloqueo.TabIndex = 9;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Activo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Bloqueo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(45, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Rol";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Correo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // rdoTodos
            // 
            this.rdoTodos.AutoSize = true;
            this.rdoTodos.Location = new System.Drawing.Point(16, 9);
            this.rdoTodos.Name = "rdoTodos";
            this.rdoTodos.Size = new System.Drawing.Size(55, 17);
            this.rdoTodos.TabIndex = 10;
            this.rdoTodos.TabStop = true;
            this.rdoTodos.Text = "Todos";
            this.rdoTodos.UseVisualStyleBackColor = true;
            // 
            // rdoBloqueados
            // 
            this.rdoBloqueados.AutoSize = true;
            this.rdoBloqueados.Location = new System.Drawing.Point(77, 9);
            this.rdoBloqueados.Name = "rdoBloqueados";
            this.rdoBloqueados.Size = new System.Drawing.Size(81, 17);
            this.rdoBloqueados.TabIndex = 11;
            this.rdoBloqueados.TabStop = true;
            this.rdoBloqueados.Text = "Bloqueados";
            this.rdoBloqueados.UseVisualStyleBackColor = true;
            // 
            // rdoActivos
            // 
            this.rdoActivos.AutoSize = true;
            this.rdoActivos.Location = new System.Drawing.Point(164, 9);
            this.rdoActivos.Name = "rdoActivos";
            this.rdoActivos.Size = new System.Drawing.Size(60, 17);
            this.rdoActivos.TabIndex = 12;
            this.rdoActivos.TabStop = true;
            this.rdoActivos.Text = "Activos";
            this.rdoActivos.UseVisualStyleBackColor = true;
            // 
            // pnlRdos
            // 
            this.pnlRdos.Controls.Add(this.rdoTodos);
            this.pnlRdos.Controls.Add(this.rdoActivos);
            this.pnlRdos.Controls.Add(this.rdoBloqueados);
            this.pnlRdos.Location = new System.Drawing.Point(422, 248);
            this.pnlRdos.Name = "pnlRdos";
            this.pnlRdos.Size = new System.Drawing.Size(240, 33);
            this.pnlRdos.TabIndex = 13;
            // 
            // lblMensaje
            // 
            this.lblMensaje.BackColor = System.Drawing.Color.White;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(414, 359);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(248, 119);
            this.lblMensaje.TabIndex = 14;
            this.lblMensaje.Text = "Modo Consulta";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBtns
            // 
            this.pnlBtns.Controls.Add(this.btnAgregar);
            this.pnlBtns.Controls.Add(this.btnSalir);
            this.pnlBtns.Controls.Add(this.btnCancelar);
            this.pnlBtns.Controls.Add(this.btnAplicar);
            this.pnlBtns.Controls.Add(this.btnDesbloquear);
            this.pnlBtns.Controls.Add(this.btnModificar);
            this.pnlBtns.Controls.Add(this.btnActivarDesactivar);
            this.pnlBtns.Location = new System.Drawing.Point(692, 30);
            this.pnlBtns.Name = "pnlBtns";
            this.pnlBtns.Size = new System.Drawing.Size(96, 222);
            this.pnlBtns.TabIndex = 15;
            // 
            // FrmGestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(800, 510);
            this.Controls.Add(this.pnlBtns);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.pnlRdos);
            this.Controls.Add(this.grpDatosUsuario);
            this.Controls.Add(this.dgvUsuarios);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmGestionUsuarios";
            this.Text = "Gestionar Usuarios";
            this.Load += new System.EventHandler(this.FrmGestionarUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.grpDatosUsuario.ResumeLayout(false);
            this.grpDatosUsuario.PerformLayout();
            this.pnlRdos.ResumeLayout(false);
            this.pnlRdos.PerformLayout();
            this.pnlBtns.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnDesbloquear;
        private System.Windows.Forms.Button btnActivarDesactivar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox grpDatosUsuario;
        private System.Windows.Forms.TextBox txtActivo;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtBloqueo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboRol;
        private System.Windows.Forms.RadioButton rdoTodos;
        private System.Windows.Forms.RadioButton rdoBloqueados;
        private System.Windows.Forms.RadioButton rdoActivos;
        private System.Windows.Forms.Panel pnlRdos;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Panel pnlBtns;
    }
}