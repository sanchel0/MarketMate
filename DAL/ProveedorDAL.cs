using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProveedorDAL : ICrud<ProveedorBE>
    {
        public void Insert(ProveedorBE proveedor)
        {
            string query = @"INSERT INTO Proveedores (CUIT, Nombre, RazonSocial, Telefono, Correo, Direccion, Banco, TipoCuenta, NumCuenta, CBU, Alias)
                         VALUES (@CUIT, @Nombre, @RazonSocial, @Telefono, @Correo, @Direccion, @Banco, @TipoCuenta, @NumCuenta, @CBU, @Alias)";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@CUIT", proveedor.CUIT),
            new SqlParameter("@Nombre", proveedor.Nombre),
            new SqlParameter("@RazonSocial", proveedor.RazonSocial),
            new SqlParameter("@Telefono", proveedor.Telefono),
            new SqlParameter("@Correo", proveedor.Correo),
            new SqlParameter("@Direccion", (object)proveedor.Direccion ?? DBNull.Value),
            new SqlParameter("@Banco", (object)proveedor.Banco ?? DBNull.Value),
            new SqlParameter("@TipoCuenta", (object)proveedor.TipoCuenta ?? DBNull.Value),
            new SqlParameter("@NumCuenta", (object)proveedor.NumCuenta ?? DBNull.Value),
            new SqlParameter("@CBU", (object)proveedor.CBU ?? DBNull.Value),
            new SqlParameter("@Alias", (object)proveedor.Alias ?? DBNull.Value)
            };

            ConnectionDB.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public void Update(ProveedorBE proveedor)
        {
            string query = @"UPDATE Proveedores 
                         SET Nombre = @Nombre, RazonSocial = @RazonSocial, Telefono = @Telefono, Correo = @Correo, 
                             Direccion = @Direccion, Banco = @Banco, TipoCuenta = @TipoCuenta, NumCuenta = @NumCuenta, 
                             CBU = @CBU, Alias = @Alias
                         WHERE CUIT = @CUIT";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@CUIT", proveedor.CUIT),
            new SqlParameter("@Nombre", proveedor.Nombre),
            new SqlParameter("@RazonSocial", proveedor.RazonSocial),
            new SqlParameter("@Telefono", proveedor.Telefono),
            new SqlParameter("@Correo", proveedor.Correo),
            new SqlParameter("@Direccion", proveedor.Direccion),
            new SqlParameter("@Banco", proveedor.Banco),
            new SqlParameter("@TipoCuenta", proveedor.TipoCuenta.ToString()),
            new SqlParameter("@NumCuenta", proveedor.NumCuenta),
            new SqlParameter("@CBU", proveedor.CBU),
            new SqlParameter("@Alias", proveedor.Alias)
            };

            ConnectionDB.ExecuteNonQuery(query, CommandType.Text, parameters);
        }

        public void Delete(string cuit)
        {
            string query = "UPDATE Proveedores SET Act_B = 1 WHERE CUIT = @CUIT";

            SqlParameter parameter = new SqlParameter("@CUIT", SqlDbType.NVarChar, 11) { Value = cuit };

            ConnectionDB.ExecuteNonQuery(query, CommandType.Text, new[] { parameter });
        }

        public List<ProveedorBE> GetAll()
        {
            string query = "SELECT * FROM Proveedores";

            List<ProveedorBE> proveedores = new List<ProveedorBE>();

            using (SqlDataReader reader = ConnectionDB.ExecuteReader(query, CommandType.Text))
            {
                proveedores = ConvertToEntity(reader);
            }

            return proveedores;
        }

        public ProveedorBE GetById(string cuit)
        {
            string query = "SELECT * FROM Proveedores WHERE CUIT = @CUIT";

            SqlParameter parameter = new SqlParameter("@CUIT", SqlDbType.NVarChar, 11) { Value = cuit };

            using (SqlDataReader reader = ConnectionDB.ExecuteReader(query, CommandType.Text, new[] { parameter }))
            {
                List<ProveedorBE> proveedores = ConvertToEntity(reader);
                return proveedores.FirstOrDefault();
            }
        }

        public List<ProveedorBE> ConvertToEntity(SqlDataReader reader)
        {
            List<ProveedorBE> proveedores = new List<ProveedorBE>();

            while (reader.Read())
            {
                TipoCuenta? tipoCuenta = null;

                if (reader["TipoCuenta"] != DBNull.Value &&
                    Enum.TryParse(reader["TipoCuenta"].ToString(), out TipoCuenta parsedTipoCuenta))
                {
                    tipoCuenta = parsedTipoCuenta;
                }

                ProveedorBE proveedor = new ProveedorBE(
                    reader["CUIT"].ToString(),
                    reader["Nombre"].ToString(),
                    reader["RazonSocial"].ToString(),
                    Convert.ToInt32(reader["Telefono"]),
                    reader["Correo"].ToString()
                )
                {
                    Direccion = reader["Direccion"] != DBNull.Value ? reader["Direccion"].ToString() : null,
                    Banco = reader["Banco"] != DBNull.Value ? reader["Banco"].ToString() : null,
                    TipoCuenta =tipoCuenta,
                    NumCuenta = reader["NumCuenta"] != DBNull.Value ? reader["NumCuenta"].ToString() : null,
                    CBU = reader["CBU"] != DBNull.Value ? reader["CBU"].ToString() : null,
                    Alias = reader["Alias"] != DBNull.Value ? reader["Alias"].ToString() : null
                };
                proveedor.ActB = Convert.ToBoolean(reader["Act_B"]);
                proveedores.Add(proveedor);
            }

            return proveedores;
        }
    }
}
