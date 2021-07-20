using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_089
{
	class Program
	{
		/* Zip 
		 */
		static void Main(string[] args)
		{
			P1();
			P2();
			P3();

			Console.ReadLine();
		}

		//兩個集合的項目進行逐一相加
		private static void P1()
		{
			int[] items1 = new int[] { 1, 2, 3, 4, 5 };
			int[] items2 = new int[] { 2, 4, 6, 8, 10 };

			Func<int, int, int> selector = (num1, num2) => num1 + num2;
			var query = items1.Zip(items2, selector).ToList();
			query.Dump("items1,items2的交集");
		}

		//若兩個項目長度不一, 以最小的為準
		private static void P2()
		{
			int[] items1 = new int[] { 1, 2, 3, 4, 5 };
			int[] items2 = new int[] { 2, 4, 6, 8 };

			Func<int, int, int> selector = (num1, num2) => num1 + num2;
			var query = items1.Zip(items2, selector).ToList();
			query.Dump("items1,items2的交集");

		}

		//item2的項目比較多, 以 items1的長度為準
		private static void P3()
		{
			int[] items1 = new int[] { 1, 2, 3, 4 };
			int[] items2 = new int[] { 2, 4, 6, 8 ,10,12};

			Func<int, int, int> selector = (num1, num2) => num1 + num2;
			var query = items1.Zip(items2, selector).ToList();
			query.Dump("items1,items2的交集");
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
