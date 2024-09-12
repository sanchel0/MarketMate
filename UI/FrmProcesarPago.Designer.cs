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
            this.lblNumTransac = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtNumTransac = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnRegistrarPago = new System.Windows.Forms.Button();
            this.lblNumOrden = new System.Windows.Forms.Label();
            this.txtNumOrden = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblNumTransac
            // 
            this.lblNumTransac.AutoSize = true;
            this.lblNumTransac.Location = new System.Drawing.Point(50, 71);
            this.lblNumTransac.Name = "lblNumTransac";
            this.lblNumTransac.Size = new System.Drawing.Size(124, 13);
            this.lblNumTransac.TabIndex = 0;
            this.lblNumTransac.Text = "Numero de Transaccion:";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(134, 97);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(40, 13);
            this.lblMonto.TabIndex = 1;
            this.lblMonto.Text = "Monto:";
            // 
            // txtNumTransac
            // 
            this.txtNumTransac.Location = new System.Drawing.Point(189, 68);
            this.txtNumTransac.Name = "txtNumTransac";
            this.txtNumTransac.Size = new System.Drawing.Size(100, 20);
            this.txtNumTransac.TabIndex = 2;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(189, 94);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 3;
            // 
            // btnRegistrarPago
            // 
            this.btnRegistrarPago.Location = new System.Drawing.Point(204, 120);
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
            this.lblNumOrden.Location = new System.Drawing.Point(26, 45);
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
            // FrmProcesarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 175);
            this.Controls.Add(this.txtNumOrden);
            this.Controls.Add(this.lblNumOrden);
            this.Controls.Add(this.btnRegistrarPago);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.txtNumTransac);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblNumTransac);
            this.Name = "FrmProcesarPago";
            this.Text = "FrmProcesarPago";
            this.Load += new System.EventHandler(this.FrmProcesarPago_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumTransac;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtNumTransac;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnRegistrarPago;
        private System.Windows.Forms.Label lblNumOrden;
        private System.Windows.Forms.TextBox txtNumOrden;
    }
}