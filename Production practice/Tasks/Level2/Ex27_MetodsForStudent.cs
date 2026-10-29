using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level2
{
    internal class Ex27_MetodsForStudent : ITask
    {
        public string Title => "IComparable / IComparer<T> для `Student";
        public string Description => "Научить Student сортироваться.";
        public string[] Condition => new[]
        {
            "Класс Student: Name, AverageGrade",
            "Реализовать IComparable<Student> — сортировка по среднему баллу (по убыванию)",
            "Реализовать IComparer<Student> ByNameComparer — сортировка по имени",
            "Продемонстрировать обе сортировки на List<Student>"
        };

        public void Launch()
        {
            List<Student> students = new List<Student>
            {
                new Student("Никита", 3.4),
                new Student("Максим", 3.0),
                new Student("Александра", 4.6),
                new Student("Станислав", 4.1),
                new Student("Василий", 4.0),
                new Student("Кристина", 3.2),
                new Student("Тимур", 3.8),
                new Student("Роксана", 4.0)
            };
            Console.WriteLine("--- Исходный список студентов ---");
            PrintList(students);


            students.Sort(); // Первый способ IComparable
            Console.WriteLine("\n--- Сортировка 1: По среднему баллу (по убыванию) ---");
            Console.WriteLine("(Использован метод students.Sort() и IComparable)");
            PrintList(students);

            students.Sort(new ByNameComparer()); //Второй способ IComparer
            Console.WriteLine("\n--- Сортировка 2: По имени (в алфавитном порядке) ---");
            Console.WriteLine("(Использован students.Sort(new ByNameComparer()) и IComparer)");
            PrintList(students);
        }
        private void PrintList(List<Student> students)
        {
            foreach (var s in students)
            {
                Console.WriteLine(s);
            }
        }
        public class Student : IComparable<Student>
        {
            public string Name { get; set; }
            public double AverageScore{ get; set; }

            public Student(string name, double averageScore)
            {
                Name = name;
                AverageScore = averageScore;
            }
            public int CompareTo(Student other)
            {
                if (other == null) return 1;

                int result = other.AverageScore.CompareTo(this.AverageScore);

                if (result == 0)
                {
                    return string.Compare(this.Name, other.Name, StringComparison.Ordinal);
                }

                return result;
            }
            public override string ToString()
            {
                return $"Студент: {Name,-10} | Средний балл: {AverageScore:F1}";
            }
        }
        public class ByNameComparer : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                if (x == null && y == null) return 0;
                if (x == null) return -1;
                if (y == null) return 1;

                return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
            }
        }
    }
}
