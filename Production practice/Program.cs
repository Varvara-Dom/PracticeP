using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Production_practice.Menu;

namespace Production_practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var projectMenu = new MenuRunner();
            projectMenu.Start();
        }  
    }
}

