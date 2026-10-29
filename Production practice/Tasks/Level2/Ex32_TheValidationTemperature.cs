using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level2
{
    internal class Ex32_TheValidationTemperature : ITask
    {
        public string Title => "Свойства с валидацией (Temperature)";
        public string Description => "Класс Temperature с валидацией в set.";
        public string[] Condition => new[]
        {
            "Свойство Celsius с проверкой в set: не ниже −273.15",
            "При некорректном значении — бросать ArgumentOutOfRangeException",
            "Вычисляемое свойство Fahrenheit (только get)",
            "Продемонстрировать корректное и некорректное присваивание"
        };

        public void Launch()
        {
            var temp = new Temperature();

            Console.WriteLine("--- Корректное присваивание ---");
            temp.Celsius = 25;
            Console.WriteLine($"Установлено: {temp.Celsius} °C");
            Console.WriteLine($"Пересчёт в Фаренгейты: {temp.Fahrenheit:F2} °F\n");

            Console.WriteLine("--- Изменение значения и пересчет ---");
            temp.Celsius = 0;
            Console.WriteLine($"Установлено: {temp.Celsius} °C");
            Console.WriteLine($"Пересчёт в Фаренгейты: {temp.Fahrenheit:F2} °F\n");

            Console.WriteLine("--- Граничное значение (Абсолютный ноль) ---");
            temp.Celsius = -273.15;
            Console.WriteLine($"Установлено: {temp.Celsius} °C");
            Console.WriteLine($"Пересчёт в Фаренгейты: {temp.Fahrenheit:F2} °F\n");

            Console.WriteLine("--- Некорректное присваивание (ниже абсолютного нуля) ---");
            try
            {
                Console.WriteLine("Попытка установить -300 °C...");
                temp.Celsius = -300;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"[Ошибка] {ex.ParamName}: {ex.Message}");
                Console.WriteLine($"Текущая температура осталась прежней: {temp.Celsius} °C");
            }
        }
        public class Temperature
        {
            private double _celsius;

            public double Celsius
            {
                get { return _celsius; }
                set
                {
                    if (value < -273.15)
                    {
                        throw new ArgumentOutOfRangeException(
                            nameof(value),
                            "Температура не может быть ниже абсолютного нуля (-273.15 °C).");
                    }
                    _celsius = value;
                }
            }
            public double Fahrenheit
            {
                get
                {
                    return (_celsius * 9 / 5) + 32;
                }
            }
        }
    }
}
