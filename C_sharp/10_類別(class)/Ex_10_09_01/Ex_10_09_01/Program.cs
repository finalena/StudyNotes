using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_09_01
{
	class Program
	{
		/* 擴充方法(Extenstion Methods)
		 * 1.在靜態類別裡, 撰寫靜態方法
		 * 2.靜態方法中至少要有一參數，第一個參數前要加上this，表示要擴充的型別
		 */
		static void Main(string[] args)
		{
			string source = null;
			Console.WriteLine(source.Left(10));

			source = string.Empty;
			Console.WriteLine(source.Left(10));

			source = "abcdef";
			Console.WriteLine(source.Left(-10)); 
			Console.WriteLine(source.Left(100)); 
			Console.WriteLine(source.Left(3));

			List<string> itemsA = new List<string> { "A", null, "B", null, null, "C" };
			List<string> resultA = itemsA.WhereNotNull();

			Console.ReadLine();
		}
	}

	public static class StringExts
	{
		public static string Left(this string source, int length)
		{
			if (string.IsNullOrEmpty(source)) return string.Empty;
			if (length <= 0) return string.Empty;
			if (length > source.Length) return source;

			return source.Substring(0, 1);
		}
	}

	public static class ArrayExts
	{
		public static List<T> WhereNotNull<T> (this List<T> source) where T: class
		{
			if (source == null) return new List<T>();

			return source.Where(x => x != null).ToList();
		}
	}
}
