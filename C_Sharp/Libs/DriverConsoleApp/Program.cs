using Extension;
using Alg;
using System;

namespace DriverConsoleApp
{
    public class Program
    {
        public static int[] testArray = { 556, 5, 1, 3, 2, 0, 1, 2, 3, 44, 55, 12, 6553, 4, 234234, 2345235, 9 };

        public static void Main(string[] args)
        {
            BenchMark.BenchMark timeTester = new BenchMark.BenchMark();

            timeTester.Start();
            foreach (int i in testArray) Console.Write($"{i} ");
            Console.WriteLine();

            testArray.BubbleSort();
            timeTester.Mark($"Array.Copy test");

            foreach (int i in testArray) Console.Write($"{i} ");
            Console.WriteLine();

            timeTester.End();
            timeTester.Report(false);
        }
    }
}
