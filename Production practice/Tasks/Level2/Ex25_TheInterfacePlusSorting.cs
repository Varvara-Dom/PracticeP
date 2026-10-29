using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Menu
{
    internal class Ex25_TheInterfacePlusSorting : ITask
    {
        public string Title => "Интерфейс IShape + сортировка фигур";
        public string Description => "Реализовать интерфейс фигур и отсортировать их.";
        public string[] Condition => new[]
        {
            "IShape с методами Area() и Perimeter()",
            "Классы Circle, Rectangle, Triangle — реализуют IShape",
            "Создать List<IShape> из 5+ фигур",
            "Отсортировать по площади (через List.Sort с лямбдой или OrderBy)",
            "Вывести фигуры с площадями до и после сортировки"
        };

        public void Launch()
        {
            List<IShape> Shapes = new List<IShape>
            {
                new Circle(5),
                new Rectangle(2, 3),
                new Triangle(3, 4, 5),
                new Circle(1.5),
                new Rectangle(10, 0.5),
                new Triangle(5, 5, 6),
                new Circle(10),
                new Rectangle(11, 3),
                new Triangle(5, 5, 5)
            };
            Console.WriteLine("--- Фигуры до сортировки ---");
            PrintShapes(Shapes);
            Shapes.Sort((s1, s2) => s1.Area().CompareTo(s2.Area()));

            Console.WriteLine("\n--- Фигуры после сортировки (по возрастанию площади) ---");
            PrintShapes(Shapes);
        }
        private void PrintShapes(List<IShape> Shapes)
        {
            foreach (var Shape in Shapes)
            {
                Console.WriteLine($"{Shape,-25} | Площадь: {Shape.Area(),6:F2} | Периметр: {Shape.Perimeter(),6:F2}");
            }
        }
        public interface IShape
        {
            double Area();
            double Perimeter();
        }
        public class Circle : IShape
        {
            public double Radius { get; set; }
            public Circle(double radius)
            {
                Radius = radius;
            }
            public double Area() => Math.PI * Radius * Radius;
            public double Perimeter() => 2 * Math.PI * Radius;
            public override string ToString() => $"Круг (R={Radius})";
        }
        public class Rectangle : IShape
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }
            public double Area() => Width * Height;
            public double Perimeter() => 2 * (Width + Height);
            public override string ToString() => $"Прямоугольник ({Width}x{Height})";
        }
        public class Triangle : IShape
        {
            public double A { get; set; }
            public double B { get; set; }
            public double C { get; set; }

            public Triangle(double a, double b, double c)
            {
                A = a;
                B = b;
                C = c;
            }
            public double Area()
            {
                double p = Perimeter() / 2;
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }
            public double Perimeter() => A + B + C;

            public override string ToString() => $"Треугольник ({A},{B},{C})";
        }
    }
}
