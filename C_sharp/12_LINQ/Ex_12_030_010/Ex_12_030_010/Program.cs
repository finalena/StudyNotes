using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_010
{
    class Program
    {
        /* First : 用來取得集合裡的第一個項目, 如果集合是空的, 會丟出例外
         * FirstOrDefault : 若集合是空的, 會傳回此型別的預設值
         * Last, LastOrDefault : 取得集合裡的最後一個項目(用法同上)
         */
        static void Main(string[] args)
        {
            int[] items = new int[] { 1, 5, 66, -2 };
            Console.WriteLine(items.First());
            Console.WriteLine(items.Last());

            IEnumerable<int> items2 = Enumerable.Empty<int>();
            //int firstItem2 = items2.First(); // 丟出例外
            //int lastItem2 = items2.Last(); // 丟出例外

            Console.WriteLine(items2.FirstOrDefault()); //int 的預設值為零
            Console.WriteLine(items2.LastOrDefault());

            IEnumerable<string> items3 = Enumerable.Empty<string>();
            Console.WriteLine(items3.FirstOrDefault()); //string 的預設值為 null
            Console.WriteLine(items3.LastOrDefault());

            Console.ReadLine();
        }
    }
}
