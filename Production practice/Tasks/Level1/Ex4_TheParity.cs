using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level1
{
    internal class Ex4_TheParity : ITask
    {
        public string Title => "Чётность числа (два способа)";
        public string Description => "определить, чётное ли введённое число.";
        public string[] Condition => new[]
        {
            "Способ 1: через % 2 == 0",
            "Способ 2: через тернарный оператор ? :",
            "Оба способа реализовать отдельными методами",
            "Вывести результат обоих способов"
        };
        public void Launch()
        {
            int numb = TheParityNumbInput("Введите целое число: ");

            TheParityNumbPercent(numb);
            TheParityNumbByQuestion(numb);
        }

        private int TheParityNumbInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                Console.WriteLine("Некорректный ввод. Введите, пожалуйста, целое число.");
            }
        }

        private void TheParityNumbPercent(int a)
        {
            Console.Write("Способ 1 (if-else): ");
            if (a % 2 == 0)
            {
                Console.WriteLine($"{a} - четное");
            }
            else
            {
                Console.WriteLine($"{a} - нечетное");
            }
        }

        private void TheParityNumbByQuestion(int a)
        {
            Console.Write("Способ 2 (?:): ");
            string result = (a % 2 == 0) ? $"{a} - чётное" : $"{a} - нечётное";
            Console.WriteLine(result);
        }
    }
}
