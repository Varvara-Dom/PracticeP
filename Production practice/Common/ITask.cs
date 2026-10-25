using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production_practice.Common
{
    public interface ITask
    {
        string Title { get; }
        string Description { get; }
        string[] Condition { get; }
        void Launch();
    }
}
