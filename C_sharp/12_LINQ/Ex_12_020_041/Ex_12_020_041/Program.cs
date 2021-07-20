using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_020_041
{
    class Program
    {
        //OrderBy
        static void Main(string[] args)
        {
            string[] source = new string[] { "ZA", "RR", "Apple", "iPhone", "iOS", "Windows", "Mac" };
            string[] result = source.OrderBy(x => x.Length).ToArray();
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
                Console.WriteLine(item);
            }
        }
    }
}
