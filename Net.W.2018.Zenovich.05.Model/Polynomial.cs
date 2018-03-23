using System;
using System.Collections.Generic;

namespace Net.W._2018.Zenovich._05.Model
{
    public class Polynomial
    {
        public const double Eps = 0.000000001;

        private double[] _coefficients;

        public Polynomial(double[] coefficients)
        {
            _coefficients = coefficients ?? throw new ArgumentNullException(nameof(coefficients));
        }

        private static int GetMinLength(Polynomial first, Polynomial second)
        {
            int firstLength = first._coefficients.Length;
            int secondLength = second._coefficients.Length;

            return firstLength < secondLength ? firstLength : secondLength;

        }

        private static Polynomial FactoryInitialization(Polynomial first, Polynomial second, Func<double, double, double> filter)
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }

            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            int firstLength = first._coefficients.Length;
            int secondLength = second._coefficients.Length;

            int minLength = firstLength < secondLength ? firstLength : secondLength;
            int maxLength = firstLength > secondLength ? firstLength : secondLength;

            double[] firstCoefficients = first._coefficients;
            double[] secondCoefficients = second._coefficients;

            double[] result = new double[maxLength];
            
            for (int i = 0; i < minLength; i++)
            {
                result[i] = filter(firstCoefficients[i], secondCoefficients[i]);
            }

            firstCoefficients = firstLength == maxLength ? firstCoefficients : secondCoefficients;

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
            Polynomial result = FactoryInitialization(first, second, MinusFilter);

            int firstLength = first._coefficients.Length;
            int secondLength = second._coefficients.Length;

            for (int i = firstLength; i < secondLength; i++)
            {
                result._coefficients[i] = -result._coefficients[i];
            }

            return result;
        }

        private static bool IsFirstMaxLength(Polynomial first, Polynomial second)
        {
            int firstLength = first._coefficients.Length;
            int secondLength = second._coefficients.Length;

            if (firstLength > secondLength)
            {
                return true;
            }

            return false;
        }


        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            Polynomial result = FactoryInitialization(first, second, MultiplyFilter);

            if (IsFirstMaxLength(first, second))
            {
                Polynomial temp = first;
                first = second;
                second = temp;
            }

            int secondLength = second._coefficients.Length;

            for (int i = first._coefficients.Length; i < secondLength; i++)
            {
                result._coefficients[i] = second._coefficients[i];
            }

            return result;
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

        private bool IsEqualDoubleArray(double[] first, double[] second)
        {
            if (first.Length != second.Length)
            {
                return false;
            }

            int length = first.Length;
            for (int i = 0; i < length; i++)
            {
                if (first[i] - second[i] > Eps)
                {
                    return false;
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            var polynomial = obj as Polynomial;
            return polynomial != null &&
                   IsEqualDoubleArray(_coefficients, polynomial._coefficients);
        }

        public override int GetHashCode()
        {
            return 710347640 + _coefficients.GetHashCode();
        }

        public override string ToString()
        {
            string toString = string.Empty;
            int length = _coefficients.Length;

            if (length < 0)
            {
                return toString;
            }

            int i = 0;

            toString += _coefficients[i] >= 0 ? $"+{_coefficients[i]}" : $"{_coefficients[i]}";
            i++;

            while (i < length)
            {
                toString += _coefficients[i] >= 0 ? 
                    $" +{_coefficients[i]}x^{i}" : 
                    $" {_coefficients[i]}x^{i}";

                i++;
            }

            return toString;
        }
    }
}
