using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_020_011_P
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> list = Enumerable.Range(1, 10).ToList();
			list.Dump();

			Console.ReadLine();
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
