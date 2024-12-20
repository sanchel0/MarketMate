﻿namespace UI
{
    partial class FrmRegistrarProveedor
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
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCbu = new System.Windows.Forms.TextBox();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtRazon = new System.Windows.Forms.TextBox();
            this.lblCbu = new System.Windows.Forms.Label();
            this.lblBanco = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblRazon = new System.Windows.Forms.Label();
            this.lblDir = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblCuit = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblProcessType = new System.Windows.Forms.Label();
            this.btnRegistrar = new UI.CustomButton();
            this.btnSalir = new UI.CustomButton();
            this.cboTipoCuenta = new System.Windows.Forms.ComboBox();
            this.lblTipoCuenta = new System.Windows.Forms.Label();
            this.lblAlias = new System.Windows.Forms.Label();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.lblNumCuenta = new System.Windows.Forms.Label();
            this.txtNumCuenta = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtCuit
            // 
            this.txtCuit.Location = new System.Drawing.Point(114, 63);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(100, 20);
            this.txtCuit.TabIndex = 0;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(114, 89);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // txtCbu
            // 
            this.txtCbu.Location = new System.Drawing.Point(114, 324);
            this.txtCbu.Name = "txtCbu";
            this.txtCbu.Size = new System.Drawing.Size(100, 20);
            this.txtCbu.TabIndex = 2;
            // 
            // txtBanco
            // 
            this.txtBanco.Location = new System.Drawing.Point(114, 219);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(100, 20);
            this.txtBanco.TabIndex = 3;
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(114, 193);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(100, 20);
            this.txtDir.TabIndex = 4;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(114, 167);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(100, 20);
            this.txtCorreo.TabIndex = 5;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(114, 141);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(100, 20);
            this.txtTel.TabIndex = 6;
            // 
            // txtRazon
            // 
            this.txtRazon.Location = new System.Drawing.Point(114, 115);
            this.txtRazon.Name = "txtRazon";
            this.txtRazon.Size = new System.Drawing.Size(100, 20);
            this.txtRazon.TabIndex = 7;
            // 
            // lblCbu
            // 
            this.lblCbu.AutoSize = true;
            this.lblCbu.Location = new System.Drawing.Point(66, 327);
            this.lblCbu.Name = "lblCbu";
            this.lblCbu.Size = new System.Drawing.Size(32, 13);
            this.lblCbu.TabIndex = 8;
            this.lblCbu.Text = "CBU:";
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Location = new System.Drawing.Point(57, 222);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(41, 13);
            this.lblBanco.TabIndex = 9;
            this.lblBanco.Text = "Banco:";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(46, 144);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(52, 13);
            this.lblTel.TabIndex = 10;
            this.lblTel.Text = "Telefono:";
            // 
            // lblRazon
            // 
            this.lblRazon.AutoSize = true;
            this.lblRazon.Location = new System.Drawing.Point(25, 118);
            this.lblRazon.Name = "lblRazon";
            this.lblRazon.Size = new System.Drawing.Size(73, 13);
            this.lblRazon.TabIndex = 11;
            this.lblRazon.Text = "Razon Social:";
            // 
            // lblDir
            // 
            this.lblDir.AutoSize = true;
            this.lblDir.Location = new System.Drawing.Point(43, 196);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(55, 13);
            this.lblDir.TabIndex = 12;
            this.lblDir.Text = "Direccion:";
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Location = new System.Drawing.Point(57, 170);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(41, 13);
            this.lblCorreo.TabIndex = 13;
            this.lblCorreo.Text = "Correo:";
            // 
            // lblCuit
            // 
            this.lblCuit.AutoSize = true;
            this.lblCuit.Location = new System.Drawing.Point(63, 66);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(35, 13);
            this.lblCuit.TabIndex = 14;
            this.lblCuit.Text = "CUIT:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(51, 92);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 15;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblProcessType
            // 
            this.lblProcessType.AutoSize = true;
            this.lblProcessType.Location = new System.Drawing.Point(77, 21);
            this.lblProcessType.Name = "lblProcessType";
            this.lblProcessType.Size = new System.Drawing.Size(76, 13);
            this.lblProcessType.TabIndex = 16;
            this.lblProcessType.Text = "tipo de registro";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegistrar.Location = new System.Drawing.Point(49, 380);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 17;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.Location = new System.Drawing.Point(139, 380);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 18;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // cboTipoCuenta
            // 
            this.cboTipoCuenta.FormattingEnabled = true;
            this.cboTipoCuenta.Location = new System.Drawing.Point(114, 245);
            this.cboTipoCuenta.Name = "cboTipoCuenta";
            this.cboTipoCuenta.Size = new System.Drawing.Size(100, 21);
            this.cboTipoCuenta.TabIndex = 19;
            // 
            // lblTipoCuenta
            // 
            this.lblTipoCuenta.AutoSize = true;
            this.lblTipoCuenta.Location = new System.Drawing.Point(30, 248);
            this.lblTipoCuenta.Name = "lblTipoCuenta";
            this.lblTipoCuenta.Size = new System.Drawing.Size(68, 13);
            this.lblTipoCuenta.TabIndex = 20;
            this.lblTipoCuenta.Text = "Tipo Cuenta:";
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.Location = new System.Drawing.Point(66, 301);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(32, 13);
            this.lblAlias.TabIndex = 22;
            this.lblAlias.Text = "Alias:";
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(114, 298);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(100, 20);
            this.txtAlias.TabIndex = 21;
            // 
            // lblNumCuenta
            // 
            this.lblNumCuenta.AutoSize = true;
            this.lblNumCuenta.Location = new System.Drawing.Point(14, 275);
            this.lblNumCuenta.Name = "lblNumCuenta";
            this.lblNumCuenta.Size = new System.Drawing.Size(84, 13);
            this.lblNumCuenta.TabIndex = 24;
            this.lblNumCuenta.Text = "Numero Cuenta:";
            // 
            // txtNumCuenta
            // 
            this.txtNumCuenta.Location = new System.Drawing.Point(114, 272);
            this.txtNumCuenta.Name = "txtNumCuenta";
            this.txtNumCuenta.Size = new System.Drawing.Size(100, 20);
            this.txtNumCuenta.TabIndex = 23;
            // 
            // FrmRegistrarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(265, 445);
            this.Controls.Add(this.lblNumCuenta);
            this.Controls.Add(this.txtNumCuenta);
            this.Controls.Add(this.lblAlias);
            this.Controls.Add(this.txtAlias);
            this.Controls.Add(this.lblTipoCuenta);
            this.Controls.Add(this.cboTipoCuenta);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.lblProcessType);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCuit);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.lblDir);
            this.Controls.Add(this.lblRazon);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.lblBanco);
            this.Controls.Add(this.lblCbu);
            this.Controls.Add(this.txtRazon);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.txtBanco);
            this.Controls.Add(this.txtCbu);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCuit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRegistrarProveedor";
            this.Text = "Registrar Proveedor";
            this.Load += new System.EventHandler(this.FrmRegistrarProveedor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCbu;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtRazon;
        private System.Windows.Forms.Label lblCbu;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblRazon;
        private System.Windows.Forms.Label lblDir;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblProcessType;
        private System.Windows.Forms.ComboBox cboTipoCuenta;
        private System.Windows.Forms.Label lblTipoCuenta;
        private System.Windows.Forms.Label lblAlias;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.Label lblNumCuenta;
        private System.Windows.Forms.TextBox txtNumCuenta;
        private CustomButton btnRegistrar;
        private CustomButton btnSalir;
    }
}