using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MapPermisoMenu
    {
        public static readonly Dictionary<string, Patente> MapeoPermisos = new Dictionary<string, Patente>
        {
            { "subItemGestionUsuarios", Patente.GestionUsuarios },
            { "subItemGestionPerfiles", Patente.GestionPerfiles },
            { "subItemClientes", Patente.Clientes },
            { "subItemProductos", Patente.Inventario },
            { "subItemCategorias", Patente.Inventario },
            { "subItemProveedores", Patente.Proveedores },
            { "subItemCambiarClave", Patente.CambiarClave },
            { "subItemCambiarIdioma", Patente.CambiarIdioma },
            { "subItemLogout", Patente.Logout },
            { "subItemLogin", Patente.Login },
            { "subItemGenerarTicket", Patente.GenerarTicket },
            { "subItemTickets", Patente.Tickets },
            { "subItemOrdenes", Patente.Ordenes },
            { "subItemRotacionProductos", Patente.RotacionProductos },
            { "subItemAuditoriaEventos", Patente.AuditoriaEventos },
            { "subItemAuditoriaCambios", Patente.AuditoriaCambios },
            { "subItemRespaldos", Patente.Respaldos },
            { "subItemGenerarSolicitudCotizacion", Patente.GenerarSolicitudCotizacion },
            { "subItemGenerarOrdenCompra", Patente.GenerarOrdenCompra },
            { "subItemRecepcion", Patente.Recepcion },
            //{ "itemAyuda", Patente.Ayuda },
            // Nuevos ayudaSubItems
            { "ayudaSubItemAuditoriaDeEventos", Patente.AuditoriaEventos },
            { "ayudaSubItemGestionPerfiles", Patente.GestionPerfiles },
            { "ayudaSubItemClientes", Patente.Clientes },
            { "ayudaSubItemProductos", Patente.Inventario },
            { "ayudaSubItemProveedores", Patente.Proveedores },
            { "ayudaSubItemAuditoriaDeCambios", Patente.AuditoriaCambios },
            { "ayudaSubItemUsuario", Patente.GestionUsuarios },
            { "ayudaSubItemCambiarClave", Patente.CambiarClave },
            { "ayudaSubItemCambiarIdioma", Patente.CambiarIdioma },
            { "ayudaSubItemLogin", Patente.Login },
            { "ayudaSubItemLogout", Patente.Logout },
            { "ayudaSubItemGenerarTicket", Patente.GenerarTicket },
            { "ayudaSubItemGenerarSolicitudCotizacion", Patente.GenerarSolicitudCotizacion },
            { "ayudaSubItemGenerarOrdenDeCompra", Patente.GenerarOrdenCompra },
            { "ayudaSubItemRecepcion", Patente.Recepcion },
            { "ayudaSubItemTickets", Patente.Tickets },
            { "ayudaSubItemOrdenes", Patente.Ordenes },
            { "ayudaSubItemRotacionDeProductos", Patente.RotacionProductos },
            { "ayudaSubItemCategorias", Patente.Inventario },
            { "ayudaSubItemGestionUsuarios", Patente.GestionUsuarios },
            { "ayudaSubItemRespaldos", Patente.Respaldos }
        };
    }
}
