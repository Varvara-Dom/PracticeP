using Production_practice.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_practice.Tasks.Level3
{
    internal class Ex40_AAPlusExceptionHandling : ITask
    {
        public string Title => "async/await + обработка исключений";
        public string Description => "Асинхронный метод с эмуляцией «скачивания».";
        public string[] Condition => new[]
        {
            "async Task<string> DownloadAsync(string url) — внутри Task.Delay(1000)",
            "Имитировать ошибку: если url пустой — бросить ArgumentException",
            "В Main вызвать через await внутри try/catch",
            "Продемонстрировать успешный и ошибочный вызов"
        };

        public void Launch()
        {
            RunAsync().GetAwaiter().GetResult();
        }
        private async Task RunAsync()
        {
            Console.WriteLine("Показ 1 - Успешный вызов");
            try
            {
                string result = await DownloadAsync("https://example.com/file.zip");
                Console.WriteLine($"Успешно: {result}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка аргумента: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
            }

            Console.WriteLine("\nПоказ 2 - Ошибочный вызов");
            try
            {
                string result = await DownloadAsync("");
                Console.WriteLine($"Успешно: {result}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Перехвачено исключение: {ex.Message}");
                Console.WriteLine("Приложение продолжает работу, не падает!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
            }

            Console.WriteLine("\nКонец программы");
        }
        public async Task<string> DownloadAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("URL не может быть пустым или null.", nameof(url));
            }

            Console.WriteLine($"[DownloadAsync] Начинаем скачивание с {url}..");

            await Task.Delay(1000);

            Console.WriteLine($"[DownloadAsync] Скачивание завершено для {url}.");

            return "1024 байта (эмуляция)";
        }
    }
}
