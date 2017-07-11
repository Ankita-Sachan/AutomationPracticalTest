using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextFileOperation;
using System.Collections;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class TextFileTest
    {
        [TestMethod]
        public void CreateFile()
        {
            Operations op = new Operations();
            string data = "Hi please write over here.\t\n";
            Assert.AreEqual(true, op.CreateFile(@"D:\test\test.txt", data));
        }
        [TestMethod]
        public void SearchFileInDirectory()
        {
            Operations op = new Operations();
          List<string> lst =  new List<string>();
          lst.Add(@"D:\test\test.txt");
            CollectionAssert.AreEqual(lst, op.SearchFileInDirectory(@"D:\test\", "test.txt"));
        }
        [TestMethod]
        public void RenameFile()
        {
            Operations op = new Operations();
            string sourceFilePath = @"D:\test\test.txt";
            string newFilePath=@"D:\test\test1.txt";

            Assert.AreEqual(true, op.RenameFile(sourceFilePath, newFilePath));
        }
   
         [TestMethod]
        public void CopyFile()
        {
            Operations op = new Operations();
            string sourceFilePath = @"D:\test\test.txt";
            string destinationFilePath = @"D:\test\test1.txt";

            Assert.AreEqual(true, op.CopyFile(sourceFilePath, destinationFilePath));
        }
         [TestMethod]
         public void DeleteFile()
         {
             Operations op = new Operations();

             Assert.AreEqual(true, op.DeleteFile(@"D:\test", "test1.txt"));
         }
    }
}
