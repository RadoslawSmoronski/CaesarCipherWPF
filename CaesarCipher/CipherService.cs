using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    public class CipherService : ICipherService
    {
        public char[] Alphabet { get; }

        public int MoveAmount { get; set; }

        public CipherService(char[] alphabet)
        {
            MoveAmount = 2;

            Alphabet = alphabet;
        }

        private int GetCharNumberFromChar(char character)
        {
          
            for(int i=0; i < Alphabet.Length; i++)
            {
                if (Alphabet[i] == char.ToUpper(character))
                {
                    return i;
                }
            }

            return -1;
        }


        public void IncreaseMoveAmount()
        {
            if(MoveAmount < (Alphabet.Length-1))
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
            StringBuilder sb = new StringBuilder();

            foreach(char c in text)
            {
                int cNum = GetCharNumberFromChar(c);

                if (cNum != -1)
                {
                    int num = cNum + MoveAmount;

                    if ((num) >= Alphabet.Length)
                    {
                        num -= Alphabet.Length;
                    }

                    char newCharacter = Alphabet[num];

                    if(char.IsLower(c))
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

        public string ConvertFromCipherToText(string text)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in text)
            {
                int cNum = GetCharNumberFromChar(c);

                if (cNum != -1)
                {
                    int num = cNum - MoveAmount;

                    if ((num) < 0)
                    {
                        num += Alphabet.Length;
                    }

                    char newCharacter = Alphabet[num];

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
