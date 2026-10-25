using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Common;

namespace Production_practice.Tasks.Level1
{
    internal class Ex2_PrimitivesType : ITask
    {
        public string Title => "Переменные примитивных типов";
        public string Description => "объявить переменные всех примитивных типов и вывести их значения и типы.";
        public string[] Condition => new[]
        {
            "Объявить минимум: int, long, double, float, decimal, bool, char, string",
            "Для каждой переменной вывести значение и GetType().Name",
            "decimal — с суффиксом m, float — с f"
        };
        public void Launch()
        {
            int integer = 123;
            long l_ng = 487553760;
            double d_ble = 333.3;
            float fl_t = 3.141592653589793238462643383279502884197169399375105820974944592f;
            decimal d_imal = 1.67m;
            bool b_l = false;
            char ch_r = 'v';
            string st_ng = "isp";
            sbyte sb_te = 98;
            short sh_rt = -18;
            ushort us_rt = 3;
            ulong ul_ng = 8676649;

            BringOutVariables("integer", integer);
            BringOutVariables("long", l_ng);
            BringOutVariables("double", d_ble);
            BringOutVariables("float", fl_t);
            BringOutVariables("decimal", d_imal);
            BringOutVariables("bool", b_l);
            BringOutVariables("char", ch_r);
            BringOutVariables("string", st_ng);
            BringOutVariables("sbyte", sb_te);
            BringOutVariables("short", sh_rt);
            BringOutVariables("ushort", us_rt);
            BringOutVariables("ulong", ul_ng);
        }

        private void BringOutVariables<V>(string name, V value)
        {
            Console.WriteLine($"{name} = {value} ({value.GetType().Name})");
        }
    }
}
