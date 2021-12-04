using Extension;
using Alg;
using System;

namespace DriverConsoleApp
{
    public static class Program
    {
        //public static int[] testArray = new int[50000];
        //public static int[] testArray = new int[10];

        public static void Main(string[] args)
        {
            /*
            Random rand = new Random();
            for (int i = 0; i < testArray.Length; i++)
                testArray[i] = rand.Next(1, 1000);
            */
            //int[] testArray = { 9, 6, 3, 1, 2, 5, 4, 7, 8, 0};
            int[] testArray = { 9, 6, 3, 1, 2, 5};
            int length = testArray.Length;

            Console.WriteLine($"Testing with array of size {length}");

            for (int i = 0; i < length; i++)
            {
                Console.Write($"{testArray[i]} ");
            }
            Console.WriteLine();

            BenchMark.BenchMark timeTester = new BenchMark.BenchMark();

            timeTester.Start();

            MergeSort(testArray, 0, length);

            timeTester.End();
            timeTester.Report(false);
        }

        public static void MergeSort(int[] array, int l, int r)
        {
            if (r > l)
            {
                int m = (l + r) / 2;
                Console.WriteLine($"l:{l}, r:{r}, m:{m}");

                MergeSort(array, l, m);
                MergeSort(array, m + 1, r);
                Merge(array, l, r, m);
            }
        }

        public static void Merge(int[] array, int l, int r, int m)
        {
            // sort first sub array
            int[] left = new int[m - l + 1];
            int[] right = new int[r - m];
            int leftL = left.Length;
            int rightL = right.Length;
            int length = array.Length;

            Console.WriteLine($"left[] length: {left.Length}, right[] length: {right.Length}, m: {m}");

            // edge case
            if (left.Length == 0 && right.Length == 0)
                return;

            for (int i = 0; i < leftL; i++)
            {
                left[i] = array[i];
                Console.Write($"{left[i]} ");
            }

            Console.WriteLine();

            for (int i = 1; i < rightL; i++)
            {
                right[i] = array[m + i];
                Console.Write($"{right[i]} ");
            }

            Console.WriteLine();

            int ii = 0;
            int j = 0;
            for (int k = l; k < r; k++)
            {
               if(left[ii] <= right[j])
                {
                    ii++;
                }else
                {
                    j++;
                }
            }
        }
    }
}
