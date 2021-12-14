using Alg;
using NUnit.Framework;
using System;

namespace T.Sort
{
    [TestFixture]
    public class MergeSort
    {
        public int[] array1 = { 0, 0, 0 };
        public int[] array2 = { 1 };
        public int[] array3 = { 100, 99 };
        public int[] array4 = { 100, 98, 97, 96, 95, 94, 0, 92, 93, 91 };
        public int[] array5 = { 0, 2, 3, 11, 11, 11, 0, 2, 3, 99 };
        public int[] array6 = new int[100000];
        public int[] array7 = null;

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
            int length = array1.Length;
            int[] arrayTest = new int[length];
            Array.Copy(array1, arrayTest, array1.Length);
            array1.MergeSort(0, length - 1);
            Array.Sort(arrayTest);
            Assert.AreEqual(arrayTest, array1);
        }

        [Test]
        public void SortArrayLengthOne()
        {
            int length = array2.Length;
            int[] arrayTest = new int[length];
            Array.Copy(array2, arrayTest, array2.Length);
            array2.MergeSort(0, length - 1);
            Array.Sort(arrayTest);
            Assert.AreEqual(arrayTest, array2);
        }

        [Test]
        public void SortArrayBackwards()
        {
            int length = array3.Length;
            int[] arrayTest = new int[length];
            Array.Copy(array3, arrayTest, array3.Length);
            array3.MergeSort(0, length - 1);
            Array.Sort(arrayTest);
            Assert.AreEqual(arrayTest, array3);
        }

        [Test]
        public void SortMixedArray()
        {
            int length = array4.Length;
            int[] arrayTest = new int[length];
            Array.Copy(array4, arrayTest, array4.Length);
            array4.MergeSort(0, length - 1);
            Array.Sort(arrayTest);
            Assert.AreEqual(arrayTest, array4);
        }

        [Test]
        public void SortWithDuplicatesArray()
        {
            int length = array5.Length;
            int[] arrayTest = new int[length];
            Array.Copy(array5, arrayTest, array5.Length);
            array5.MergeSort(0, length - 1);
            Array.Sort(arrayTest);
            Assert.AreEqual(arrayTest, array5);
        }

        [Test]
        public void SortLargeRandArray()
        {
            int length = array6.Length;
            int[] arrayTest = new int[length];
            Array.Copy(array6, arrayTest, array6.Length);
            array6.MergeSort(0, length - 1);
            Array.Sort(arrayTest);
            Assert.AreEqual(arrayTest, array6);
        }

        [Test]
        public void SortNullArray()
        {
            array7.BubbleSort();
            Assert.IsNull(array7);
        }
    }
}
