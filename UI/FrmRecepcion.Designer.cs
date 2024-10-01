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
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtCant = new System.Windows.Forms.TextBox();
            this.lblCant = new System.Windows.Forms.Label();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.lblProvs = new System.Windows.Forms.Label();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.lblProdsSelect = new System.Windows.Forms.Label();
            this.lblProds = new System.Windows.Forms.Label();
            this.dgvProdsOrden = new System.Windows.Forms.DataGridView();
            this.lblNumCoti = new System.Windows.Forms.Label();
            this.txtNumFact = new System.Windows.Forms.TextBox();
            this.btnSeleccionarProd = new System.Windows.Forms.Button();
            this.dgvProdsRecibidos = new System.Windows.Forms.DataGridView();
            this.lblFechaEntrega = new System.Windows.Forms.Label();
            this.dtpFechaEntrega = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdsOrden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdsRecibidos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(616, 451);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 51;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // txtCant
            // 
            this.txtCant.Location = new System.Drawing.Point(131, 419);
            this.txtCant.Name = "txtCant";
            this.txtCant.Size = new System.Drawing.Size(100, 20);
            this.txtCant.TabIndex = 50;
            // 
            // lblCant
            // 
            this.lblCant.AutoSize = true;
            this.lblCant.Location = new System.Drawing.Point(28, 422);
            this.lblCant.Name = "lblCant";
            this.lblCant.Size = new System.Drawing.Size(97, 13);
            this.lblCant.TabIndex = 49;
            this.lblCant.Text = "Cantidad Recibida:";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(535, 451);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizar.TabIndex = 46;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            // 
            // lblProvs
            // 
            this.lblProvs.AutoSize = true;
            this.lblProvs.Location = new System.Drawing.Point(361, 33);
            this.lblProvs.Name = "lblProvs";
            this.lblProvs.Size = new System.Drawing.Size(157, 13);
            this.lblProvs.TabIndex = 43;
            this.lblProvs.Text = "Ordenes de Compra Pendientes";
            // 
            // dgvOrdenes
            // 
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.Location = new System.Drawing.Point(361, 49);
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.Size = new System.Drawing.Size(330, 150);
            this.dgvOrdenes.TabIndex = 42;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(600, 415);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(91, 23);
            this.btnQuitar.TabIndex = 38;
            this.btnQuitar.Text = "Quitar Producto";
            this.btnQuitar.UseVisualStyleBackColor = true;
            // 
            // lblProdsSelect
            // 
            this.lblProdsSelect.AutoSize = true;
            this.lblProdsSelect.Location = new System.Drawing.Point(358, 243);
            this.lblProdsSelect.Name = "lblProdsSelect";
            this.lblProdsSelect.Size = new System.Drawing.Size(105, 13);
            this.lblProdsSelect.TabIndex = 37;
            this.lblProdsSelect.Text = "Productos Recibidos";
            // 
            // lblProds
            // 
            this.lblProds.AutoSize = true;
            this.lblProds.Location = new System.Drawing.Point(22, 245);
            this.lblProds.Name = "lblProds";
            this.lblProds.Size = new System.Drawing.Size(156, 13);
            this.lblProds.TabIndex = 36;
            this.lblProds.Text = "Productos de Orden de Compra";
            // 
            // dgvProdsOrden
            // 
            this.dgvProdsOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdsOrden.Location = new System.Drawing.Point(25, 259);
            this.dgvProdsOrden.Name = "dgvProdsOrden";
            this.dgvProdsOrden.Size = new System.Drawing.Size(330, 150);
            this.dgvProdsOrden.TabIndex = 35;
            // 
            // lblNumCoti
            // 
            this.lblNumCoti.AutoSize = true;
            this.lblNumCoti.Location = new System.Drawing.Point(24, 77);
            this.lblNumCoti.Name = "lblNumCoti";
            this.lblNumCoti.Size = new System.Drawing.Size(101, 13);
            this.lblNumCoti.TabIndex = 33;
            this.lblNumCoti.Text = "Numero de Factura:";
            // 
            // txtNumFact
            // 
            this.txtNumFact.Location = new System.Drawing.Point(131, 74);
            this.txtNumFact.Name = "txtNumFact";
            this.txtNumFact.Size = new System.Drawing.Size(200, 20);
            this.txtNumFact.TabIndex = 30;
            // 
            // btnSeleccionarProd
            // 
            this.btnSeleccionarProd.Location = new System.Drawing.Point(237, 417);
            this.btnSeleccionarProd.Name = "btnSeleccionarProd";
            this.btnSeleccionarProd.Size = new System.Drawing.Size(118, 23);
            this.btnSeleccionarProd.TabIndex = 28;
            this.btnSeleccionarProd.Text = "Seleccionar Producto";
            this.btnSeleccionarProd.UseVisualStyleBackColor = true;
            // 
            // dgvProdsRecibidos
            // 
            this.dgvProdsRecibidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdsRecibidos.Location = new System.Drawing.Point(361, 259);
            this.dgvProdsRecibidos.Name = "dgvProdsRecibidos";
            this.dgvProdsRecibidos.Size = new System.Drawing.Size(330, 150);
            this.dgvProdsRecibidos.TabIndex = 27;
            // 
            // lblFechaEntrega
            // 
            this.lblFechaEntrega.AutoSize = true;
            this.lblFechaEntrega.Location = new System.Drawing.Point(30, 136);
            this.lblFechaEntrega.Name = "lblFechaEntrega";
            this.lblFechaEntrega.Size = new System.Drawing.Size(95, 13);
            this.lblFechaEntrega.TabIndex = 53;
            this.lblFechaEntrega.Text = "Fecha de Entrega:";
            // 
            // dtpFechaEntrega
            // 
            this.dtpFechaEntrega.Location = new System.Drawing.Point(131, 136);
            this.dtpFechaEntrega.Name = "dtpFechaEntrega";
            this.dtpFechaEntrega.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaEntrega.TabIndex = 52;
            // 
            // FrmRecepcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 520);
            this.Controls.Add(this.lblFechaEntrega);
            this.Controls.Add(this.dtpFechaEntrega);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtCant);
            this.Controls.Add(this.lblCant);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.lblProvs);
            this.Controls.Add(this.dgvOrdenes);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.lblProdsSelect);
            this.Controls.Add(this.lblProds);
            this.Controls.Add(this.dgvProdsOrden);
            this.Controls.Add(this.lblNumCoti);
            this.Controls.Add(this.txtNumFact);
            this.Controls.Add(this.btnSeleccionarProd);
            this.Controls.Add(this.dgvProdsRecibidos);
            this.Name = "FrmRecepcion";
            this.Text = "FrmRecepcion";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdsOrden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdsRecibidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtCant;
        private System.Windows.Forms.Label lblCant;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Label lblProvs;
        private System.Windows.Forms.DataGridView dgvOrdenes;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Label lblProdsSelect;
        private System.Windows.Forms.Label lblProds;
        private System.Windows.Forms.DataGridView dgvProdsOrden;
        private System.Windows.Forms.Label lblNumCoti;
        private System.Windows.Forms.TextBox txtNumFact;
        private System.Windows.Forms.Button btnSeleccionarProd;
        private System.Windows.Forms.DataGridView dgvProdsRecibidos;
        private System.Windows.Forms.Label lblFechaEntrega;
        private System.Windows.Forms.DateTimePicker dtpFechaEntrega;
    }
}