using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BE;

namespace Services
{
    public class LanguageSubject
    {
        private static LanguageSubject _instance;
        private List<ILanguageObserver> _observers = new List<ILanguageObserver>();
        private Dictionary<string, Translation> _translations = new Dictionary<string, Translation>();
        private Language _currentLanguage = Language.en;
        private string _translationsFolderPath = Path.Combine("..", "..", "..", "Translations");
        //private string _translationsFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Translations");

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

            foreach (var observer in _observers)
            {
                LoadFormTranslations(observer.FormName);
            }

            Notify();
        }

        public Translation GetTranslations(string formName)
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
                var formTranslations = JsonConvert.DeserializeObject<Translation>(jsonContent);
                _translations[formName] = formTranslations;
            }
            else
            {
                _translations[formName] = new Translation();
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
                observer.UpdateLanguage(/*_translations*/);
            }
        }
    }
}
