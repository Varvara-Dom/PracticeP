
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Tasks.Level1;
using Production_practice.Common;

namespace Production_practice.Menu
{
    internal class MenuRunner
    {
        private readonly List<ITask> _level1Tasks;

        public MenuRunner()
        {
            _level1Tasks = new List<ITask>
    {
        new Ex1_HelloWorld(),
        new Ex2_PrimitivesType(),
        new Ex3_TheCalculator(),
        new Ex4_TheParity(),
        new Ex5_TheMultiplicationTable(),
        new Ex6_TheSumOfDigits(),
        new Ex7_TheStringReverse(),
        new Ex8_FizzBuzz(),
        new Ex9_TheArray(),
        new Ex10_TheSorting(),
        new Ex11_TheMatrixDiagonal(),
        new Ex12_ThePalindrome(),
        new Ex13_TheCounterWord(),
        new Ex14_TheCalculatorAge()
    };
        }

        public void Start()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Практикум по C# ===");
                Console.WriteLine("1. Уровень 1 — Базовый (задания 1–15)");
                Console.WriteLine("2. Уровень 2 — Средний (задания 16–35)");
                Console.WriteLine("3. Уровень 3 — Продвинутый (задания 36–50)");
                Console.WriteLine("0. Выход");
                Console.Write("\nВыберите уровень: ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1": RunLevel1(); break;
                    case "2": Console.WriteLine("В разработке"); ConsoleHelper.Pause(); break;
                    case "3": Console.WriteLine("В разработке"); ConsoleHelper.Pause(); break;
                    case "0": running = false; break;
                    default:
                        Console.WriteLine("Некорректный ввод.");
                        ConsoleHelper.Pause();
                        break;
                }
            }
        }

        private void RunLevel1()
        {
            bool inLevel = true;
            while (inLevel)
            {
                Console.Clear();
                Console.WriteLine("--- Уровень 1: Базовый ---");

                for (int i = 0; i < _level1Tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_level1Tasks[i].Title}");
                }
                Console.WriteLine("0. Назад");
                Console.Write("\nВыберите задание: ");

                string input = Console.ReadLine();
                if (input == "0") { inLevel = false; continue; }

                if (int.TryParse(input, out int taskNum) && taskNum > 0 && taskNum <= _level1Tasks.Count)
                {
                    var task = _level1Tasks[taskNum - 1];

                    ConsoleHelper.PrintTaskHeader(task.Title, task.Description, task.Condition);

                    task.Launch();

                    ConsoleHelper.Pause();
                }
                else
                {
                    Console.WriteLine("Такого задания нет.");
                    ConsoleHelper.Pause();
                }
            }
        }
    }
}
