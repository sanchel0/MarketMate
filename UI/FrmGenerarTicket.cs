using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;
using UI;
using Services;

namespace UI
{
    //[DesignerCategory("Form")]
    public partial class FrmGenerarTicket : Form
    {
        TicketBLL _ticketBLL;
        TicketBE _ticketBE;

        public FrmGenerarTicket()
        {
            InitializeComponent();
            _ticketBLL = new TicketBLL();
            _ticketBE = new TicketBE();
            dgvProductos.CellFormatting += dgvProd_CellFormatting;
        }

        private void GenerarTicket_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrarProds_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSeleccionarProductos frmSeleccionarProductos = new FrmSeleccionarProductos();
                if (frmSeleccionarProductos.ShowDialog() == DialogResult.OK)
                {
                    List<DetalleVentaBE> detalles = frmSeleccionarProductos.DetallesVenta.ToList();
                    _ticketBLL.AgregarDetallesVenta(_ticketBE, detalles);
                    ControlHelper.UpdateGrid(dgvProductos, _ticketBE.Detalles);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            try
            {
                ControlHelper.ValidateTextBoxLength(txtDni, 8);
                ClienteBLL clienteBLL = new ClienteBLL();
                _ticketBLL.AsignarCliente(_ticketBE, clienteBLL.GetById(txtDni.Text));
                MessageBox.Show("El cliente ya está registrado");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegistrarCli_Click(object sender, EventArgs e)
        {
            try
            {
                FrmRegistrarCliente frmRegistrarCliente = new FrmRegistrarCliente();
                frmRegistrarCliente.ShowDialog();
                if (frmRegistrarCliente.ClienteRegistrado != null)
                {
                    _ticketBLL.AsignarCliente(_ticketBE, frmRegistrarCliente.ClienteRegistrado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Aún se puede acceder a la propiedad clienteRegistrado desde el formulario principal después de cerrar el formHijo (frmRegistrarCliente),
            //siempre que se mantenga una referencia válida al frmRegistrarCliente y este objeto no haya sido destruido por el recolector de basura.
        }//Una vez que el método btnRegistrarCli_Click finaliza y sales de su ámbito, la variable frmRegistrarCliente se elimina de la memoria y ya no se tendrá acceso a la propiedad ClienteRegistrado del formulario creado a través de esa variable.

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            try
            {
                _ticketBLL.Insert(_ticketBE);

                FrmCobrarVenta frmCobrarVenta = new FrmCobrarVenta(_ticketBE);
                if (frmCobrarVenta.ShowDialog() == DialogResult.OK)
                {
                    _ticketBLL.AsignarDatosPago(_ticketBE, frmCobrarVenta.NumTrans, frmCobrarVenta.MetodoPagoSeleccionado, frmCobrarVenta.TipoTarjetaSeleccionada, frmCobrarVenta.NumTarjeta, frmCobrarVenta.AliasMP, frmCobrarVenta.FechaTrans);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                _ticketBLL.FinalizarSolicitud(_ticketBE);
                _ticketBLL.GenerarReporteDeTickets(new List<TicketBE>() { _ticketBE });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvProd_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dataGridView = (DataGridView)sender;
                var columnName = dataGridView.Columns[e.ColumnIndex].Name;

                if (columnName == "Producto")
                {
                    var cellValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    if (cellValue != null && cellValue is ProductoBE producto)
                    {
                        e.Value = producto.Nombre;
                    }
                }
            }
        }
    }
}
