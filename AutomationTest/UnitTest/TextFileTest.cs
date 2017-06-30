using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextFileOperation;


namespace UnitTest
{
    [TestClass]
    public class TextFileTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Operations op = new Operations();
            string data = "Hi please write over here.\t\n";
            op.CreateFile(@"D:\test\test.txt",data);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Operations op = new Operations();
            op.SearchFileInDirectory(@"D:\test\","test.txt");
        }
        [TestMethod]
        public void TestMethod3()
        {
            Operations op = new Operations();
            string sourceFilePath = @"D:\test\test.txt";
            string newFilePath=@"D:\test\test1.txt";
            op.RenameFile(sourceFilePath,newFilePath );
        }
   
         [TestMethod]
        public void TestMethod4()
        {
            Operations op = new Operations();
            string sourceFilePath = @"D:\test\test.txt";
            string destinationFilePath = @"D:\test\test1.txt";
             op.CopyFile(sourceFilePath, destinationFilePath);
        }
         [TestMethod]
         public void TestMethod5()
         {
             Operations op = new Operations();
             op.DeleteFile(@"D:\test", "test.txt");
         }
    }
}
