namespace UI
{
    partial class FrmReparacion
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
            this.btnSalir = new UI.CustomButton();
            this.btnRestore = new UI.CustomButton();
            this.btnRecalcular = new UI.CustomButton();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.Location = new System.Drawing.Point(79, 110);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRestore.Location = new System.Drawing.Point(79, 81);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 4;
            this.btnRestore.Text = "Restore BD";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnRecalcular
            // 
            this.btnRecalcular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnRecalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecalcular.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRecalcular.Location = new System.Drawing.Point(79, 52);
            this.btnRecalcular.Name = "btnRecalcular";
            this.btnRecalcular.Size = new System.Drawing.Size(75, 23);
            this.btnRecalcular.TabIndex = 3;
            this.btnRecalcular.Text = "Recalcular DV";
            this.btnRecalcular.UseVisualStyleBackColor = true;
            this.btnRecalcular.Click += new System.EventHandler(this.btnRecalcular_Click);
            // 
            // FrmReparacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(225, 190);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnRecalcular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmReparacion";
            this.Text = "Reparacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmReparacion_FormClosing);
            this.Load += new System.EventHandler(this.FrmReparacion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomButton btnSalir;
        private CustomButton btnRestore;
        private CustomButton btnRecalcular;
    }
}