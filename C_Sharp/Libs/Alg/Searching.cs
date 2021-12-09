using System;
using System.Collections.Generic;
using System.Text;

namespace Alg
{
    public static class Searching
    {
        public static int? LinearSearch(this int[] array, int searchTerm)
        {
            int length = array.Length;
            int i = 0;
            while (i < length)
            {
                if (array[i] == searchTerm)
                {
                    return i;
                }
                i++;
            }
            return null;
        }

        public static int? BinarySearch(this int[] array, int searchTerm, int left, int right)
        {
            int middle = left + (right - left) / 2;

            if(right >= left)
            {
                if (array[middle] == searchTerm)
                {
                    return middle;
                }
                
                if (array[middle] > searchTerm)
                {
                    return BinarySearch(array, searchTerm, left, middle - 1);
                }
                return BinarySearch(array, searchTerm, middle + 1, right);
            }

            return null;
        }

        public static int? JumpSearch(this int[] array, int searchTerm)
        {
            int size = array.Length;
            int step = Convert.ToInt32(Math.Floor(Math.Sqrt(size)));
            int start = 0;
            int end = step;

            while(array[end] <= searchTerm && end < size)
            {
                start = end;
                end += step;

                if (end > size - 1)
                {
                    end = size;
                    break;
                }
            }

            for(int i = start; i < end; i++)
            {
                if(array[i] == searchTerm)
                {
                    return i;
                }
            }

            return null;
        }
    }
}
