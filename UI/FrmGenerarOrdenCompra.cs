using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using GUI;
using Services;

namespace UI
{
    public partial class FrmGenerarOrdenCompra : Form
    {
        OrdenCompraBE ordenBE;
        SolicitudCotizacionBLL solicitudBLL;
        OrdenCompraBLL ordenCompraBLL;
        BindingList<DetalleSolicitudBE> _detallesSoli;
        BindingList<DetalleOrdenBE> _detallesOrden;
        public FrmGenerarOrdenCompra()
        {
            InitializeComponent();
            ordenBE = new OrdenCompraBE();
            solicitudBLL = new SolicitudCotizacionBLL();
            ordenCompraBLL = new OrdenCompraBLL();
            _detallesSoli = new BindingList<DetalleSolicitudBE>();
            _detallesOrden = new BindingList<DetalleOrdenBE>();
            cboNumSoli.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboNumSoli.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btnRegistrarProv_Click(object sender, EventArgs e)
        {
            if (dgvProvs.SelectedRows.Count > 0)
            {
                ProveedorBE p = (ProveedorBE)dgvProvs.SelectedRows[0].DataBoundItem;
                FrmRegistrarProveedor f = new FrmRegistrarProveedor(p);
            }
        }

        private void btnSeleccionarProd_Click(object sender, EventArgs e)
        {
            if (dgvProdsSoli.SelectedRows.Count > 0)
            {
                DetalleSolicitudBE detalleSoli = (DetalleSolicitudBE)dgvProdsSoli.SelectedRows[0].DataBoundItem;
                if (!_detallesOrden.Any(d => d.Producto.Codigo == detalleSoli.Producto.Codigo))
                {
                    int cant = int.Parse(txtCant.Text);
                    if (cant <= 0 || txtCant.Text == string.Empty)
                        MessageBox.Show("La cantidad debe ser mayor que cero.");
                    else
                    {
                        if (txtPrecio.Text == string.Empty || int.Parse(txtPrecio.Text) <= 0)
                            MessageBox.Show("El precio debe ser mayor que cero.");
                        else
                        {
                            _detallesOrden.Add(new DetalleOrdenBE(detalleSoli.Producto, cant, decimal.Parse(txtPrecio.Text)));
                            txtPrecio.Text = string.Empty;
                            txtCant.Text = string.Empty;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El producto seleccionado ya está en la lista.");
                }
            }
            {
                MessageBox.Show("No seleccionó ningún producto.");
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvProdsOrden.SelectedRows.Count > 0)
            {
                DetalleOrdenBE detalle = (DetalleOrdenBE)dgvProdsOrden.SelectedRows[0].DataBoundItem;
                _detallesOrden.Remove(detalle);
            }
            else
            {
                MessageBox.Show("Seleccione un producto de la grilla de Productos Seleccionados.");
            }
        }

        private void btnProcesarPago_Click(object sender, EventArgs e)
        {
            if (dgvProvs.SelectedRows.Count > 0)
            {
                ProveedorBE proveedor = (ProveedorBE)dgvProvs.SelectedRows[0].DataBoundItem;
                ordenCompraBLL.AsignarDetalles(ordenBE, _detallesOrden.ToList());
                ordenCompraBLL.AsignarProveedor(ordenBE, proveedor);
                ordenCompraBLL.Insert(ordenBE);
                FrmProcesarPago f = new FrmProcesarPago();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ordenCompraBLL.AsignarNumeroTransferencia(ordenBE, f.NumTransferencia);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor.");
            }
        }
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            ordenCompraBLL.Update(ordenBE);
            ControlHelper.ClearGrid(dgvProvs);
            ControlHelper.ClearGrid(dgvProdsSoli);
            ControlHelper.ClearGrid(dgvProdsOrden);
        }
        private void dgvProvs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProvs.SelectedRows.Count > 0)
            {
                ProveedorBE p = (ProveedorBE)dgvProvs.SelectedRows[0].DataBoundItem;
                txtProvSelect.Text = $"CUIT: {p.CUIT}";
            }
            else
                txtProvSelect.Text = string.Empty;
        }

