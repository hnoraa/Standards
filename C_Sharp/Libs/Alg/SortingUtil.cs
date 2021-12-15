using System;
using System.Collections.Generic;
using System.Text;

namespace Alg
{
    public static class SortingUtil
    {
        /// <summary>
        /// Swap two indices of an array.
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="firstIndex">The first index to swap</param>
        /// <param name="secondIndex">The second index to swap</param>
        public static void Swap(this int[] array, int firstIndex, int secondIndex)
        {
            int temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }

        /// <summary>
        /// Merge for merge sort. This is the Conquer of the Divide and Conquer of Merge Sort
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left">The left bound of the array</param>
        /// <param name="middle">The middle of the array</param>
        /// <param name="right">The right of the array</param>
        public static void Merge(this int[] array, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];
            int i, j = 0;

            for (i = 0; i < n1; i++)
            {
                leftArray[i] = array[left + i];
            }

            for (j = 0; j < n2; j++)
            {
                rightArray[j] = array[middle + j + 1];
            }

            i = j = 0;
            int k = left;

            // initial copy
            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            // copy over remainders
            while (i < n1)
            {
                array[k] = leftArray[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                array[k] = rightArray[j];
                j++;
                k++;
            }
        }

        /// <summary>
        /// Heapify:
        /// The process of reshaping a binary tree into a Heap data structure is known as ‘heapify’. 
        /// A binary tree is a tree data structure that has two child nodes at max. 
        /// If a node’s children nodes are ‘heapified’, then only ‘heapify’ process can be applied over 
        /// that node. A heap should always be a complete binary tree. 
        /// 
        /// Starting from a complete binary tree, we can modify it to become a Max-Heap by running 
        /// a function called ‘heapify’ on all the non-leaf elements of the heap.
        /// i.e. ‘heapify’ uses recursion.
        /// </summary>
        /// <param name="array">The un-sorted array</param>
        /// <param name="index">The current index</param>
        /// <param name="length">The length of the array</param>
        public static void Heapify(this int[] array, int index, int length)
        {
            int largest = index;
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            if (left < length && array[left] > array[largest])
            {
                largest = left;
            }

            if (right < length && array[right] > array[largest])
            {
                largest = right;
            }

            if (largest != index)
            {
                int temp = array[index];
                array[index] = array[largest];
                array[largest] = temp;

                Heapify(array, largest, length);
            }
        }

        /// <summary>
        /// Partition Algorithm:
        /// There can be many ways to do partition. 
        /// The logic is simple, we start from the leftmost element and 
        /// keep track of index of smaller (or equal to) elements as i. 
        /// While traversing, if we find a smaller element, we swap current 
        /// element with arr[i]. Otherwise we ignore current element. 
        /// </summary>
        /// <param name="array">The un-sorted array</param>
        /// <param name="low">The low starting index</param>
        /// <param name="high">The high ending index</param>
        /// <returns>The partition index</returns>
        public static int Partition(this int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = (low - 1);

            for(int j = low; j <= high - 1; j++)
            {
                if(array[j] < pivot)
                {
                    i++;
                    array.Swap(i, j);
                }
            }

            array.Swap((i + 1), high);
            return (i + 1);
        }
    }
}
