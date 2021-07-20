using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_005
{
    class Program
    {
        /* Empty 用來建立一個空的集合
         * Append 可以在集合的最後面加入一個新項目
         * Prepend 可以在集合的最前面加入一個新項目
         */
        static void Main(string[] args)
        {
            IEnumerable<int> items = Enumerable.Empty<int>();
            var result = items.Append(50);
            result = result.Prepend(10);
            result = result.Append(199);

            result.Dump();

            Console.ReadLine();
        }
    }
    static class EnumerableExts
    {
        public static void Dump<T>(this IEnumerable<T> source)
        {
            foreach (T item in source)
            {
                Console.Write(item + ", ");
            }
        }
    }
}
