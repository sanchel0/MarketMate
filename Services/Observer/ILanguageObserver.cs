using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ILanguageObserver
    {
        void UpdateLanguage();
        string FormName { get; }
    }
}
