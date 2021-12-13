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

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void SortArrayAllZero()
        {
            int[] arrayTest1 = new int[3];
            int length = array1.Length;
            Array.Copy(array1, arrayTest1, array1.Length);
            array1.MergeSort(0, length - 1);
            Assert.AreEqual(arrayTest1, array1);
        }

        [Test]
        public void SortArrayLengthOne()
        {
            int[] arrayTest = new int[1];
            int length = array2.Length;
            array2.MergeSort(0, length - 1);
            Array.Copy(array2, arrayTest, array2.Length);
            Assert.AreEqual(arrayTest, array2);
        }

        [Test]
        public void SortArrayBackwards()
        {
            int[] arrayTest = { 99, 100 };
            int length = array3.Length;
            array3.MergeSort(0, length - 1);
            Assert.AreEqual(arrayTest, array3);
        }

        [Test]
        public void SortMixedArray()
        {
            int[] arrayTest = { 0, 91, 92, 93, 94, 95, 96, 97, 98, 100 };
            int length = array4.Length;
            array4.MergeSort(0, length - 1);
            Assert.AreEqual(arrayTest, array4);
        }
    }
}
