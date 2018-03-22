using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.W._2018.Zenovich._05.API
{
    public interface IJaggedArrayUtils
    {
        T[][] MinSort<T>(T[][] jaggedArray, FuncComparer<T> comparer)
            where T : IComparable<T>;
        T[][] MaxSort<T>(T[][] jaggedArray, FuncComparer<T> comparer)
            where T : IComparable<T>;
        int[][] SumSort(int[][] jaggedArray, FuncComparer<int> comparer);
    }
}
