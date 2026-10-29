using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level2
{
    internal class Ex33_LINQTheStaff : ITask
    {
        public string Title => "LINQ: сотрудники (top-3, avg по отделу, фильтр)";
        public string Description => "LINQ-запросы по списку сотрудников.";
        public string[] Condition => new[]
        {
            "Класс Employee: Name, Age, Salary, Department",
            "Список из 10+ сотрудников",
            "Запросы через LINQ: топ-3 по зарплате (убывание); средняя зарплата по каждому отделу (GroupBy + Average), сотрудники старше 30 (Where)",
            "Вывести результаты"
        };

        public void Launch()
        {
            List<Staff> staff = new List<Staff>
            {
                new Staff("Елизавета", 20, 70000m, "Design"),
                new Staff("Варвара", 19, 120000m, "Design"),
                new Staff("Альберт", 32, 45000m, "HR"),
                new Staff("Мирра", 25, 60000m, "Marketing"),
                new Staff("Роза", 21, 150000m, "Front"),
                new Staff("Роман", 35, 110000m, "Front"),
                new Staff("Андрей", 22, 45000m, "Back"),
                new Staff("Владислав", 31, 85000m, "Back"),
                new Staff("Александр", 23, 70000m, "Back"),
                new Staff("Семён", 26, 130000m, "Sales"),
                new Staff("Анна", 33, 100000m, "Test"),
                new Staff("Дмитрий", 27, 55000m, "Test")
            };
            Console.WriteLine("--- Топ-3 сотрудника по зарплате ---");
            var top3Salaries = staff
                .OrderByDescending(e => e.Salary)
                .Take(3);
            foreach (var emp in top3Salaries)
            {
                Console.WriteLine($"{emp.Name,-10} | Зарплата: {emp.Salary:C} | Отдел: {emp.Department}");
            }
            Console.WriteLine();
            Console.WriteLine("--- Средняя зарплата по отделам ---");
            var avgByDept = staff
                .GroupBy(e => e.Department)
                .Select(group => new
                {
                    Department = group.Key,
                    AverageSalary = group.Average(e => e.Salary),
                    EmployeeCount = group.Count()
                })
                .OrderByDescending(x => x.AverageSalary);

            foreach (var dept in avgByDept)
            {
                Console.WriteLine($"{dept.Department,-12} | Средняя Зарплата: {dept.AverageSalary:C} | Сотрудников: {dept.EmployeeCount}");
            }
            Console.WriteLine();

            Console.WriteLine("--- Сотрудники старше 30 лет ---");
            var olderThan30 = staff
                .Where(e => e.Age > 30)
                .OrderBy(e => e.Age);
            foreach (var emp in olderThan30)
            {
                Console.WriteLine($"{emp.Name,-10} | Возраст: {emp.Age} | Зарплата: {emp.Salary:C}");
            }
        }
        public class Staff
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public decimal Salary { get; set; }
            public string Department { get; set; }
            public Staff(string name, int age, decimal salary, string department)
            {
                Name = name;
                Age = age;
                Salary = salary;
                Department = department;
            }
        }
    }
}
