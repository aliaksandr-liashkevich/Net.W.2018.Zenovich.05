using System;
using System.Collections.Generic;

namespace Net.W._2018.Zenovich._05.Model
{
    public class Polynomial
    {
        private double[] _coefficients;

        public Polynomial(double[] coefficients)
        {
            _coefficients = coefficients;
        }

        private static int GetMinLength(Polynomial first, Polynomial second)
        {
            int firstLength = first._coefficients.Length;
            int secondLength = second._coefficients.Length;

            return firstLength < secondLength ? firstLength : secondLength;

        }

        private static Polynomial FactoryInitialization(Polynomial first, Polynomial second, Func<double, double, double> filter)
        {
            int minLength = GetMinLength(first, second);
            double[] firstCoefficients = first._coefficients;
            double[] secondCoefficients = second._coefficients;

            double[] result = new double[minLength];
            
            for (int i = 0; i < minLength; i++)
            {
                result[i] = filter(firstCoefficients[i], secondCoefficients[i]);
            }

            return new Polynomial(result);
        }

        private static bool IsEquivalentPolynomial(Polynomial first, Polynomial second)
        {
            if (first._coefficients.Length != second._coefficients.Length)
            {
                return false;
            }

            int minLength = GetMinLength(first, second);
            double[] firstCoefficients = first._coefficients;
            double[] secondCoefficients = second._coefficients;

            for (int i = 0; i < minLength; i++)
            {
                if (firstCoefficients[i] != secondCoefficients[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static Polynomial operator +(Polynomial first, Polynomial second)
        {
            return FactoryInitialization(first, second, (firstCoefficients, secondCoefficients) =>
            {
                return firstCoefficients + secondCoefficients;
            });
        }

        public static Polynomial operator -(Polynomial first, Polynomial second)
        {

            return FactoryInitialization(first, second, (firstCoefficients, secondCoefficients) =>
            {
                return firstCoefficients - secondCoefficients;
            });
        }

        public static Polynomial operator *(Polynomial first, Polynomial second)
        {

            return FactoryInitialization(first, second, (firstCoefficients, secondCoefficients) =>
            {
                return firstCoefficients * secondCoefficients;
            });
        }

        public static bool operator ==(Polynomial first, Polynomial second)
        {
            return IsEquivalentPolynomial(first, second);
        }

        public static bool operator !=(Polynomial first, Polynomial second)
        {
            return !(first == second);
        }

        public override bool Equals(object obj)
        {
            var polynomial = obj as Polynomial;
            return polynomial != null &&
                   EqualityComparer<double[]>.Default.Equals(_coefficients, polynomial._coefficients);
        }

        public override int GetHashCode()
        {
            return 1112971371 + EqualityComparer<double[]>.Default.GetHashCode(_coefficients);
        }
    }
}
