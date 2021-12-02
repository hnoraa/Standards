using Extension;
using System;

namespace DriverConsoleApp
{
    public class Program
    {
        public static long[] testArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 5, 6, 7, 7, 5, 7, 88, 45, 6, 345, 672, 5646, 234, 346
                , 2342, 57457548, 879797, 35413, 42, 24, 124, 143453, 72368, 23834, 123123, 12312, 2523, 5654, 76, 1, 7, 4, 1, 123, 514, 7, 6
                , 46, 146, 1245, 123, 424, 535646, 3453, 2342, 234 };
        public static int offset;
        public static int length = 0;

        public static void Reset()
        {
            Extension.Extension.ResetArray(testArray);
            offset = 5; // testArray[5] = 6
            length = testArray.Length - offset;
        }

        public static void Main(string[] args)
        {
            BenchMark.BenchMark timeTester = new BenchMark.BenchMark();

            Reset();
            Console.WriteLine($"Starting tests with array of length: {testArray.Length}, offset of: {offset} and length of: {length}");

            timeTester.Start();

            // Array.Copy test
            Reset();
            testArray.SubArrayCopy(offset, length);
            timeTester.Mark($"Array.Copy test");

            // Enumerable.Skip and Enumerable.Take test
            Reset();
            testArray.SubArrayCopy(offset, length);
            timeTester.Mark($"Enumerable.Skip and Enumerable.Take test");

            // ArraySegment<T> Struct test
            Reset();
            testArray.SubArrayCopy(offset, length);
            timeTester.Mark($"ArraySegment<T> Struct test");

            // List.GetRange() test
            Reset();
            testArray.SubArrayCopy(offset, length);
            timeTester.Mark($"List.GetRange() test");

            timeTester.End();
            timeTester.Report(true);
        }
    }
}
