﻿namespace UI
{
    partial class FrmRotacionProductos
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
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoMayor = new System.Windows.Forms.RadioButton();
            this.rdoMenor = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpInicio
            // 
            this.dtpInicio.Location = new System.Drawing.Point(314, 78);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpInicio.TabIndex = 2;
            // 
            // dtpFin
            // 
            this.dtpFin.Location = new System.Drawing.Point(314, 105);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFin.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fin";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(152, 206);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 6;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(233, 206);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tipo de Rotación:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoMayor);
            this.panel1.Controls.Add(this.rdoMenor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(49, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 61);
            this.panel1.TabIndex = 9;
            // 
            // rdoMayor
            // 
            this.rdoMayor.AutoSize = true;
            this.rdoMayor.Location = new System.Drawing.Point(34, 34);
            this.rdoMayor.Name = "rdoMayor";
            this.rdoMayor.Size = new System.Drawing.Size(54, 17);
            this.rdoMayor.TabIndex = 12;
            this.rdoMayor.TabStop = true;
            this.rdoMayor.Text = "Mayor";
            this.rdoMayor.UseVisualStyleBackColor = true;
            // 
            // rdoMenor
            // 
            this.rdoMenor.AutoSize = true;
            this.rdoMenor.Location = new System.Drawing.Point(95, 34);
            this.rdoMenor.Name = "rdoMenor";
            this.rdoMenor.Size = new System.Drawing.Size(55, 17);
            this.rdoMenor.TabIndex = 13;
            this.rdoMenor.TabStop = true;
            this.rdoMenor.Text = "Menor";
            this.rdoMenor.UseVisualStyleBackColor = true;
            // 
            // FrmRotacionProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 291);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFin);
            this.Controls.Add(this.dtpInicio);
            this.Name = "FrmRotacionProductos";
            this.Text = "FrmRotacionProductos";
            this.Load += new System.EventHandler(this.FrmRotacionProductos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdoMayor;
        private System.Windows.Forms.RadioButton rdoMenor;
    }
}