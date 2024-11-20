namespace UI
{
    partial class FrmRegistrarCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistrarCliente));
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.btnRegsitrar = new CustomButton();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(38, 77);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.BackColor = System.Drawing.Color.Transparent;
            this.lblApellido.ForeColor = System.Drawing.Color.Black;
            this.lblApellido.Location = new System.Drawing.Point(38, 106);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.BackColor = System.Drawing.Color.Transparent;
            this.lblCorreo.ForeColor = System.Drawing.Color.Black;
            this.lblCorreo.Location = new System.Drawing.Point(44, 134);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(41, 13);
            this.lblCorreo.TabIndex = 2;
            this.lblCorreo.Text = "Correo:";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.BackColor = System.Drawing.Color.Transparent;
            this.lblDni.ForeColor = System.Drawing.Color.Black;
            this.lblDni.Location = new System.Drawing.Point(56, 52);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(29, 13);
            this.lblDni.TabIndex = 3;
            this.lblDni.Text = "DNI:";
            // 
            // btnRegsitrar
            // 
            this.btnRegsitrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnRegsitrar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRegsitrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegsitrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegsitrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRegsitrar.Location = new System.Drawing.Point(101, 184);
            this.btnRegsitrar.Name = "btnRegsitrar";
            this.btnRegsitrar.Size = new System.Drawing.Size(90, 28);
            this.btnRegsitrar.TabIndex = 4;
            this.btnRegsitrar.Text = "Registrar";
            this.btnRegsitrar.UseVisualStyleBackColor = false;
            this.btnRegsitrar.Click += new System.EventHandler(this.btnRegsitrar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Location = new System.Drawing.Point(91, 77);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 13);
            this.txtNombre.TabIndex = 5;
            // 
            // txtApellido
            // 
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtApellido.Location = new System.Drawing.Point(91, 106);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 13);
            this.txtApellido.TabIndex = 6;
            // 
            // txtCorreo
            // 
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorreo.Location = new System.Drawing.Point(91, 134);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(100, 13);
            this.txtCorreo.TabIndex = 7;
            // 
            // txtDni
            // 
            this.txtDni.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDni.Location = new System.Drawing.Point(91, 52);
            this.txtDni.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(100, 13);
            this.txtDni.TabIndex = 8;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelefono.Location = new System.Drawing.Point(91, 159);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 13);
            this.txtTelefono.TabIndex = 9;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.BackColor = System.Drawing.Color.Transparent;
            this.lblTelefono.ForeColor = System.Drawing.Color.Black;
            this.lblTelefono.Location = new System.Drawing.Point(33, 159);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 10;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // FrmRegistrarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(251, 260);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnRegsitrar);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRegistrarCliente";
            this.Text = "Registrar Cliente";
            this.Load += new System.EventHandler(this.RegistrarCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Button btnRegsitrar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
    }
}