using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level2
{
    public static class StringExtensions
    {
        public static bool IsPalindrome(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            var cleaned = new string(str.Where(char.IsLetterOrDigit).ToArray()).ToLower();

            int left = 0;
            int right = cleaned.Length - 1;

            while (left < right)
            {
                if (cleaned[left] != cleaned[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }
        public static int WordCount(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return 0;
            return str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
        public static string ReverseString(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
    public class Ex16_TheSolutionMethod : ITask
    {
        public string Title => "Методы расширения для `string`";
        public string Description => "Написать extension-методы для `string`";
        public string[] Condition => new[]
        {
            "Реализовать в статическом классе StringExtensions.",
            "Методы: IsPalindrome(), WordCount(), ReverseString()",
            "Методы должны быть public static с this string` первым параметром",
            "Продемонстрировать вызов на 2–3 строках"
        };

        public void Launch()
        {
            Console.WriteLine("Введите 1-ое слово: ");
            string wordA = Console.ReadLine();
            Console.WriteLine("Введите 2-ое слово: ");
            string wordB = Console.ReadLine();
            Console.WriteLine("Введите 3-ье слово: ");
            string wordC = Console.ReadLine();

            if (string.IsNullOrEmpty(wordA))
                wordA = "пусто";
            if (string.IsNullOrEmpty(wordB))
                wordB = "пусто";
            if (!string.IsNullOrEmpty(wordC))
                wordC = "пусто";

            ShowResults(wordA);
            ShowResults(wordB);
            ShowResults(wordC);
        }
        private void ShowResults(string word)
        {
            Console.WriteLine($"Текст: {word}");
            Console.WriteLine($"Палиндром: {word.IsPalindrome()}");
            Console.WriteLine($"Слов: {word.WordCount()}");
            Console.WriteLine($"Реверс: {word.ReverseString()}");
        }
    }
}
