using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_093
{
	class Program
	{
		//ToLookup 與 GroupBy 類似, 都可以根據某條件做群組分類
		static void Main(string[] args)
		{
			List<Book> books = new List<Book>
			{
				new Book("ASP.NET專題實務", "程式", 620),
				new Book("煲湯熬粥128道", "飲食", 160),
				new Book("河鮮海鮮128道", "飲食", 88),
				new Book("日本觀察日記", "旅遊", 238),
				new Book("日本鐵道繪旅行", "旅遊", 228),
			};

			P1(books);
			P2(books);

			Console.ReadLine();
		}

		private static void P1(List<Book> books)
		{
			ILookup<string, Book> result = books.ToLookup(x => x.CategoryName);

			IEnumerable<IGrouping<string, Book>> resultA = books.GroupBy(x => x.CategoryName);
			result.Dump("依書籍分類分組");
		}

		private static void P2(List<Book> books)
		{
			Func<Book, string> keySelector = book => book.UnitPrice < 300 ? "高價書" : "平價書";
			Func<Book, string> resultSelecor = book => book.Name;
			ILookup<string, string> resultB = books.ToLookup(keySelector, resultSelecor);

			resultB.Dump("自訂分組條件");
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
		public static void Dump<TKey, TValue>(this ILookup<TKey, TValue> source, string title)
		{
			if (!string.IsNullOrEmpty(title))
			{
				Console.WriteLine("\r\n" + title);
				Console.WriteLine(new string('=', 20));
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

