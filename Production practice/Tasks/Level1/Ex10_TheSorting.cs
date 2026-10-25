using Production_practice.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_practice.Tasks.Level1
{
    internal class Ex10_TheSorting : ITask
    {
        public string Title => "Сортировка пузырьком + вставками";
        public string Description => "отсортировать массив двумя алгоритмами.";
        public string[] Condition => new[]
        {
            "Реализовать BubbleSort и InsertionSort отдельными методами",
            "Оба — без LINQ и Array.Sort",
            "Замерить время каждого через `Stopwatch` на массиве 10 000 элементов",
            "Вывести оба времени"
        };

        public void Launch()
        {
            const int size = 10000;
            var random = new Random();

            int[] ArrayMain = new int[size];
            for (int i = 0; i < size; i++)
            {
                ArrayMain[i] = random.Next(1, 1000);
            }

            int[] ArrayForBubble = (int[])ArrayMain.Clone();
            int[] ArrayForInsertion = (int[])ArrayMain.Clone();

            var swBubble = Stopwatch.StartNew();
            BubbleSort(ArrayForBubble);
            swBubble.Stop();

            var swInsertion = Stopwatch.StartNew();
            InsertionSort(ArrayForInsertion);
            swInsertion.Stop();

            Console.WriteLine($"Размер массива: {size}");
            Console.WriteLine($"Время пузырька: {swBubble.ElapsedMilliseconds} мс.");
            Console.WriteLine($"Время вставками: {swInsertion.ElapsedMilliseconds} мс.");

            bool equal = true;
            for (int i = 0; i < size; i++)
            {
                if (ArrayForBubble[i] != ArrayForInsertion[i])
                {
                    equal = false;
                    break;
                }
            }

            Console.WriteLine(equal
                ? "\nПроверка проведена: оба массива отсортированы идентично."
                : "\nОшибка: массивы отличаются!");
        }

        private void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }
            }
        }

        private void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }
    }
}
