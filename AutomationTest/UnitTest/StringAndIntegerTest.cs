using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringAndIntergerOperation;

namespace UnitTest
{
    [TestClass]
    public class StringAndIntegerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string testStr = "Hi tester";
            StringIntegerOperation.CountNumberOfWords(ref testStr);
        }

        [TestMethod]
        public void TestMethod2()
        {

            StringIntegerOperation.CheckNumberPalindrome(121);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string testStr = "Automation";
            StringIntegerOperation.RemoveRepetitiveCharacters(ref testStr);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int[] arr = {24,1,30,5,62,};
            StringIntegerOperation.SortArrayInAschendindOrder(ref arr);
        }
    }
}
