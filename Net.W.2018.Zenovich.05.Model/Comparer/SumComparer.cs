using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.W._2018.Zenovich._05.Model.Comparer
{
    /// <summary>
    ///  Sum comparer for array row.
    /// </summary>
    /// <seealso cref="int" />
    public class SumComparer : IComparer<int[]>
    {
        public int Compare(int[] first, int[] second)
        {
            int firstSum = 0;
            foreach (int item in first)
            {
                firstSum += item;
            }

            int secondSum = 0;
            foreach (int item in second)
            {
                secondSum += item;
            }

            return firstSum.CompareTo(secondSum);
        }
    }
}
