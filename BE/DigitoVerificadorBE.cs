using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DigitoVerificadorBE
    {
        public DigitoVerificadorBE(string tableName, string dvh, string dvv)
        {
            TableName = tableName;
            DVH = dvh;
            DVV = dvv;
        }
        public string TableName { get; set; }
        public string DVH { get; set; }
        public string DVV { get; set; }
    }
}
