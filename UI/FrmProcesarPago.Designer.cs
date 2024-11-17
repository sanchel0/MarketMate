namespace UI
{
    partial class FrmProcesarPago
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
            this.lblNumTransfer = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtNumTransac = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnRegistrarPago = new System.Windows.Forms.Button();
            this.lblNumOrden = new System.Windows.Forms.Label();
            this.txtNumOrden = new System.Windows.Forms.TextBox();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNumTransfer
            // 
            this.lblNumTransfer.AutoSize = true;
            this.lblNumTransfer.Location = new System.Drawing.Point(50, 149);
            this.lblNumTransfer.Name = "lblNumTransfer";
            this.lblNumTransfer.Size = new System.Drawing.Size(130, 13);
            this.lblNumTransfer.TabIndex = 0;
            this.lblNumTransfer.Text = "Numero de Transferencia:";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(140, 123);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(40, 13);
            this.lblMonto.TabIndex = 1;
            this.lblMonto.Text = "Monto:";
            // 
            // txtNumTransac
            // 
            this.txtNumTransac.Location = new System.Drawing.Point(189, 146);
            this.txtNumTransac.Name = "txtNumTransac";
            this.txtNumTransac.Size = new System.Drawing.Size(100, 20);
            this.txtNumTransac.TabIndex = 2;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(189, 120);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 3;
            // 
            // btnRegistrarPago
            // 
            this.btnRegistrarPago.Location = new System.Drawing.Point(123, 172);
            this.btnRegistrarPago.Name = "btnRegistrarPago";
            this.btnRegistrarPago.Size = new System.Drawing.Size(85, 23);
            this.btnRegistrarPago.TabIndex = 4;
            this.btnRegistrarPago.Text = "Registrar Pago";
            this.btnRegistrarPago.UseVisualStyleBackColor = true;
            this.btnRegistrarPago.Click += new System.EventHandler(this.btnRegistrarPago_Click);
            // 
            // lblNumOrden
            // 
            this.lblNumOrden.AutoSize = true;
            this.lblNumOrden.Location = new System.Drawing.Point(32, 45);
            this.lblNumOrden.Name = "lblNumOrden";
            this.lblNumOrden.Size = new System.Drawing.Size(148, 13);
            this.lblNumOrden.TabIndex = 5;
            this.lblNumOrden.Text = "Numero de Orden de Compra:";
            // 
            // txtNumOrden
            // 
            this.txtNumOrden.Location = new System.Drawing.Point(189, 42);
            this.txtNumOrden.Name = "txtNumOrden";
            this.txtNumOrden.ReadOnly = true;
            this.txtNumOrden.Size = new System.Drawing.Size(100, 20);
            this.txtNumOrden.TabIndex = 6;
            // 
            // txtBanco
            // 
            this.txtBanco.Location = new System.Drawing.Point(189, 68);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.ReadOnly = true;
            this.txtBanco.Size = new System.Drawing.Size(100, 20);
            this.txtBanco.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Banco:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(189, 94);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "CBU:";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(214, 172);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmProcesarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 220);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBanco);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumOrden);
            this.Controls.Add(this.lblNumOrden);
            this.Controls.Add(this.btnRegistrarPago);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.txtNumTransac);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblNumTransfer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmProcesarPago";
            this.Text = "Procesar Pago";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmProcesarPago_FormClosing);
            this.Load += new System.EventHandler(this.FrmProcesarPago_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumTransfer;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtNumTransac;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnRegistrarPago;
        private System.Windows.Forms.Label lblNumOrden;
        private System.Windows.Forms.TextBox txtNumOrden;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalir;
    }
}