using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.W._2018.Zenovich._05.Model;

namespace Net.W._2018.Zenovich._05.Tests
{
    [TestClass]
    public class PolynomialTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Polynomial firstPolynomial = new Polynomial(new double[5] {
                20.2, 11.2, 44.1, 0, 11
            });
            Polynomial secondPolynomial = new Polynomial(new double[3] {
                -11.2, 32.0, 0
            });

            var sum = secondPolynomial + firstPolynomial;
            var minus = secondPolynomial - firstPolynomial;
            var multi = secondPolynomial * firstPolynomial;




            Debug.WriteLine(firstPolynomial);
            Debug.WriteLine(secondPolynomial);

            Debug.WriteLine(new string('-', 10));
            Debug.WriteLine(sum);
            Debug.WriteLine(minus);
            Debug.WriteLine(multi);
        }
    }
}
