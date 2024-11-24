namespace UI
{
    partial class FrmGenerarTicket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGenerarTicket));
            this.dgvProductos = new UI.CustomDataGridView();
            this.btnSeleccionarProds = new UI.CustomButton();
            this.btnVerificar = new UI.CustomButton();
            this.btnRegistrarCli = new UI.CustomButton();
            this.btnCobrar = new UI.CustomButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.grpCli = new System.Windows.Forms.GroupBox();
            this.grpProds = new System.Windows.Forms.GroupBox();
            this.btnFinalizar = new UI.CustomButton();
            this.btnSalir = new UI.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.grpCli.SuspendLayout();
            this.grpProds.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(6, 20);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(378, 199);
            this.dgvProductos.TabIndex = 0;
            // 
            // btnSeleccionarProds
            // 
            this.btnSeleccionarProds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnSeleccionarProds.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSeleccionarProds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarProds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarProds.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSeleccionarProds.Location = new System.Drawing.Point(6, 225);
            this.btnSeleccionarProds.Name = "btnSeleccionarProds";
            this.btnSeleccionarProds.Size = new System.Drawing.Size(167, 28);
            this.btnSeleccionarProds.TabIndex = 1;
            this.btnSeleccionarProds.Text = "Seleccionar Productos";
            this.btnSeleccionarProds.UseVisualStyleBackColor = false;
            this.btnSeleccionarProds.Click += new System.EventHandler(this.btnRegistrarProds_Click);
            // 
            // btnVerificar
            // 
            this.btnVerificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnVerificar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnVerificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerificar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVerificar.Location = new System.Drawing.Point(10, 55);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(175, 28);
            this.btnVerificar.TabIndex = 2;
            this.btnVerificar.Text = "Verificar";
            this.btnVerificar.UseVisualStyleBackColor = false;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // btnRegistrarCli
            // 
            this.btnRegistrarCli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnRegistrarCli.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRegistrarCli.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarCli.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegistrarCli.Location = new System.Drawing.Point(10, 84);
            this.btnRegistrarCli.Name = "btnRegistrarCli";
            this.btnRegistrarCli.Size = new System.Drawing.Size(175, 28);
            this.btnRegistrarCli.TabIndex = 3;
            this.btnRegistrarCli.Text = "Registrar Cliente";
            this.btnRegistrarCli.UseVisualStyleBackColor = false;
            this.btnRegistrarCli.Click += new System.EventHandler(this.btnRegistrarCli_Click);
            // 
            // btnCobrar
            // 
            this.btnCobrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnCobrar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCobrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCobrar.Location = new System.Drawing.Point(521, 203);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(90, 28);
            this.btnCobrar.TabIndex = 4;
            this.btnCobrar.Text = "Cobrar Venta";
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "DNI Cliente:";
            // 
            // txtDni
            // 
            this.txtDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDni.Location = new System.Drawing.Point(85, 30);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(100, 21);
            this.txtDni.TabIndex = 6;
            // 
            // grpCli
            // 
            this.grpCli.BackColor = System.Drawing.Color.White;
            this.grpCli.Controls.Add(this.label1);
            this.grpCli.Controls.Add(this.txtDni);
            this.grpCli.Controls.Add(this.btnVerificar);
            this.grpCli.Controls.Add(this.btnRegistrarCli);
            this.grpCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCli.ForeColor = System.Drawing.Color.Black;
            this.grpCli.Location = new System.Drawing.Point(413, 37);
            this.grpCli.Name = "grpCli";
            this.grpCli.Size = new System.Drawing.Size(198, 121);
            this.grpCli.TabIndex = 7;
            this.grpCli.TabStop = false;
            this.grpCli.Text = "Cliente";
            // 
            // grpProds
            // 
            this.grpProds.BackColor = System.Drawing.Color.White;
            this.grpProds.Controls.Add(this.dgvProductos);
            this.grpProds.Controls.Add(this.btnSeleccionarProds);
            this.grpProds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpProds.ForeColor = System.Drawing.Color.Black;
            this.grpProds.Location = new System.Drawing.Point(12, 37);
            this.grpProds.Name = "grpProds";
            this.grpProds.Size = new System.Drawing.Size(395, 262);
            this.grpProds.TabIndex = 8;
            this.grpProds.TabStop = false;
            this.grpProds.Text = "Productos";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnFinalizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFinalizar.Location = new System.Drawing.Point(521, 237);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(90, 28);
            this.btnFinalizar.TabIndex = 9;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.Location = new System.Drawing.Point(521, 271);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 28);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmGenerarTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(638, 318);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.grpProds);
            this.Controls.Add(this.grpCli);
            this.Controls.Add(this.btnCobrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmGenerarTicket";
            this.Text = "Generar Ticket";
            this.Load += new System.EventHandler(this.GenerarTicket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.grpCli.ResumeLayout(false);
            this.grpCli.PerformLayout();
            this.grpProds.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.GroupBox grpCli;
        private System.Windows.Forms.GroupBox grpProds;
        private CustomDataGridView dgvProductos;
        private CustomButton btnSeleccionarProds;
        private CustomButton btnVerificar;
        private CustomButton btnRegistrarCli;
        private CustomButton btnCobrar;
        private CustomButton btnFinalizar;
        private CustomButton btnSalir;
    }
}