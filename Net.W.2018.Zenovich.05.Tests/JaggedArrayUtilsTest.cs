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
        [TestMethod]
        public void TestMethod1()
        {
            IJaggedArrayUtils jaggedArrayUtils = new JaggedArrayUtils();
            int[][] array = new int[3][]
            {
                new int[] { 1, 22, 4, 11},
                new int[] { 8, 3, 7, -2, 60},
                new int[] { 1, 55, 4, 11}
            };

            jaggedArrayUtils.SumSort(array);

            foreach (var items in array)
            {
                foreach (var item in items)
                {
                    Debug.Write(item + " ");
                }
                Debug.WriteLine("");
            }
        }
    }
}
