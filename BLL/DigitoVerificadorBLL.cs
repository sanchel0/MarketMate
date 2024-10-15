using BE;
using DAL;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DigitoVerificadorBLL
    {
        DigitoVerificadorDAL dal;

        public DigitoVerificadorBLL()
        {
            dal = new DigitoVerificadorDAL();
        }
        public void Update()
        {
            dal.Update();
        }

        public void VerifyDV(string username)
        {
            if (!dal.CompareDV())
            {
                UsuarioBLL userBLL = new UsuarioBLL();
                if (userBLL.IsAdmin(username))//El metodo IsAdmin(), devuelve false ya sea que el rol de Username dado no sea de Administrador o si no se pudo encontrar el rol asignado al Username, debido a que es incorrecto.
                    throw new DVException(DVErrorType.Admin);
                throw new DVException(DVErrorType.NoAdmin);
            }
            //Si el usuario no ingresa los datos correctos en el login, igualmente muestra el mismo mensaje por defecto para los usuarios normales.
            //
            /*

            List<ProveedorBE> list = new ProveedorBLL().GetAll();
            //Repetir para cada entidad de negocio.
            GenerarDVH(list);
            GenerarDVV(list);
            //Repetir proceso para cada lista, se podria lamacenar cada lista en un diccionario, y se itera en un foreach y dentro se ejecutan esos dos metodos por cada valor de la lista, donde cada valor sería una lista de entidades
            */
        }


    }
}
