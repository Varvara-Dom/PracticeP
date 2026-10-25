using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level1
{
    public class Ex1_HelloWorld : ITask
    {
        public string Title => "Hello, Word + текущая дата";
        public string Description => "Вывести приветствие и текущую дату.";
        public string[] Condition => new[]
        {
            "Использовать Console.WriteLine",
            "Дату получить через `DateTime.Now`, отформатировать как `dd.MM.yyyy",
            "Вывести две строки: приветствие и дату"
        };

        public void Launch()
        {
            Console.WriteLine("Hello,World!");
            Console.WriteLine($"Сегодня: {DateTime.Now:dd.MM.yyyy}");
        }
    }
}
