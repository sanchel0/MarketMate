namespace UI
{
    partial class FrmRecepcion
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
            this.txtCant = new System.Windows.Forms.TextBox();
            this.lblCant = new System.Windows.Forms.Label();
            this.btnFinalizar = new UI.CustomButton();
            this.lblProvs = new System.Windows.Forms.Label();
            this.dgvOrdenes = new UI.CustomDataGridView();
            this.btnQuitar = new UI.CustomButton();
            this.lblProdsSelect = new System.Windows.Forms.Label();
            this.lblProds = new System.Windows.Forms.Label();
            this.dgvProdsOrden = new UI.CustomDataGridView();
            this.lblNumCoti = new System.Windows.Forms.Label();
            this.txtNumFact = new System.Windows.Forms.TextBox();
            this.btnSeleccionarProd = new UI.CustomButton();
            this.dgvProdsRecibidos = new UI.CustomDataGridView();
            this.lblFechaEntrega = new System.Windows.Forms.Label();
            this.dtpFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.lblMontoFact = new System.Windows.Forms.Label();
            this.txtMontoFact = new System.Windows.Forms.TextBox();
            this.lblFechaFact = new System.Windows.Forms.Label();
            this.dtpFact = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRecepciones = new UI.CustomDataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDetallesRecep = new UI.CustomDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdsOrden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdsRecibidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecepciones)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesRecep)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalir.Location = new System.Drawing.Point(626, 188);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 51;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtCant
            // 
            this.txtCant.Location = new System.Drawing.Point(118, 361);
            this.txtCant.Name = "txtCant";
            this.txtCant.Size = new System.Drawing.Size(100, 20);
            this.txtCant.TabIndex = 50;
            // 
            // lblCant
            // 
            this.lblCant.AutoSize = true;
            this.lblCant.Location = new System.Drawing.Point(15, 364);
            this.lblCant.Name = "lblCant";
            this.lblCant.Size = new System.Drawing.Size(97, 13);
            this.lblCant.TabIndex = 49;
            this.lblCant.Text = "Cantidad Recibida:";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFinalizar.Location = new System.Drawing.Point(545, 188);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizar.TabIndex = 46;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // lblProvs
            // 
            this.lblProvs.AutoSize = true;
            this.lblProvs.Location = new System.Drawing.Point(12, 12);
            this.lblProvs.Name = "lblProvs";
            this.lblProvs.Size = new System.Drawing.Size(157, 13);
            this.lblProvs.TabIndex = 43;
            this.lblProvs.Text = "Ordenes de Compra Pendientes";
            // 
            // dgvOrdenes
            // 
            this.dgvOrdenes.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvOrdenes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.Location = new System.Drawing.Point(12, 28);
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.Size = new System.Drawing.Size(330, 150);
            this.dgvOrdenes.TabIndex = 42;
            this.dgvOrdenes.SelectionChanged += new System.EventHandler(this.DgvOrdenes_SelectionChanged);
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuitar.Location = new System.Drawing.Point(239, 188);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(91, 23);
            this.btnQuitar.TabIndex = 38;
            this.btnQuitar.Text = "Quitar Producto";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // lblProdsSelect
            // 
            this.lblProdsSelect.AutoSize = true;
            this.lblProdsSelect.Location = new System.Drawing.Point(1, 21);
            this.lblProdsSelect.Name = "lblProdsSelect";
            this.lblProdsSelect.Size = new System.Drawing.Size(105, 13);
            this.lblProdsSelect.TabIndex = 37;
            this.lblProdsSelect.Text = "Productos Recibidos";
            // 
            // lblProds
            // 
            this.lblProds.AutoSize = true;
            this.lblProds.Location = new System.Drawing.Point(9, 187);
            this.lblProds.Name = "lblProds";
            this.lblProds.Size = new System.Drawing.Size(160, 13);
            this.lblProds.TabIndex = 36;
            this.lblProds.Text = "Detalles de Orden Seleccionada";
            // 
            // dgvProdsOrden
            // 
            this.dgvProdsOrden.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvProdsOrden.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProdsOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdsOrden.Location = new System.Drawing.Point(12, 201);
            this.dgvProdsOrden.Name = "dgvProdsOrden";
            this.dgvProdsOrden.Size = new System.Drawing.Size(330, 150);
            this.dgvProdsOrden.TabIndex = 35;
            // 
            // lblNumCoti
            // 
            this.lblNumCoti.AutoSize = true;
            this.lblNumCoti.Location = new System.Drawing.Point(372, 38);
            this.lblNumCoti.Name = "lblNumCoti";
            this.lblNumCoti.Size = new System.Drawing.Size(101, 13);
            this.lblNumCoti.TabIndex = 33;
            this.lblNumCoti.Text = "Numero de Factura:";
            // 
            // txtNumFact
            // 
            this.txtNumFact.Location = new System.Drawing.Point(479, 35);
            this.txtNumFact.Name = "txtNumFact";
            this.txtNumFact.Size = new System.Drawing.Size(222, 20);
            this.txtNumFact.TabIndex = 30;
            // 
            // btnSeleccionarProd
            // 
            this.btnSeleccionarProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnSeleccionarProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarProd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSeleccionarProd.Location = new System.Drawing.Point(224, 359);
            this.btnSeleccionarProd.Name = "btnSeleccionarProd";
            this.btnSeleccionarProd.Size = new System.Drawing.Size(118, 23);
            this.btnSeleccionarProd.TabIndex = 28;
            this.btnSeleccionarProd.Text = "Seleccionar Producto";
            this.btnSeleccionarProd.UseVisualStyleBackColor = true;
            this.btnSeleccionarProd.Click += new System.EventHandler(this.btnSeleccionarProd_Click);
            // 
            // dgvProdsRecibidos
            // 
            this.dgvProdsRecibidos.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvProdsRecibidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProdsRecibidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdsRecibidos.Location = new System.Drawing.Point(0, 35);
            this.dgvProdsRecibidos.Name = "dgvProdsRecibidos";
            this.dgvProdsRecibidos.Size = new System.Drawing.Size(330, 150);
            this.dgvProdsRecibidos.TabIndex = 27;
            // 
            // lblFechaEntrega
            // 
            this.lblFechaEntrega.AutoSize = true;
            this.lblFechaEntrega.Location = new System.Drawing.Point(378, 113);
            this.lblFechaEntrega.Name = "lblFechaEntrega";
            this.lblFechaEntrega.Size = new System.Drawing.Size(95, 13);
            this.lblFechaEntrega.TabIndex = 53;
            this.lblFechaEntrega.Text = "Fecha de Entrega:";
            // 
            // dtpFechaEntrega
            // 
            this.dtpFechaEntrega.Location = new System.Drawing.Point(479, 113);
            this.dtpFechaEntrega.Name = "dtpFechaEntrega";
            this.dtpFechaEntrega.Size = new System.Drawing.Size(222, 20);
            this.dtpFechaEntrega.TabIndex = 52;
            // 
            // lblMontoFact
            // 
            this.lblMontoFact.AutoSize = true;
            this.lblMontoFact.Location = new System.Drawing.Point(393, 64);
            this.lblMontoFact.Name = "lblMontoFact";
            this.lblMontoFact.Size = new System.Drawing.Size(79, 13);
            this.lblMontoFact.TabIndex = 55;
            this.lblMontoFact.Text = "Monto Factura:";
            // 
            // txtMontoFact
            // 
            this.txtMontoFact.Location = new System.Drawing.Point(479, 61);
            this.txtMontoFact.Name = "txtMontoFact";
            this.txtMontoFact.Size = new System.Drawing.Size(222, 20);
            this.txtMontoFact.TabIndex = 54;
            // 
            // lblFechaFact
            // 
            this.lblFechaFact.AutoSize = true;
            this.lblFechaFact.Location = new System.Drawing.Point(378, 87);
            this.lblFechaFact.Name = "lblFechaFact";
            this.lblFechaFact.Size = new System.Drawing.Size(94, 13);
            this.lblFechaFact.TabIndex = 57;
            this.lblFechaFact.Text = "Fecha de Factura:";
            // 
            // dtpFact
            // 
            this.dtpFact.Location = new System.Drawing.Point(479, 87);
            this.dtpFact.Name = "dtpFact";
            this.dtpFact.Size = new System.Drawing.Size(222, 20);
            this.dtpFact.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(380, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Recepciones Asociadas";
            // 
            // dgvRecepciones
            // 
            this.dgvRecepciones.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvRecepciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecepciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecepciones.Location = new System.Drawing.Point(383, 28);
            this.dgvRecepciones.Name = "dgvRecepciones";
            this.dgvRecepciones.Size = new System.Drawing.Size(330, 150);
            this.dgvRecepciones.TabIndex = 59;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txtNumFact);
            this.groupBox1.Controls.Add(this.btnQuitar);
            this.groupBox1.Controls.Add(this.lblProdsSelect);
            this.groupBox1.Controls.Add(this.lblNumCoti);
            this.groupBox1.Controls.Add(this.dgvProdsRecibidos);
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Controls.Add(this.lblMontoFact);
            this.groupBox1.Controls.Add(this.txtMontoFact);
            this.groupBox1.Controls.Add(this.btnFinalizar);
            this.groupBox1.Controls.Add(this.dtpFact);
            this.groupBox1.Controls.Add(this.dtpFechaEntrega);
            this.groupBox1.Controls.Add(this.lblFechaEntrega);
            this.groupBox1.Controls.Add(this.lblFechaFact);
            this.groupBox1.Location = new System.Drawing.Point(12, 388);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(718, 226);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nueva Recepcion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(380, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Detalles de Recepcion Seleccionada";
            // 
            // dgvDetallesRecep
            // 
            this.dgvDetallesRecep.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvDetallesRecep.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetallesRecep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallesRecep.Location = new System.Drawing.Point(383, 201);
            this.dgvDetallesRecep.Name = "dgvDetallesRecep";
            this.dgvDetallesRecep.Size = new System.Drawing.Size(330, 150);
            this.dgvDetallesRecep.TabIndex = 62;
            // 
            // FrmRecepcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(745, 636);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDetallesRecep);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvRecepciones);
            this.Controls.Add(this.txtCant);
            this.Controls.Add(this.lblCant);
            this.Controls.Add(this.lblProvs);
            this.Controls.Add(this.dgvOrdenes);
            this.Controls.Add(this.lblProds);
            this.Controls.Add(this.dgvProdsOrden);
            this.Controls.Add(this.btnSeleccionarProd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRecepcion";
            this.Text = "Recepcion";
            this.Load += new System.EventHandler(this.FrmRecepcion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdsOrden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdsRecibidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecepciones)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesRecep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtCant;
        private System.Windows.Forms.Label lblCant;
        private System.Windows.Forms.Label lblProvs;
        private System.Windows.Forms.Label lblProdsSelect;
        private System.Windows.Forms.Label lblProds;
        private System.Windows.Forms.Label lblNumCoti;
        private System.Windows.Forms.TextBox txtNumFact;
        private System.Windows.Forms.Label lblFechaEntrega;
        private System.Windows.Forms.DateTimePicker dtpFechaEntrega;
        private System.Windows.Forms.Label lblMontoFact;
        private System.Windows.Forms.TextBox txtMontoFact;
        private System.Windows.Forms.Label lblFechaFact;
        private System.Windows.Forms.DateTimePicker dtpFact;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private CustomButton btnSalir;
        private CustomButton btnFinalizar;
        private CustomDataGridView dgvOrdenes;
        private CustomButton btnQuitar;
        private CustomDataGridView dgvProdsOrden;
        private CustomButton btnSeleccionarProd;
        private CustomDataGridView dgvProdsRecibidos;
        private CustomDataGridView dgvRecepciones;
        private CustomDataGridView dgvDetallesRecep;
    }
}