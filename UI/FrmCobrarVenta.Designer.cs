namespace UI
{
    partial class FrmCobrarVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCobrarVenta));
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtNumTarjeta = new System.Windows.Forms.TextBox();
            this.txtNumTransaccion = new System.Windows.Forms.TextBox();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblNumTarjeta = new System.Windows.Forms.Label();
            this.lblNumTransaccion = new System.Windows.Forms.Label();
            this.lblAlias = new System.Windows.Forms.Label();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.cboMetodoPago = new System.Windows.Forms.ComboBox();
            this.dtpFechaTransaccion = new System.Windows.Forms.DateTimePicker();
            this.btnFinalizar = new UI.CustomButton();
            this.btnConectar = new UI.CustomButton();
            this.cboTipoTarjeta = new System.Windows.Forms.ComboBox();
            this.lblTipoTarjeta = new System.Windows.Forms.Label();
            this.lblNumTicket = new System.Windows.Forms.Label();
            this.txtNumTicket = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.BackColor = System.Drawing.Color.Transparent;
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.lblCliente.Location = new System.Drawing.Point(12, 57);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.BackColor = System.Drawing.Color.Transparent;
            this.lblMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.lblMonto.Location = new System.Drawing.Point(12, 76);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(40, 13);
            this.lblMonto.TabIndex = 3;
            this.lblMonto.Text = "Monto:";
            // 
            // txtCliente
            // 
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCliente.Enabled = false;
            this.txtCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.txtCliente.Location = new System.Drawing.Point(152, 57);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(200, 13);
            this.txtCliente.TabIndex = 4;
            // 
            // txtMonto
            // 
            this.txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMonto.Enabled = false;
            this.txtMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.txtMonto.Location = new System.Drawing.Point(152, 76);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(200, 13);
            this.txtMonto.TabIndex = 5;
            // 
            // txtNumTarjeta
            // 
            this.txtNumTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.txtNumTarjeta.Location = new System.Drawing.Point(152, 176);
            this.txtNumTarjeta.Name = "txtNumTarjeta";
            this.txtNumTarjeta.Size = new System.Drawing.Size(200, 13);
            this.txtNumTarjeta.TabIndex = 6;
            // 
            // txtNumTransaccion
            // 
            this.txtNumTransaccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumTransaccion.Enabled = false;
            this.txtNumTransaccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.txtNumTransaccion.Location = new System.Drawing.Point(152, 214);
            this.txtNumTransaccion.Name = "txtNumTransaccion";
            this.txtNumTransaccion.Size = new System.Drawing.Size(200, 13);
            this.txtNumTransaccion.TabIndex = 7;
            // 
            // txtAlias
            // 
            this.txtAlias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAlias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.txtAlias.Location = new System.Drawing.Point(152, 195);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(200, 13);
            this.txtAlias.TabIndex = 8;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.lblFecha.Location = new System.Drawing.Point(12, 101);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 9;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblNumTarjeta
            // 
            this.lblNumTarjeta.AutoSize = true;
            this.lblNumTarjeta.BackColor = System.Drawing.Color.Transparent;
            this.lblNumTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.lblNumTarjeta.Location = new System.Drawing.Point(12, 176);
            this.lblNumTarjeta.Name = "lblNumTarjeta";
            this.lblNumTarjeta.Size = new System.Drawing.Size(98, 13);
            this.lblNumTarjeta.TabIndex = 10;
            this.lblNumTarjeta.Text = "Número de Tarjeta:";
            // 
            // lblNumTransaccion
            // 
            this.lblNumTransaccion.AutoSize = true;
            this.lblNumTransaccion.BackColor = System.Drawing.Color.Transparent;
            this.lblNumTransaccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.lblNumTransaccion.Location = new System.Drawing.Point(12, 214);
            this.lblNumTransaccion.Name = "lblNumTransaccion";
            this.lblNumTransaccion.Size = new System.Drawing.Size(124, 13);
            this.lblNumTransaccion.TabIndex = 11;
            this.lblNumTransaccion.Text = "Número de Transacción:";
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.BackColor = System.Drawing.Color.Transparent;
            this.lblAlias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.lblAlias.Location = new System.Drawing.Point(12, 195);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(32, 13);
            this.lblAlias.TabIndex = 12;
            this.lblAlias.Text = "Alias:";
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.BackColor = System.Drawing.Color.Transparent;
            this.lblMetodoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.lblMetodoPago.Location = new System.Drawing.Point(12, 125);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(89, 13);
            this.lblMetodoPago.TabIndex = 13;
            this.lblMetodoPago.Text = "Método de Pago:";
            // 
            // cboMetodoPago
            // 
            this.cboMetodoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMetodoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.cboMetodoPago.FormattingEnabled = true;
            this.cboMetodoPago.Location = new System.Drawing.Point(152, 122);
            this.cboMetodoPago.Name = "cboMetodoPago";
            this.cboMetodoPago.Size = new System.Drawing.Size(200, 21);
            this.cboMetodoPago.TabIndex = 14;
            this.cboMetodoPago.SelectedIndexChanged += new System.EventHandler(this.cboMetodoPago_SelectedIndexChanged);
            // 
            // dtpFechaTransaccion
            // 
            this.dtpFechaTransaccion.Enabled = false;
            this.dtpFechaTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaTransaccion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaTransaccion.Location = new System.Drawing.Point(152, 95);
            this.dtpFechaTransaccion.Name = "dtpFechaTransaccion";
            this.dtpFechaTransaccion.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaTransaccion.TabIndex = 15;
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnFinalizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFinalizar.Location = new System.Drawing.Point(262, 248);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(90, 28);
            this.btnFinalizar.TabIndex = 16;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnConectar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnConectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConectar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConectar.Location = new System.Drawing.Point(166, 248);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(90, 28);
            this.btnConectar.TabIndex = 17;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = false;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // cboTipoTarjeta
            // 
            this.cboTipoTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.cboTipoTarjeta.FormattingEnabled = true;
            this.cboTipoTarjeta.Location = new System.Drawing.Point(152, 149);
            this.cboTipoTarjeta.Name = "cboTipoTarjeta";
            this.cboTipoTarjeta.Size = new System.Drawing.Size(200, 21);
            this.cboTipoTarjeta.TabIndex = 18;
            // 
            // lblTipoTarjeta
            // 
            this.lblTipoTarjeta.AutoSize = true;
            this.lblTipoTarjeta.BackColor = System.Drawing.Color.Transparent;
            this.lblTipoTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.lblTipoTarjeta.Location = new System.Drawing.Point(12, 152);
            this.lblTipoTarjeta.Name = "lblTipoTarjeta";
            this.lblTipoTarjeta.Size = new System.Drawing.Size(82, 13);
            this.lblTipoTarjeta.TabIndex = 19;
            this.lblTipoTarjeta.Text = "Tipo de Tarjeta:";
            // 
            // lblNumTicket
            // 
            this.lblNumTicket.AutoSize = true;
            this.lblNumTicket.BackColor = System.Drawing.Color.Transparent;
            this.lblNumTicket.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.lblNumTicket.Location = new System.Drawing.Point(12, 38);
            this.lblNumTicket.Name = "lblNumTicket";
            this.lblNumTicket.Size = new System.Drawing.Size(95, 13);
            this.lblNumTicket.TabIndex = 21;
            this.lblNumTicket.Text = "Número de Ticket:";
            // 
            // txtNumTicket
            // 
            this.txtNumTicket.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumTicket.Enabled = false;
            this.txtNumTicket.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(52)))));
            this.txtNumTicket.Location = new System.Drawing.Point(152, 38);
            this.txtNumTicket.Name = "txtNumTicket";
            this.txtNumTicket.Size = new System.Drawing.Size(200, 13);
            this.txtNumTicket.TabIndex = 20;
            // 
            // FrmCobrarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(404, 297);
            this.Controls.Add(this.lblNumTicket);
            this.Controls.Add(this.txtNumTicket);
            this.Controls.Add(this.lblTipoTarjeta);
            this.Controls.Add(this.cboTipoTarjeta);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.dtpFechaTransaccion);
            this.Controls.Add(this.cboMetodoPago);
            this.Controls.Add(this.lblMetodoPago);
            this.Controls.Add(this.lblAlias);
            this.Controls.Add(this.lblNumTransaccion);
            this.Controls.Add(this.lblNumTarjeta);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.txtAlias);
            this.Controls.Add(this.txtNumTransaccion);
            this.Controls.Add(this.txtNumTarjeta);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCobrarVenta";
            this.Text = "Cobrar Venta";
            this.Load += new System.EventHandler(this.FrmCobrarVenta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtNumTarjeta;
        private System.Windows.Forms.TextBox txtNumTransaccion;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblNumTarjeta;
        private System.Windows.Forms.Label lblNumTransaccion;
        private System.Windows.Forms.Label lblAlias;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.ComboBox cboMetodoPago;
        private System.Windows.Forms.DateTimePicker dtpFechaTransaccion;
        private System.Windows.Forms.ComboBox cboTipoTarjeta;
        private System.Windows.Forms.Label lblTipoTarjeta;
        private System.Windows.Forms.Label lblNumTicket;
        private System.Windows.Forms.TextBox txtNumTicket;
        private CustomButton btnFinalizar;
        private CustomButton btnConectar;
    }
}