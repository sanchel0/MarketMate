using BE;
using BLL;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    [DesignerCategory("Form")]
    public partial class FrmRecepcion : BaseFormObserver
    {
        List<OrdenCompraBE> ordenesPendientes;
        BindingList<DetalleRecepcionBE> _detallesRecep;
        RecepcionBLL recepcionBLL;
        public FrmRecepcion()
        {
            InitializeComponent();
            ordenesPendientes = new List<OrdenCompraBE>();
            _detallesRecep = new BindingList<DetalleRecepcionBE>();
            recepcionBLL = new RecepcionBLL();
        }

        private void FrmRecepcion_Load(object sender, EventArgs e)
        {
            /*Bitmap bmp = new Bitmap(this.Width, this.Height);

            // Capturar la imagen del formulario y sus controles
            this.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));

            // Guardar la imagen en la ubicación deseada
            bmp.Save($@"C:\Users\user\Desktop\Forms\{this.Name}.png", ImageFormat.Png);*/

            ordenesPendientes = new OrdenCompraBLL().GetAllPendientes();
            TranslateEntityList(ordenesPendientes, Translation);
            ControlHelper.UpdateGrid(dgvOrdenes, ordenesPendientes);
            LoadDgvProdsOrden();
            LoadDgvRecepciones();
            LoadDgvDetalles();
            LoadDgvProdsRecibidos();
            dgvOrdenes.SelectionChanged += DgvOrdenes_SelectionChanged;
        }

        private void btnSeleccionarProd_Click(object sender, EventArgs e)
        {
            try
            {
                ControlHelper.TryGetSelectedRow(dgvProdsOrden, out DetalleOrdenBE detalleOrden);
                recepcionBLL.AgregarProductoADetalles(detalleOrden.Producto, txtCant.Text, _detallesRecep);
                dgvProdsRecibidos.DataSource = _detallesRecep;
                txtCant.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                ControlHelper.TryGetSelectedRow(dgvProdsRecibidos, out DetalleRecepcionBE detalle);
                recepcionBLL.QuitarProductoDeDetalles(detalle, _detallesRecep);
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
                ControlHelper.TryGetSelectedRow(dgvOrdenes, out OrdenCompraBE orden);
                TranslationService.SetTranslations(this.Translation);
                recepcionBLL.FinalizarRecepcion(orden, dtpFechaEntrega.Value, Convert.ToInt32(txtNumFact.Text), Convert.ToDecimal(txtMontoFact.Text), dtpFact.Value, _detallesRecep.ToList());
                MessageBox.Show(GetTranslation(SuccessType.OperationSuccess));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadDgvProdsOrden()
        {
            dgvProdsOrden.AutoGenerateColumns = false;

            dgvProdsOrden.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CodigoProducto",
                HeaderText = "Codigo Producto",
            });

            dgvProdsOrden.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NombreProducto",
                HeaderText = "Nombre Producto",
            });

            dgvProdsOrden.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CantidadSolicitada",
                HeaderText = "Cantidad Solicitada",
                DataPropertyName = "CantidadSolicitada"
            });

            dgvProdsOrden.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CantidadRecibida",
                HeaderText = "Cantidad Total Recibida",
                DataPropertyName = "CantidadRecibida"
            });

            /*dgvProdsOrden.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "PrecioUnitario",
                HeaderText = "Precio Unitario",
                DataPropertyName = "PrecioUnitario"
            });

            dgvProdsOrden.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "IVA",
                HeaderText = "IVA",
                DataPropertyName = "PorcentajeIVA"
            });*/

            dgvProdsOrden.CellFormatting += DgvProdsOrden_CellFormatting;
        }

        private void LoadDgvRecepciones()
        {
            dgvRecepciones.AutoGenerateColumns = false;

            dgvRecepciones.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NumeroRecepcion",
                HeaderText = "Número Recepción",
                DataPropertyName = "NumeroRecepcion"
            });

            dgvRecepciones.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "FechaRecepcion",
                HeaderText = "Fecha Recepción",
                DataPropertyName = "FechaRecepcion"
            });

            dgvRecepciones.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NumeroFactura",
                HeaderText = "Número Factura",
                DataPropertyName = "NumeroFactura"
            });

            dgvRecepciones.SelectionChanged += DgvRecepciones_SelectionChanged;
        }

        private void DgvRecepciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRecepciones.CurrentRow?.DataBoundItem is RecepcionBE recepcion)
            {
                dgvDetallesRecep.DataSource = recepcion.Detalles;
            }
        }

        private void ConfigurarGrillaDetalleRecepcion(DataGridView grilla)
        {
            grilla.AutoGenerateColumns = false;
            grilla.Columns.Clear();

            grilla.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CodigoProducto",
                HeaderText = "Código Producto"
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NombreProducto",
                HeaderText = "Nombre Producto"
            });

            grilla.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CantidadRecibida",
                HeaderText = "Cantidad Recibida",
                DataPropertyName = "CantidadRecibida"
            });

            grilla.CellFormatting += DgvDetallesR_CellFormatting;
        }

        private void DgvDetallesR_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var grilla = sender as DataGridView;
            var detalle = grilla?.Rows[e.RowIndex].DataBoundItem as DetalleRecepcionBE;
            if (detalle == null) return;

            switch (grilla.Columns[e.ColumnIndex].Name)
            {
                case "CodigoProducto":
                    e.Value = detalle.Producto.Codigo;
                    break;
                case "NombreProducto":
                    e.Value = detalle.Producto.Nombre;
                    break;
            }
        }

        private void LoadDgvDetalles()
        {
            ConfigurarGrillaDetalleRecepcion(dgvDetallesRecep);
        }

        private void LoadDgvProdsRecibidos()
        {
            ConfigurarGrillaDetalleRecepcion(dgvProdsRecibidos);
        }
        /*private void LoadDgvDetalles()
        {
            dgvDetallesRecep.AutoGenerateColumns = false;
            dgvDetallesRecep.Columns.Clear();

            dgvDetallesRecep.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CodigoProducto",
                HeaderText = "Código Producto"
            });

            dgvDetallesRecep.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NombreProducto",
                HeaderText = "Nombre Producto"
            });

            dgvDetallesRecep.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CantidadRecibida",
                HeaderText = "Cantidad Recibida",
                DataPropertyName = "CantidadRecibida"
            });

            dgvDetallesRecep.CellFormatting += DgvDetallesRecep_CellFormatting;
        }

        private void DgvDetallesRecep_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var detalle = dgvDetallesRecep.Rows[e.RowIndex].DataBoundItem as DetalleRecepcionBE;
            if (detalle == null) return;

            switch (dgvDetallesRecep.Columns[e.ColumnIndex].Name)
            {
                case "CodigoProducto":
                    e.Value = detalle.Producto.Codigo;
                    break;
                case "NombreProducto":
                    e.Value = detalle.Producto.Nombre;
                    break;
            }
        }

        private void LoadDgvProdsRecibidos()
        {
            dgvProdsRecibidos.AutoGenerateColumns = false;

            dgvProdsRecibidos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CodigoProducto",
                HeaderText = "Código Producto"
            }); 
            
            dgvProdsRecibidos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NombreProducto",
                HeaderText = "Nombre Producto"
            });

            dgvProdsRecibidos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CantidadRecibida",
                HeaderText = "Cantidad Recibida",
                DataPropertyName = "CantidadRecibida"
            });

            dgvProdsRecibidos.CellFormatting += dgvProdsRecibidos_CellFormatting;
        }

        private void dgvProdsRecibidos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var detalle = dgvProdsRecibidos.Rows[e.RowIndex].DataBoundItem as DetalleRecepcionBE;
            if (detalle == null) return;

            switch (dgvProdsRecibidos.Columns[e.ColumnIndex].Name)
            {
                case "CodigoProducto":
                    e.Value = detalle.Producto.Codigo;
                    break;
                case "NombreProducto":
                    e.Value = detalle.Producto.Nombre;
                    break;
            }
        }*/

        private void DgvProdsOrden_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var detalle = dgvProdsOrden.Rows[e.RowIndex].DataBoundItem as DetalleOrdenBE;
            if (detalle == null) return;

            switch (dgvProdsOrden.Columns[e.ColumnIndex].Name)
            {
                case "CodigoProducto":
                    e.Value = detalle.Producto.Codigo;
                    break;
                case "NombreProducto":
                    e.Value = detalle.Producto.Nombre;
                    break;
            }
        }

        private void DgvOrdenes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (ControlHelper.TryGetSelectedRowWithoutException(dgvOrdenes, out OrdenCompraBE orden))
                {
                    TranslateEntityList(orden.Detalles, Translation);
                    dgvProdsOrden.DataSource = orden.Detalles;
                    List<RecepcionBE> recepciones = recepcionBLL.ObtenerRecepcionesPorOrden(orden.NumeroOrden);
                    TranslateEntityList(recepciones, Translation);
                    dgvRecepciones.DataSource = recepciones;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
