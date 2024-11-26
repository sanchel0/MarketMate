using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public abstract class BasePdfContent
    {
        protected Font fontTitle = FontFactory.GetFont(FontFactory.TIMES_BOLD, 18f);
        protected Font fontSubTitle = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12f, BaseColor.BLACK);
        public abstract void GeneratePdfContent(Document document);
        protected string GetTranslation(string key)
        {
            return TranslationService.GetTranslation(key);
        }
    }
}
