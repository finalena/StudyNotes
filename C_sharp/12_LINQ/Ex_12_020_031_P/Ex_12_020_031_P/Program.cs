using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_020_031_P
{
	class Program
	{
		static void Main(string[] args)
		{
			DisplayHeader("將下列陣列轉為 int[] ");
			string[] sourceA = new string[] { "1", "99", "-2" };
			int[] resultA = sourceA.Select(x => int.Parse(x)).ToArray();
			resultA.Dump();

			DisplayHeader("取得每一個項目的字串長度為");
			string[] sourceB = new string[] { "ABC", "ABCDEF", "" };
			int[] resultB = sourceB.Select(x => x.Length).ToArray();
			resultB.Dump();

			DisplayHeader("請搭配 Enumerable.Range,ToArray, Where, Select 得到以下 string[] 陣列");
			IEnumerable<int> sourceC = Enumerable.Range(3, 15);
			string[] resultC = sourceC.Where(x => x % 3 == 0).Select(x => "number " + x.ToString()).ToArray();
			resultC.Dump();

			Console.ReadLine();
		}

		private static void DisplayHeader(string title)
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
				Console.Write(item + ", ");
			}
			Console.WriteLine();
		}
	}
}
