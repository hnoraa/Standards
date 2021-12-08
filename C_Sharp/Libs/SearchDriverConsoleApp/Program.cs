using Alg;
using System;

namespace SearchDriverConsoleApp
{
    public static class Program
    {
        public static int[] testArray = { 1, 2, 3, 4, 5, 6, 7, 8 };

        public static void Main(string[] args)
        {
            Console.WriteLine($"Array: {String.Join(",", testArray)}");
            string value = "";
            int searchItem = 0;

            while (value != "q")
            {
                Console.WriteLine("Enter a search value (type 'q' to quit): ");
                value = Console.ReadLine().ToLower();

                if (value != "q")
                {
                    if (!int.TryParse(value, out searchItem))
                    {
                        Console.WriteLine("Please enter an integer value");
                        continue;
                    }

                    int? retVal = Searching.LinearSearch(testArray, searchItem);
                    if (retVal == null)
                    {
                        Console.WriteLine($"{searchItem} not found in testArray");
                        continue;
                    }
                    Console.WriteLine($"Found {searchItem} in testArray[{retVal}]!");
                }
            }
        }

        public static bool Find(int value)
        {
            int i = testArray.Length - 1;
            while (i >= 0)
            {
                if (testArray[i] == value)
                    return true;
                i--;
            }
            return false;
        }
    }
}
