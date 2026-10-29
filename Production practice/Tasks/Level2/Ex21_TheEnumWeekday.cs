using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Menu
{
    internal class Ex21_TheEnumWeekday : ITask
    {
        public string Title => "Enum дни недели";
        public string Description => "Описать дни недели через `enum` и определить тип дня.";
        public string[] Condition => new[]
        {
            "Enum DayOfWeek { Monday, ..., Sunday }",
            "Метод IsWeekend(DayOfWeek day) - true для субботы и воскресенья",
            "Метод GetRussianName(DayOfWeek day) - возвращает название на русском",
            "Продемонстрировать на всех 7 днях"
        };

        public enum DayOfWeek
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
        public static bool IsWeekend(DayOfWeek day)
        {
            return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
        }
        public static string GetRuName(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday: return "Понедельник";
                case DayOfWeek.Tuesday: return "Вторник";
                case DayOfWeek.Wednesday: return "Среда";
                case DayOfWeek.Thursday: return "Четверг";
                case DayOfWeek.Friday: return "Пятница";
                case DayOfWeek.Saturday: return "Суббота";
                case DayOfWeek.Sunday: return "Воскресенье";
                default: return "Неизвестный день";
            }
        }
       public void Launch()
        {
            Console.WriteLine("--- Тестирование enum дней недели ---\n");

            var allDays = (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek));

            foreach (var day in allDays)
            {
                string RusName = GetRuName(day);
                bool theWeekend = IsWeekend(day);

                Console.WriteLine($"День: {day,-9} | Название: {RusName,-11} | Выходной: {theWeekend}");
            }
        }
    }
}
