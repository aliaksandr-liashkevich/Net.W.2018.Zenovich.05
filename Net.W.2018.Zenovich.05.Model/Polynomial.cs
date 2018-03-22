using System;
using System.Collections.Generic;

namespace Net.W._2018.Zenovich._05.Model
{
    public class Polynomial
    {
        private double[] _coefficients;

        public Polynomial(double[] coefficients)
        {
            _coefficients = coefficients ?? throw new NullReferenceException(nameof(coefficients));
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
            int maxLength = first._coefficients.Length != minLength ? minLength : second._coefficients.Length;

            double[] firstCoefficients = first._coefficients;
            double[] secondCoefficients = second._coefficients;

            double[] result = new double[minLength];
            
            for (int i = 0; i < minLength; i++)
            {
                result[i] = filter(firstCoefficients[i], secondCoefficients[i]);
            }

            firstCoefficients = firstCoefficients.Length == maxLength ? firstCoefficients : secondCoefficients;

            for (int i = minLength; i < maxLength; i++)
            {
                result[i] = firstCoefficients[i];
            }

            return new Polynomial(result);
        }

        public static Polynomial operator +(Polynomial first, Polynomial second)
        {
            return FactoryInitialization(first, second, PlusFilter);
        }

        public static Polynomial operator -(Polynomial first, Polynomial second)
        {

            return FactoryInitialization(first, second, MinusFilter);
        }

        public static Polynomial operator *(Polynomial first, Polynomial second)
        {

            return FactoryInitialization(first, second, MultiplyFilter);
        }

        public static bool operator ==(Polynomial polynomial1, Polynomial polynomial2)
        {
            return EqualityComparer<Polynomial>.Default.Equals(polynomial1, polynomial2);
        }

        public static bool operator !=(Polynomial polynomial1, Polynomial polynomial2)
        {
            return !(polynomial1 == polynomial2);
        }

        private static double PlusFilter(double first, double second)
        {
            return first + second;
        }

        private static double MinusFilter(double first, double second)
        {
            return first - second;
        }

        private static double MultiplyFilter(double first, double second)
        {
            return first * second;
        }

        public override bool Equals(object obj)
        {
            var polynomial = obj as Polynomial;
            return polynomial != null &&
                   EqualityComparer<double[]>.Default.Equals(_coefficients, polynomial._coefficients);
        }

        public override int GetHashCode()
        {
            return 710347640 + EqualityComparer<double[]>.Default.GetHashCode(_coefficients);
        }
        /*
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
        }*/
    }
}
