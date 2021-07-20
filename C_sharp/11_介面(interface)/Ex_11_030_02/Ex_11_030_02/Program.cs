using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_11_030_02
{
    class Program
    {
        /* 實作 IComparable 介面，為自訂型別的陣列進行排序
         * IComparable 可以讓我們方便地寫出比較兩個物件大小的功能
         * IComparer則是方便我們針對同一個型別寫出多種比較大小的功能
         */
        static void Main(string[] args)
        {
            Member[] items = new[]
            {
                new Member{Id=1, Name = "A1", Height = 180},
                new Member{Id=2, Name = "A2", Height = 160},
                new Member{Id=3, Name = "A3", Height = 170},
            };

            Array.Sort(items);
            foreach (var member in items)
            {
                Console.WriteLine(member);
            }

            Console.WriteLine("\r\n根據身高排序");

            IComparer<Member> sortByHeight = new SortByHeight();
            IComparer<Member> sortByNameDesc = new SortByNameDesc();

            Array.Sort(items, sortByHeight);
            foreach (var member in items)
            {
                Console.WriteLine(member);
            }

            Console.WriteLine("\r\n針對姓名遞減排序");

            Array.Sort(items, sortByNameDesc);
            foreach (var member in items)
            {
                Console.WriteLine(member);
            }


            Console.ReadLine();
        }
    }

    public class SortByHeight : IComparer<Member>
    {
        public int Compare(Member x, Member y)
        {
            return x.Height.CompareTo(y.Height);
        }
    }

    public class SortByNameDesc : IComparer<Member>
    {
        public int Compare(Member x, Member y)
        {
            return y.Name.CompareTo(x.Name);
        }
    }

    public class Member : IComparable<Member> 
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public int Height { get; set; }

        public int CompareTo(Member other)
        {
            Member current = this;
            if (this.Height > other.Height)
            {
                return 1;
            }
            else if (this.Height == other.Height)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public override string ToString()
        {
            return $"Id={Id}, Name={Name}, Height={Height}";
        }
    }
}
