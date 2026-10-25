using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level1
{
    internal class Ex6_TheSumOfDigits : ITask
    {
        public string Title => "Сумма цифр числа (строка + арифметика)";
        public string Description => "найти сумму цифр введённого числа (например, 1234 → 10)";
        public string[] Condition => new[]
        {
            "Способ 1 (строка): число → ToString() → пройти по символам → int.Parse` каждой цифры",
            "Способ 2 (арифметика): цикл while (n > 0) { sum += n % 10; n /= 10; }",
            "Оба способа оформить отдельными методами",
            "Отрицательные числа — брать модуль"
        };
        public void Launch()
        {
            Console.WriteLine("Введите целое число:");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("Ошибка: введено некорректное число.");
                return;
            }

            int sumLine = SumLine(number);
            int sumArithmetic = SumArithmetic(number);

            Console.WriteLine($"\nВведено число: {number}");
            Console.WriteLine($"Через строку: {sumLine}");
            Console.WriteLine($"Через арифметику: {sumArithmetic}");

            if (sumLine == sumArithmetic)
                Console.WriteLine("Решения совпадают.");
            else
                Console.WriteLine("Решения НЕ совпадают.");
        }

        private int SumLine(int v)
        {
            v = Math.Abs(v);
            string numberStr = v.ToString();
            int sum = 0;

            foreach (char n in numberStr)
            {
                sum += int.Parse(n.ToString());
            }
            return sum;
        }

        private int SumArithmetic(int v)
        {
            v = Math.Abs(v);
            int sum = 0;

            while (v > 0)
            {
                sum += v % 10;
                v /= 10;
            }
            return sum;
        }
    }
}