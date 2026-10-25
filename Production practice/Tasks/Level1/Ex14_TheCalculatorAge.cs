using Production_practice.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_practice.Tasks.Level1 
{
    internal class Ex14_TheCalculatorAge : ITask
    {
        public string Title => "Возраст по дате рождения";
        public string Description => "по дате рождения вычислить точный возраст в годах, месяцах и днях.";
        public string[] Condition => new[]
        {
            "Ввод даты через `DateTime.TryParse` (или `TryParseExact`)",
            "Учесть, что день рождения в этом году мог ещё не наступить",
            "Вывести «X лет, Y месяцев, Z дней»",
            "Некорректная дата — сообщение об ошибке, не падать"
        };

        public void Launch()
        {
            Console.Write("Введите дату рождения (дд.мм.гггг): ");
            string input = Console.ReadLine();

            if (!DateTime.TryParseExact(input, "dd.MM.yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime birthdate))
            {
                Console.WriteLine("Ошибка: неверный формат даты. Используйте дд.мм.гггг (например, 25.12.1995).");
                return;
            }

            DateTime today = DateTime.Today;

            if (birthdate > today)
            {
                Console.WriteLine("Ошибка: дата рождения не может быть в будущем.");
                return;
            }

            int years = today.Year - birthdate.Year;

            if (today.Month < birthdate.Month || (today.Month == birthdate.Month && today.Day < birthdate.Day))
                years--;

            DateTime tempdate = birthdate.AddYears(years);
            int months = today.Month - tempdate.Month;

            if (today.Day < tempdate.Day) months--;

            if (months < 0)
            {
                months += 12;
                years--;
            }

            DateTime startOfLastMonth = tempdate.AddMonths(months);
            int days = (today - startOfLastMonth).Days;

            Console.WriteLine($"\nВозраст: {years} лет, {months} месяцев, {days} дней.");
        }
    }
}
