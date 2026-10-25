using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_practice.Common
{
    internal class ConsoleHelper
    {
        public static void PrintTaskHeader(string title, string description, string[] condition)
        {
            Console.Clear();
            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"Задание: {title}");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Описание:");
            Console.WriteLine($"  {description}");
            Console.WriteLine("\nТребования:");
            foreach (var req in condition)
            {
                Console.WriteLine($"  - {req}");
            }
            Console.WriteLine(new string('=', 50) + "\n");
        }

        public static void Pause()
        {
            Console.WriteLine("\nНажмите Enter для возврата в меню");
            Console.ReadLine();
        }
    }
}
