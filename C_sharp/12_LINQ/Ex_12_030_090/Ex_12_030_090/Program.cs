using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_090
{
	class Program
	{
		/* GroupBy 依條件將項目分成群組
		 */

		static List<Book> books;
		static void Main(string[] args)
		{
			books = new List<Book>
			{
				new Book("ASP.NET專題實務", "程式", 620),
				new Book("煲湯熬粥128道", "飲食", 160),
				new Book("河鮮海鮮128道", "飲食", 88),
				new Book("日本觀察日記", "旅遊", 238),
				new Book("日本鐵道繪旅行", "旅遊", 228),
			};

			P1();
			P2();
			P3(); 

			Console.ReadLine();
		}

		private static void P1()
		{
			IEnumerable<IGrouping<string, Book>> groupByCategory = books.GroupBy(x => x.CategoryName);
			groupByCategory.Dump("書籍分類把 books 區分成若干群組");
		}

		/// <summary>
		/// 自訂委派, 傳回群組key的物件(傳回字串, 書籍售價的級距)
		/// </summary>
		private static void P2()
		{
			Func<Book, string> keySelector = book =>
			{
				int groupNumber = book.UnitPrice / 100;
				int beginPrice = groupNumber * 100;
				int endPrice = beginPrice + 99;
				return $"{beginPrice,3} - {endPrice,3}";
			};

			IEnumerable<IGrouping<string, Book>> groupByCategoryA = books.GroupBy(keySelector)
																		 .OrderBy(x => x.Key);
			groupByCategoryA.Dump("依書籍售價的級距分成若干群組");
		}

		/// <summary>
		/// 自訂分群依據, 自訂項目型別
		/// </summary>
		private static void P3()
		{
			//分組依據: 依價格決定為平價書或高價書；群組型別為string
			Func<Book, string> keySelector = book => book.UnitPrice < 300 ? "平價書" : "高價書";
			Func<Book, string> resultSelector = book => book.Name;

			IEnumerable<IGrouping<string, string>> groupByCategory = books.GroupBy(keySelector, resultSelector);
			groupByCategory.Dump("");
		}
	}

	class Book
	{
		public string Name { get; set; }
		public string CategoryName { get; set; }
		public int UnitPrice { get; set; }
		public Book(string name, string categoryName, int unitPrice)
		{
			this.Name = name;
			this.CategoryName = categoryName;
			this.UnitPrice = unitPrice;
		}
		public override string ToString()
		{
			return $"{Name,-20}\t, ${UnitPrice}";
		}
	}

	static class GroupingExts
	{
		public static void Dump<TKey, TValue>(this IEnumerable<IGrouping<TKey, TValue>> source , string title)
		{
			if (!string.IsNullOrEmpty(title))
			{
				Console.WriteLine(title);
				Console.WriteLine(new string('=', 40));
			}

			foreach (IGrouping<TKey, TValue> grouping in source)
			{
				Console.WriteLine(grouping.Key);
				foreach (TValue item in grouping)
				{
					Console.WriteLine("\t" + item);
				}
			}
		}
	}
}
