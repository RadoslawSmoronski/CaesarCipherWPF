using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    public class CipherService : ICipherService
    {
        public Dictionary<char, int> AlphabetForward { get; } = new Dictionary<char, int>();
        public Dictionary<int, char> AlphabetBackward { get; } = new Dictionary<int, char>();
        public int MoveAmount { get; set; }

        public CipherService()
        {
            MoveAmount = 2;

            char[] alphabet = new char[]
{
                'A', 'Ą', 'B', 'C', 'Ć', 'D', 'E', 'Ę', 'F', 'G',
                'H', 'I', 'J', 'K', 'L', 'Ł', 'M', 'N', 'Ń', 'O',
                'Ó', 'P', 'R', 'S', 'Ś', 'T', 'U', 'W', 'Y',
                'Z', 'Ż', 'Ź'
};
            for (int i = 0; i < alphabet.Length; i++)
            {
                AlphabetForward[alphabet[i]] = i;
                AlphabetBackward[i] = alphabet[i];
            }
        }

        public void IncreaseMoveAmount()
        {
            if(MoveAmount < (AlphabetForward.Count-1))
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

            foreach (char c in text)
            {
                char key = char.ToUpper(c);
                if (AlphabetForward.ContainsKey(key))
                {
                    int num = AlphabetForward[char.ToUpper(c)] + MoveAmount;

                    if((num) >= AlphabetForward.Count)
                    {
                        num -= AlphabetForward.Count;
                    }

                    char newKey = AlphabetBackward[num];

                    if (char.IsUpper(c))
                    {
                        sb.Append(newKey);
                    }
                    else
                    {
                        sb.Append(char.ToLower(newKey));
                    }
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
