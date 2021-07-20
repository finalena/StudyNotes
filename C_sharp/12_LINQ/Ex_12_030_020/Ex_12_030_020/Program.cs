using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_020
{
    class Program
    {
        /* Single, SingleOrDefault 
         * 超過一個項目符合條件會丟出例外
         * first和single的使用標準，可以依「是否在意只能有一個項目符合」
         */
        static void Main(string[] args)
        {
            IEnumerable<int> items = Enumerable.Range(4, 9);
            Console.WriteLine(items.FirstOrDefault(x => x % 3 == 0));
            Console.WriteLine(items.SingleOrDefault(x => x % 3 == 0));


        }
    }
}
