namespace UI
{
    partial class FrmCambiarIdioma
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblIdiomas = new System.Windows.Forms.Label();
            this.cboIdiomas = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(136, 130);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Confirmar";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblIdiomas
            // 
            this.lblIdiomas.AutoSize = true;
            this.lblIdiomas.Location = new System.Drawing.Point(78, 78);
            this.lblIdiomas.Name = "lblIdiomas";
            this.lblIdiomas.Size = new System.Drawing.Size(43, 13);
            this.lblIdiomas.TabIndex = 1;
            this.lblIdiomas.Text = "Idiomas";
            // 
            // cboIdiomas
            // 
            this.cboIdiomas.FormattingEnabled = true;
            this.cboIdiomas.Location = new System.Drawing.Point(127, 75);
            this.cboIdiomas.Name = "cboIdiomas";
            this.cboIdiomas.Size = new System.Drawing.Size(121, 21);
            this.cboIdiomas.TabIndex = 2;
            // 
            // FrmCambiarIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 206);
            this.Controls.Add(this.cboIdiomas);
            this.Controls.Add(this.lblIdiomas);
            this.Controls.Add(this.btnConfirm);
            this.Name = "FrmCambiarIdioma";
            this.Text = "Cambiar Idioma";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblIdiomas;
        private System.Windows.Forms.ComboBox cboIdiomas;
    }
}