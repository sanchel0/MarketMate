using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public enum Operacion
    {
        Login,
        Logout,
        CambiarClave,
        CambiarIdioma,
        ClaveIncorrecta,
        
        BloquearUsuario,
        DesbloquearUsuario,
        ActivarUsuario,
        DesactivarUsuario,
        RegistrarUsuario,
        ModificarUsuario,
        
        Backup,
        Restore,
        Serializar,
        Deserializar,

        CobrarVenta,
        GenerarTicket,

        GenerarSolicitudCotizacion,
        RegistroInicialCliente,
        CompletarRegistroCliente,
        GenerarOrdenCompra,
        Recepcion,

        RegistrarRol,
        ModificarRol,
        EliminarRol,

        RegistrarFamilia,
        ModificarFamilia,
        EliminarFamilia,

        RegistroCambioProducto,
        RestaurarEstadoProducto,

        RegistrarProducto,
        ModificarProducto,
        EliminarProducto,

        RegistrarCategoria,
        ModificarCategoria,
        EliminarCategoria,

        RegistrarMarca,
        ModificarMarca,
        EliminarMarca,

        RegistrarCliente,
        ModificarCliente,
        EliminarCliente,

        RegistrarProveedor,
        ModificarProveedor,
        EliminarProveedor,

        GenerarReporte1,
        GenerarReporte2,
        GenerarReporte3
    }
}
