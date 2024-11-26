using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPdfContent
    {
        void GeneratePdfContent(Document document, Dictionary<string, string> translations);
    }
}
