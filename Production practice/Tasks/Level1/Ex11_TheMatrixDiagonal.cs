using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level1
{
    internal class Ex11_TheMatrixDiagonal : ITask
    {
        public string Title => "Диагональ матрицы N×N";
        public string Description => "найти сумму элементов главной диагонали матрицы N×N";
        public string[] Condition => new[]
        {
            "Размер N вводится пользователем (минимум 2)",
            "Матрица заполняется случайными числами",
            "Сумма считается без LINQ, в одном цикле for",
            "Вывести саму матрицу и сумму"
        };

        public void Launch()
        {
            int v;
            while (true)
            {
                Console.Write("Введите размер матрицы N (минимум 2): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out v) && v >= 2)
                {
                    break;
                }
                Console.WriteLine("Некорректный ввод! Введите целое число >= 2.");
            }

            int[,] matrix = new int[v, v];
            var rnd = new Random();
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    matrix[i, j] = rnd.Next(1, 100);
                }
            }

            Console.WriteLine($"\nМатрица {v}x{v}:");
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine();
            }

            long sum = 0;
            for (int i = 0; i < v; i++)
            {
                sum += matrix[i, i];
            }

            Console.WriteLine($"\nСумма элементов главной диагонали: {sum}");
        }
    }
}
