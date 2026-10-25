using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level1
{
    internal class Ex5_TheMultiplicationTable : ITask
    {
        public string Title => "Таблица умножения 10×10";
        public string Description => "Вывести таблицу умножения 10×10.";
        public string[] Condition => new[]
        {
            "Использовать вложенные циклы for",
            "Выровнять столбцы",
            "Заголовки строк/столбцов — не обязательны, но приветствуются"
        };
        public void Launch()
        {
            const int size = 10;
            int width = 4;
            for (int i = 0; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    Console.Write("{0," + width + "}", i == 0 ? j : i * j);
                }
                Console.WriteLine();
            }
        }
    }
}
