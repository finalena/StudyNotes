using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_088
{
	class Program
	{
		/* Except 差集，針對第一個集合做處理, 將同時也存在第二個集合的項目扣除
		 * Intersect 交集，兩個集合都有相同的項目
		 */
		static void Main(string[] args)
		{
			int[] items1 = new int[] { 1, 2, 3, 4, 5 };
			int[] items2 = new int[] { 2, 4, 6, 8, 10 };

			var query = items1.Except(items2).ToList();
			query.Dump("items1扣除 items2的項目結果");

			var queryA = items1.Intersect(items2).ToList();
			queryA.Dump("items1,items2的交集");

			Console.ReadLine();
		}
	}

	static class IEnumerableExts
	{
		public static void Dump<T>(this IEnumerable<T> source, string title)
		{
			if (!string.IsNullOrEmpty(title))
			{
				Console.WriteLine(title);
				Console.WriteLine(new string('=', 40));
			}

			foreach (var item in source)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine();
		}
	}
}
