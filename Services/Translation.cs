using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Translation
    {
        public Dictionary<string, Dictionary<string, string>> Controls { get; set; }
        public Dictionary<string, Dictionary<string, Dictionary<string, string>>> Entities { get; set; }
    }
}
