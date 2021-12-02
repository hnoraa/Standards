using System;
using System.Collections.Generic;
using System.Linq;

namespace SubArrayTesting
{
    /// <summary>
    /// Extension class with Generic methods
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// Get a sub array by using System.Copy
        /// </summary>
        /// <typeparam name="T">Generic array</typeparam>
        /// <param name="array">The array to get a sub array from</param>
        /// <param name="offset">The starting point (index) for the sub array</param>
        /// <param name="length">The length of the sub array</param>
        /// <returns>A sub array specified by the offset and length parameters</returns>
        public static T[] SubArrayCopy<T>(this T[] array, int offset, int length)
        {
            ///NOTE: This seems to be the most efficient (also doesn't need additional libraries)
            T[] result = new T[length];
            Array.Copy(array, offset, result, 0, length);
            return result;
        }

        /// <summary>
        /// Get a sub array by using Enumerable.Skip and Enumerable.Take (from System.Linq)
        /// </summary>
        /// <typeparam name="T">Generic array</typeparam>
        /// <param name="array">The array to get a sub array from</param>
        /// <param name="offset">The starting point (index) for the sub array</param>
        /// <param name="length">The length of the sub array</param>
        /// <returns>A sub array specified by the offset and length parameters</returns>
        public static T[] SubArraySkip<T>(this T[] array, int offset, int length)
        {
            return array.Skip(offset)
                .Take(length)
                .ToArray();
        }

        /// <summary>
        /// Get a sub array by using ArraySegment
        /// </summary>
        /// <typeparam name="T">Generic array</typeparam>
        /// <param name="array">The array to get a sub array from</param>
        /// <param name="offset">The starting point (index) for the sub array</param>
        /// <param name="length">The length of the sub array</param>
        /// <returns>A sub array specified by the offset and length parameters</returns>
        public static T[] SubArraySegment<T>(this T[] array, int offset, int length)
        {
            return new ArraySegment<T>(array, offset, length)
                .ToArray();
        }

        /// <summary>
        /// Get a sub array by using List.GetRange (from System.Collections.Generic)
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="array">The array to get a sub array from</param>
        /// <param name="offset">The starting point (index) for the sub array</param>
        /// <param name="length">The length of the sub array</param>
        /// <returns>A sub array specified by the offset and length parameters</returns>
        public static T[] SubArrayGetRange<T>(this T[] array, int offset, int length)
        {
            ///NOTE: This seems to be the slowest
            return new List<T>(array)
                .GetRange(offset, length)
                .ToArray();
        }

        /// <summary>
        /// Reset an array to it's initialized values
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="array">The array to re-initialize</param>
        public static void ResetArray<T>(this T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                // default(T) will return the default value for whatever type T is
                // For example, if T is an int, default(T) would return 0
                array[i] = default(T);
            }
        }
    }
}
