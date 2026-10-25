using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level1
{
    internal class Ex12_ThePalindrome : ITask
    {
        public string Title => "Палиндром (без учёта регистра/пробелов)";
        public string Description => "проверить, является ли строка палиндромом.";
        public string[] Condition => new[]
        {
            "Игнорировать регистр (ToLower/ToUpper)",
            "Игнорировать пробелы и знаки пунктуации (или хотя бы пробелы)",
            "Не использовать LINQ `Reverse",
            "Пустая строка и строка из одного символа — палиндром"
        };

        public void Launch()
        {
            Console.Write("Введите строку для проверки: ");
            string userInput = Console.ReadLine() ?? string.Empty;

            if (ThePalindrome(userInput))
                Console.WriteLine("Это палиндром!");
            else
                Console.WriteLine("Это не палиндром.");
        }

        private bool ThePalindrome(string strn)
        {
            if (string.IsNullOrEmpty(strn)) return true;

            int left = 0;
            int right = strn.Length - 1;

            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(strn[left]))
                {
                    left++;
                }
                while (left < right && !char.IsLetterOrDigit(strn[right]))
                {
                    right--;
                }

                if (char.ToLower(strn[left]) != char.ToLower(strn[right]))
                {
                    return false;
                }

                left++;
                right--;
            }
            return true;
        }
    }
}
