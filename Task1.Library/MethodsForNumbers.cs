using System;

namespace Task1.Library
{
    public static class MethodsForNumbers
    {
        public static double FindRootByNewton(double number, int degree, double eps = 1e-10)
        {
            if (number < 0 && degree % 2 == 0)
            {
                throw new ArgumentException("Root of even degree for negative numbers is undefined");
            }
            if (degree < 0)
            {
                throw new ArgumentException("This method is undefined for negative degree");
            }
            if (degree == 0)
            {
                throw new ArgumentException();
            }
            var x = number / degree;
            var xk = 2 - (x / number);
            while (Math.Abs(x - xk) > eps)
            {
                x = xk;
                xk = xk - xk / degree + number * Math.Pow(xk, 1 - degree) / degree;
            }
            return x;
        }
    }
}

