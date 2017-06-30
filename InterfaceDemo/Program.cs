using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Interface1 derived1 = new Derived();
            derived1.A();
            derived1.C();
            Interface2 derived2 = new Derived();
            derived2.B();
            derived2.C();
            Console.ReadLine();
        }
    }
}
