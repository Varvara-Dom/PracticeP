using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level2
{
    internal class Ex19_OwnStackOrQueueToArray : ITask
    {
        public string Title => "Свой стек/очередь на массиве";
        public string Description => "Реализовать MyStack<T> и MyQueue<T> на массиве.";
        public string[] Condition => new[]
        {
            "Стек: Push, Pop, Peek, Count, IsEmpty",
            "Очередь: Enqueue, Dequeue, Peek, Count, IsEmpty",
            "При переполнении — расширять внутренний массив (удвоение)",
            "Pop/Dequeue на пустой коллекции — бросать InvalidOperationException"
        };

        public void Launch()
        {
            Console.WriteLine("--- Тестирование MyStack<T> ---");
            var stack = new MyStack<int>(2);

            Console.WriteLine($"Сначала пуст: {stack.IsEmpty}");

            stack.Push(10);
            stack.Push(20);
            Console.WriteLine("Добавили 10, 20. Расширяем при следующем добавлении..");
            stack.Push(30);
            stack.Push(40);
            stack.Push(50);

            Console.WriteLine($"Текущий размер (Count): {stack.Count}");
            Console.WriteLine($"Верхний элемент (Peek): {stack.Peek()}");

            Console.WriteLine($"Извлекаем (Pop): {stack.Pop()}");
            Console.WriteLine($"Извлекаем (Pop): {stack.Pop()}");
            Console.WriteLine($"Текущий размер (Count): {stack.Count}");

            stack.Pop();
            stack.Pop();
            stack.Pop();

            Console.WriteLine($"Теперь пуст: {stack.IsEmpty}");

            try
            {
                stack.Pop();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"[Ошибка] Pop на пустом стеке: {ex.Message}");
            }

            Console.WriteLine("\n--- Тестирование MyQueue<T> ---");
            var queue = new Queue<string>(2);

            Console.WriteLine($"Изначально пуста: {queue.IsEmpty}");

            queue.EnQueue("A");
            queue.EnQueue("B");
            Console.WriteLine("Добавили A, B. Расширяем...");
            queue.EnQueue("C");
            queue.EnQueue("D");
            queue.EnQueue("E");

            Console.WriteLine($"Текущий размер (Count): {queue.Count}");
            Console.WriteLine($"Первый элемент (Peek): {queue.Peek()}");

            Console.WriteLine($"Извлекаем (Dequeue): {queue.DeQueue()}");
            Console.WriteLine($"Извлекаем (Dequeue): {queue.DeQueue()}");
            Console.WriteLine($"Текущий размер (Count): {queue.Count}");

            queue.EnQueue("F");
            Console.WriteLine($"Добавили F. Первый элемент: {queue.Peek()}");

            queue.DeQueue();
            queue.DeQueue();
            queue.DeQueue();
            queue.DeQueue();

            Console.WriteLine($"Теперь пусто: {queue.IsEmpty}");
        }

        public class Queue<T>
        {
            private T[] _items;
            private int _head;
            private int _tail;
            private int _count;
            public int Count => _count;
            public bool IsEmpty => _count == 0;

            public Queue(int volume = 4)
            {
                if (volume <= 4) volume = 4;
                _items = new T[volume];
                _head = 0;
                _tail = 0;
                _count = 0;
            }
            public void EnQueue(T item)
            {
                if (_count == _items.Length)
                {
                    Resize();
                }

                _items[_tail] = item;
                _tail = (_tail + 1) % _items.Length;
                _count++;
            }
            public T DeQueue()
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Очередь пуста.");

                T item = _items[_head];
                _items[_head] = default;
                _items[_count] = default;
                _count--;

                return item;
            }
            public T Peek()
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Очередь пуста.");

                return _items[_head];
            }
            public void Resize()
            {
                T[] newArr = new T[_items.Length * 2];

                for (int i = 0; i < _count; i++)
                {
                    newArr[i] = _items[(_head + i) % _items.Length];
                }

                _items = newArr;
                _head = 0;
                _tail = _count;
            }
        }
        public class MyStack<T>
        {
            private T[] _items;
            private int _count;
            public int Count => _count;
            public bool IsEmpty => _count == 0;
            public MyStack(int volume = 4)
            {
                if (volume <= 0) volume = 4;
                _items = new T[volume];
                _count = 0;
            }
            public void Push(T item)
            {
                if (_count == _items.Length)
                {
                    Rasize();
                }
                _items[_count] = item;
                _count++;
            }
            public T Pop()
            {
                if (IsEmpty) throw new InvalidOperationException("Стек пуст.");

                _count--;
                T item = _items[_count];
                _items[_count] = default;
                return item;
            }
            public T Peek()
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Стек пуст.");

                return _items[_count - 1];
            }

            public void Rasize()
            {
                T[] newArr = new T[_items.Length * 2];
                Array.Copy(_items, newArr, _items.Length);
                _items = newArr;
            }
        }
    }
}
