using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MarcaBLL : BaseBLL<MarcaBE>
    {
        public MarcaBLL() : base(new MarcaDAL())
        {
        }
    }
}
