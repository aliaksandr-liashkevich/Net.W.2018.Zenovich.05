using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.W._2018.Zenovich._05.API;
using Net.W._2018.Zenovich._05.Model;

namespace Net.W._2018.Zenovich._05.Tests
{
    [TestClass]
    public class JaggedArrayUtilsTest
    {
        private IJaggedArrayUtils jaggedArrayUtils;
        private int[][] inputArray;

        [TestInitialize]
        public void TestInitialize()
        {
            jaggedArrayUtils = new JaggedArrayUtils();
            inputArray = new int[3][]
            {
                new int[] { 1, 22, 4, 11},
                new int[] { 8, 3, 7, -2, 60},
                new int[] { 1, 55, 4, 11}
            };
        }

        [TestMethod]
        public void SumSort_OrderByAscending()
        {
            // arrange
            int[][] expected = new int[3][]
            {
                new int[] { 1, 22, 4, 11},
                new int[] { 1, 55, 4, 11},
                new int[] { 8, 3, 7, -2, 60 },
            };

            // act
            int[][] actual = jaggedArrayUtils.SumSort(inputArray);

            // assert
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void MaxSort_OrderByAscending()
        {
            // arrange
            int[][] expected = new int[3][]
            {
                new int[] { 1, 22, 4, 11},
                new int[] { 1, 55, 4, 11},
                new int[] { 8, 3, 7, -2, 60 },
            };

            // act
            int[][] actual = jaggedArrayUtils.MaxSort(inputArray);

            // assert
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void MinSort_OrderByAscending()
        {
            // arrange
            int[][] expected = new int[3][]
            {
                new int[] { 8, 3, 7, -2, 60 },
                new int[] { 1, 22, 4, 11},
                new int[] { 1, 55, 4, 11},
            };

            // act
            int[][] actual = jaggedArrayUtils.MinSort(inputArray);

            // assert
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void SumSort_OrderByDescending()
        {
            // arrange
            int[][] expected = new int[3][]
            {
                new int[] { 8, 3, 7, -2, 60 },
                new int[] { 1, 55, 4, 11},
                new int[] { 1, 22, 4, 11}
            };

            // act
            int[][] actual = jaggedArrayUtils.SumSort(inputArray, OrderdBy.Descending);

            // assert
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void MaxSort_OrderByDescending()
        {
            // arrange
            int[][] expected = new int[3][]
            {
                new int[] { 8, 3, 7, -2, 60 },
                new int[] { 1, 55, 4, 11},
                new int[] { 1, 22, 4, 11}
            };

            // act
            int[][] actual = jaggedArrayUtils.MaxSort(inputArray, OrderdBy.Descending);

            // assert
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void MinSort_OrderByDescending()
        {
            // arrange
            inputArray[0][0] = 2;
            int[][] expected = new int[3][]
            {
                new int[] { 2, 22, 4, 11},
                new int[] { 1, 55, 4, 11},
                new int[] { 8, 3, 7, -2, 60 }
            };

            // act
            int[][] actual = jaggedArrayUtils.MinSort(inputArray, OrderdBy.Descending);

            // assert
            for (int i = 0; i < expected.Length; i++)
            {
                CollectionAssert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MinSort_ArgumentNullException()
        {
            // arrange
            inputArray = null;

            // act
            int[][] actual = jaggedArrayUtils.MinSort(inputArray);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MaxSort_ArgumentNullException()
        {
            // arrange
            inputArray = null;

            // act
            int[][] actual = jaggedArrayUtils.MaxSort(inputArray, OrderdBy.Descending);
        }
    }
}
