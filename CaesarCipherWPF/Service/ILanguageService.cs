using CaesarCipherWPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipherWPF.Service
{
    public interface ILanguageService
    {
        public void ChangeLanguage(LanguagesTypeEnum type);
        public string GetText(string code);
        
    }
}
