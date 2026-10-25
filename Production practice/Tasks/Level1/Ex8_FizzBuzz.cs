using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level1
{
    internal class Ex8_FizzBuzz : ITask
    {
        public string Title => "FizzBuzz 1–100";
        public string Description => "Вывести числа от 1 до 100 с заменами.";
        public string[] Condition => new[]
        {
            "Кратно 3 → Fizz",
            "Кратно 5 → Buzz",
            "Кратно 15 → FizzBuzz",
            "Иначе — само число",
            "Порядок проверок: сначала 15, потом 3 и 5"
        };

        public void Launch()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 15 == 0)
                    Console.WriteLine("FizzBuzz");
                else if (i % 3 == 0)
                    Console.WriteLine("Fizz");
                else if (i % 5 == 0)
                    Console.WriteLine("Buzz");
                else
                    Console.WriteLine(i);
            }
        }
    }
}
