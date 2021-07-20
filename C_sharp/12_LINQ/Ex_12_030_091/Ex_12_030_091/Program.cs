using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_091
{
	class Program
	{
		//ToDictionary
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

			//書籍名稱為 Key 值的取得方式
			Func<Book, string> keySelector = book => book.Name;
			Dictionary<string, Book> result = books.ToDictionary(keySelector);
			result.Dump();

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

	static class DictionaryExts
	{
		public static void Dump<TKey, TValue>(this Dictionary<TKey, TValue> source)
		{
			foreach (KeyValuePair<TKey, TValue> item in source)
			{
				Console.WriteLine($"{item.Key,-20}\t\t{item.Value}");
			}
		}
	}

}
