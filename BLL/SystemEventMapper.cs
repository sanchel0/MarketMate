using BE;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SystemEventMapper
    {
        private static Dictionary<int, Dictionary<Modulo, List<Operacion>>> criticidadModulosOperaciones;

        public SystemEventMapper()
        {
            criticidadModulosOperaciones = new Dictionary<int, Dictionary<Modulo, List<Operacion>>>();
            LoadDefaultValues();
        }

        public static bool ValidateSelection(int criticidad, Modulo modulo, Operacion operacion)
        {
            // Verifica si el nivel de criticidad es válido
            if (!criticidadModulosOperaciones.ContainsKey(criticidad))
            {
                throw new ArgumentException($"Nivel de criticidad {criticidad} no es válido.");
            }

            // Obtener el diccionario de módulos y operaciones para el nivel de criticidad seleccionado
            var modulosOperaciones = criticidadModulosOperaciones[criticidad];

            // Verifica si el módulo es válido para el nivel de criticidad
            if (!modulosOperaciones.ContainsKey(modulo))
            {
                throw new ArgumentException($"Módulo {modulo} no es válido para el nivel de criticidad {criticidad}.");
            }

            // Verifica si la operación es válida para el módulo y el nivel de criticidad seleccionados
            var operaciones = modulosOperaciones[modulo];

            if (!operaciones.Contains(operacion))
            {
                throw new ArgumentException($"Operación {operacion} no es válida para el módulo {modulo} y nivel de criticidad {criticidad}.");
            }

            return true; // Selección válida
        }

        private void LoadDefaultValues()
        {
            // Nivel de criticidad 1
            criticidadModulosOperaciones[1] = new Dictionary<Modulo, List<Operacion>> {
                { Modulo.Usuario,new List<Operacion> {
                    Operacion.Login,
                    Operacion.Logout,
                    Operacion.CambiarClave,
                    Operacion.CambiarIdioma,
                    Operacion.ClaveIncorrecta,
                    Operacion.BloquearUsuario,
                    Operacion.DesbloquearUsuario,
                    Operacion.ActivarUsuario,
                    Operacion.DesactivarUsuario,
                    Operacion.RegistrarUsuario,
                    Operacion.ModificarUsuario
                } }
            };

            // Nivel de criticidad 2
            criticidadModulosOperaciones[2] = new Dictionary<Modulo, List<Operacion>> {
                { Modulo.Respaldos, new List<Operacion> { Operacion.Backup, Operacion.Restore } },
                { Modulo.Inventario, new List<Operacion> {
                    Operacion.RegistrarProducto,
                    Operacion.ModificarProducto,
                    Operacion.EliminarProducto,
                    Operacion.RegistrarCategoria,
                    Operacion.ModificarCategoria,
                    Operacion.EliminarCategoria,
                    Operacion.RegistrarMarca,
                    Operacion.ModificarMarca,
                    Operacion.EliminarMarca } },
                { Modulo.CambiosProductos, new List<Operacion> {
                    Operacion.RegistroCambioProducto,
                    Operacion.RestaurarEstadoProducto } },
                { Modulo.Perfiles, new List<Operacion> {
                    Operacion.RegistrarRol,
                    Operacion.ModificarRol,
                    Operacion.EliminarRol,
                    Operacion.RegistrarFamilia,
                    Operacion.ModificarFamilia,
                    Operacion.EliminarFamilia
                } }
            };

            // Nivel de criticidad 3
            criticidadModulosOperaciones[3] = new Dictionary<Modulo, List<Operacion>> {
                { Modulo.Ventas, new List<Operacion> {
                    Operacion.CobrarVenta,
                    Operacion.GenerarTicket
                } },
                { Modulo.Compras, new List<Operacion> {
                    Operacion.GenerarSolicitudCotizacion,
                    Operacion.GenerarOrdenCompra,
                    Operacion.Recepcion
                } },
                { Modulo.Clientes, new List<Operacion> {
                    Operacion.RegistrarCliente,
                    Operacion.ModificarCliente,
                    Operacion.EliminarCliente
                } },
                { Modulo.Proveedores, new List<Operacion> {
                    Operacion.RegistrarProveedor,
                    Operacion.ModificarProveedor,
                    Operacion.EliminarProveedor
                } }
            };

            // Nivel de criticidad 4
            criticidadModulosOperaciones[4] = new Dictionary<Modulo, List<Operacion>> {
                { Modulo.Reportes, new List<Operacion> {
                    Operacion.GenerarReporte1,
                    Operacion.GenerarReporte2,
                    Operacion.GenerarReporte3,
                } }
            };

            // Nivel de criticidad 5
            criticidadModulosOperaciones[5] = new Dictionary<Modulo, List<Operacion>> {
                { Modulo.Serializacion, new List<Operacion> {
                    Operacion.Serializar,
                    Operacion.Deserializar
                } }
            };
        }
    }
}
