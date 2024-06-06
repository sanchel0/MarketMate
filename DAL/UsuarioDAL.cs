using BE;
using System;
using System.Collections.Generic;
using System.Data;
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
            string commandText = "SP_RegistrarUsuario";
            CommandType commandType = CommandType.StoredProcedure;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DNI", pUsuario.Dni),
                new SqlParameter("@Nombre", pUsuario.Nombre),
                new SqlParameter("@Apellido", pUsuario.Apellido),
                new SqlParameter("@Correo", pUsuario.Correo),
                new SqlParameter("@RolID", (int)pUsuario.Rol),
                new SqlParameter("@Username", pUsuario.Username),
                new SqlParameter("@Password", pUsuario.Password),
                new SqlParameter("@Bloqueo", pUsuario.Bloqueo),
                new SqlParameter("@Activo", pUsuario.Activo)
            };

            ConnectionDB.ExecuteNonQuery(commandText, commandType, parameters);
        }

        public void Update(UsuarioBE pUsuario)
        {
            string commandText = "SP_ModificarUsuario";
            CommandType commandType = CommandType.StoredProcedure;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DNI", pUsuario.Dni),
                new SqlParameter("@Nombre", pUsuario.Nombre),
                new SqlParameter("@Apellido", pUsuario.Apellido),
                new SqlParameter("@Correo", pUsuario.Correo),
                new SqlParameter("@RolID", (int)pUsuario.Rol),
                new SqlParameter("@Username", pUsuario.Username),
                new SqlParameter("@Password", pUsuario.Password),
                new SqlParameter("@Bloqueo", pUsuario.Bloqueo),
                new SqlParameter("@Activo", pUsuario.Activo)
            };

            ConnectionDB.ExecuteNonQuery(commandText, commandType, parameters);
        }

        public void Delete(string pId)
        {
            string commandText = "SP_DeshabilitarUsuario";
            CommandType commandType = CommandType.StoredProcedure;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DNI", SqlDbType.Char, 8) { Value = pId }
            };

            ConnectionDB.ExecuteNonQuery(commandText, commandType, parameters);
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

            SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, parameters);
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

            try
            {
                using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, parameters))
                {
                    usuarios = ConvertToEntity(reader);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener usuarios", ex);
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

            using (SqlDataReader reader = ConnectionDB.ExecuteReader(commandText, parameters))
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

        /*public void Desbloquear(UsuarioBE pUsuario)
        {

        }*/

        public void Block(string pUsername)
        {
            string commandText = "SP_BloquearUsuario";
            CommandType commandType = CommandType.StoredProcedure;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", SqlDbType.NVarChar, 50) { Value = pUsername }
            };

            ConnectionDB.ExecuteNonQuery(commandText, commandType, parameters);
        }

        public List<UsuarioBE> ConvertToEntity(SqlDataReader reader)
        {
            List<UsuarioBE> usuarios = new List<UsuarioBE>();

            while (reader.Read())
            {
                UsuarioBE usuario = new UsuarioBE(
                    reader["DNI"].ToString(),
                    reader["Nombre"].ToString(),
                    reader["Apellido"].ToString(),
                    reader["Correo"].ToString(),
                    (Rol)reader["RolID"],
                    (bool)reader["Bloqueo"],
                    (bool)reader["Activo"]
                );
                usuario.Username = reader["Username"].ToString();
                usuario.Password = reader["Password"].ToString();
                
                usuarios.Add(usuario);
            }

            //reader.Close();
            return usuarios;
        }

        
    }
}
