using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_020_021_P
{
	class Program
	{
		static void Main(string[] args)
		{
			DisplayHeader("找出下方陣列裡, 大於零的項目並用一個新陣列存放結果");
			int[] source = new int[] { 1, 100, -5, 88, -99, 0, -22 };
			int[] result = source.Where(x => x > 0).ToArray();
			result.Dump();
	
			DisplayHeader("找出下方陣列裡, 字串長度超過 3 的項目並用一個新陣列存放結果");
			string[] sourceA = new string[] { "abc", "12345", "11", "", "                    " };
			string[] resultA = sourceA.Where(x => x.Length > 3).ToArray();
			resultA.Dump();

			DisplayHeader("找出下方陣列裡, 字串包含 \"A\" 的項目並用一個新陣列存放結果");
			string[] sourceB = new string[] { "ABC", "12345", "11", null, "Apple", "lam" };
			string[] resultB = sourceB.Where(x => !string.IsNullOrEmpty(x) && x.Contains("A")).ToArray();
			resultB.Dump();

			DisplayHeader("找出下方陣列裡, 字串不是 nulll 項目並用一個新陣列存放結果");
			string[] sourceC = new string[] { "ABC", "12345", "11", null, "Apple" };
			string[] resultC = sourceC.Where(x => !string.IsNullOrEmpty(x)).ToArray();
			resultC.Dump();

			DisplayHeader("找出下方陣列裡, 字串長度超過 3 而且包含 \"A\" 的項目(大小寫視為相異, 'a'視為不符合條件)並用一個新陣列存放結果");
			string[] sourceD = new string[] { "ABC", "12345", "11", "", "this is a book", "FRAMEWORK" };
			string[] resultD = sourceD.Where(x => !string.IsNullOrEmpty(x) && x.Length > 3 && x.Contains("A")).ToArray();
			resultD.Dump();

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
