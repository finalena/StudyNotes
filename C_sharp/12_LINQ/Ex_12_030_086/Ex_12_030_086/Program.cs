using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_086
{
	class Program
	{
		/* Union 將集合合併起來，會刪除相同值的項目
		 * Concat 將集合合併起來，不會刪除相同值的項目
		 */
		static void Main(string[] args)
		{
			P1();
			P2();
			Console.ReadLine();
		}

		private static void P1()
		{
			int[] items1 = new int[] { 1, 2, 3, 4, 5 };
			int[] items2 = new int[] { 3, 5, 6, 7, 8, 9 };

			var query = items1.Union(items2).ToList();
			query.Dump();
		}

		private static void P2()
		{
			int[] items1 = new int[] { 1, 2, 3, 4, 5 };
			int[] items2 = new int[] { 3, 5, 6, 7, 8, 9 };

			var query = items1.Concat(items2).ToList();
			query.Dump();
		}

	}

	static class IEnumerableExts
	{
		public static void Dump<T>(this IEnumerable<T> source)
		{
			foreach (var item in source)
			{
				Console.WriteLine(item);
			}
		}
	}
}