        private void btnSeleccionarSoli_Click(object sender, EventArgs e)
        {
            if (cboNumSoli.SelectedItem != null)
            {
                int numeroSolicitud = (int)cboNumSoli.SelectedItem;
                try
                {
                    SolicitudCotizacionBE solicitud = solicitudBLL.GetById(numeroSolicitud);

                    if (solicitud != null)
                    {
                        //LoadDgvProdsSoli(solicitud);
                        dgvProvs.DataSource = solicitud.Proveedores;
                        _detallesSoli = new BindingList<DetalleSolicitudBE>(solicitud.Detalles);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la solicitud de cotización.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener la solicitud de cotización: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboNumSoli_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void FrmGenerarOrdenCompra_Load(object sender, EventArgs e)
        {
            LoadDgvProdsSoli();
            LoadDgvProdsOrden();
            List<int> solicitudes = solicitudBLL.GetAllIds();
            cboNumSoli.Items.Clear();
            foreach (var solicitud in solicitudes)
            {
                cboNumSoli.Items.Add(solicitud);
            }
            //cboNumSoli.DataSource = solicitudBLL.GetAllIds();
        }

        private void LoadDgvProdsSoli(/*SolicitudCotizacionBE solicitud*/)
        {
            dgvProdsSoli.AutoGenerateColumns = false;

            dgvProdsSoli.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CodigoProducto",
                HeaderText = "Codigo Producto",
                DataPropertyName = "Producto.Codigo"
            });

            dgvProdsSoli.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NombreProducto",
                HeaderText = "Nombre Producto",
                DataPropertyName = "Producto.Nombre"
            });
            
            dgvProdsSoli.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Cantidad",
                HeaderText = "Cantidad Requerida",
                DataPropertyName = "Cantidad"
            });

            dgvProdsSoli.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NombreCategoria",
                HeaderText = "Categoría",
                DataPropertyName = "Producto.Categoria.Nombre"
            });

            dgvProdsSoli.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NombreMarca",
                HeaderText = "Marca",
                DataPropertyName = "Producto.Marca.Nombre"
            });

            dgvProdsSoli.DataSource = _detallesSoli;
        }

        private void LoadDgvProdsOrden(/*OrdenCompraBE orden*/)
        {
            dgvProdsOrden.AutoGenerateColumns = false;

            dgvProdsOrden.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CodigoProducto",
                HeaderText = "Codigo Producto",
                DataPropertyName = "Producto.Codigo"
            });

            dgvProdsOrden.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NombreProducto",
                HeaderText = "Nombre Producto",
                DataPropertyName = "Producto.Nombre"
            });

            dgvProdsOrden.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CantidadSolicitada",
                HeaderText = "Cantidad Solicitada",
                DataPropertyName = "CantidadSolicitada"
            });

            dgvProdsOrden.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "PrecioUnitario",
                HeaderText = "Precio Unitario",
                DataPropertyName = "PrecioUnitario"
            });

            dgvProdsOrden.DataSource = _detallesOrden;
        }
        //Una vez que se da click en Seleccionar Cotizacion, se busca en la BD la cotizacion que corresponda con el valor ingresado en el txt NumCoti, en las grillas se cargarian los productos de la coti y los proveedores a los que se les envio la coti.
        //En la grilla de provs, los que estan pre-registrados aparecerán de un color determinado para saber cuando Completa el registro. Cuando se selecciona un prov que esta completo, se deshabilita el boton "Completar Registro". Si es un pre-registro, entonces se lo habilita.
        //Al seleccionar un prod de la grilla Prod de Coti, abajo se le debe asignar un precio, que sería el que aparece en la cotizacion recibia en papel. Antes de darle a al btn "SeleccionarProd", se le debe haber dado al btn "AsignarPrecio". No se tienen que seleccionar necesariamnete todos los productos que aparecen en la grilla. Solo los que se pediran en la orden.
        //Una misma orden para varios provs? Entonces en DetalleOrden debe aparecer el prod y el prov al que se pide?
    }
}
