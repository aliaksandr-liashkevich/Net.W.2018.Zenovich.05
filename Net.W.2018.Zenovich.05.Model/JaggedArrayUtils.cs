using Net.W._2018.Zenovich._05.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.W._2018.Zenovich._05.Model
{
    public class JaggedArrayUtils : IJaggedArrayUtils
    {
        protected delegate bool FuncComparer(int first, int second);

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

        private bool OrderByAscending(int first, int second)
        {
            return first.CompareTo(second) > 0;
        }

        private bool OrderByDescending(int first, int second)
        {
            return first.CompareTo(second) < 0;
        }

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

        public int[][] MaxSort(int[][] jaggedArray, OrderdBy orderdBy = OrderdBy.Ascending)
        {
            return Sort(jaggedArray, GetMaxElement, orderdBy);
        }

        public int[][] MinSort(int[][] jaggedArray, OrderdBy orderdBy = OrderdBy.Ascending)
        {
            return Sort(jaggedArray, GetMinElement, orderdBy);
        }

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

        private int[][] Sort(int[][] jaggedArray, FuncFilter filter, OrderdBy orderdBy)
        {
            if (jaggedArray == null)
            {
                throw new ArgumentNullException(nameof(jaggedArray));
            }

            FuncComparer comparer = GetOrderBy(orderdBy);

            int length = jaggedArray.Length;
            int[] filterArray = new int[length];

            for (int i = 0; i < length; i++)
            {
                filterArray[i] = filter(jaggedArray[i]);
            }

            BubbleSort(jaggedArray, filterArray, comparer);

            return jaggedArray;
        }
    }
}
