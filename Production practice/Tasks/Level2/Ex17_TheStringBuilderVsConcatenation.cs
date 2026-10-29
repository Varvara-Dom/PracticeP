using Production_practice.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_practice.Tasks.Level2
{
    internal class Ex17_TheStringBuilderVsConcatenation : ITask
    {
        public string Title => "StringBuilder vs конкатенация (замер)";
        public string Description => "Сравнить производительность конкатенации через + и StringBuilder.";
        public string[] Condition => new[]
        {
            "Собрать строку из 10 000 (или 100 000) чисел двумя способами",
            "Замерить время каждого через Stopwatch",
            "Вывести оба времени и разницу",
            "Объяснить в комментарии, почему StringBuilder быстрее"
        };

        public void Launch()
        {
            const int count = 100_000;
            string resultCC = "";
            var SB = new StringBuilder();

            var swConcat = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
                resultCC += i;
            swConcat.Stop();

            var swSB = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
                SB.Append(i);
            string resultSB = SB.ToString();
            swSB.Stop();

            bool IsComparison = resultCC == resultSB;

            Console.WriteLine($"Конкатенация (+): {swConcat.ElapsedMilliseconds} мс");
            Console.WriteLine($"StringBuilder: {swSB.ElapsedMilliseconds} мс");
            Console.WriteLine($"Разница: {swConcat.ElapsedMilliseconds - swSB.ElapsedMilliseconds} мс");
            Console.WriteLine($"Результаты равны: {IsComparison}");
            Console.WriteLine($"Длина итоговой строки: {resultCC.Length} символов");

            /* Объяснение почему StringBuilder быстрее
             * 1. В C# string - неизменяемый тип данных, при любой операции с ним в памяти формируется новый объект.
             * В цикле особенно заметно, на каждой итерации создаётся строка большего размера, куда копируются данные из предыдущей версии плюс добавленная часть.
             * * Из‑за постоянного выделения памяти растёт нагрузка на систему, а также увеличивается количество обращений к сборщику мусора.
             * * 2. StringBuilder работает так:
             * * 1) Он хранит последовательность символов в изменяемом виде, внутри него находится массив символов.
             * * 2) Все изменения выполняются в пределах этого объекта, без генерации новых строк на каждом шаге.
             */
        }
    }
}
