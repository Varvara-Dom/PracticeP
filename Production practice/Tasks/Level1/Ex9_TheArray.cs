using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level1
{
    internal class Ex9_TheArray : ITask
    {
        public string Title => "Массивы: min/max/sum/avg";
        public string Description => "для массива чисел найти минимум, максимум, сумму и среднее.";
        public string[] Condition => new[]
        {
            "Заполнить массив (например, случайными числами 1–100, размер 20)",
            "Реализовать без LINQ (Min/Max/Sum/Average запрещены)",
            "Оформить 4 отдельных метода",
            "Пустой массив — обработать (вернуть ошибку или 0, но не падать)"
        };

        public void Launch()
        {
            int[] numbers = new int[20];
            var random = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 101);
            }

            Console.WriteLine("Массив: " + string.Join(", ", numbers));
            Console.WriteLine($"Минимум: {ReceiveMin(numbers)}");
            Console.WriteLine($"Максимум: {ReceiveMax(numbers)}");
            Console.WriteLine($"Сумма: {ReceiveSum(numbers)}");
            Console.WriteLine($"Среднее: {ReceiveAvg(numbers):F3}");
        }

        private int ReceiveMin(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] < min) min = arr[i];
            return min;
        }

        private int ReceiveMax(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
                if (arr[i] > max) max = arr[i];
            return max;
        }

        private long ReceiveSum(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;
            long sum = 0;
            for (int i = 0; i < arr.Length; i++) sum += arr[i];
            return sum;
        }

        private double ReceiveAvg(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;
            return (double)ReceiveSum(arr) / arr.Length;
        }
    }
}
