using Extension;
using Alg;
using System;

namespace DriverConsoleApp
{
    public static class Program
    {
        //public static int[] list = { 82, 901, 100, 12, 150, 77, 55, 23 };
        public static int[] list = { 9, 7, 3, 2, 3, 3, 2, 1, 0, 7, 8, 6, 9, 9, 9 };

        public static void Main(string[] args)
        {
            //Random rand = new Random();
            //for (int i = 0; i < testArray.Length; i++)
            //    testArray[i] = rand.Next(1, 1000);

            Console.SetWindowSize(120, 40);
            Console.WriteLine($"list: {String.Join(",", list)}");
            //BenchMark.BenchMark timeTester = new BenchMark.BenchMark();

            //timeTester.Start();

            list.CountingSort();
            Console.WriteLine($"list: {String.Join(",", list)}");
            //timeTester.End();
            //timeTester.Report(false);
        }

        public static int GetMax(this int[] array)
        {
            int length = array.Length - 1;
            int max = array[0];
            for(int i = length; i >= 0; i--)
            {
                if(array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }
    
        public static int[] CountingSort(this int[] array)
        {
            int length = array.Length;
            int max = array.GetMax();
            int[] counts = new int[max + 1];
            int[] output = new int[max + 1];

            for(int i = 0; i < length; i++)
            {
                for(int j = 0; j < counts.Length; j++)
                {
                    if(array[i] == j)
                    {
                        counts[j]++;
                    }
                }
            }

            Console.WriteLine($"{String.Join(",", counts)}");

            for (int k = 1; k < counts.Length; k++)
            {
                counts[k] += counts[k - 1];
            }

            Console.WriteLine($"{String.Join(",", counts)}");

            for (int x = output.Length - 1; x >= 0; x--)
            {
                output[array[x]] = array[x];
                //counts[array[x]]--;
            }

            Console.WriteLine($"{String.Join(",", output)}");

            return array;
        }
    }
}
