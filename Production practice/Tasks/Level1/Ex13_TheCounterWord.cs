using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level1
{
    internal class Ex13_TheCounterWord : ITask
    {
        public string Title => "Счётчик вхождений слов в тексте (Dictionary)";
        public string Description => "посчитать, сколько раз каждое слово встречается в тексте.";
        public string[] Condition => new[]
        {
            "Использовать `Dictionary<string, int>",
            "Разбить текст на слова (по пробелам и знакам пунктуации)",
            "Привести слова к нижнему регистру",
            "Вывести пары «слово → количество», отсортированные по убыванию количества."
        };

        public void Launch()
        {
            Console.WriteLine("Введите текст для рассмотрения:");
            string text = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Текст не введен.");
                return;
            }

            char[] separator = { ' ', '.', ',', '!', '?', ';', ':', '"', '(', ')', '\n', '\r', '-' };
            string[] Words = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            var counts = new Dictionary<string, int>();

            foreach (var word in Words)
            {
                string cleanWord = word.Trim().ToLower();
                if (string.IsNullOrEmpty(cleanWord)) continue;

                if (counts.ContainsKey(cleanWord))
                    counts[cleanWord]++;
                else
                    counts.Add(cleanWord, 1);
            }

            var sortedList = new List<KeyValuePair<string, int>>(counts);
            sortedList.Sort((x, y) => y.Value.CompareTo(x.Value));

            Console.WriteLine("\nРезультаты (слово → количество):");
            Console.WriteLine(new string('-', 30));

            foreach (var pair in sortedList)
            {
                Console.WriteLine($"{pair.Key,-15} -> {pair.Value}");
            }
        }
    }
}
