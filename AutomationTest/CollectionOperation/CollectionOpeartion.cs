using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionCategory
{
    public class CollectionOpeartion
    {
        static void Main(string[] args)
        {
            List<int> lst = new List<int>();
            int x;
            int pos = -1;
            lst.Add(1);
            lst.Add(2);
            lst.Add(3);
            lst.Add(4);
            lst.Add(5);
            lst.Add(2);
            
            Operations operations = new Operations();
            operations.Display(ref lst);
            bool correct = true;
            int option;
            while (correct)
            {
                Console.WriteLine("\nSelect Following Option/s\n");

                Console.WriteLine("1 - Remove Number.");
                Console.WriteLine("2 - Find Position of number");
                Console.WriteLine("3 - Insert Number");
                Console.WriteLine("5 - Exit\n");

                Console.WriteLine("Please provide valid input 1 or 2 or 3.\n");
                while (!Int32.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Please provide valid input 1 or 2 or 3.\n");
                }
                switch (option)
                {
                    case 1:
                        Console.Write("Number = ");
                        x = Convert.ToInt32(Console.ReadLine());

                        operations.Remove(ref lst, x);
                        operations.Display(ref lst);
                        break;
                    case 2:
                        Console.Write("Number = ");
                        x = Convert.ToInt32(Console.ReadLine());

                        pos = operations.Find(ref lst, x);
                        if (pos == -1) Console.WriteLine("Not in list.");
                        else Console.WriteLine("Position is " + pos);
                        break;
                    case 3:
                        Console.Write("Number = ");
                        x = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Position = ");
                        pos = Convert.ToInt32(Console.ReadLine());

                        if (pos < lst.Count)
                        {
                            operations.Insert(lst, x, pos);
                            operations.Display(ref lst);
                        }

                        else Console.WriteLine("Position is out of bound.");

                        break;
                    case 4:
                        correct = false;
                        break;

                }

            }

        }


    }

    public class Operations
    {

        public void Display(ref List<int> lst)
        {
            Console.WriteLine("Collection is");
            lst.ForEach(x => Console.Write(x+" " ));
            Console.WriteLine("\n");
        }
        public void Insert(List<int> lst, int x, int pos)
        {
            lst.Insert(pos, x);
        }

        public int Find(ref List<int> lst, int x)
        {
            int pos = lst.IndexOf(x);
            return pos;
        }
        public void Remove(ref List<int> lst, int x)
        {
            lst.RemoveAll(a => a == x);
        }
    }
}
