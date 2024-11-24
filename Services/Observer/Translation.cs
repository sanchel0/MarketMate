using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Translation
    {
        public Dictionary<string, string> PDF { get; set; }
        public Dictionary<string, Dictionary<string, string>> Controls { get; set; }
        public Dictionary<string, Dictionary<string, string>> Enums { get; set; }
        public Dictionary<string, Dictionary<string, Dictionary<string, string>>> Entities { get; set; }

        /*public string GetTranslatedValueFromEntity(string entity, string headerOrValue, string key)
        {
            return Entities[entity]?[headerOrValue]?[key]?.ToString() ?? key;
        }*/

        public string GetEnumTranslation<T>(T enumValue)
        {
            try
            {
                string enumName = typeof(T).Name;
                string enumKey = enumValue.ToString();
                if (Enums.ContainsKey(enumName) && Enums[enumName].ContainsKey(enumKey))
                {
                    return Enums[enumName][enumKey];
                }
                return enumKey;
            }
            catch(Exception ex) { Console.WriteLine(ex.ToString()); return null;}
        }
    }
}
