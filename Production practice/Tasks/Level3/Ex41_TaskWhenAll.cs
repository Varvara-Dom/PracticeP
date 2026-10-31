using Production_practice.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_practice.Tasks.Level3
{
    internal class Ex41_TaskWhenAll : ITask
    {
        public string Title => "Task.WhenAll — параллельно 10 задач";
        public string Description => "Запустить 10 задач параллельно и сравнить с последовательным выполнением.";
        public string[] Condition => new[]
        {
            "Метод Task<int> WorkAsync(int id) — Task.Delay(500), возвращает id",
            "Последовательный запуск 10 задач в цикле с await",
            "Параллельный запуск через Task.WhenAll",
            "Замерить время обоих вариантов через Stopwatch",
            "Вывести оба времени и объяснить разницу"
        };
        private const int TaskCount = 10;
        private const int DelayMs = 500;
        public void Launch()
        {
            RunAsync().GetAwaiter().GetResult();
        }
        private async Task RunAsync()
        {
            Console.WriteLine($"Сравнение последовательного и параллельного выполнения {TaskCount} задач");
            Console.WriteLine($"Каждая задача занимает {DelayMs} мс.");
            Console.WriteLine();

            Stopwatch sw = Stopwatch.StartNew();
            List<int> sequentialResults = new List<int>();

            for (int i = 0; i < TaskCount; i++)
            {
                int result = await WorkAsync(i);
                sequentialResults.Add(result);
            }

            sw.Stop();
            TimeSpan sequentialTime = sw.Elapsed;
            Console.WriteLine($"Последовательный запуск: {sequentialTime.TotalMilliseconds,7:F1} мс");
            Console.WriteLine($"Результаты: {string.Join(", ", sequentialResults)}");
            Console.WriteLine();

            sw.Restart();

            IEnumerable<Task<int>> tasks = Enumerable.Range(0, TaskCount).Select(i => WorkAsync(i));

            int[] parallelResults = await Task.WhenAll(tasks);

            sw.Stop();
            TimeSpan parallelTime = sw.Elapsed;
            Console.WriteLine($"Параллельный запуск (WhenAll): {parallelTime.TotalMilliseconds,7:F1} мс");
            Console.WriteLine($"Результаты: {string.Join(", ", parallelResults)}");
            Console.WriteLine();

            bool resultsMatch = sequentialResults.SequenceEqual(parallelResults);
            double speedup = sequentialTime.TotalMilliseconds / parallelTime.TotalMilliseconds;

            Console.WriteLine("Сравнение");
            Console.WriteLine($"Разница во времени: {sequentialTime.TotalMilliseconds - parallelTime.TotalMilliseconds:F1} мс");
            Console.WriteLine($"Параллельный вариант быстрее в {speedup:F1} раз(а)");
            Console.WriteLine($"Результаты совпадают: {resultsMatch}");
            Console.WriteLine();

        }
        private async Task<int> WorkAsync(int id)
        {
            await Task.Delay(DelayMs);
            return id;
        }
    }
}
