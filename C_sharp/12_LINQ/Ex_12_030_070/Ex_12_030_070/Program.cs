using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_070
{
	class Program
	{
		//Distinct 
		static void Main(string[] args)
		{
			P1();
			P2();
			P3();

			Console.ReadLine();
		}

		private static void P1()
		{
			string[] items = new string[] { "AB", "C", "D", "A", "C", "AB" };
			var result = items.Distinct().ToList();
			result.Dump();

			var result2 = items.Distinct().OrderBy(x => x).ToList();
			result2.Dump();
		}

		private static void P2()
		{
			string[] itemsA = new string[] { "AB", "C", "Ab", "ab" };
			var resultA = itemsA.Distinct().ToList();
			resultA.Dump();
			var resultA1 = itemsA.Distinct(StringComparer.CurrentCultureIgnoreCase).ToList();
			resultA1.Dump();
		}

		//自訂比對邏輯
		private static void P3()
		{
			//大小寫視為不同
			string[] items = new string[] { "AB", "C", "Ab", "cde", "cd" };
			var result = items.Distinct().ToList();
			result.Dump();

			var result2 = items.Distinct(MyStringComparer.ByLength).ToList();
			result2.Dump();
		}

	}

	public class MyStringComparer : IEqualityComparer<string>
	{
		private static MyStringComparer Instance;

		static MyStringComparer()
		{
			Instance = new MyStringComparer();
		}

		public static IEqualityComparer<string> ByLength
		{
			get { return Instance; }
		}

		public bool Equals(string x, string y)
		{
			if (x == null && y == null) return true;
			if (x == null || y == null) return false;

			return x.Length == y.Length; //根據字串長度當作是否相等的依據
		}

		public int GetHashCode(string obj)
		{
			if (obj == null) return -1;
			return obj.Length.GetHashCode();
		}
	}

	static class ArrayExts
	{
		public static void Dump<T>(this List<T> source)
		{
			string result = (source == null || source.Count == 0)
				? string.Empty
				: source.Select(x => x.ToString()).Aggregate((acc, next) => acc + ", " + next);
			Console.WriteLine(result);
		}
	}
}
