/// Sources: 
/// https://www.geeksforgeeks.org/fundamentals-of-algorithms/
/// https://travcav.medium.com/why-reverse-loops-are-faster-a09d65473006

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
            // edge cases
            if (array is null || array.Length == 0)
                return null;

            if (array.Length == 1)
                return array;

            int length = array.Length;  // array.Length is an expensive instruction, the for loop will execute it every time it iterates

            // O(n^2) - 2 for loops
            for (int i = 0; i < length; i++)
            {
                // find the minimum of the array
                // Step 1 assume min = current i
                int min = i;

                // Step 2 find the minimum element in the sub array
                for (int j = i + 1; j < length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }

                // Step 3 swap min and i
                array.Swap(i, min);
            }

            return array;
        }

        /// <summary>
        /// Bubble sort:
        /// Bubble Sort is the simplest sorting algorithm that works by repeatedly swapping the adjacent elements if they are in wrong order.
        /// Example: 
        /// First Pass: 
        /// ( 5 1 4 2 8 ) –> ( 1 5 4 2 8 ), Here, algorithm compares the first two elements, and swaps since 5 > 1. 
        /// ( 1 5 4 2 8 ) –>  ( 1 4 5 2 8 ), Swap since 5 > 4 
        /// ( 1 4 5 2 8 ) –>  ( 1 4 2 5 8 ), Swap since 5 > 2 
        /// ( 1 4 2 5 8 ) –> ( 1 4 2 5 8 ), Now, since these elements are already in order(8 > 5), algorithm does not swap them.
        /// Second Pass: 
        /// ( 1 4 2 5 8 ) –> ( 1 4 2 5 8 ) 
        /// ( 1 4 2 5 8 ) –> ( 1 2 4 5 8 ), Swap since 4 > 2 
        /// ( 1 2 4 5 8 ) –> ( 1 2 4 5 8 ) 
        /// ( 1 2 4 5 8 ) –>  ( 1 2 4 5 8 ) 
        /// Now, the array is already sorted, but our algorithm does not know if it is completed.The algorithm needs one whole pass without any swap to know it is sorted.
        /// Third Pass: 
        /// ( 1 2 4 5 8 ) –> ( 1 2 4 5 8 ) 
        /// ( 1 2 4 5 8 ) –> ( 1 2 4 5 8 ) 
        /// ( 1 2 4 5 8 ) –> ( 1 2 4 5 8 ) 
        /// ( 1 2 4 5 8 ) –> ( 1 2 4 5 8 ) 
        /// </summary>
        /// <param name="array">The un-sorted array</param>
        /// <returns>The array sorted</returns>
        public static int[] BubbleSort(this int[] array)
        {
            // edge cases
            if (array is null || array.Length == 0)
                return null;

            if (array.Length == 1)
                return array;

            int length = array.Length;  // array.Length is an expensive instruction, the for loop will execute it every time it iterates

            for (int i = 0; i < length; i++)
            {
                for(int j = i + 1; j < length; j++)
                {
                    if (array[i] > array[j])
                    {
                        array.Swap(i, j);
                    }
                }
            }

            return array;
        }

        /// <summary>
        /// Insertion sort:
        /// Insertion sort is a simple sorting algorithm that works similar to the way you sort playing cards in your hands. The array is virtually split into a sorted and an unsorted part. Values from the unsorted part are picked and placed at the correct position in the sorted part.
        /// Algorithm
        ///     To sort an array of size n in ascending order: 
        ///         1: Iterate from arr[1] to arr[n] over the array.
        ///         2: Compare the current element (key) to its predecessor. 
        ///         3: If the key element is smaller than its predecessor, compare it to the elements before. Move the greater elements one position up to make space for the swapped element.
        /// </summary>
        /// <param name="array">The un-sorted array</param>
        /// <returns>The array sorted</returns>
        public static int[] InsertionSort(this int[] array)
        {
            // https://travcav.medium.com/why-reverse-loops-are-faster-a09d65473006
            // edge cases
            if (array is null || array.Length == 0)
                return null;

            if (array.Length == 1)
                return array;

            int length = array.Length;  // array.Length is an expensive instruction, the for loop will execute it every time it iterates

            // step 1: i = 1 to i = array.Length
            for (int i = 1; i < length; i++)
            {
                // step2: for all of the array indices less than i, this compares the key element array[i] to it's predecessors
                // in these cases, a reverse loop is faster, because it's cheaper to compare j > 0 than it is to compare j < i - 1
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;  // reverse through subarray
                }
                array[j + 1] = key;
            }

            return array;
        }

        /// <summary>
        /// Merge sort:
        /// Merge Sort is a Divide and Conquer algorithm. It divides the input array into two halves, 
        /// calls itself for the two halves, and then merges the two sorted halves. 
        /// The merge() function is used for merging two halves. 
        /// The merge(arr, l, m, r) is a key process that assumes that arr[l..m] 
        /// and arr[m+1..r] are sorted and merges the two sorted sub-arrays into one. 
        /// </summary>
        /// <param name="array">The un-sorted array</param>
        /// <param name="left">The left half array</param>
        /// <param name="right">The right half array</param>
        /// <param name="middle">The middle of the array</param>
        /// <returns>The array sorted</returns>
        public static int[] MergeSort(this int[] array, int left, int right)
        {
            if (array is null || array.Length == 0)
                return null;

            if (array.Length == 1)
                return array;

            if (right > left)
            {
                int middle = left + (right - left) / 2;
                array.MergeSort(left, middle);
                array.MergeSort(middle + 1, right);
                array.Merge(left, middle, right);
            }

            return array;
        }

        /// <summary>
        /// Heap sort:
        /// Heap sort is a comparison-based sorting technique based on Binary Heap data structure. 
        /// It is similar to selection sort where we first find the minimum element and place 
        /// the minimum element at the beginning. We repeat the same process for the remaining elements.
        /// </summary>
        /// <param name="array">The un-sorted array</param>
        /// <returns>The array sorted</returns>
        public static int[] HeapSort(this int[] array)
        {
            if (array is null || array.Length == 0)
                return null;

            if (array.Length == 1)
                return array;

            int length = array.Length;

            for(int i = (length/2); i >= 0; i--) {
                array.Heapify(i, length);
            }

            for(int j = length - 1; j > 0; j--)
            {
                array.Swap(0, j);
                array.Heapify(0, j);
            }

            return array;
        }

        /// <summary>
        /// Quick Sort:
        /// It picks an element as pivot and partitions the given array around the picked pivot. 
        /// There are many different versions of quickSort that pick pivot in different ways. 
        ///
        /// 1. Always pick first element as pivot.
        /// 2. Always pick last element as pivot (implemented below).
        /// 3. Pick a random element as pivot.
        /// 4. Pick median as pivot.
        /// 
        /// The key process in quickSort is partition(). Target of partitions is, given an array and an element x of array as pivot, 
        /// put x at its correct position in sorted array and put all smaller elements(smaller than x) before x, and put all greater 
        /// elements(greater than x) after x.
        /// 
        /// All this should be done in linear time.
        /// </summary>
        /// <param name="array">The un-sorted array</param>
        /// <param name="low">The low starting index</param>
        /// <param name="high">The high ending index</param>
        /// <returns>The array sorted</returns>
        public static int[] QuickSort(this int[] array, int low, int high)
        {
            if (array is null || array.Length == 0)
                return null;

            if (array.Length == 1)
                return array;

            if (low < high)
            {
                int partitionIndex = array.Partition(low, high);

                array.QuickSort(low, partitionIndex - 1);
                array.QuickSort(partitionIndex + 1, high);
            }
            return array;
        }
    }
}
