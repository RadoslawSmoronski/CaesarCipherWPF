using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace CaesarCipherWPF.Service
{
    public class LanguageService : ILanguageService
    {
        private string LanguageCode = "en-GB";
        private ResourceManager _resourceManager;

        public LanguageService()
        {
            _resourceManager = new ResourceManager("CaesarCipherWPF.Properties.Languages.MainWindow", typeof(LanguageService).Assembly);
        }

        public void ChangeLanguage(LanguagesTypeEnum type)
        {
            switch (type)
            {
                case LanguagesTypeEnum.English:
                    LanguageCode = "en-GB";
                    break;

                case LanguagesTypeEnum.Polish:
                    LanguageCode = "pl";
                    break;

                default:
                    throw new ArgumentException("Invalid language type.");
            }
        }

        public string GetText(string code)
        {
            CultureInfo cultureInfo = new CultureInfo(LanguageCode);
            var response = _resourceManager.GetString(code, cultureInfo);

            return response ?? "[language error]";
        }
    }
}