using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_092
{
	class Program
	{
		//ToHasSet - 從 IEnumerable<T> 傳換為 HashSet<T>
		static void Main(string[] args)
		{
			List<Book> books = new List<Book>
			{
				new Book("ASP.NET專題實務", "程式", 999),
				new Book("ASP.NET專題實務", "程式", 620),
				new Book("煲湯熬粥128道", "飲食", 160),
				new Book("河鮮海鮮128道", "飲食", 88),
				new Book("日本觀察日記", "旅遊", 238),
				new Book("日本鐵道繪旅行", "旅遊", 228),
			};

			//值重複，只保留一筆
			HashSet<string> result = books.Select(x=> x.Name).ToHashSet();
			result.Dump();

			//大小寫不同時, 是否視為相同
			List<string> items = new List<string> { "ABC", "DE", "abc", "de" };
			HashSet<string> resultA = items.ToHashSet();
			resultA.Dump();

			Console.WriteLine(new string('=', 20));

			HashSet<string> resultA1 = items.ToHashSet(StringComparer.CurrentCultureIgnoreCase);
			resultA1.Dump();

			Console.ReadLine();
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
			return $"{CategoryName}\t${UnitPrice}";
		}
	}

	static class HashSetExts
	{
		public static void Dump<T>(this HashSet<T> source)
		{
			foreach (T item in source)
			{
				Console.WriteLine(item);
			}
		}
	}
}
