using CaesarCipherWPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    public interface ICipherService
    {
        public int MoveAmount { get; set; }
        public void ChangeAlphabet(AlphabetTypeEnum alphabetType);
        public void IncreaseMoveAmount();
        public void DecreaseMoveAmount();
        public string ConvertFromTextToCipher(string text);
        public string ConvertFromCipherToText(string text);
    }
}
