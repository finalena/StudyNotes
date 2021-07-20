using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_040
{
    class Program
    {
        //Max, Min
        static void Main(string[] args)
        {
            //找出值最大的項目 - 用 Max
            var items = new int[] { 5, 8, 1, 99, 35 };
            Console.WriteLine(items.Max());
            //找出值最大的項目 - 先排序再取得第一個值(耗時)
            Console.WriteLine(items.OrderByDescending(x => x).First());

            //找出項目字串長度，最長是多少
            var items2 = new string[] { "ZBC", "BC", "ABCD", "A" };
            Console.WriteLine(items2.Max(x => x.Length));

			//找出項目最長字串長度，回傳項目本身
			Console.WriteLine(items2.OrderByDescending(x => x.Length).First());
			//方式二:自己寫擴充方法
			Console.WriteLine(items2.MaxByLength(x => x.Length));

            Console.ReadKey();
        }
    }

    static class Exts 
    {
        public static T MaxByLength<T>(this IEnumerable<T> source, Func<T,int> lengthSelector)
        {
            int maxLength = -1;
            T result = default(T);

            foreach (var item in source)
            {
                //取得目前項目的長度
                int lengthofCurrentItem = lengthSelector(item); //項目長度
                if (lengthofCurrentItem >maxLength)
                {
                    maxLength = lengthofCurrentItem;
                    result = item; //若目前項目值的長度是最長，result保存目前項目(不是項目長度)
				}
            }

            return result;
        }
    }
}
