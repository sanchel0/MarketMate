using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DigitoVerificadorBE
    {
        public DigitoVerificadorBE(string dvh, string dvv)
        {
            DVH = dvh;
            DVV = dvv;
        }
        public string DVH { get; set; }
        public string DVV { get; set; }
    }
}
