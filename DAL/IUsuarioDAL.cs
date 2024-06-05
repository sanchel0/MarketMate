using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUsuarioDAL
    {
        UsuarioBE GetByUsername(string pUsername);
        void Bloquear(string pUsername);
    }
}
