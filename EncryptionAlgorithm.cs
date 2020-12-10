using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject1
{
    public class EncryptionAlgorithm
    {
        internal static List<char> rusAlphabet = new List<char> { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
        static List<char> rusAlphabetBig = new List<char> { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };        
        
        // Побуквенная шифровка
        private static char Encrypt(char letter, int step)
        {
            if (rusAlphabet.Contains(letter))
            {
                if (rusAlphabet.IndexOf(letter) + step > 32)
                {
                    int displaceStep = (int)step - (33 - rusAlphabet.IndexOf(letter));
                    letter = rusAlphabet[displaceStep];
                }
                else
                {
                    letter = rusAlphabet[rusAlphabet.IndexOf(letter) + step];
                }
                return letter;
            }
            else if (rusAlphabetBig.Contains(letter))
            {
                if (rusAlphabetBig.IndexOf(letter) + step > 32)
                {
                    int displaceStep = (int)step - (33 - rusAlphabetBig.IndexOf(letter));
                    letter = rusAlphabetBig[displaceStep];
                }
                else
                {
                    letter = rusAlphabetBig[rusAlphabetBig.IndexOf(letter) + step];
                }
                return letter;
            }
            else
            {
                return letter;
            }

        }

        // Побуквенная дешифровка
        private static char Decrypt(char letter, int step)
        {

            if (rusAlphabet.Contains(letter))
            {
                if (rusAlphabet.IndexOf(letter) - step < 0)
                {
                    int displaceStep = (int)step - rusAlphabet.IndexOf(letter);
                    letter = rusAlphabet[33 - displaceStep];
                }
                else
                {
                    letter = rusAlphabet[rusAlphabet.IndexOf(letter) - step];
                }
                return letter;
            }
            else if (rusAlphabetBig.Contains(letter))
            {
                if (rusAlphabetBig.IndexOf(letter) - step < 0)
                {
                    int displaceStep = (int)step - rusAlphabetBig.IndexOf(letter);
                    letter = rusAlphabetBig[33 - displaceStep];
                }
                else
                {
                    letter = rusAlphabetBig[rusAlphabetBig.IndexOf(letter) - step];
                }
                return letter;
            }
            else
            {
                return letter;
            }

        }

        // Получение зашифрованной строки
        public static string GetEncryptedString(string text, string key)
        {
            string result = "";
            int[] steps = GetSteps(key, text.Length);
            int j = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (rusAlphabet.Contains(char.ToLower(text[i])))
                {
                    result += Encrypt(text[i], steps[j]); ;
                    j++;
                }
                else
                {
                    result += text[i];
                }
            }
            return result;
        }

        // Получение расшифрованной строки
        public static string GetDecryptedString(string text, string key)
        {
            string result = "";
            int[] steps = GetSteps(key, text.Length);
            int j = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (rusAlphabet.Contains(char.ToLower(text[i])))
                {
                    result += Decrypt(text[i], steps[j]);
                    j++;
                }
                else
                {
                    result += text[i];
                }
            }
            return result;
        }

        // Вспомогательный метод, возвращающий массив значений сдвига для каждой буквы
        private static int[] GetSteps(string key, int count)
        {
            key = key.Replace(" ", "");
            string keyCount = "";
            for (int i = 0; i < count; i++)
            {
                keyCount += key;
            }
            keyCount = keyCount.Substring(0, count);
            int[] positions = new int[count];
            for (int i = 0; i < keyCount.Length; i++)
            {
                if (rusAlphabet.Contains(keyCount[i]))
                {
                    positions[i] = rusAlphabet.IndexOf(keyCount[i]);
                }
            }
            return positions;
        }
    }
}
