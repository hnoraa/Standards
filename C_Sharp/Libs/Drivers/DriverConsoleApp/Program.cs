﻿using Extension;
using Alg;
using System;

namespace DriverConsoleApp
{
    public static class Program
    {
        public static int[] array1 = { 0, 0, 0 };
        public static int[] array2 = { 1 };
        public static int[] array3 = { 100, 99 };
        public static int[] array4 = { 100, 98, 97, 96, 95, 94, 0, 92, 93, 91 };
        public static int[] array5 = { 0, 2, 3, 11, 11, 11, 0, 2, 3, 99 };

        public static void Main(string[] args)
        {
            //Random rand = new Random();
            //for (int i = 0; i < testArray.Length; i++)
            //    testArray[i] = rand.Next(1, 1000);

            //int[] testArray = { 99, 7, 8, 245, 230, 1, 0 };
            //int length = testArray.Length;
            Console.SetWindowSize(120, 40);

            BenchMark.BenchMark timeTester = new BenchMark.BenchMark();

            timeTester.Start();

            // insertion sort
            array1.QuickSort(0, array1.Length-1);
            Console.WriteLine($"{String.Join(",", array1)}");

            array2.QuickSort(0, array2.Length-1);
            Console.WriteLine($"{String.Join(",", array2)}");

            array3.QuickSort(0, array3.Length-1);
            Console.WriteLine($"{String.Join(",", array3)}");

            array4.QuickSort(0, array4.Length-1);
            Console.WriteLine($"{String.Join(",", array4)}");

            array5.QuickSort(0, array5.Length-1);
            Console.WriteLine($"{String.Join(",", array5)}");

            timeTester.End();
            timeTester.Report(false);
        }
    }
}
