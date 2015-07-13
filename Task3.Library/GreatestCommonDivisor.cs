using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Library
{
    public static class GreatestCommonDivisor
    {
        private static int Gcd(int a, int b)
        {
            while (true)
            {
                if (b == 0) return a;
                var temp = a;
                a = b;
                b = temp % b;
            }
        }


        public static int GcdWithTime(out long timeOfWork, int a, params int[] rest)
        {
            var watch = Stopwatch.StartNew();
            var gcdResult = rest.Aggregate(a, Gcd);
            watch.Stop();
            timeOfWork = watch.ElapsedMilliseconds;
            return gcdResult;
        }

        public static uint GcdByStein(uint u, uint v)
        {
            if (u == v || v == 0)
                return u;
            if (u == 0)
                return v;
            if ((u & 1) == 0) // u is even
            {
                if ((v & 1) == 1) // v is odd
                    return GcdByStein(u >> 1, v);
                return GcdByStein(u >> 1, v >> 1) << 1; // both u and v are even   
            }
            if ((v & 1) == 0) // u is odd, v is even
                return GcdByStein(u, v >> 1);
            return u > v ? GcdByStein((u - v) >> 1, v) : GcdByStein((v - u) >> 1, u); // reduce larger argument
        }

        public static int GcdBySteinsAndTimeOfWork(out long workTime, int a, params int[] rest)
        {
            var watch = Stopwatch.StartNew();
            var gcdResult = rest.Select(i => (uint)Math.Abs(i)).Aggregate((uint)Math.Abs(a), GcdByStein);
            watch.Stop();
            workTime = watch.ElapsedMilliseconds;
            return (int)gcdResult;
        }
    }
}
