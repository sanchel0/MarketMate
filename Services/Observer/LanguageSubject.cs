using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BE;
using static System.Net.Mime.MediaTypeNames;

namespace Services
{
    public class LanguageSubject
    {
        private static LanguageSubject _instance;
        private List<ILanguageObserver> _observers = new List<ILanguageObserver>();
        private Dictionary<string, Dictionary<string, string>> _translations = new Dictionary<string, Dictionary<string, string>>();
        private Language _currentLanguage = Language.en;
        private Dictionary<string, string> _enumTranslations = new Dictionary<string, string>();
        private string _translationsFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Translations");

        private LanguageSubject() { }

        public static LanguageSubject Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LanguageSubject();
                }
                return _instance;
            }
        }

        public Language CurrentLanguage
        {
            get { return _currentLanguage; }
        }

        public void ChangeLanguage(Language language)
        {
            _currentLanguage = language;
            _translations.Clear();
            _enumTranslations.Clear();

            foreach (var observer in _observers)
            {
                LoadFormTranslations(observer.FormName);
            }

            LoadEnumTranslations();
            Notify();
        }

        public string GetEnumTranslation(Enum enumValue)
        {
            string key = enumValue.ToString();
            if (_enumTranslations.TryGetValue(key, out string translation))
            {
                return translation;
            }
            return key;
        }

        private void LoadEnumTranslations()
        {
            string languageFolder = _currentLanguage == Language.es ? "Spanish" : "English";
            string enumsFilePath = Path.Combine(_translationsFolderPath, languageFolder, "Enums.json");

            if (File.Exists(enumsFilePath))
            {
                string jsonContent = File.ReadAllText(enumsFilePath);
                _enumTranslations = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonContent);
            }
            else
            {
                _enumTranslations = new Dictionary<string, string>();
            }
        }

        public Dictionary<string, string> GetTranslations(string formName)
        {
            if (!_translations.ContainsKey(formName))
            {
                LoadFormTranslations(formName);
            }
            return _translations[formName];
        }

        private void LoadFormTranslations(string formName)
        {
            string languageFolder = _currentLanguage == Language.es ? "Spanish" : "English";
            string translationsFilePath = Path.Combine(_translationsFolderPath, languageFolder, $"{formName}.json");
            if (File.Exists(translationsFilePath))
            {
                string jsonContent = File.ReadAllText(translationsFilePath);
                var formTranslations = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonContent);
                _translations[formName] = formTranslations;
            }
            else
            {
                _translations[formName] = new Dictionary<string, string>();
            }
        }

        public void Attach(ILanguageObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void Detach(ILanguageObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.UpdateLanguage();
            }
        }
    }
}
