using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_060
{
	class Program
	{
		//Take、Skip、TakeWhile、SkipWhile
		static void Main(string[] args)
		{
			var items = Enumerable.Range(1, 100)
						.Skip(20)
						.Take(10)
						.ToList();
			items.Dump();

			P1();
			P2();
			P3();
			P4();

			Console.ReadLine();
		}

		//分頁
		static void P1()
		{
			int pageNumber = 3; //呈現的頁碼
			int pageSize = 5;
			int skipRows = (pageNumber - 1) * pageSize; //略過多少項目

			var itemsA = Enumerable.Range(1, 1000)
						.Skip(skipRows)
						.Take(pageSize)
						.ToList();
			itemsA.Dump();
		}

		//分頁2 - 超出範圍, 不會出錯
		static void P2()
		{
			int pageNumber = 31; //呈現的頁碼
			int pageSize = 5;
			int skipRows = (pageNumber - 1) * pageSize; //略過150個項目，已超出資料範圍

			var itemsA = Enumerable.Range(1, 100)
						.Skip(skipRows)
						.Take(pageSize)
						.ToList();
			itemsA.Dump();
		}

		//SkipWhile - 回傳值為 true 時，就跳過數據，找到後就終止繼續往下比對
		private static void P3()
		{
			var items = new int[] { 1, 3, 5, 7, 9, 2, 4, 6 };
			var result = items.SkipWhile(x => x < 5).ToList();
			result.Dump();
		}

		//TakeWhile - 回傳值為 true 時，才取出來；如果回傳值為 false 就會終止查詢
		private static void P4()
		{
			var items = new int[] { 1, 3, 5, 7, 9, 2, 4 };
			var result = items.TakeWhile(x => x < 5).ToList();
			result.Dump();
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
