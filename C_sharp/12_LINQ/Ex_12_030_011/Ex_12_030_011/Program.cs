using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_011
{
    class Program
    {
        //First() 多載
        static void Main(string[] args)
        {
            IEnumerable<int> items = Enumerable.Range(5, 10);
            Console.WriteLine(items.FirstOrDefault(x => x % 3 == 0));
            Console.WriteLine(items.LastOrDefault(x => x % 5 == 0));
            
            Console.Read();
        }
    }
}
