using System;
using System.Collections.Generic;

namespace Net.W._2018.Zenovich._05.Model
{
    /// <summary>
    /// Contains methods for working with polynomials of degree from one variable of real type.
    /// </summary>
    public class Polynomial
    {
        /// <summary>
        /// Comparison accuracy.
        /// </summary>
        public static readonly double Eps = 0.00001;

        /// <summary>
        /// Filters the data in an array from the beginning to the minimum length.
        /// </summary>
        /// <param name="first">first input number.</param>
        /// <param name="second">second input number.</param>
        /// <returns>result of filtration</returns>
        protected delegate double FuncFilter(double first, double second);
        /// <summary>
        /// Filters the data in an array from the minimum length to the maximum length
        /// </summary>
        /// <param name="maxLength">Max length of array</param>
        /// <param name="IsFirstLengthMoreThanSecondLength">Is first length more than second length of array.</param>
        /// <returns>result of filtration</returns>
        protected delegate double FuncFilterFromMinLengthToMaxLength(double maxLength, bool IsFirstLengthMoreThanSecondLength);

        /// <summary>
        /// Array of coefficients.
        /// </summary>
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

        private static Polynomial FactoryInitialization(Polynomial first, Polynomial second, 
            FuncFilter filter, FuncFilterFromMinLengthToMaxLength maxFilter = null)
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
            bool IsFirstLengthMoreThanSecondLength = firstLength == maxLength ? true : false; 

            for (int i = minLength; i < maxLength; i++)
            {
                result[i] = maxFilter != null ? 
                    maxFilter(firstCoefficients[i], IsFirstLengthMoreThanSecondLength) 
                    : firstCoefficients[i];
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// The sum operator.
        /// </summary>
        /// <param name="first">left value.</param>
        /// <param name="second">right value.</param>
        /// <returns>Result of operation.</returns>
        public static Polynomial operator +(Polynomial first, Polynomial second)
        {
            return FactoryInitialization(first, second, PlusFilter);
        }

        /// <summary>
        /// The difference operator.
        /// </summary>
        /// <param name="first">left value.</param>
        /// <param name="second">right value.</param>
        /// <returns>Result of operation.</returns>
        public static Polynomial operator -(Polynomial first, Polynomial second)
        {
            Polynomial result = FactoryInitialization(first, second, MinusFilter, MinusFilterFromMinLengthToMaxLength);

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

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="first">left value.</param>
        /// <param name="second">right value.</param>
        /// <returns>Result of operation.</returns>
        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            Polynomial result = FactoryInitialization(first, second, MultiplyFilter);

            return result;
        }
        /// <summary>
        /// The equality operator.
        /// </summary>
        /// <param name="first">left value.</param>
        /// <param name="second">right value.</param>
        /// <returns>Result of operation.</returns>
        public static bool operator ==(Polynomial first, Polynomial second)
        {
            return EqualityComparer<Polynomial>.Default.Equals(first, second);
        }
        /// <summary>
        /// The inequality operator.
        /// </summary>
        /// <param name="first">left value.</param>
        /// <param name="second">right value.</param>
        /// <returns>Result of operation.</returns>
        public static bool operator !=(Polynomial first, Polynomial second)
        {
            return !(first == second);
        }

        private static double MinusFilterFromMinLengthToMaxLength(double number, bool isFirstLengthMoreThanSecondLength)
        {
            return isFirstLengthMoreThanSecondLength ? number : -number;
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
        /// <summary>
        /// Returns a unique value.
        /// </summary>
        /// <returns>Unique value.</returns>
        public override int GetHashCode()
        {
            int result = 17;

            foreach (var number in _coefficients)
            {
                result = 37 * result + (int)number;
            }

            return result;
        }
        /// <summary>
        /// Converts an object to string.
        /// </summary>
        /// <returns>String representation.</returns>
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
