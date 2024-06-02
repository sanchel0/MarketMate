﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmGenerarTicket : Form
    {
        public FrmGenerarTicket()
        {
            InitializeComponent();
        }

        private void GenerarTicket_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrarProds_Click(object sender, EventArgs e)
        {
            FrmSeleccionarProductos frmSeleccionarProductos = new FrmSeleccionarProductos();
            frmSeleccionarProductos.ShowDialog();
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrarCli_Click(object sender, EventArgs e)
        {
            FrmRegistrarCliente frmRegistrarCliente = new FrmRegistrarCliente();
            frmRegistrarCliente.ShowDialog();
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            FrmCobrarVenta frmCobrarVenta = new FrmCobrarVenta();
            frmCobrarVenta.ShowDialog();
        }
    }
}