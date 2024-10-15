using BE;
using Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioDAL : IUsuarioDAL
    {
        public UsuarioDAL()
        {
            
        }

        public void Insert(UsuarioBE pUsuario)
        {
            /*bool existeEnUsuarios = ExisteDNI(pUsuario.Dni);
            bool existeEnClientes = ClienteDAL.ExisteDNI(pUsuario.Dni);
            if(existeEnUsuarios || existeEnClientes)
            {
                throw new Exception("El DNI ya existe");
            }*/

            string commandText = "SP_RegistrarUsuario";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DNI", pUsuario.Dni),
                new SqlParameter("@Nombre", pUsuario.Nombre),
                new SqlParameter("@Apellido", pUsuario.Apellido),
                new SqlParameter("@Correo", pUsuario.Correo),
                new SqlParameter("@RolID", pUsuario.Rol.Codigo),
                new SqlParameter("@Username", pUsuario.Username),
                new SqlParameter("@Password", pUsuario.Password),
                new SqlParameter("@Bloqueo", pUsuario.Bloqueo),
                new SqlParameter("@Activo", pUsuario.Activo),
                new SqlParameter("@Idioma", pUsuario.Idioma.ToString())
            };

            ConnectionDB.ExecuteNonQuery(commandText, CommandType.StoredProcedure, parameters);
        }

        public void Update(UsuarioBE pUsuario)
        {
            string commandText = "SP_ModificarUsuario";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DNI", pUsuario.Dni),
                new SqlParameter("@Nombre", pUsuario.Nombre),
                new SqlParameter("@Apellido", pUsuario.Apellido),
                new SqlParameter("@Correo", pUsuario.Correo),
                new SqlParameter("@RolID", pUsuario.Rol.Codigo),
                new SqlParameter("@Username", pUsuario.Username),
                new SqlParameter("@Password", pUsuario.Password),
                new SqlParameter("@Bloqueo", pUsuario.Bloqueo),
                new SqlParameter("@Activo", pUsuario.Activo),
                new SqlParameter("@Idioma", pUsuario.Idioma.ToString())
            };

            ConnectionDB.ExecuteNonQuery(commandText, CommandType.StoredProcedure, parameters);
        }

        public void Delete(string pId)//Desactivar
        {
            string commandText = "SP_DeshabilitarUsuario";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DNI", SqlDbType.Char, 8) { Value = pId }
            };

            ConnectionDB.ExecuteNonQuery(commandText, CommandType.StoredProcedure, parameters);
        }

        public UsuarioBE GetById(string pId)
        {
            string commandText = "SP_Consultar";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NombreTabla", SqlDbType.NVarChar, 50){Value = "Usuarios"},
                new SqlParameter("@CampoID", SqlDbType.NVarChar, 50) { Value = "DNI" },
                new SqlParameter("@ValorID", SqlDbType.NVarChar, 1000) { Value = pId }
            };

            SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.StoredProcedure, parameters);
            List<UsuarioBE> usuarios = ConvertToEntity(reader);

            return usuarios.FirstOrDefault();
        }

        public List<UsuarioBE> GetAll()
        {
            string commandText = "SP_Consultar";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NombreTabla", SqlDbType.NVarChar, 50){Value = "Usuarios"}
            };
            
            List<UsuarioBE> usuarios = new List<UsuarioBE>();

            /*try
            {
                using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.StoredProcedure, parameters))
                {
                    usuarios = ConvertToEntity(reader);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener usuarios", ex);
            }*/
            using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.StoredProcedure, parameters))
            {
                usuarios = ConvertToEntity(reader);
            }

            return usuarios;
        }
        
        public UsuarioBE GetByUsername(string username)
        {
            string commandText = "SP_ConsultarPorUsername";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", SqlDbType.NVarChar, 50) { Value = username }
            };

            using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, CommandType.StoredProcedure, parameters))
            {
                if (reader.HasRows)
                {
                    List<UsuarioBE> usuarios = ConvertToEntity(reader);
                    return usuarios.FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
        }

        public bool IsAdmin(string username)
        {
            string query = @"SELECT P.Nombre AS Rol
                FROM Usuarios U
                JOIN Permisos P ON U.Rol = P.Codigo
                WHERE U.Username = @Username;";

            SqlParameter[] parameters = { new SqlParameter("@Username", username) };

            using (SqlDataReader reader = ConnectionDB.ExecuteReader(query, CommandType.Text, parameters))
            {
                if (reader.Read())
                {
                    return reader["Rol"].ToString() == "Administrador";
                }
                else
                {
                    return false;
                }
            }
        }

        /*public void Desbloquear(UsuarioBE pUsuario)
        {

        }*/

        public void Block(string pUsername)
        {
            string commandText = "SP_BloquearUsuario";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", SqlDbType.NVarChar, 50) { Value = pUsername }
            };

            ConnectionDB.ExecuteNonQuery(commandText, CommandType.StoredProcedure, parameters);
        }

        public static bool ExisteDNI(string dni)
        {
            string query = "SELECT COUNT(*) FROM Usuarios WHERE Dni = @Dni";
            SqlParameter parametro = new SqlParameter("@Dni", dni);
            int count = Convert.ToInt32(ConnectionDB.ExecuteScalar(query, CommandType.Text, new[] { parametro }));
            return count > 0;
        }

        public List<UsuarioBE> ConvertToEntity(SqlDataReader reader)
        {
            PermisoDAL permisoDAL = new PermisoDAL();
            List<UsuarioBE> usuarios = new List<UsuarioBE>();

            try
            {
                while (reader.Read())
                {
                    int rolCodigo = reader.GetInt32(reader.GetOrdinal("Rol"));

                    PermisoCompuesto rol = permisoDAL.GetById(rolCodigo);

                    UsuarioBE usuario = new UsuarioBE(
                        reader["DNI"].ToString(),
                        reader["Nombre"].ToString(),
                        reader["Apellido"].ToString(),
                        reader["Correo"].ToString(),
                        rol,
                        (bool)reader["Bloqueo"],
                        (bool)reader["Activo"]
                    );
                    usuario.Username = reader["Username"].ToString();
                    usuario.Password = reader["Password"].ToString();

                    Enum.TryParse(reader["Idioma"].ToString(), out Language idioma);
                    usuario.Idioma = idioma;

                    usuarios.Add(usuario);
                }

                return usuarios;
            }
            catch (Exception)
            {
                if (!reader.IsClosed)
                {
                    reader.Close();
                }
                throw new DatabaseException(DatabaseErrorType.DataConversionError);
            }
        }
    }
}
