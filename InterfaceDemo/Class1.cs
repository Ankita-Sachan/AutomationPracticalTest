using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
   public abstract class Class1 :Interface1
    {
        
       public  void A()
        {
            throw new NotImplementedException();
        }

         public abstract void MethodB();
    }
}
