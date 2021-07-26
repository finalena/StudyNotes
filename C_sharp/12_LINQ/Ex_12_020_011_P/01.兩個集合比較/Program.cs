using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.兩個集合比較
{
	class Program
	{
		static void Main(string[] args)
		{
			P1();
			P2();
			Console.ReadLine();
		}

		private static void P1()
		{
			DisplayHeader("兩個集合都有的項目");

			string[] fruits = new string[] { "Apple", "Cherry", "Guava", "Lemon", "Orange", "Kiwi" };
			string[] bag = new string[] { "Banana", "Apple", "KIWI" };

			//方法1-使用 Intersect
			var resultB = fruits.Intersect(bag).ToList();

			//方法2-使用 Any
			var result = fruits.Where(x => bag.Any(b => string.Equals(x, b, StringComparison.OrdinalIgnoreCase))).ToList();
			result.Dump();

			//方法3-使用 Exists
			List<string> bagA = bag.ToList();
			var resultA = fruits.Where(x => bagA.Exists(b => string.Equals(x, b, StringComparison.OrdinalIgnoreCase))).ToList();
			resultA.Dump();

			resultB.Dump();
		}

		private static void P2()
		{
			DisplayHeader("針對第一個集合，排除含第二個集合的項目");

			string[] fruits = new string[] { "Apple", "Cherry", "Guava", "Lemon", "Orange", "Kiwi" };
			string[] bag = new string[] { "Banana", "Apple", "KIWI" };

			//方法1-使用 Except
			var resultA = fruits.Except(bag).ToList();
			resultA.Dump();

			//方法2-使用 Exists
			List<string> bagA = bag.ToList();
			var result = fruits.Where(x => !bagA.Exists(b => string.Equals(x, b, StringComparison.OrdinalIgnoreCase))).ToList();
			result.Dump();


		}

		static void DisplayHeader(string title)
		{
			Console.WriteLine("\r\n");
			Console.WriteLine(title);
			Console.WriteLine(new string('=', 40));
		}

	}

	static class IEnumerableExts
	{
		public static void Dump<T>(this IEnumerable<T> source)
		{
			foreach (var item in source)
			{
				Console.Write(item + "\t");
			}
			Console.WriteLine();
		}
	}
}
