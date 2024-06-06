using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL
{
    public class ProductoBLL : BaseBLL<ProductoBE>
    {
        public ProductoBLL() : base(new ProductoDAL())
        {
            //crud = new ProductoDAL();
        }


    }
}
