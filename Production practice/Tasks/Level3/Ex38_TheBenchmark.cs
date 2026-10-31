using Production_practice.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_practice.Tasks.Level3
{
    internal class Ex38_TheBenchmark : ITask
    {
        public string Title => "List<T> vs LinkedList<T> (бенчмарк)";
        public string Description => "Сравнить вставку в середину List<T> и LinkedList<T>.";
        public string[] Condition => new[]
        {
            "Создать List<int> и LinkedList<int> по 100 000 элементов",
            "Вставить 1000 элементов в середину каждой коллекции",
            "Замерить время через Stopwatch",
            "Вывести оба времени и объяснить результат в комментарии"
        };

        private const int CollectionSize = 100_000;
        private const int InsertCount = 1_000;

        public void Launch()
        {
            var theFundamental = Enumerable.Range(0, CollectionSize).ToList();
            var list = new List<int>(theFundamental);
            var linkList = new LinkedList<int>(theFundamental);
            Console.WriteLine("List<T> vs LinkedList<T>: вставка в середину");
            Console.WriteLine($"Размер коллекций: {CollectionSize:N0} элементов");
            Console.WriteLine($"Количество вставок: {InsertCount:N0}");
            Console.WriteLine();

            Stopwatch sw = Stopwatch.StartNew();
            int listMidIndex = list.Count / 2;
            for (int i = 0; i < InsertCount; i++)
            {
                list.Insert(listMidIndex, -1);
            }
            sw.Stop();
            TimeSpan listTS = sw.Elapsed;

            sw.Restart();

            LinkedListNode<int> midNode = linkList.First;
            for (int i = 0; i < CollectionSize / 2 && midNode != null; i++)
            {
                midNode = midNode.Next;
            }
            for (int i = 0; i < InsertCount; i++)
            {
                linkList.AddAfter(midNode, -1);
            }
            sw.Stop();
            TimeSpan linkListTS = sw.Elapsed;

            Console.WriteLine($"List<int>:{listTS.TotalMilliseconds,10:F3} мс (итоговый размер: {list.Count:N0})");
            Console.WriteLine($"LinkedList<int>:{linkListTS.TotalMilliseconds,10:F3} мс (итоговый размер:{linkList.Count:N0})");
            Console.WriteLine();

            double speed = linkListTS.TotalMilliseconds > 0 ? listTS.TotalMilliseconds / linkListTS.TotalMilliseconds : double.PositiveInfinity;

            Console.WriteLine("Сравнение");
            Console.WriteLine($"Разница во времени: {listTS.TotalMilliseconds - linkListTS.TotalMilliseconds:F3} мс");
            Console.WriteLine($"LinkedList быстрее примерно в {speed:F1} раз(а)");
            Console.WriteLine();
            /* Объяснение
             * List - при вставке он сдвигает кучу элементов вправо, чтобы освободить место. 
             * Если вставлять 1000 раз в середину большого списка (100 000 элементов),то получается очень много перемещений.
             * LinkedList - сначала доходит до середины списка, потом вставляет элементы, ничего не сдвигая.
             * Такая вставка почти мгновенная.
             * В итоге - LinkedList лучше, т.к. не тратит время на перетаскивание данных
             */
        }
    }
}