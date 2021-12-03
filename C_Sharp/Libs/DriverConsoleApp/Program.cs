using Extension;
using Alg;
using System;

namespace DriverConsoleApp
{
    public class Program
    {
        public static int[] testArray = { 12, 5, 1, 3, 2, 0, 1, 2, 3, 44, 55, 556, 6553, 1223, 234234, 2345235, 234251 };

        public static void Main(string[] args)
        {
            BenchMark.BenchMark timeTester = new BenchMark.BenchMark();

            timeTester.Start();
            foreach (int i in testArray) Console.Write($"{i} ");
            Console.WriteLine();

            testArray.SelectionSort();
            timeTester.Mark($"Array.Copy test");

            foreach (int i in testArray) Console.Write($"{i} ");
            Console.WriteLine();

            timeTester.End();
            timeTester.Report(false);
        }
    }
}
