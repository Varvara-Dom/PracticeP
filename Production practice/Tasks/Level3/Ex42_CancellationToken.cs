using Production_practice.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Production_practice.Tasks.Level3
{
    internal class Ex42_CancellationToken : ITask
    {
        public string Title => "CancellationToken — отмена через 2 сек";
        public string Description => "Реализовать долгую операцию с поддержкой отмены.";
        public string[] Condition => new[]
        {
            "async Task LongOperationAsync(CancellationToken token) — цикл с Task.Delay(500, token) 10 раз",
            "В Main создать CancellationTokenSource, запустить операцию, отменить через 2 секунды",
            "Обработать OperationCanceledException",
            "Вывести «операция отменена»"
        };

        public void Launch()
        {
            RunAsync().GetAwaiter().GetResult();
        }
        private async Task RunAsync()
        {
            Console.WriteLine("Демонстрация отмены задачи (CancellationToken)");
            Console.WriteLine("Запуск долгой операции..");
            Console.WriteLine();

            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                Task operationTask = LongOperationAsync(cts.Token);

                await Task.Delay(2000);

                Console.WriteLine("\n Время вышло. Вызываем cts.Cancel() \n");
                cts.Cancel();

                try
                {
                    await operationTask;
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Перехвачено OperationCanceledException.");
                    Console.WriteLine("Операция отменена.");
                }
            }

            Console.WriteLine("\nКонец программы");
        }
        private async Task LongOperationAsync(CancellationToken token)
        {
            for (int i = 1; i <= 10; i++)
            {
                await Task.Delay(500, token);

                Console.WriteLine($"Шаг {i}/10 выполнен.");
            }

            Console.WriteLine("Операция полностью завершена (дошла до конца).");
        }
    }
}
