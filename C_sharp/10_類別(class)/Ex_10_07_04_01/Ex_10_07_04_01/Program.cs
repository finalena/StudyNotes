using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_07_04_01
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] items = new[] { 1, 55, 22, 33, 44, 11 };
			//Array.Sort(items);

			//OrderBy 參數是 Func<int, int>，會根據傳回值當作排序的依據
			int[] result = items.OrderBy(x => x).ToArray(); //使用新的變數來承接新的結果
			Dump(result);

			//傳回字串長度，按字串長度排序
			string[] itemsA = new[] { "ABC", "ABCD", "DEF", "A", "AAAAAAAA" };
			string[] resultA = itemsA.OrderBy(x => x.Length).ToArray();
			Dump(resultA);

			//傳回字串長度，遞減排序
			string[] resultB = itemsA.OrderByDescending(x => x.Length).ToArray();
			Dump(resultB);

			Console.ReadLine();
		}

		private static void Dump<T>(T[] items)
		{
			foreach (var item in items)
			{
				Console.WriteLine($"{item}\t");
			}

			Console.WriteLine("\r\n");
		}
	}
}
