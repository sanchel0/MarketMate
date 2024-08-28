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
        
        CobrarVenta,
        //Conectar,
        GenerarTicket,

        RealizarCompra,

        RegistrarRol,
        ModificarRol,
        EliminarRol,

        RegistrarFamilia,
        ModificarFamilia,
        EliminarFamilia,

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
        EliminarProveedor
    }
}
