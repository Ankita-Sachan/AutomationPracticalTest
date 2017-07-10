using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CollectionCategory;

namespace UnitTest
{
    [TestClass]
    public class CollectionTest
    {
        List<int> lst = new List<int>() { 1,2,3,4,5,2};
        Operations operations = new Operations();

        [TestMethod]
        public void TestMethod1()
        {
            operations.Remove(ref lst, 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
           int pos = operations.Find(ref lst, 3);
        }
        [TestMethod]
        public void TestMethod3()
        {
            operations.Insert(lst, 2, 10);
         }

    }
}
