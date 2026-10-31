using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level3
{
    internal class Ex39_OddNumberGenerator : ITask
    {
        public string Title => "yield return — генератор чётных чисел";
        public string Description => "Реализовать генератор чётных чисел через yield return.";
        public string[] Condition => new[]
        {
            "Метод IEnumerable<int> GetEvenNumbers(int max) — возвращает чётные числа до max",
            "Реализовать именно через yield return, без промежуточного списка",
            "Продемонстрировать работу в foreach",
            "Дополнительно: показать ленивость — вывести сообщение внутри генератора и убедиться, что оно печатается по одному"
        };

        public void Launch()
        {
            Console.WriteLine("Показ 1 - полный перебор");
            foreach (int number in GetEvenNumbers(10))
            {
                Console.Write(number + " ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Показ 2 - ленивость");

            var evenNumbers = GetEvenNumbers(10);
            Console.WriteLine("Генератор создан, но код внутри ещё не выполнялся (нет вывода от генератора).");
            Console.WriteLine("Берём только первые 3 числа:\n");

            int count = 0;
            foreach (int number in evenNumbers)
            {
                Console.WriteLine(number + " ");
                count++;
                if (count >= 3)
                {
                    break;
                }
            }
            Console.WriteLine("\n\nЦикл прерван (break). Остальные числа не вычислялись.");
            Console.WriteLine("Именно это доказывает ленивость: генератор работает только по запросу.");
        }

        private IEnumerable<int> GetEvenNumbers(int max)
        {
            for (int i = 0; i <= max; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine($"[Генератор] yield return {i}");
                    yield return i;
                }
            }
        }
    }
}