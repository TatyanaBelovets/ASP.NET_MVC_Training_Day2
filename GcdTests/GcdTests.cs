using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3.Library;

namespace Task3.Tests
{
    [TestClass]
    public class GcdTests
    {
        [TestMethod]
        public void MatchResultsForEuclidGcd()
        {
            int[] values = {1, 2, 8, 102, 22569};
            int gcd = 1;
            long timeOfWork;
            Assert.AreEqual(gcd, GreatestCommonDivisor.GcdWithTime(out timeOfWork, 144,values));
        }

        [TestMethod]
        public void MatchResultsForSteinGcd()
        {
            int[] values = { 1, 2, 8, 102, 22569 };
            int gcd = 1;
            long timeOfWork;
            Assert.AreEqual(gcd, GreatestCommonDivisor.GcdBySteinsAndTimeOfWork(out timeOfWork, 144, values));
        }
    }
}
