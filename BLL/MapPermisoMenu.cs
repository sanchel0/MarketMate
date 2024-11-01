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
            { "subItemAuditoriaEventos", Patente.AuditoriaEventos },
            { "subItemAuditoriaCambios", Patente.AuditoriaCambios },
            { "subItemRespaldos", Patente.Respaldos },
            { "subItemGenerarSolicitudCotizacion", Patente.GenerarSolicitudCotizacion },
            { "subItemGenerarOrdenCompra", Patente.GenerarOrdenCompra },
            { "subItemRecepcion", Patente.Recepcion }
        };
    }
}
