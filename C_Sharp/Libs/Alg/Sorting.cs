﻿///https://www.geeksforgeeks.org/fundamentals-of-algorithms/
using System;
using System.Collections.Generic;
using System.Text;

namespace Alg
{
    /// <summary>
    /// Sorting algorithms
    /// </summary>
    public static class Sorting
    {
        /// <summary>
        /// Selection sort:
        /// The selection sort algorithm sorts an array by repeatedly finding the minimum element (considering ascending order) from unsorted part and putting it at the beginning. 
        /// The algorithm maintains two subarrays in a given array.
        /// 1) The subarray which is already sorted.
        /// 2) Remaining subarray which is unsorted.
        /// In every iteration of selection sort, the minimum element(considering ascending order) from the unsorted subarray is picked and moved to the sorted subarray.
        /// </summary>
        /// <param name="array">The un-sorted array</param>
        /// <returns>The array sorted</returns>
        public static int[] SelectionSort(this int[] array)
        {
            // edge case
            if (array.Length == 1)
                return array;

            // O(n^2) - 2 for loops
            for (int i = 0; i < array.Length - 1; i++)
            {
                // find the minimum of the array
                // Step 1 assume min = current i
                int min = i;

                // Step 2 find the minimum element in the sub array
                for (int j = i + 1; j < array.Length - 1; j++)
                {
                    if(array[j] < array[min])
                    {
                        min = j;
                    }
                }

                // Step 3 swap min and i
                int temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }

            return array;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array">The un-sorted array</param>
        /// <returns>The array sorted</returns>
        public static int[] BubbleSort(this int[] array)
        {
            // edge case
            if (array.Length == 1)
                return array;

            for(int i = 0; i < array.Length; i++)
            {
                for(int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }
    }
}