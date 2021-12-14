using Alg;
using NUnit.Framework;
using System;

namespace T.Sort
{
    [TestFixture]
    public class InsertionSort
    {
        public int[] array1 = { 0, 0, 0 };
        public int[] array2 = { 1 };
        public int[] array3 = { 100, 99 };
        public int[] array4 = { 100, 98, 97, 96, 95, 94, 0, 92, 93, 91 };
        public int[] array5 = { 0, 2, 3, 11, 11, 11, 0, 2, 3, 99 };
        public int[] array6 = new int[100000];

        [SetUp]
        public void SetUp()
        {
            Random rand = new Random();
            for (int i = 0; i < array6.Length; i++)
                array6[i] = rand.Next(1, 1000);
        }

        [Test]
        public void SortArrayAllZero()
        {
            int[] arrayTest = new int[array1.Length];
            Array.Copy(array1, arrayTest, array1.Length);
            array1.InsertionSort();
            Array.Sort(arrayTest);
            Assert.AreEqual(arrayTest, array1);
        }

        [Test]
        public void SortArrayLengthOne()
        {
            int[] arrayTest = new int[array2.Length];
            Array.Copy(array2, arrayTest, array2.Length);
            array2.InsertionSort();
            Array.Sort(arrayTest);
            Assert.AreEqual(arrayTest, array2);
        }

        [Test]
        public void SortArrayBackwards()
        {
            int[] arrayTest = new int[array3.Length];
            Array.Copy(array3, arrayTest, array3.Length);
            array3.InsertionSort();
            Array.Sort(arrayTest);
            Assert.AreEqual(arrayTest, array3);
        }

        [Test]
        public void SortMixedArray()
        {
            int[] arrayTest = new int[array4.Length];
            Array.Copy(array4, arrayTest, array4.Length);
            array4.InsertionSort();
            Array.Sort(arrayTest);
            Assert.AreEqual(arrayTest, array4);
        }

        [Test]
        public void SortWithDuplicatesArray()
        {
            int[] arrayTest = new int[array5.Length];
            Array.Copy(array5, arrayTest, array5.Length);
            array5.InsertionSort();
            Array.Sort(arrayTest);
            Assert.AreEqual(arrayTest, array5);
        }

        [Test]
        public void SortLargeRandArray()
        {
            int[] arrayTest = new int[array6.Length];
            Array.Copy(array6, arrayTest, array6.Length);
            array6.InsertionSort();
            Array.Sort(arrayTest);
            Assert.AreEqual(arrayTest, array6);
        }
    }
}
