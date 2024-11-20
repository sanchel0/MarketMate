namespace UI
{
    partial class FrmTickets
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
            this.dgvTickets = new UI.CustomDataGridView();
            this.btnGenerar = new UI.CustomButton();
            this.btnSalir = new UI.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTickets
            // 
            this.dgvTickets.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvTickets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTickets.Location = new System.Drawing.Point(33, 37);
            this.dgvTickets.Name = "dgvTickets";
            this.dgvTickets.Size = new System.Drawing.Size(576, 227);
            this.dgvTickets.TabIndex = 0;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGenerar.Location = new System.Drawing.Point(430, 309);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(98, 23);
            this.btnGenerar.TabIndex = 1;
            this.btnGenerar.Text = "Generar PDF";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.Location = new System.Drawing.Point(534, 309);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(641, 360);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.dgvTickets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmTickets";
            this.Text = "Tickets";
            this.Load += new System.EventHandler(this.FrmTickets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomDataGridView dgvTickets;
        private CustomButton btnGenerar;
        private CustomButton btnSalir;
    }
}