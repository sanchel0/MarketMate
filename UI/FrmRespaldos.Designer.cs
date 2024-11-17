namespace UI
{
    partial class FrmRespaldos
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
            this.btnAplicarB = new System.Windows.Forms.Button();
            this.btnAplicarR = new System.Windows.Forms.Button();
            this.txtRestorePath = new System.Windows.Forms.TextBox();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.picBackup = new System.Windows.Forms.PictureBox();
            this.grpBackup = new System.Windows.Forms.GroupBox();
            this.grpRestore = new System.Windows.Forms.GroupBox();
            this.picRestore = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBackup)).BeginInit();
            this.grpBackup.SuspendLayout();
            this.grpRestore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRestore)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAplicarB
            // 
            this.btnAplicarB.Location = new System.Drawing.Point(19, 94);
            this.btnAplicarB.Name = "btnAplicarB";
            this.btnAplicarB.Size = new System.Drawing.Size(343, 23);
            this.btnAplicarB.TabIndex = 0;
            this.btnAplicarB.Text = "Aplicar";
            this.btnAplicarB.UseVisualStyleBackColor = true;
            this.btnAplicarB.Click += new System.EventHandler(this.btnAplicarB_Click);
            // 
            // btnAplicarR
            // 
            this.btnAplicarR.Location = new System.Drawing.Point(16, 94);
            this.btnAplicarR.Name = "btnAplicarR";
            this.btnAplicarR.Size = new System.Drawing.Size(343, 23);
            this.btnAplicarR.TabIndex = 1;
            this.btnAplicarR.Text = "Aplicar";
            this.btnAplicarR.UseVisualStyleBackColor = true;
            this.btnAplicarR.Click += new System.EventHandler(this.btnAplicarR_Click);
            // 
            // txtRestorePath
            // 
            this.txtRestorePath.Location = new System.Drawing.Point(16, 40);
            this.txtRestorePath.Name = "txtRestorePath";
            this.txtRestorePath.ReadOnly = true;
            this.txtRestorePath.Size = new System.Drawing.Size(290, 20);
            this.txtRestorePath.TabIndex = 2;
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(19, 40);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.ReadOnly = true;
            this.txtBackupPath.Size = new System.Drawing.Size(290, 20);
            this.txtBackupPath.TabIndex = 3;
            // 
            // picBackup
            // 
            this.picBackup.Image = global::UI.Properties.Resources.folder1;
            this.picBackup.Location = new System.Drawing.Point(315, 32);
            this.picBackup.Name = "picBackup";
            this.picBackup.Size = new System.Drawing.Size(47, 36);
            this.picBackup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBackup.TabIndex = 4;
            this.picBackup.TabStop = false;
            this.picBackup.Click += new System.EventHandler(this.picBackup_Click);
            // 
            // grpBackup
            // 
            this.grpBackup.Controls.Add(this.btnAplicarB);
            this.grpBackup.Controls.Add(this.picBackup);
            this.grpBackup.Controls.Add(this.txtBackupPath);
            this.grpBackup.Location = new System.Drawing.Point(29, 21);
            this.grpBackup.Name = "grpBackup";
            this.grpBackup.Size = new System.Drawing.Size(381, 163);
            this.grpBackup.TabIndex = 5;
            this.grpBackup.TabStop = false;
            this.grpBackup.Text = "Backup";
            // 
            // grpRestore
            // 
            this.grpRestore.Controls.Add(this.picRestore);
            this.grpRestore.Controls.Add(this.btnAplicarR);
            this.grpRestore.Controls.Add(this.txtRestorePath);
            this.grpRestore.Location = new System.Drawing.Point(29, 190);
            this.grpRestore.Name = "grpRestore";
            this.grpRestore.Size = new System.Drawing.Size(381, 163);
            this.grpRestore.TabIndex = 6;
            this.grpRestore.TabStop = false;
            this.grpRestore.Text = "Restore";
            // 
            // picRestore
            // 
            this.picRestore.Image = global::UI.Properties.Resources.folder1;
            this.picRestore.Location = new System.Drawing.Point(312, 32);
            this.picRestore.Name = "picRestore";
            this.picRestore.Size = new System.Drawing.Size(47, 36);
            this.picRestore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRestore.TabIndex = 7;
            this.picRestore.TabStop = false;
            this.picRestore.Click += new System.EventHandler(this.picRestore_Click);
            // 
            // FrmRespaldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 368);
            this.Controls.Add(this.grpRestore);
            this.Controls.Add(this.grpBackup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRespaldos";
            this.Text = "Respaldos";
            this.Load += new System.EventHandler(this.FrmRespaldos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBackup)).EndInit();
            this.grpBackup.ResumeLayout(false);
            this.grpBackup.PerformLayout();
            this.grpRestore.ResumeLayout(false);
            this.grpRestore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRestore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAplicarB;
        private System.Windows.Forms.Button btnAplicarR;
        private System.Windows.Forms.TextBox txtRestorePath;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.PictureBox picBackup;
        private System.Windows.Forms.GroupBox grpBackup;
        private System.Windows.Forms.GroupBox grpRestore;
        private System.Windows.Forms.PictureBox picRestore;
    }
}