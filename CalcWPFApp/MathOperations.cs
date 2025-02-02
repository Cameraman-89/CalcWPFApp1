using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources.Extensions;
using System.Text;
using System.Threading.Tasks;

namespace CalcWPFApp
{
    internal static class MathOperations
    {
        private static readonly int a;
        private static readonly int b;

        public static string Sum(double a, double b)
        {
            string result;

            var res = a + b;
            result = res.ToString();

            return result;
        }

        public static string Divide(double a, double b)
        {
            if (b == 0)
            {
                return "0";
            }
            var res = a / b;
            return res.ToString();
        }

        internal static string Subtract(double previousNumber, double currentNumber)
        {
            string result;

            var res = previousNumber - currentNumber;
            result = res.ToString();

            return result;
        }

        public static string Multiply(double a, double b)
        {
            string result;

            var res = a * b;
            return res.ToString("0");

            return result;
        }

        internal static string Percent(double currentNumber, double currentNumber1)
        {
            string result;

            var res = currentNumber / 100;
            result = res.ToString("0.##");

            return result;
        }
    }
}
