using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level1
{
    internal class Ex7_TheStringReverse : ITask
    {
        public string Title => "Ревёрс строки без LINQ";
        public string Description => "перевернуть введённую строку";
        public string[] Condition => new[]
        {
            "Не использовать Array.Reverse и LINQ",
            "Реализовать через цикл for от конца к началу (или через char[] и swap)",
            "Пустая строка и строка из одного символа — обрабатываются корректно"
        };
        public void Launch()
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine() ?? string.Empty;

            char[] mas = input.ToCharArray();
            int left = 0;
            int right = mas.Length - 1;

            while (left < right)
            {
                char temp = mas[left];
                mas[left] = mas[right];
                mas[right] = temp;

                left++;
                right--;
            }
            string result = new string(mas);

            Console.WriteLine($"Ревёрс: \"{result}\"");
        }
    }
}
