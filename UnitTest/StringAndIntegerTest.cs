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
            
            Assert.AreEqual(2,StringIntegerOperation.CountNumberOfWords(ref testStr));
        }

        [TestMethod]
        public void TestMethod2()
        {
            int num = 121;
           Assert.AreEqual(121, StringIntegerOperation.CheckNumberPalindrome(num));
        }

        [TestMethod]
        public void TestMethod3()
        {
          string testStr = "Automation";
          string result=  StringIntegerOperation.RemoveRepetitiveCharacters(ref testStr);

          Assert.AreEqual("Automin", result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int[] arr = {24,1,30,1,24};
            int[] arr1={1,1,24,24,30}; 
           StringIntegerOperation.SortArrayInAschendindOrder(ref arr);
           
        }
    }
}
