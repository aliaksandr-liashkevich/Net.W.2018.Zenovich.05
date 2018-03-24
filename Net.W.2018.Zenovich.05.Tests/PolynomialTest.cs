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
        public void SumOperator_AreEqualExpected()
        {
            // arrange
            Polynomial expected = new Polynomial(new double[]
            {
                9.0, 43.2, 44.1, 0, 11.0
            });

            // act
            Polynomial actual = firstPolynomial + secondPolynomial;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MinusOperator__AreEqualExpected()
        {
            // arrange
            Polynomial expected = new Polynomial(new double[]
            {
                31.4, -20.8, 44.1, 0, 11
            });

            // act
            Polynomial actual = firstPolynomial - secondPolynomial;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiOperator__AreEqualExpectedAreEqual()
        {
            // arrange
            Polynomial expected = new Polynomial(new double[]
            {
                -226.24, 358.399999999999, 0, 0, 11
            });

            // act
            Polynomial actual = firstPolynomial * secondPolynomial;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MultiOperator_NullFirst_ArgumentNullException()
        {
            // arrange
            firstPolynomial = null;

            // act
            Polynomial actual = firstPolynomial * secondPolynomial;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MultiOperator_NullSecond_ArgumentNullException()
        {
            // arrange
            secondPolynomial = null;

            // act
            Polynomial actual = firstPolynomial + secondPolynomial;
        }

        [TestMethod]
        public void EqualOperator__AreEqualTrue()
        {
            // arrange
            Polynomial expected = new Polynomial(new double[]
            {
                20.2, 11.2, 44.1, 0, 11
            });

            // act
            bool actual = firstPolynomial  == expected;

            // assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ToString_AreEqualExpected()
        {
            // arrange
            String expected = new Polynomial(new double[]
            {
                20.2, 11.2, 44.1, 0, 11
            }).ToString();

            // act
            string actual = firstPolynomial.ToString();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetHashCode_AreEqualExpected()
        {
            // arrange
            int expected = new Polynomial(new double[]
            {
                20.2, 11.2, 44.1, 0, 11
            }).GetHashCode();

            // act
            int actual = firstPolynomial.GetHashCode();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NotEqualOperator_AreEqualFalse()
        {
            // arrange
            Polynomial expected = new Polynomial(new double[]
            {
                20.2, 11.2, 44.1, 0, 11
            });

            // act
            bool actual = firstPolynomial != expected;

            // assert
            Assert.IsFalse(actual);
        }
    }
}
