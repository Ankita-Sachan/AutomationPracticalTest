using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    public class Derived :Interface1,Interface2
    {
        public void A()
        {
            Console.WriteLine("In A");
        }

        public void B()
        {
            Console.WriteLine("In B");
        }


         void Interface1.C()
        {
            Console.WriteLine("In C of interface1");
        }
         void Interface2.C()
        {
            Console.WriteLine("In C of interface1");
        }
    }
}
