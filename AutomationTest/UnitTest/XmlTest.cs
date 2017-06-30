using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XmlFileOperation;
using System.IO;


namespace UnitTest
{
    [TestClass]
    public class XmlTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string fileName = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Persons.xml");
            XmlOperations.CreateXmlFile(fileName);
           
            XmlOperations.DeleteNode(fileName,1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string fileName = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Persons.xml");
            XmlOperations.CreateXmlFile(fileName);
            XmlOperations.GetNode(fileName, "1");
        }

        [TestMethod]
        public void TestMethod3()
        {
            string fileName = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Persons.xml");
            XmlOperations.CreateXmlFile(fileName);
            //id3 should be greater than id2 and less than id1
           
            Person person = new Person();
            person.id = 1;
            person.Name = "Test name";
            person.Age =12;
            person.Gender = "Female";
            XmlOperations.InsertNode(fileName, person);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string fileName = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Persons.xml");
            XmlOperations.CreateXmlFile(fileName);
            XmlOperations.ReadXml(fileName);
        }

        [TestMethod]
        public void TestMethod5()
        {
            string fileName = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Persons.xml");
            XmlOperations.CreateXmlFile(fileName);
            XmlOperations.DeleteNode(fileName, 1);
        }


    }
}
