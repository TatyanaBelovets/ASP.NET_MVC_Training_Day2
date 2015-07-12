using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Library;

namespace Task1.Tests
{
    [TestClass]
    public class TestsForNewtonMethod
    {
        [TestMethod]
        public void TestAccuracy()
        {
            double[] numbers = {1, 2, 8, 18, 88, 30.7, 150.6, 300, 1024, 500};
            int[] degrees = {1, 2, 3, 4, 5, 10};
            for(int i = 0; i < numbers.Length; i++)
            {
                foreach (int t in degrees)
                {
                    var rootByMath = Math.Pow(numbers[i], 1.0 / t);
                    var rootByNewton = MethodsForNumbers.FindRootByNewton(numbers[i], t);
                    var eps = Math.Abs(rootByMath - rootByNewton);
                    Assert.IsTrue(eps < 0.001);
                }
            }
            
        }
        [TestMethod]
        public void TestMatchValues()
        {
            double[] numbersBefore = { 1, 4, 16, 81, 256, 64, 100 };
            int[] degrees = { 1, 2, 4, 4, 4, 3, 2};
            for (int i = 0; i < numbersBefore.Length; i++)
            {
                Assert.AreEqual(Math.Round(Math.Pow(numbersBefore[i], 1.0/degrees[i]), 5), 
                    Math.Round(MethodsForNumbers.FindRootByNewton(numbersBefore[i], degrees[i]), 5));
            }

        }
        
    }
}
