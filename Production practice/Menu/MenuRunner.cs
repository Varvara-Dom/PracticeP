
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Tasks.Level1;
using Production_practice.Tasks.Level2;
using Production_practice.Common;

namespace Production_practice.Menu
{
    internal class MenuRunner
    {
        private readonly List<ITask> _level1Tasks;
        private readonly List<ITask> _level2Tasks;

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
            _level2Tasks = new List<ITask>
        {
        new Ex16_TheSolutionMethod(),
        new Ex17_TheStringBuilderVsConcatenation(),
        new Ex18_TryParseVsTryCatch(),
        new Ex19_OwnStackOrQueueToArray(),
        new Ex20_TheGeneralizations(),
        new Ex21_TheEnumWeekday(),
        new Ex22_ParamsMethodPlusOverload(),
        new Ex23_TheNullableTypes(),
        new Ex24_OOPTheAnimals(),
        new Ex25_TheInterfacePlusSorting(),
        new Ex26_PatternStrategy(),
        new Ex27_MetodsForStudent(),
        new Ex28_MethodsForPoint(),
        new Ex29_PatternFactory(),
        new Ex30_BankAccountAndOwnException(),
        new Ex31_IDisposableAndUsing(),
        new Ex32_TheValidationTemperature(),
        new Ex33_LINQTheStaff(),
        new Ex34_LINQFirstLetter()
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
                    case "2": RunLevel2(); break;
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

        private void RunLevel2()
        {
            bool inLevel2 = true;
            while (inLevel2)
            {
                Console.Clear();
                Console.WriteLine("--- Уровень 2 — Средний ---");

                for (int i = 0; i < _level2Tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_level2Tasks[i].Title}");
                }
                Console.WriteLine("0. Назад");
                Console.Write("\nВыберите задание: ");

                string input1 = Console.ReadLine();
                if (input1 == "0") { inLevel2 = false; continue; }

                if (int.TryParse(input1, out int taskNum1) && taskNum1 > 0 && taskNum1 <= _level2Tasks.Count)
                {
                    var task2 = _level2Tasks[taskNum1 - 1];

                    ConsoleHelper.PrintTaskHeader(task2.Title, task2.Description, task2.Condition);

                    task2.Launch();

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
