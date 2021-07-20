using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_020_042
{
    class Program
    {
        /* OrderBy
         * 多條件排序 & 查詢語法
         */
        static void Main(string[] args)
        {
            List<Student> source = new List<Student>
            {
                new Student("王吉霸", 90,100),
                new Student("李小華", 100,90),
                new Student("柯玲芬", 10, 58)
            };

            DisplayHeader("依總分遞減排序, 再根據國文遞減排序");
            Student[] resultA = source
                                .OrderByDescending(x => x.總分)
                                .OrderByDescending(x => x.國文)
                                .ToArray();
            resultA.Dump();

            Console.WriteLine("\r\n查詢語法");
            Student[] resultA2 = (from item in source
                                  orderby item.總分 descending, item.國文 descending
                                  select item)
                                 .ToArray();

            resultA2.Dump();

            DisplayHeader("總分遞減排序, 若總分相同, 以英文為準, 愈高的排愈前面");
            Student[] resultB = source
                                .OrderByDescending(x => x.總分)
                                .OrderByDescending(x => x.英文)
                                .ToArray();
            resultA.Dump();

            Console.ReadLine();
        }

        static void DisplayHeader(string title)
        {
            Console.WriteLine("\r\n");
            Console.WriteLine(title);
            Console.WriteLine(new string('=', 40));
        }
    }
    
    class Student 
    {
        public string Name { get; set; }
        public int 國文 { get; set; }
        public int 英文 { get; set; }

        public int 總分
        {
            get
            {
                return 國文 + 英文;
            }
        }

        public Student(string name, int 國分文數, int 英文分數)
        {
            this.Name = name;
            this.國文 = 國分文數;
            this.英文 = 英文分數;
        }

        public override string ToString()
        {
            return $"{Name},\t{國文}\t{英文}\t{總分}";
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
