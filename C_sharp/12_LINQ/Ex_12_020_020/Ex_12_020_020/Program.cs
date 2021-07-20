using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_020_020
{
	class Program
	{
		static void Main(string[] args)
		{
			IEnumerable<int> items = Enumerable.Range(11, 100).Where(func);
			//items.Dump();

			int[] result = Enumerable.Range(11, 100)
							.Where(x => x % 3 == 0)
							.ToArray();
			result.Dump();

			Console.ReadLine();
		}

		static bool func(int value)
		{
			return (value % 3 == 0);
		}
	}

	static class IEnumerableExts
	{
		public static void Dump<T>(this IEnumerable<T> source)
		{
			foreach (var item in source)
			{
				Console.Write(item + ", ");
			}
			Console.WriteLine();
		}
	}
}
