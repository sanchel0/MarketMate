using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TranslationService
    {
        private static Dictionary<string, string> translations;

        public static void SetTranslations(Dictionary<string, string> t)
        {
            translations = t;
        }

        public static string GetTranslation(string key)
        {
            return translations != null && translations.ContainsKey(key) ? translations[key] : key;
        }

        public static Dictionary<string, string> GetTranslations()
        {
            return translations;
        }
    }
}
