﻿using Extension;
using Alg;
using System;

namespace DriverConsoleApp
{
    public static class Program
    {
        public static int[] testArray = new int[50000];

        public static void Main(string[] args)
        {
            Random rand = new Random();
            for (int i = 0; i < testArray.Length; i++)
                testArray[i] = rand.Next(1, 1000);
            int length = testArray.Length;
            Console.SetWindowSize(120, 40);
            Console.WriteLine($"Testing with array of size {length}");

            BenchMark.BenchMark timeTester = new BenchMark.BenchMark();

            timeTester.Start();

            testArray.MergeSort(0, length - 1);
            timeTester.Mark("MergeSort");

            testArray.SelectionSort();
            timeTester.Mark("SelectionSort");

            testArray.InsertionSort();
            timeTester.Mark("InsertionSort");

            testArray.BubbleSort();
            timeTester.Mark("BubbleSort");

            timeTester.End();
            timeTester.Report(false);
        }
    }
}
