using Production_practice.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Production_practice.Tasks.Level3
{
    internal class Ex44_MiniProject : ITask
    {
        public string Title => "Минипроект «Todo List» (классы + JSON)";
        public string Description => "консольное приложение для списка задач с сохранением в JSON.";
        public string[] Condition => new[]
        {
            "Способ 1: через HashSet<int> — при добавлении проверять Contains",
            "Способ 2: через LINQ GroupBy(x => x).Where(g => g.Count() > 1)",
            "Оба способа оформить отдельными методами",
            "Продемонстрировать на списке с повторяющимися значениями"
        };

        public void Launch()
        {
            TaskService service = new TaskService();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\nTODO LIST MENU");
                Console.WriteLine("1.Добавить задачу");
                Console.WriteLine("2.Показать все задачи");
                Console.WriteLine("3.Отметить задачу выполненной");
                Console.WriteLine("4.Удалить задачу");
                Console.WriteLine("0.Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Введите название задачи: ");
                            string title = Console.ReadLine() ?? "";
                            service.AddTask(title);
                            Console.WriteLine("Задача успешно добавлена!");
                            break;

                        case "2":
                            var tasks = service.GetTasks();
                            if (tasks.Count == 0)
                            {
                                Console.WriteLine("Список задач пуст.");
                            }
                            else
                            {
                                Console.WriteLine("\nВАШИ ЗАДАЧИ");
                                foreach (var task in tasks)
                                {
                                    string status = task.IsDone ? "[x]" : "[ ]";
                                    Console.WriteLine($"{status} ID: {task.Id} | {task.Title}");
                                }
                            }
                            break;

                        case "3":
                            Console.Write("Введите ID задачи для выполнения: ");
                            if (int.TryParse(Console.ReadLine(), out int doneId))
                            {
                                if (service.MarkAsDone(doneId))
                                    Console.WriteLine("Задача отмечена как выполненная!");
                                else
                                    Console.WriteLine($"Задача с ID {doneId} не найдена.");
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: ID должен быть числом.");
                            }
                            break;

                        case "4":
                            Console.Write("Введите ID задачи для удаления: ");
                            if (int.TryParse(Console.ReadLine(), out int deleteId))
                            {
                                if (service.DeleteTask(deleteId))
                                    Console.WriteLine("Задача удалена!");
                                else
                                    Console.WriteLine($"Задача с ID {deleteId} не найдена.");
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: ID должен быть числом.");
                            }
                            break;

                        case "0":
                            isRunning = false;
                            Console.WriteLine("Выход из программы. Данные сохранены.");
                            break;

                        default:
                            Console.WriteLine("Неверный выбор. Введите число от 0 до 4.");
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка ввода: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
                }
            }
        }
        public class TaskItem
        {
            public int Id { get; set; }
            public string Title { get; set; } = string.Empty;
            public bool IsDone { get; set; }
        }
        public class TaskRepository
        {
            private readonly string _filePath = "tasks.json";
            private List<TaskItem> _tasks = new List<TaskItem>();
            private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { WriteIndented = true };

            public TaskRepository()
            {
                Load();
            }

            public List<TaskItem> GetAll() => _tasks;

            public void Add(TaskItem task)
            {
                _tasks.Add(task);
                Save();
            }

            public void Update()
            {
                Save();
            }

            public bool Delete(int id)
            {
                var task = _tasks.FirstOrDefault(t => t.Id == id);
                if (task != null)
                {
                    _tasks.Remove(task);
                    Save();
                    return true;
                }
                return false;
            }

            private void Save()
            {
                try
                {
                    string json = JsonSerializer.Serialize(_tasks, _jsonOptions);
                    File.WriteAllText(_filePath, json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Ошибка сохранения]: {ex.Message}");
                }
            }

            private void Load()
            {
                if (!File.Exists(_filePath))
                {
                    _tasks = new List<TaskItem>();
                    return;
                }

                try
                {
                    string json = File.ReadAllText(_filePath);
                    _tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
                }
                catch (JsonException)
                {
                    Console.WriteLine("[Ошибка]: Файл tasks.json поврежден. Создан новый пустой список.");
                    _tasks = new List<TaskItem>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Ошибка загрузки]: {ex.Message}");
                    _tasks = new List<TaskItem>();
                }
            }
        }
        public class TaskService
        {
            private readonly TaskRepository _repository = new TaskRepository();

            public void AddTask(string title)
            {
                if (string.IsNullOrWhiteSpace(title))
                    throw new ArgumentException("Название задачи не может быть пустым.");

                int nextId = _repository.GetAll().Any() ? _repository.GetAll().Max(t => t.Id) + 1 : 1;
                var newTask = new TaskItem { Id = nextId, Title = title.Trim(), IsDone = false };
                _repository.Add(newTask);
            }

            public List<TaskItem> GetTasks() => _repository.GetAll();

            public bool MarkAsDone(int id)
            {
                var task = _repository.GetAll().FirstOrDefault(t => t.Id == id);
                if (task == null) return false;

                task.IsDone = true;
                _repository.Update();
                return true;
            }

            public bool DeleteTask(int id) => _repository.Delete(id);
        }
    }
}