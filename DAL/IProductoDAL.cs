using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IProductoDAL : ICrud<ProductoBE>
    {
        List<ProductoBE> GetProductosConStockMinimo();
        List<ProductoBE> GetProductosActivos();
    }
}
