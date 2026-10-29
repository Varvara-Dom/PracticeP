using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level2
{
    internal class Ex28_MethodsForPoint : ITask
    {
        public string Title => "Equals / GetHashCode для Point";
        public string Description => "Переопределить Equals и GetHashCode для класса Point(x, y).";
        public string[] Condition => new[]
        {
            "Переопределить Equals(object) и GetHashCode()",
            "Реализовать IEquatable<Point>",
            "Проверить: две точки с одинаковыми координатами равны",
            "Проверить в HashSet<Point>: добавление дубликата не увеличивает Count"
        };

        public void Launch()
        {
            Console.WriteLine("--- Проверка c методом Equals ---");
            Point p1 = new Point(5, 10);
            Point p2 = new Point(5, 10);
            Point p3 = new Point(3, 7);

            Console.WriteLine($"p1: {p1}");
            Console.WriteLine($"p2: {p2}");
            Console.WriteLine($"p3: {p3}\n");

            Console.WriteLine($"p1.Equals(p2) (одинаковые координаты): {p1.Equals(p2)}");

            Console.WriteLine($"p1.Equals((object)p2) : {p1.Equals((object)p2)}");
            Console.WriteLine($"p1.Equals(p3) (разные координаты) : {p1.Equals(p3)}\n");

            Console.WriteLine("--- Проверка в HashSet<Point> ---");
            HashSet<Point> points = new HashSet<Point>();

            points.Add(p1);
            Console.WriteLine($"Добавили p1 (5,10). Текущий Count: {points.Count}");

            points.Add(p2);
            Console.WriteLine($"Добавили дубликат p2 (5,10). Текущий Count: {points.Count}");

            points.Add(p3);
            Console.WriteLine($"Добавили p3 (3,7). Текущий Count: {points.Count}");

            Console.WriteLine("\nСодержимое HashSet:");
            foreach (var point in points)
            {
                Console.WriteLine(point);
            }
        }
        public class Point : IEquatable<Point>
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
            public bool Equals(Point other)
            {
                if (other == null) return false;

                if (ReferenceEquals(this, other)) return true;

                return X == other.X && Y == other.Y;
            }
            public override bool Equals(object obj)
            {
                return Equals(obj as Point);
            }
            public override int GetHashCode()
            {
                unchecked
                {
                    int hash = 17;
                    hash = hash * 23 + X.GetHashCode();
                    hash = hash * 23 + Y.GetHashCode();
                    return hash;
                }
            }
            public static bool operator ==(Point p1, Point p2)
            {
                if (ReferenceEquals(p1, null)) return ReferenceEquals(p2, null);
                return p1.Equals(p2);
            }
            public static bool operator !=(Point p1, Point p2)
            {
                return !(p1 == p2);
            }
            public override string ToString()
            {
                return $"Point({X}, {Y})";
            }
        }
    }
}
