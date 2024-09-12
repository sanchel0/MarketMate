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

namespace UI
{
    public partial class FrmGenerarOrdenCompra : Form
    {
        public FrmGenerarOrdenCompra()
        {
            InitializeComponent();
        }

        private void btnRegistrarProv_Click(object sender, EventArgs e)
        {
            if (dgvProvs.SelectedRows.Count > 0)
            {
                ProveedorBE p = (ProveedorBE)dgvProvs.SelectedRows[0].DataBoundItem;
                FrmRegistrarProveedor f = new FrmRegistrarProveedor(p);
            }
        }

        private void btnAsignarPrecio_Click(object sender, EventArgs e)
        {

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {

        }

        private void btnProcesarPago_Click(object sender, EventArgs e)
        {
            FrmProcesarPago f = new FrmProcesarPago();
            f.Show();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {

        }

        //Una vez que se da click en Seleccionar Cotizacion, se busca en la BD la cotizacion que corresponda con el valor ingresado en el txt NumCoti, en las grillas se cargarian los productos de la coti y los proveedores a los que se les envio la coti.
        //En la grilla de provs, los que estan pre-registrados aparecerán de un color determinado para saber cuando Completa el registro. Cuando se selecciona un prov que esta completo, se deshabilita el boton "Completar Registro". Si es un pre-registro, entonces se lo habilita.
        //Al seleccionar un prod de la grilla Prod de Coti, abajo se le debe asignar un precio, que sería el que aparece en la cotizacion recibia en papel. Antes de darle a al btn "SeleccionarProd", se le debe haber dado al btn "AsignarPrecio". No se tienen que seleccionar necesariamnete todos los productos que aparecen en la grilla. Solo los que se pediran en la orden.
        //Una misma orden para varios provs? Entonces en DetalleOrden debe aparecer el prod y el prov al que se pide?
    }
}
