using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Menu
{
    internal class Ex20_TheGeneralizations : ITask
    {
        public string Title => "Обобщения: Swap<T>, Max<T> с IComparable<T>";
        public string Description => "Написать обобщённые методы.";
        public string[] Condition => new[]
        {
            "Swap<T>(ref T a, ref T b) — меняет значения местами",
            "Max<T>(T a, T b) where T : IComparable<T>` — возвращает большее",
            "Продемонстрировать на int, string, double",
            "Swap — без ограничений, Max — с ограничением"
        };

        public void Launch()
        {
            //тест int
            Console.WriteLine("--- Тестирование на типе int ---");
            int intA = 19;
            int intB = 32;

            Console.WriteLine($"До смены: a = {intA}, b = {intB}");
            Swap(ref intA, ref intB);
            Console.WriteLine($"После смены: a = {intA}, b = {intB}");

            Console.WriteLine($"Максимум из ({intA}, {intB}): {Max(intA, intB)}");

            Console.WriteLine("--- Тестирование на типе string ---");
            string strA = "Dayz";
            string strB = "Hellraiser";

            Console.WriteLine($"До смены: a = {strA}, b = {strB}");
            Swap(ref strA, ref strB);
            Console.WriteLine($"После смены: a = {strA}, b = {strB}");

            Console.WriteLine($"Максимум из ({strA}, {strB}): {Max(strA, strB)}");

            Console.WriteLine("--- Тестирование на типе double ---");
            double dubA = 6.29;
            double dubB = 4.26;

            Console.WriteLine($"До смены: a = {dubA}, b = {dubB}");
            Swap(ref dubA, ref dubB);
            Console.WriteLine($"После смены: a = {dubA}, b = {dubB}");

            Console.WriteLine($"Максимум из ({dubA}, {dubB}): {Max(dubA, dubB)}");
        }
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        public static T Max<T>(T a, T b) where T : IComparable<T>
        {
            if (a.CompareTo(b) > 0)
            {
                return a;
            }
            return b;
        }
    }
}
