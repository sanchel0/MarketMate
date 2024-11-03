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
        ModificarTicket,
        RegistrarDetallesTicket,

        GenerarSolicitudCotizacion,
        RegistrarDetallesSolicitud,
        RegistrarProveedoresSolicitud,
        //RegistroInicialCliente,
        //CompletarRegistroCliente,
        GenerarOrdenCompra,
        ModificarOrdenCompra,
        RegistrarDetallesOrden,
        ModificarDetallesOrden,
        RegistrarRecepcion,
        RegistrarDetallesRecepcion,

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

        RecalcularDVs,

        GenerarReporte1,
        GenerarReporte2,
        GenerarReporte3
    }
}
