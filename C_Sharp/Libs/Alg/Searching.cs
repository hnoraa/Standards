using System;
using System.Collections.Generic;
using System.Text;

namespace Alg
{
    public static class Searching
    {
        public static int? LinearSearch(int[] array, int searchTerm)
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
    }
}
