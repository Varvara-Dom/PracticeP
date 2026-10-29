using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level2
{
    internal class Ex34_LINQFirstLetter : ITask
    {
        public string Title => "LINQ: группировка слов по первой букве";
        public string Description => "Сгруппировать слова по первой букве.";
        public string[] Condition => new[]
        {
            "Взять список слов (10+)",
            "Сгруппировать через LINQ GroupBy(w => w[0])",
            "Отсортировать группы по первой букве",
            "Внутри группы — отсортировать слова",
            "Вывести «Буква: слово1, слово2, ..»"
        };

        public void Launch()
        {
            List<string> words = new List<string>
            {
                "Eon", "Auto-da-fe", "Epigram", "Dialysis", "Apomorphine",
                "Neoromanticism", "Deserts", "Namtar"

            };

            Console.WriteLine("--- Исходный список слов ---");
            Console.WriteLine(string.Join(", ", words));
            Console.WriteLine();

            var groupedWords = words
                .GroupBy(w => w[0])
                .OrderBy(group => group.Key)
                .Select(group => new
                {
                    Letter = group.Key,
                    SortedWords = group.OrderBy(w => w).ToList()
                });

            Console.WriteLine("--- Результат ---");

            foreach (var group in groupedWords)
            {
                Console.WriteLine($"{char.ToUpper(group.Letter)}: {string.Join(", ", group.SortedWords)}");
            }
        }
    }
}
