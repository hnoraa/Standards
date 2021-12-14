using Alg;
using NUnit.Framework;
using System;

namespace T.Search
{
    [TestFixture]
    public class LinearSearch
    {
        public int[] array = { 99, 12, 23, 400, 7, 17, 20, 35, 100, 999, 0, 80, 80, 99, 12, 23, 67 };
        public int searchFirst;
        public int searchLast;
        public int searchMiddle;
        public int searchNotFound;
        public int searchDuplicate;
        public int length;
        public int middle;

        [SetUp]
        public void SetUp()
        {
            length = array.Length - 1;
            middle = Convert.ToInt32(length / 2);
            searchFirst = array[0];
            searchLast = array[length];
            searchMiddle = array[middle];
            searchNotFound = 1000;
            searchDuplicate = 12;
        }

        [Test]
        public void SearchFirst()
        {
            int? search;
            search = array.LinearSearch(searchFirst);
            Assert.AreEqual(array[0], array[(int)search]);
        }

        [Test]
        public void SearchLast()
        {
            int? search;
            search = array.LinearSearch(searchLast);
            Assert.AreEqual(array[length], array[(int)search]);
        }

        [Test]
        public void SearchMiddle()
        {
            int? search;
            search = array.LinearSearch(searchMiddle);
            Assert.AreEqual(array[middle], array[(int)search]);
        }

        [Test]
        public void SearchNotFound()
        {
            int? search;
            search = array.LinearSearch(searchNotFound);
            Assert.IsNull(search);
        }

        [Test]
        public void SearchDuplicate()
        {
            int? search;
            search = array.LinearSearch(searchDuplicate);
            Assert.IsNotNull(search);
        }
    }
}
