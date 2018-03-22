using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.W._2018.Zenovich._05.API
{
    public delegate bool FuncComparer<T>(T first, T second)
        where T : IComparable<T>;
}
