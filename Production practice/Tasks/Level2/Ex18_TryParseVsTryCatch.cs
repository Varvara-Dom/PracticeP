using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level2
{
    internal class Ex18_TryParseVsTryCatch : ITask
    {
        public string Title => "TryParse vs try/catch";
        public string Description => "Сравнить два способа обработки некорректного ввода числа.";
        public string[] Condition => new[]
        {
            "Способ 1: int.TryParse — вернуть bool + значение через out",
            "Способ 2: int.Parse внутри try/catch — ловить FormatException",
            "Оба оформить отдельными методами",
            "Продемонстрировать на корректном и некорректном вводе"
        };

        public void Launch()
        {
            string[] inputs = { "123", "abc" };

            foreach (var input in inputs)
            {
                Console.WriteLine($"--- Ввод: \"{input}\" ---");

                if (TryParseMethod1(input, out int resultTryParse))
                    Console.WriteLine($"TryParse: успешно, результат = {resultTryParse}");
                else
                    Console.WriteLine($"TryParse: ошибка преобразования");

                try
                {
                    int resultTryCatch2 = TryCatchMethod2(input);
                    Console.WriteLine($"try/catch: успешно, результат = {resultTryCatch2}");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"try/catch: ошибка преобразования (пойман FormatException)");
                }
            }
        }

        public static bool TryParseMethod1(string input, out int result)
        {
            return int.TryParse(input, out result);
        }
        public static int TryCatchMethod2(string input)
        {
            return int.Parse(input);
        }
    }
}
