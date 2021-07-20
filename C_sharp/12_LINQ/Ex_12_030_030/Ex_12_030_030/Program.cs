using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_030
{
    class Program
    {
        /* All, Any
         * All 用來判斷集合裡是否每一個項目都符合條件
         * Any 用來判斷集合裡是否至少一個項目符合條件
         */
        static void Main(string[] args)
        {
            int[] items = new int[] { 1, 5, 66, -2 };
            Console.WriteLine(items.All(x => x > 0));
            Console.WriteLine(items.Any(x => x % 5 == 0));
       

            Console.ReadLine();
        }
    }

    static class EnumerableExts
    {
        public static void Dump<T>(this IEnumerable<T> source)
        {
            foreach (T item in source)
            {
                Console.WriteLine(item);
            }
        }
    }
}
