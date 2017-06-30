using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfaceDemo;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Interface1 derived1 = new Derived();
            derived1.A();
            derived1.C();
            Interface2 derived2 = new Derived();
            derived2.B();
            derived2.C();
        }
    }
}
