using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.W._2018.Zenovich._05.Model
{
    class DescendingOrderable : IOrderable
    {
        public bool OrderBy(int comparableResult)
        {
            return comparableResult < 0;
        }
    }
}
