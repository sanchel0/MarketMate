using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace DAL
{
    public class PermisoDAL
    {
        public List<PermisoSimple> GetAllPatentes()
        {
            List<PermisoSimple> patentes = new List<PermisoSimple>();
            string query = @"SELECT *
                             FROM Permisos p
                             WHERE p.Tipo = 'Patente';";

            using (SqlDataReader reader = ConnectionDB.ExecuteReader(query, CommandType.Text))
            {
                while (reader.Read())
                {
                    int codigo = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    string tipoString = reader.GetString(2);
                    TipoPermiso tipo = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), tipoString);

                    PermisoSimple permisoSimple = new PermisoSimple(nombre, tipo);
                    permisoSimple.Codigo = codigo;

                    patentes.Add(permisoSimple);
                }
            }

            return patentes;
        }

        public List<PermisoCompuesto> GetAllRoles()
        {
            SqlParameter parameter = new SqlParameter("@TipoPermiso", SqlDbType.VarChar) { Value = "Rol" };

            List<Permiso> permisos = LoadPermisosMapAndHijosPendientesMap(parameter);

            List<PermisoCompuesto> roles = permisos
                .OfType<PermisoCompuesto>()
                .Where(p => p.Tipo == TipoPermiso.Rol)
                .ToList();

            return roles;
        }

        public List<PermisoCompuesto> GetAllFamilias()
        {
            SqlParameter parameter = new SqlParameter("@TipoPermiso", SqlDbType.VarChar) { Value = "Familia" };

            List<Permiso> permisos = LoadPermisosMapAndHijosPendientesMap(parameter);

            List<PermisoCompuesto> familias = permisos
                .OfType<PermisoCompuesto>()
                .Where(p => p.Tipo == TipoPermiso.Familia)
                .ToList();

            return familias;
        }

        public PermisoCompuesto GetById(int pId)
        {
            SqlParameter parameter = new SqlParameter("@CodigoPermiso", SqlDbType.Int) { Value = pId };

            List<Permiso> permisos = LoadPermisosMapAndHijosPendientesMap(parameter);

            PermisoCompuesto permiso = permisos
                .OfType<PermisoCompuesto>()
                .FirstOrDefault(p => p.Codigo == pId);

            return permiso;
        }

        public List<Permiso> GetPermisosByRol(int pId)
        {
            List<Permiso> permisos = new List<Permiso>();

            return permisos;
        }

        private List<Permiso> LoadPermisosMapAndHijosPendientesMap(SqlParameter parameter)
        {
            Dictionary<int, Permiso> permisosMap = new Dictionary<int, Permiso>();
            Dictionary<int, List<int>> hijosPendientesMap = new Dictionary<int, List<int>>();

            string commandText = "SP_ObtenerPermisos";

            using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.StoredProcedure, new[] { parameter }))
            {
                while (reader.Read())
                {
                    int codPadre = reader.GetInt32(reader.GetOrdinal("CodigoPadre"));
                    string nombre = reader.GetString(reader.GetOrdinal("NombrePadre"));
                    string tipoPadreString = reader.GetString(reader.GetOrdinal("TipoPadre"));
                    TipoPermiso tipo = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), tipoPadreString);

                    int codHijo = reader.GetInt32(reader.GetOrdinal("CodigoHijo"));
                    string nombreHijo = reader.GetString(reader.GetOrdinal("NombreHijo"));
                    string tipoHijoString = reader.GetString(reader.GetOrdinal("TipoHijo"));
                    TipoPermiso tipoHijo = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), tipoHijoString);

                    if (!permisosMap.ContainsKey(codPadre))
                    {
                        Permiso permisoPadre = new PermisoCompuesto(nombre, tipo);
                        permisoPadre.Codigo = codPadre;
                        permisosMap[codPadre] = permisoPadre;
                    }

                    if (!permisosMap.ContainsKey(codHijo))
                    {
                        Permiso permisoHijo;
                        if (tipoHijo == TipoPermiso.Familia)
                            permisoHijo = new PermisoCompuesto(nombreHijo, tipoHijo);
                        else
                            permisoHijo = new PermisoSimple(nombreHijo, tipoHijo);
                        permisoHijo.Codigo = codHijo;

                        permisosMap[codHijo] = permisoHijo;
                    }

                    if (!hijosPendientesMap.ContainsKey(codPadre))
                    {
                        hijosPendientesMap[codPadre] = new List<int>();
                    }
                    hijosPendientesMap[codPadre].Add(codHijo);
                }
            }

            CargarHijosPendientes(permisosMap, hijosPendientesMap);

            List<PermisoCompuesto> list = new List<PermisoCompuesto>();

            foreach (var permiso in permisosMap.Values)
            {
                if (permiso is PermisoCompuesto compuesto)
                {
                    list.Add(compuesto);
                }
            }

            return permisosMap.Values.ToList();
        }

        private void CargarHijosPendientes(Dictionary<int, Permiso> permisosMap, Dictionary<int, List<int>> hijosPendientesMap)
        {
            foreach (var kvp in hijosPendientesMap)
            {
                int codPadre = kvp.Key;
                List<int> codigosHijos = kvp.Value;

                if (permisosMap.ContainsKey(codPadre) && permisosMap[codPadre] is PermisoCompuesto compuesto)
                {
                    foreach (int codHijo in codigosHijos)
                    {
                        if (permisosMap.ContainsKey(codHijo))
                        {
                            compuesto.Add(permisosMap[codHijo]);
                        }
                    }
                }
            }
        }

        public void Create(PermisoCompuesto padre)
        {
            string insertPermisoQuery = "INSERT INTO Permisos (Nombre, Tipo) VALUES (@Nombre, @Tipo); SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = {
                new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = padre.Nombre },
                 new SqlParameter("@Tipo", SqlDbType.VarChar) { Value = padre.Tipo.ToString() }
            };

            object result = ConnectionDB.ExecuteScalar(insertPermisoQuery, CommandType.Text, parameters);
            int padreId = Convert.ToInt32(result);

            padre.Codigo = padreId;

            string insertPermisoPermisoQuery = "INSERT INTO PermisosPermisos (PermisoPadreCod, PermisoHijoCod) VALUES (@PermisoPadreCod, @PermisoHijoCod)";

            foreach (Permiso hijo in padre.Hijos)
            {
                SqlParameter[] hijoParameters = {
                    new SqlParameter("@PermisoPadreCod", SqlDbType.Int) { Value = padre.Codigo },
                    new SqlParameter("@PermisoHijoCod", SqlDbType.Int) { Value = hijo.Codigo }
                };

                ConnectionDB.ExecuteNonQuery(insertPermisoPermisoQuery, CommandType.Text, hijoParameters);
            }
        }

        public void Update(PermisoCompuesto padre)
        {
            // Verificar si el padre tiene hijos que se deben agregar o eliminar
            List<int> codigosHijosActuales = new List<int>();
            foreach (Permiso hijo in padre.Hijos)
            {
                codigosHijosActuales.Add(hijo.Codigo);
            }

            // Obtener los hijos actuales de la base de datos para comparar
            List<int> codigosHijosEnBD = new List<int>();
            string selectHijosQuery = "SELECT PermisoHijoCod FROM PermisosPermisos WHERE PermisoPadreCod = @PadreCodigo";
            SqlParameter padreCodigoParameter = new SqlParameter("@PadreCodigo", SqlDbType.Int) { Value = padre.Codigo };
            using (SqlDataReader reader = ConnectionDB.ExecuteReader(selectHijosQuery, CommandType.Text, new[] { padreCodigoParameter }))
            {
                while (reader.Read())
                {
                    codigosHijosEnBD.Add(reader.GetInt32(0));
                }
            }

            // Identificar los hijos que se deben agregar y eliminar
            List<int> hijosAgregar = codigosHijosActuales.Except(codigosHijosEnBD).ToList();
            List<int> hijosEliminar = codigosHijosEnBD.Except(codigosHijosActuales).ToList();

            // Insertar nuevos hijos en PermisosPermisos1
            string insertPermisoPermisoQuery = "INSERT INTO PermisosPermisos (PermisoPadreCod, PermisoHijoCod) VALUES (@PermisoPadreCod, @PermisoHijoCod)";
            foreach (int codigoHijoAgregar in hijosAgregar)
            {
                SqlParameter[] hijoParameters = {
                    new SqlParameter("@PermisoPadreCod", SqlDbType.Int) { Value = padre.Codigo },
                    new SqlParameter("@PermisoHijoCod", SqlDbType.Int) { Value = codigoHijoAgregar }
                };
                ConnectionDB.ExecuteNonQuery(insertPermisoPermisoQuery, CommandType.Text, hijoParameters);
            }

            // Eliminar hijos que ya no están en la lista de hijos actuales
            string deletePermisoPermisoQuery = "DELETE FROM PermisosPermisos WHERE PermisoPadreCod = @PermisoPadreCod AND PermisoHijoCod = @PermisoHijoCod";
            foreach (int codigoHijoEliminar in hijosEliminar)
            {
                SqlParameter[] hijoParameters = {
                    new SqlParameter("@PermisoPadreCod", SqlDbType.Int) { Value = padre.Codigo },
                    new SqlParameter("@PermisoHijoCod", SqlDbType.Int) { Value = codigoHijoEliminar }
                };
                ConnectionDB.ExecuteNonQuery(deletePermisoPermisoQuery, CommandType.Text, hijoParameters);
            }
        }

        public void Delete(int cod)
        {
            Check(cod);

            if (IsRoleInUse(cod))
            {
                throw new Exception("No se puede eliminar el rol porque está en uso por uno o más usuarios.");
            }

            string deleteAssociationsQuery = "DELETE FROM PermisosPermisos WHERE PermisoPadreCod = @PermisoId OR PermisoHijoCod = @PermisoId";

            SqlParameter[] associationParams = {
                new SqlParameter("@PermisoId", SqlDbType.Int) { Value = cod }
            };

            ConnectionDB.ExecuteNonQuery(deleteAssociationsQuery, CommandType.Text, associationParams);

            string deletePermissionQuery = "DELETE FROM Permisos WHERE Codigo = @PermisoId";

            SqlParameter[] permissionParams = {
                new SqlParameter("@PermisoId", SqlDbType.Int) { Value = cod }
            };

            ConnectionDB.ExecuteNonQuery(deletePermissionQuery, CommandType.Text, permissionParams);
        }

        private void Check(int cod)
        {
            int codFamiliaProtegida = 1;
            if (cod == codFamiliaProtegida)
            {
                throw new Exception("No se puede eliminar la familia del rol, ya que esta familia contiene los permisos básicos de un rol.");
            }
        }

        public bool IsRoleInUse(int rolId)
        {
            string query = "SELECT COUNT(*) FROM Usuarios WHERE Rol = @RolID";
            SqlParameter parametro = new SqlParameter("@RolID", rolId);
            int count = Convert.ToInt32(ConnectionDB.ExecuteScalar(query, CommandType.Text, new[] { parametro }));
            return count > 0;
        }
    }
}
