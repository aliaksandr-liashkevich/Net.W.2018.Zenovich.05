using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.W._2018.Zenovich._05.Model.Comparer
{
    /// <summary>
    /// Max comparer for array row.
    /// </summary>
    /// <seealso cref="int" />
    public class MaxComparer : IComparer<int[]>
    {
        public int Compare(int[] first, int[] second)
        {
            int firstMin = int.MinValue;
            foreach (int item in first)
            {
                if (item > firstMin)
                {
                    firstMin = item;
                }
            }

            int secondMin = int.MinValue;
            foreach (int item in second)
            {
                if (item > secondMin)
                {
                    secondMin = item;
                }
            }

            return firstMin.CompareTo(secondMin);
        }
    }
}
