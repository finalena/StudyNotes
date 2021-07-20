using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_020_035
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] source = new string[] { "AB", "RR", "Apple", "iPhone", "iOS", "Windows", "Mac" };
			string[] result = source.Select(Func).ToArray();
			result.Dump();

			string[] resultA = source.Select((value, index) => $"{index + 1}. {value}").ToArray();
			resultA.Dump();

			Console.ReadLine();
		}

		static string Func(string value, int index)
		{
			return $"{index + 1}. {value}";
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
