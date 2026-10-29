using Production_practice.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_practice.Tasks.Level2 
{
    internal class Ex31_IDisposableAndUsing : ITask
    {
        public string Title => "IDisposable + using";
        public string Description => "Реализовать IDisposable для класса, работающего с файлом.";
        public string[] Condition => new[]
        {
            "Класс FileWriter с полем StreamWriter",
            "Реализовать Dispose() (закрыть StreamWriter)",
            "Продемонстрировать использование через using",
            "Дополнительно: продемонстрировать using-декларацию (C# 8+, using var)"
        };

        public void Launch()
        {
            string filePath = "test_output.txt";
            if (File.Exists(filePath)) File.Delete(filePath);

            Console.WriteLine("--- Классический using блок ---");

            using (var writer = new FileWriter(filePath))
            {
                writer.Write("Привет!");
                writer.Write("Это тестовая запись в файл.");
                Console.WriteLine("Запись в файл выполнена внутри блока using...");
            }

            Console.WriteLine("Вышли из блока using. Файл должен быть закрыт.\n");

            Console.WriteLine("--- Проверка содержимого файла ---");
            try
            {
                string content = File.ReadAllText(filePath);
                Console.WriteLine("Файл успешно прочитан (доступен для других процессов):");
                Console.WriteLine(content);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"ОШИБКА: Файл заблокирован. {ex.Message}");
            }

            Console.WriteLine("\n--- Дополнительно: using-декларация (C# 8+) ---");
            /*
            using var writer2 = new FileWriter("test_output_2.txt");
            writer2.Write("Надпись через using var.");
            Console.WriteLine("Запись через using var выполнена (файл закроется в конце метода).");
            */
            Console.WriteLine("\n--- Проверка использования после Dispose ---");
            var closedWriter = new FileWriter("temp.txt");
            closedWriter.Dispose();

            try
            {
                closedWriter.Write("Попытка записи после Dispose...");
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine($"Ожидаемая ошибка: {ex.Message}");
            }
        }

        public class FileWriter : IDisposable
        {
            private StreamWriter _writer;
            private bool _disposed = false;
            public FileWriter(string filePath)
            {
                _writer = new StreamWriter(filePath, append: false);
            }
            public void Write(string text)
            {
                if (_disposed)
                    throw new ObjectDisposedException(nameof(FileWriter), "Невозможно писать в закрытый файл.");

                _writer.WriteLine(text);
            }
            public void Dispose()
            {
                Dispose(true);

                GC.SuppressFinalize(this);
            }
            protected virtual void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        _writer.Dispose();
                    }
                    disposing = true;
                }
            }
        }
    }
}
