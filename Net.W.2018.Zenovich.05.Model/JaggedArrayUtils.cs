using Net.W._2018.Zenovich._05.API;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.W._2018.Zenovich._05.Model
{
    /// <summary>
    /// Contains methods for sorting jagged array.
    /// </summary>
    public class JaggedArrayUtils : IJaggedArrayUtils
    {
        /// <summary>
        /// Compares value when sorting.
        /// </summary>
        /// <param name="first">first input number.</param>
        /// <param name="second">second input number.</param>
        /// <returns>result of filtration</returns>
        protected delegate bool FuncComparer(int first, int second);
        /// <summary>
        /// Filters the rows of the jagged array.
        /// </summary>
        /// <param name="array">input jagged array row.</param>
        /// <returns>result of filtration</returns>
        protected delegate int FuncFilter(int[] array);

        private void Swap<T>(T[] items, int left, int right)
        {
            if (left != right)
            {
                T temp = items[left];
                items[left] = items[right];
                items[right] = temp;
            }
        }

        /// <summary>
        /// Sorts the specified jagged array.
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="orderdBy">The orderd by.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="jaggedArray"/> is null
        /// or
        /// <paramref name="filter"/> is null
        /// </exception>
        public int[][] Sort(int[][] jaggedArray, IComparer<int[]> filter, OrderdBy orderdBy)
        {
            if (jaggedArray == null)
            {
                throw new ArgumentNullException(nameof(jaggedArray));
            }

            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            BubbleSort(jaggedArray, filter, GetOrderableBy(orderdBy));

            return jaggedArray;
        }

        /// <summary>
        /// Sorts the rows by the max of the elements
        /// </summary>
        /// <param name="jaggedArray">Input jagged array.</param>
        /// <param name="orderdBy">Is used to sort the result-set in ascending or descending order.</param>
        /// <returns>sorted jagged array</returns>
        public int[][] MaxSort(int[][] jaggedArray, OrderdBy orderdBy = OrderdBy.Ascending)
        {
            return Sort(jaggedArray, GetMaxElement, orderdBy);
        }
        /// <summary>
        /// Sorts the rows by the min of the elements
        /// </summary>
        /// <param name="jaggedArray">Input jagged array.</param>
        /// <param name="orderdBy">Is used to sort the result-set in ascending or descending order.</param>
        /// <returns>sorted jagged array</returns>
        public int[][] MinSort(int[][] jaggedArray, OrderdBy orderdBy = OrderdBy.Ascending)
        {
            return Sort(jaggedArray, GetMinElement, orderdBy);
        }
        /// <summary>
        /// Sorts the rows by the sum of the elements.
        /// </summary>
        /// <param name="jaggedArray">Input jagged array.</param>
        /// <param name="orderdBy">Is used to sort the result-set in ascending or descending order.</param>
        /// <returns>sorted jagged array</returns>
        public int[][] SumSort(int[][] jaggedArray, OrderdBy orderdBy = OrderdBy.Ascending)
        {
            return Sort(jaggedArray, GetSumElement, orderdBy);
        }

        protected virtual FuncComparer GetOrderBy(OrderdBy orderdBy)
        {
            switch (orderdBy)
            {
                case OrderdBy.Descending:
                    {
                        return OrderByDescending;
                    }
                default:
                    {
                        return OrderByAscending;
                    }
            }
        }

        /// <summary>
        /// Implementation of sorting by a bubble.
        /// </summary>
        /// <param name="items">input jagged array</param>
        /// <param name="filterArray">array of row sorting characteristics.</param>
        /// <param name="comparer">Compares value when sorting.</param>
        private void BubbleSort(int[][] items, int[] filterArray, FuncComparer comparer)
        {
            bool swapped;

            do
            {
                swapped = false;

                for (int i = 1; i < items.Length; i++)
                {
                    if (comparer(filterArray[i - 1], filterArray[i]))
                    {
                        Swap(items, i - 1, i);
                        Swap(filterArray, i - 1, i);

                        swapped = true;
                    }
                }
            }

            while (swapped != false);
        }

        private bool OrderByAscending(int first, int second)
        {
            return first.CompareTo(second) > 0;
        }

        private bool OrderByDescending(int first, int second)
        {
            return first.CompareTo(second) < 0;
        }

        private int[][] Sort(int[][] jaggedArray, FuncFilter filter, OrderdBy orderdBy)
        {
            if (jaggedArray == null)
            {
                throw new ArgumentNullException(nameof(jaggedArray));
            }

            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            int length = jaggedArray.Length;
            int[] filterArray = new int[length];

            for (int i = 0; i < length; i++)
            {
                filterArray[i] = filter(jaggedArray[i]);
            }

            BubbleSort(jaggedArray, filterArray, GetOrderBy(orderdBy));

            return jaggedArray;
        }

        private int GetMaxElement(int[] array)
        {
            int maxElement = int.MinValue;

            foreach (var element in array)
            {
                if (maxElement.CompareTo(element) < 0)
                {
                    maxElement = element;
                }
            }

            return maxElement;
        }

        private int GetMinElement(int[] array)
        {
            int minElement = int.MaxValue;

            foreach (var element in array)
            {
                if (minElement.CompareTo(element) > 0)
                {
                    minElement = element;
                }
            }

            return minElement;
        }

        private int GetSumElement(int[] array)
        {
            int elementSum = default(int);

            foreach (var element in array)
            {
                elementSum += element;
            }

            return elementSum;
        }

        protected virtual IOrderable GetOrderableBy(OrderdBy orderdBy)
        {
            switch (orderdBy)
            {
                case OrderdBy.Descending:
                {
                    return new DescendingOrderable();
                }
                default:
                {
                    return new AscendingOrderable();
                }
            }
        }

        private void BubbleSort(int[][] items, IComparer<int[]> comparer, IOrderable orderable)
        {
            bool swapped;

            do
            {
                swapped = false;

                for (int i = 1; i < items.Length; i++)
                {
                    int comparerableResult = comparer.Compare(items[i - 1], items[i]);

                    if (orderable.OrderBy(comparerableResult))
                    {
                        Swap(items, i - 1, i);

                        swapped = true;
                    }
                }
            }

            while (swapped != false);
        }
    }
}
