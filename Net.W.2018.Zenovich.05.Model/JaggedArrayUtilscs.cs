using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.W._2018.Zenovich._05.Model
{
    public class JaggedArrayUtilscs
    {
        public delegate bool FuncComparer<T>(T first, T second)
            where T : IComparable<T>;

        public delegate T FuncFilter<T>(T[] array);

        private void Swap<T>(T[] items, int left, int right)
        {
            if (left != right)
            {
                T temp = items[left];
                items[left] = items[right];
                items[right] = temp;
            }
        }

        public bool OrderByAscending<T>(T first, T second)
            where T : IComparable<T>
        {
            return first.CompareTo(second) < 0;
        }

        public bool OrderByDescending<T>(T first, T second)
            where T : IComparable<T>
        {
            return first.CompareTo(second) > 0;
        }

        private void BubbleSort<T>(T[][] items, T[] filterArray, FuncComparer<T> comparer)
            where T : IComparable<T>
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

                        swapped = true;
                    }
                }
            }

            while (swapped != false);
        }

        private T GetMaxElement<T>(T[] array)
            where T : IComparable<T>
        {
            T maxElement = default(T);

            foreach (var element in array)
            {
                if (maxElement.CompareTo(element) < 0)
                {
                    maxElement = element;
                }
            }

            return maxElement;
        }

        private T GetMinElement<T>(T[] array)
            where T : IComparable<T>
        {
            T minElement = default(T);

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

        public T[][] MaxSort<T>(T[][] jaggedArray, FuncComparer<T> comparer)
            where T : IComparable<T>
        {
            return Sort(jaggedArray, GetMaxElement, comparer);
        }

        public T[][] MinSort<T>(T[][] jaggedArray, FuncComparer<T> comparer)
            where T : IComparable<T>
        {
            return Sort(jaggedArray, GetMinElement, comparer);
        }

        public int[][] SumSort(int[][] jaggedArray, FuncComparer<int> comparer)
        {
            return Sort(jaggedArray, GetSumElement, comparer);
        }


        private T[][] Sort<T>(T[][] jaggedArray, FuncFilter<T> filter, FuncComparer<T> comparer)
            where T : IComparable<T>
        {
            if (jaggedArray == null)
            {
                throw new ArgumentNullException(nameof(jaggedArray));
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            int length = jaggedArray.Length;
            T[] filterArray = new T[length];

            for (int i = 0; i < length; i++)
            {
                filterArray[i] = filter(jaggedArray[i]);
            }

            BubbleSort(jaggedArray, filterArray, comparer);

            return jaggedArray;
        }
    }
}
