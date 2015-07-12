using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Library;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {`
            double[] numbers = { 2, 8, 18, 88, 30.7, 150.6, 300, 1024, 500 };
            int[] degrees = { 2, 3, 4, 5, 10 };
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < degrees.Length; j++)
                {
                    var rootByMath = Math.Pow(numbers[i],  1.0/degrees[j]);
                    var rootByNewton = MethodsForNumbers.FindRootByNewton(numbers[i], degrees[j]);
                    var eps = Math.Abs(rootByMath - rootByNewton);
                    double[] numbersBefore = { 1, 4, 16, 81, 256, 64, 100 };
                    int[] degrees2 = { 1, 2, 2,  4, 4, 4, 2 };
                    //Assert.IsTrue(eps < 0.01);
                }
                Console.ReadKey();
            }
        }
    }
}
