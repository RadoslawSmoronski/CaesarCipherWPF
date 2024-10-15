using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    public interface ICipherService
    {
        public Dictionary<char, int> AlphabetForward { get; }
        public Dictionary<int, char> AlphabetBackward { get; }
        public int MoveAmount { get; set; }
        public string ConvertFromTextToCipher(string text);
        public string ConvertFromCipherToText(string text);
        public void IncreaseMoveAmount();
        public void DecreaseMoveAmount();
    }
}
