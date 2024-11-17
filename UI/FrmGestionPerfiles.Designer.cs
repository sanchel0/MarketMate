namespace UI
{
    partial class FrmGestionPerfiles
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
            this.lblModo = new System.Windows.Forms.Label();
            this.lstPermisos = new System.Windows.Forms.ListBox();
            this.lblFamiliasLst = new System.Windows.Forms.Label();
            this.lstFamilias = new System.Windows.Forms.ListBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlRdos = new System.Windows.Forms.Panel();
            this.rdoRol = new System.Windows.Forms.RadioButton();
            this.rdoFam = new System.Windows.Forms.RadioButton();
            this.pnlFam = new System.Windows.Forms.Panel();
            this.tvwPermisosFamilia = new System.Windows.Forms.TreeView();
            this.lblFamilias = new System.Windows.Forms.Label();
            this.lblPermisosAsignadosF = new System.Windows.Forms.Label();
            this.cboFamilias = new System.Windows.Forms.ComboBox();
            this.txtFamilia = new System.Windows.Forms.TextBox();
            this.lblNewFamilia = new System.Windows.Forms.Label();
            this.pnlRol = new System.Windows.Forms.Panel();
            this.tvwPermisosRol = new System.Windows.Forms.TreeView();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblPermisosAsignadosR = new System.Windows.Forms.Label();
            this.cboRoles = new System.Windows.Forms.ComboBox();
            this.txtRol = new System.Windows.Forms.TextBox();
            this.lblNewRol = new System.Windows.Forms.Label();
            this.lblGestionarPara = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.tvwPermisosFam = new System.Windows.Forms.TreeView();
            this.lblPermisosLst = new System.Windows.Forms.Label();
            this.pnlRdos.SuspendLayout();
            this.pnlFam.SuspendLayout();
            this.pnlRol.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblModo
            // 
            this.lblModo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblModo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblModo.Location = new System.Drawing.Point(301, 412);
            this.lblModo.Name = "lblModo";
            this.lblModo.Size = new System.Drawing.Size(97, 23);
            this.lblModo.TabIndex = 51;
            this.lblModo.Text = "Modo";
            this.lblModo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstPermisos
            // 
            this.lstPermisos.FormattingEnabled = true;
            this.lstPermisos.Location = new System.Drawing.Point(20, 69);
            this.lstPermisos.Name = "lstPermisos";
            this.lstPermisos.Size = new System.Drawing.Size(248, 121);
            this.lstPermisos.TabIndex = 50;
            this.lstPermisos.SelectedIndexChanged += new System.EventHandler(this.lstPermisos_SelectedIndexChanged);
            // 
            // lblFamiliasLst
            // 
            this.lblFamiliasLst.AutoSize = true;
            this.lblFamiliasLst.Location = new System.Drawing.Point(17, 193);
            this.lblFamiliasLst.Name = "lblFamiliasLst";
            this.lblFamiliasLst.Size = new System.Drawing.Size(47, 13);
            this.lblFamiliasLst.TabIndex = 49;
            this.lblFamiliasLst.Text = "Familias:";
            // 
            // lstFamilias
            // 
            this.lstFamilias.FormattingEnabled = true;
            this.lstFamilias.Location = new System.Drawing.Point(20, 209);
            this.lstFamilias.Name = "lstFamilias";
            this.lstFamilias.Size = new System.Drawing.Size(248, 121);
            this.lstFamilias.TabIndex = 48;
            this.lstFamilias.SelectedIndexChanged += new System.EventHandler(this.lstFamilias_SelectedIndexChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(813, 412);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 47;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(651, 412);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 46;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pnlRdos
            // 
            this.pnlRdos.Controls.Add(this.rdoRol);
            this.pnlRdos.Controls.Add(this.rdoFam);
            this.pnlRdos.Location = new System.Drawing.Point(446, 17);
            this.pnlRdos.Name = "pnlRdos";
            this.pnlRdos.Size = new System.Drawing.Size(123, 28);
            this.pnlRdos.TabIndex = 45;
            // 
            // rdoRol
            // 
            this.rdoRol.AutoSize = true;
            this.rdoRol.Location = new System.Drawing.Point(3, 3);
            this.rdoRol.Name = "rdoRol";
            this.rdoRol.Size = new System.Drawing.Size(41, 17);
            this.rdoRol.TabIndex = 23;
            this.rdoRol.TabStop = true;
            this.rdoRol.Text = "Rol";
            this.rdoRol.UseVisualStyleBackColor = true;
            // 
            // rdoFam
            // 
            this.rdoFam.AutoSize = true;
            this.rdoFam.Location = new System.Drawing.Point(62, 3);
            this.rdoFam.Name = "rdoFam";
            this.rdoFam.Size = new System.Drawing.Size(57, 17);
            this.rdoFam.TabIndex = 24;
            this.rdoFam.TabStop = true;
            this.rdoFam.Text = "Familia";
            this.rdoFam.UseVisualStyleBackColor = true;
            // 
            // pnlFam
            // 
            this.pnlFam.Controls.Add(this.tvwPermisosFamilia);
            this.pnlFam.Controls.Add(this.lblFamilias);
            this.pnlFam.Controls.Add(this.lblPermisosAsignadosF);
            this.pnlFam.Controls.Add(this.cboFamilias);
            this.pnlFam.Controls.Add(this.txtFamilia);
            this.pnlFam.Controls.Add(this.lblNewFamilia);
            this.pnlFam.Location = new System.Drawing.Point(631, 69);
            this.pnlFam.Name = "pnlFam";
            this.pnlFam.Size = new System.Drawing.Size(257, 273);
            this.pnlFam.TabIndex = 44;
            // 
            // tvwPermisosFamilia
            // 
            this.tvwPermisosFamilia.Location = new System.Drawing.Point(6, 71);
            this.tvwPermisosFamilia.Name = "tvwPermisosFamilia";
            this.tvwPermisosFamilia.Size = new System.Drawing.Size(248, 202);
            this.tvwPermisosFamilia.TabIndex = 19;
            // 
            // lblFamilias
            // 
            this.lblFamilias.AutoSize = true;
            this.lblFamilias.Location = new System.Drawing.Point(3, 3);
            this.lblFamilias.Name = "lblFamilias";
            this.lblFamilias.Size = new System.Drawing.Size(47, 13);
            this.lblFamilias.TabIndex = 15;
            this.lblFamilias.Text = "Familias:";
            // 
            // lblPermisosAsignadosF
            // 
            this.lblPermisosAsignadosF.AutoSize = true;
            this.lblPermisosAsignadosF.Location = new System.Drawing.Point(3, 55);
            this.lblPermisosAsignadosF.Name = "lblPermisosAsignadosF";
            this.lblPermisosAsignadosF.Size = new System.Drawing.Size(104, 13);
            this.lblPermisosAsignadosF.TabIndex = 16;
            this.lblPermisosAsignadosF.Text = "Permisos Asignados:";
            // 
            // cboFamilias
            // 
            this.cboFamilias.FormattingEnabled = true;
            this.cboFamilias.Location = new System.Drawing.Point(86, 0);
            this.cboFamilias.Name = "cboFamilias";
            this.cboFamilias.Size = new System.Drawing.Size(168, 21);
            this.cboFamilias.TabIndex = 17;
            // 
            // txtFamilia
            // 
            this.txtFamilia.Location = new System.Drawing.Point(86, 27);
            this.txtFamilia.Name = "txtFamilia";
            this.txtFamilia.Size = new System.Drawing.Size(168, 20);
            this.txtFamilia.TabIndex = 18;
            // 
            // lblNewFamilia
            // 
            this.lblNewFamilia.AutoSize = true;
            this.lblNewFamilia.Location = new System.Drawing.Point(3, 30);
            this.lblNewFamilia.Name = "lblNewFamilia";
            this.lblNewFamilia.Size = new System.Drawing.Size(77, 13);
            this.lblNewFamilia.TabIndex = 20;
            this.lblNewFamilia.Text = "Nueva Familia:";
            // 
            // pnlRol
            // 
            this.pnlRol.Controls.Add(this.tvwPermisosRol);
            this.pnlRol.Controls.Add(this.lblRol);
            this.pnlRol.Controls.Add(this.lblPermisosAsignadosR);
            this.pnlRol.Controls.Add(this.cboRoles);
            this.pnlRol.Controls.Add(this.txtRol);
            this.pnlRol.Controls.Add(this.lblNewRol);
            this.pnlRol.Location = new System.Drawing.Point(373, 69);
            this.pnlRol.Name = "pnlRol";
            this.pnlRol.Size = new System.Drawing.Size(255, 273);
            this.pnlRol.TabIndex = 43;
            // 
            // tvwPermisosRol
            // 
            this.tvwPermisosRol.Location = new System.Drawing.Point(3, 71);
            this.tvwPermisosRol.Name = "tvwPermisosRol";
            this.tvwPermisosRol.Size = new System.Drawing.Size(248, 202);
            this.tvwPermisosRol.TabIndex = 7;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(3, 3);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(37, 13);
            this.lblRol.TabIndex = 2;
            this.lblRol.Text = "Roles:";
            // 
            // lblPermisosAsignadosR
            // 
            this.lblPermisosAsignadosR.AutoSize = true;
            this.lblPermisosAsignadosR.Location = new System.Drawing.Point(3, 55);
            this.lblPermisosAsignadosR.Name = "lblPermisosAsignadosR";
            this.lblPermisosAsignadosR.Size = new System.Drawing.Size(104, 13);
            this.lblPermisosAsignadosR.TabIndex = 4;
            this.lblPermisosAsignadosR.Text = "Permisos Asignados:";
            // 
            // cboRoles
            // 
            this.cboRoles.FormattingEnabled = true;
            this.cboRoles.Location = new System.Drawing.Point(83, 0);
            this.cboRoles.Name = "cboRoles";
            this.cboRoles.Size = new System.Drawing.Size(168, 21);
            this.cboRoles.TabIndex = 5;
            // 
            // txtRol
            // 
            this.txtRol.Location = new System.Drawing.Point(83, 27);
            this.txtRol.Name = "txtRol";
            this.txtRol.Size = new System.Drawing.Size(168, 20);
            this.txtRol.TabIndex = 6;
            // 
            // lblNewRol
            // 
            this.lblNewRol.AutoSize = true;
            this.lblNewRol.Location = new System.Drawing.Point(3, 30);
            this.lblNewRol.Name = "lblNewRol";
            this.lblNewRol.Size = new System.Drawing.Size(61, 13);
            this.lblNewRol.TabIndex = 12;
            this.lblNewRol.Text = "Nuevo Rol:";
            // 
            // lblGestionarPara
            // 
            this.lblGestionarPara.AutoSize = true;
            this.lblGestionarPara.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestionarPara.Location = new System.Drawing.Point(298, 22);
            this.lblGestionarPara.Name = "lblGestionarPara";
            this.lblGestionarPara.Size = new System.Drawing.Size(145, 15);
            this.lblGestionarPara.TabIndex = 42;
            this.lblGestionarPara.Text = "Gestionar permisos para:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(570, 412);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 41;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(408, 412);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 40;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(283, 203);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 23);
            this.btnQuitar.TabIndex = 39;
            this.btnQuitar.Text = "<<- Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(489, 412);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 38;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(283, 174);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(75, 23);
            this.btnAsignar.TabIndex = 37;
            this.btnAsignar.Text = "Asignar ->>";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(732, 412);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 23);
            this.btnAplicar.TabIndex = 36;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // tvwPermisosFam
            // 
            this.tvwPermisosFam.Location = new System.Drawing.Point(20, 336);
            this.tvwPermisosFam.Name = "tvwPermisosFam";
            this.tvwPermisosFam.Size = new System.Drawing.Size(248, 99);
            this.tvwPermisosFam.TabIndex = 34;
            // 
            // lblPermisosLst
            // 
            this.lblPermisosLst.AutoSize = true;
            this.lblPermisosLst.Location = new System.Drawing.Point(17, 53);
            this.lblPermisosLst.Name = "lblPermisosLst";
            this.lblPermisosLst.Size = new System.Drawing.Size(52, 13);
            this.lblPermisosLst.TabIndex = 35;
            this.lblPermisosLst.Text = "Permisos:";
            // 
            // FrmGestionPerfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 450);
            this.Controls.Add(this.lblModo);
            this.Controls.Add(this.lstPermisos);
            this.Controls.Add(this.lblFamiliasLst);
            this.Controls.Add(this.lstFamilias);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlRdos);
            this.Controls.Add(this.pnlFam);
            this.Controls.Add(this.pnlRol);
            this.Controls.Add(this.lblGestionarPara);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.tvwPermisosFam);
            this.Controls.Add(this.lblPermisosLst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmGestionPerfiles";
            this.Text = "Gestion Perfiles";
            this.Load += new System.EventHandler(this.FrmGestionPerfiles_Load);
            this.pnlRdos.ResumeLayout(false);
            this.pnlRdos.PerformLayout();
            this.pnlFam.ResumeLayout(false);
            this.pnlFam.PerformLayout();
            this.pnlRol.ResumeLayout(false);
            this.pnlRol.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblModo;
        private System.Windows.Forms.ListBox lstPermisos;
        private System.Windows.Forms.Label lblFamiliasLst;
        private System.Windows.Forms.ListBox lstFamilias;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlRdos;
        private System.Windows.Forms.RadioButton rdoRol;
        private System.Windows.Forms.RadioButton rdoFam;
        private System.Windows.Forms.Panel pnlFam;
        private System.Windows.Forms.TreeView tvwPermisosFamilia;
        private System.Windows.Forms.Label lblFamilias;
        private System.Windows.Forms.Label lblPermisosAsignadosF;
        private System.Windows.Forms.ComboBox cboFamilias;
        private System.Windows.Forms.TextBox txtFamilia;
        private System.Windows.Forms.Label lblNewFamilia;
        private System.Windows.Forms.Panel pnlRol;
        private System.Windows.Forms.TreeView tvwPermisosRol;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblPermisosAsignadosR;
        private System.Windows.Forms.ComboBox cboRoles;
        private System.Windows.Forms.TextBox txtRol;
        private System.Windows.Forms.Label lblNewRol;
        private System.Windows.Forms.Label lblGestionarPara;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.TreeView tvwPermisosFam;
        private System.Windows.Forms.Label lblPermisosLst;
    }
}