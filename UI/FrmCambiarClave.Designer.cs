namespace UI
{
    partial class FrmCambiarClave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCambiarClave));
            this.lblCurrent = new System.Windows.Forms.Label();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.lblNew = new System.Windows.Forms.Label();
            this.btnAceptar = new UI.CustomButton();
            this.SuspendLayout();
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrent.Location = new System.Drawing.Point(75, 64);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(106, 15);
            this.lblCurrent.TabIndex = 18;
            this.lblCurrent.Text = "Contraseña Actual";
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentPassword.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtCurrentPassword.Location = new System.Drawing.Point(187, 64);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.Size = new System.Drawing.Size(154, 20);
            this.txtCurrentPassword.TabIndex = 17;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtConfirmPassword.Location = new System.Drawing.Point(187, 116);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(154, 20);
            this.txtConfirmPassword.TabIndex = 16;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtNewPassword.Location = new System.Drawing.Point(187, 90);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(154, 20);
            this.txtNewPassword.TabIndex = 15;
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirm.Location = new System.Drawing.Point(56, 116);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(127, 15);
            this.lblConfirm.TabIndex = 14;
            this.lblConfirm.Text = "Confirmar Contraseña";
            // 
            // lblNew
            // 
            this.lblNew.AutoSize = true;
            this.lblNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNew.Location = new System.Drawing.Point(75, 90);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(108, 15);
            this.lblNew.TabIndex = 13;
            this.lblNew.Text = "Nueva Contraseña";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(137, 165);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 28);
            this.btnAceptar.TabIndex = 19;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // FrmCambiarClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(406, 237);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.txtCurrentPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.lblNew);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCambiarClave";
            this.Text = "Cambiar Clave";
            this.Load += new System.EventHandler(this.FrmCambiarClave_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.Label lblNew;
        private CustomButton btnAceptar;
    }
}