using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.W._2018.Zenovich._05.Model;

namespace Net.W._2018.Zenovich._05.Tests
{
    [TestClass]
    public class PolynomialTest
    {
        private Polynomial firstPolynomial;
        private Polynomial secondPolynomial;

        [TestInitialize]
        public void TestInitialize()
        {
            firstPolynomial = new Polynomial(new double[5] {
                20.2, 11.2, 44.1, 0, 11
            });
            secondPolynomial = new Polynomial(new double[3] {
                -11.2, 32.0, 0
            });
        }

        [TestMethod]
        public void TestMethod1()
        {
            Polynomial firstPolynomial = new Polynomial(new double[5] {
                20.2, 11.2, 44.1, 0, 11
            });
            Polynomial secondPolynomial = new Polynomial(new double[3] {
                -11.2, 32.0, 0
            });

            var sum = firstPolynomial + secondPolynomial;
            var minus = firstPolynomial - secondPolynomial;
            var multi = firstPolynomial * secondPolynomial;

            Debug.WriteLine(firstPolynomial);
            Debug.WriteLine(secondPolynomial);

            Debug.WriteLine(new string('-', 10));
            Debug.WriteLine(sum);
            Debug.WriteLine(minus);
            Debug.WriteLine(multi);

            sum = secondPolynomial + firstPolynomial;
            minus = secondPolynomial - firstPolynomial;
            multi = secondPolynomial * firstPolynomial;

            Debug.WriteLine(new string('-', 10));
            Debug.WriteLine(sum);
            Debug.WriteLine(minus);
            Debug.WriteLine(multi);
        }

        [TestMethod]
        public void SumOperator_AreEqual()
        {
            // arrange
            Polynomial expected = new Polynomial(new double[]
            {
                9.0, 43.2, 44.1, 0.0, 11.0
            });

            // act
            Polynomial actual = firstPolynomial + secondPolynomial;

            // assert
            Debug.WriteLine(actual);
            Debug.WriteLine(expected);
        }
    }
}
