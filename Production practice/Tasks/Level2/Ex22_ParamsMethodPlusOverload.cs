using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level2
{
    internal class Ex22_ParamsMethodPlusOverload : ITask
    {
        public string Title => "Params-метод + перегрузка";
        public string Description => "Написать метод суммы с `params` и его перегрузку";
        public string[] Condition => new[]
        {
            "Sum(params int[] numbers) — сумма произвольного числа чисел",
            "Перегрузка Sum(int[] numbers) — та же логика для массива",
            "Продемонстрировать: Sum(1, 2, 3), Sum(new[] {1, 2, 3}), Sum()",
            "Пустой вызов — вернуть 0"
        };

        public void Launch()
        {
            Console.WriteLine("--- Тестирование params и перегрузок ---\n");

            int result1 = Sum(1, 2, 3);
            Console.WriteLine($"Sum(1, 2, 3) = {result1}");

            int[] array = { 1, 2, 3 };
            int result2 = Sum(array);
            Console.WriteLine($"Sum(new[] {{1, 2, 3}}) = {result2}");

            int result3 = Sum();
            Console.WriteLine($"Sum() = {result3}");

            //перегрузка 
            var list = new List<int> { 4, 5, 6 };
            int result4 = Sum(list);
            Console.WriteLine($"Sum(List<int> {{4, 5, 6}}) = {result4}");

            Console.WriteLine($"\nРезультаты 1 и 2 совпадают: {result1 == result2}");
        }
        public static int Sum(params int[] numbers)
        {
            if (numbers == null) return 0;

            int total = 0;
            foreach (int num in numbers)
            {
                total += num;
            }
            return total;
        }
        public static int Sum(IEnumerable<int> numbers)
        {
            if (numbers == null) return 0;

            int total = 0;
            foreach (int num in numbers)
            {
                total += num;
            }
            return total;
        }
    }
}
