using CaesarCipherWPF.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CaesarCipher
{
    public class CipherService : ICipherService
    {
        private ResourceManager _resourceManager;

        private char[] _alphabet;

        public int MoveAmount { get; set; }

        private string AlphabetType = "English";

        public CipherService(AlphabetTypeEnum alphabetType)
        {
            _resourceManager = new ResourceManager("CaesarCipher.Properties.Alphabets", typeof(CipherService).Assembly);

            MoveAmount = 2;

            ChangeAlphabet(alphabetType);
        }

        public void ChangeAlphabet(AlphabetTypeEnum type)
        {
            switch (type)
            {
                case AlphabetTypeEnum.English:
                    AlphabetType = "English";
                    break;

                case AlphabetTypeEnum.Polish:
                    AlphabetType = "Polish";
                    break;

                default:
                    throw new ArgumentException("Invalid alphabet type.");
            }

            var alphabet = _resourceManager.GetString(AlphabetType, CultureInfo.CurrentCulture);

            if (alphabet == null)
            {
                throw new ArgumentException($"Alphabet for {AlphabetType} not found in resources.");
            }

            _alphabet = alphabet.ToCharArray();

            if(MoveAmount>= _alphabet.Length)
            {
                MoveAmount = _alphabet.Length - 1;
            }
        }

        private int GetCharNumberFromChar(char character)
        {
          
            for(int i=0; i < _alphabet.Length; i++)
            {
                if (_alphabet[i] == char.ToUpper(character))
                {
                    return i;
                }
            }

            return -1;
        }


        public void IncreaseMoveAmount()
        {
            if(MoveAmount < (_alphabet.Length-1))
            {
                MoveAmount++;
            }
        }

        public void DecreaseMoveAmount()
        {
            if (MoveAmount > 0)
            {
                MoveAmount--;
            }
        }

        public string ConvertFromTextToCipher(string text)
        {
            return ConvertCaesarCipher(text, cNum => (cNum + MoveAmount) % _alphabet.Length);
        }

        public string ConvertFromCipherToText(string text)
        {
            return ConvertCaesarCipher(text, cNum => (cNum - MoveAmount + _alphabet.Length) % _alphabet.Length);
        }

        private string ConvertCaesarCipher(string text, Func<int, int> func)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in text)
            {
                int cNum = GetCharNumberFromChar(c);

                if (cNum != -1)
                {
                    int num = func(cNum);

                    if (num < 0 || num >= _alphabet.Length)
                    {
                        continue;
                    }

                    char newCharacter = _alphabet[num];

                    if (char.IsLower(c))
                        newCharacter = char.ToLower(newCharacter);

                    sb.Append(newCharacter);
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }


    }
}