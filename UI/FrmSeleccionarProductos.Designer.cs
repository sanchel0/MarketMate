namespace UI
{
    partial class FrmSeleccionarProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeleccionarProductos));
            this.dgvProductos = new UI.CustomDataGridView();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.txtCant = new System.Windows.Forms.TextBox();
            this.btnSeleccionar = new UI.CustomButton();
            this.btnQuitar = new UI.CustomButton();
            this.dgvProductosSeleccionados = new UI.CustomDataGridView();
            this.grpProds = new System.Windows.Forms.GroupBox();
            this.grpProdsSelect = new System.Windows.Forms.GroupBox();
            this.btnFinalizar = new UI.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosSeleccionados)).BeginInit();
            this.grpProds.SuspendLayout();
            this.grpProdsSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(9, 39);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(346, 165);
            this.dgvProductos.TabIndex = 0;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.BackColor = System.Drawing.Color.Transparent;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(6, 20);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 1;
            this.lblCodigo.Text = "Código:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(190, 20);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(52, 13);
            this.lblCantidad.TabIndex = 2;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // txtCod
            // 
            this.txtCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCod.Location = new System.Drawing.Point(55, 17);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(100, 20);
            this.txtCod.TabIndex = 3;
            // 
            // txtCant
            // 
            this.txtCant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCant.Location = new System.Drawing.Point(248, 17);
            this.txtCant.Name = "txtCant";
            this.txtCant.Size = new System.Drawing.Size(100, 20);
            this.txtCant.TabIndex = 4;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnSeleccionar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionar.Location = new System.Drawing.Point(9, 210);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(152, 28);
            this.btnSeleccionar.TabIndex = 5;
            this.btnSeleccionar.Text = "Seleccionar Producto";
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnQuitar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.ForeColor = System.Drawing.Color.White;
            this.btnQuitar.Location = new System.Drawing.Point(9, 188);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(127, 28);
            this.btnQuitar.TabIndex = 6;
            this.btnQuitar.Text = "Quitar Producto";
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // dgvProductosSeleccionados
            // 
            this.dgvProductosSeleccionados.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvProductosSeleccionados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductosSeleccionados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductosSeleccionados.Location = new System.Drawing.Point(6, 19);
            this.dgvProductosSeleccionados.Name = "dgvProductosSeleccionados";
            this.dgvProductosSeleccionados.Size = new System.Drawing.Size(349, 165);
            this.dgvProductosSeleccionados.TabIndex = 7;
            // 
            // grpProds
            // 
            this.grpProds.BackColor = System.Drawing.Color.White;
            this.grpProds.Controls.Add(this.dgvProductos);
            this.grpProds.Controls.Add(this.lblCodigo);
            this.grpProds.Controls.Add(this.lblCantidad);
            this.grpProds.Controls.Add(this.txtCod);
            this.grpProds.Controls.Add(this.btnSeleccionar);
            this.grpProds.Controls.Add(this.txtCant);
            this.grpProds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpProds.ForeColor = System.Drawing.Color.Black;
            this.grpProds.Location = new System.Drawing.Point(12, 12);
            this.grpProds.Name = "grpProds";
            this.grpProds.Size = new System.Drawing.Size(366, 243);
            this.grpProds.TabIndex = 8;
            this.grpProds.TabStop = false;
            this.grpProds.Text = "Productos";
            // 
            // grpProdsSelect
            // 
            this.grpProdsSelect.BackColor = System.Drawing.Color.White;
            this.grpProdsSelect.Controls.Add(this.dgvProductosSeleccionados);
            this.grpProdsSelect.Controls.Add(this.btnQuitar);
            this.grpProdsSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpProdsSelect.ForeColor = System.Drawing.Color.Black;
            this.grpProdsSelect.Location = new System.Drawing.Point(12, 261);
            this.grpProdsSelect.Name = "grpProdsSelect";
            this.grpProdsSelect.Size = new System.Drawing.Size(366, 222);
            this.grpProdsSelect.TabIndex = 9;
            this.grpProdsSelect.TabStop = false;
            this.grpProdsSelect.Text = "Productos Seleccionados";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(176)))), ((int)(((byte)(169)))));
            this.btnFinalizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.ForeColor = System.Drawing.Color.White;
            this.btnFinalizar.Location = new System.Drawing.Point(12, 489);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(90, 28);
            this.btnFinalizar.TabIndex = 10;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // FrmSeleccionarProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(391, 523);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.grpProdsSelect);
            this.Controls.Add(this.grpProds);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSeleccionarProductos";
            this.Text = "Seleccionar Productos";
            this.Load += new System.EventHandler(this.SeleccionarProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosSeleccionados)).EndInit();
            this.grpProds.ResumeLayout(false);
            this.grpProds.PerformLayout();
            this.grpProdsSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.TextBox txtCant;
        private System.Windows.Forms.GroupBox grpProds;
        private System.Windows.Forms.GroupBox grpProdsSelect;
        private CustomDataGridView dgvProductos;
        private CustomButton btnSeleccionar;
        private CustomButton btnQuitar;
        private CustomDataGridView dgvProductosSeleccionados;
        private CustomButton btnFinalizar;
    }
}