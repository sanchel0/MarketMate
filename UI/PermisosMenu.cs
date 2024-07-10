﻿using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    internal class MapPermisoMenu
    {
        public static readonly Dictionary<string, Patente> MapeoPermisos = new Dictionary<string, Patente>
    {
        { "subItemGestionUsuarios", Patente.GestionUsuarios },
        { "subItemGestionPerfiles", Patente.GestionPerfiles },
        { "subItemClientes", Patente.Clientes },
        { "subItemProductos", Patente.Inventario },
        { "subItemCategorias", Patente.Inventario },
        { "subItemMarcas", Patente.Inventario },
        { "subItemProveedores", Patente.Proveedores },
        { "subItemCambiarClave", Patente.CambiarClave },
        { "subItemCambiarIdioma", Patente.CambiarIdioma },
        { "subItemLogout", Patente.Logout },
        { "subItemLogin", Patente.Login },
        { "subItemGenerarTicket", Patente.GenerarTicket }
        /*{ "subItemProductos", Patente.PuedeHacerC },
        { "subItemProveedores", Patente.PuedeHacerD },
        { "subItemCambiarClave", Patente.PuedeHacerE },*/
    };
    }
}
