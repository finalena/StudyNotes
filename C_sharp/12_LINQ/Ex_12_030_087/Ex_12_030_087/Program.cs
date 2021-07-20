using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_087
{
	class Program
	{
		/* Full Join : 取回兩個集合的所有記錄, 就算在另一個集合裡找不到對應的記錄
		 * 先進行兩次 Leff Join , 最後再用Union 將兩次的結果合併即可
		 */
		static void Main(string[] args)
		{
			List<Book> books = new List<Book>
			{
				// new Book("ASP.NET專題實務", 1, 620),
				new Book("煲湯熬粥128道", 2, 160),
				new Book("河鮮海鮮128道", 2, 88),
				new Book("日本觀察日記", 3, 238),
				new Book("日本鐵道繪旅行", 3, 228),
			};

			List<Category> categories = new List<Category>
			{
				new Category{ Id=1, CategoryName="程式"},
				new Category{ Id=2, CategoryName="飲食"},
				//new Category{ Id=3, CategoryName="旅遊"},
				//new Category{ Id=4, CategoryName="音樂"}
			};

			Func<Book, int> keySelectorOfBook = book => book.CategoryId;
			Func<Category, int> keySelectorOfCatgory = category => category.Id;

			var leftQuery = books.GroupJoin(
								categories,
								keySelectorOfBook,
								keySelectorOfCatgory,
								(b, subCategory) => new { Book = b, Categories = subCategory.DefaultIfEmpty() }
							).Select(x => new BookResult { Name = x.Book.Name, CategoryName = x.Categories?.First()?.CategoryName ?? string.Empty })
							.ToList();

			leftQuery.Dump("所有書籍, 即使沒有對應的分類");

			var rightQuery = categories.GroupJoin(
								books,
								keySelectorOfCatgory,
								keySelectorOfBook,
								(c, subBook) => new { Category = c, Books = subBook.DefaultIfEmpty() }
							).Select(x => new BookResult { CategoryName = x.Category.CategoryName, Name = x.Books?.First()?.Name ?? string.Empty })
							.ToList();

			rightQuery.Dump("所有分類, 即使沒有對應的書籍");

			// 將兩個集合進行 union ,剔除重覆項目。傳入 IEqualityComparer<BookResult> 物件作為物件是否相同的依據
			var query = rightQuery.Union(leftQuery, new BookResultComparer()).ToList();
			query.Dump("Full Jon 的結果");

			Console.ReadLine();
		}
	}

	class BookResultComparer : IEqualityComparer<BookResult>
	{
		public bool Equals(BookResult x, BookResult y)
		{
			return x.ToString().Equals(y.ToString());
		}

		public int GetHashCode(BookResult obj)
		{
			return obj.ToString().GetHashCode();
		}
	}
	class BookResult
	{
		public string Name { get; set; }
		public string CategoryName { get; set; }
		public override string ToString()
		{
			return $"{Name,-20}\t, {CategoryName}";
		}
	}

	class Book
	{
		public string Name { get; set; }
		public int CategoryId { get; set; }
		public int UnitPrice { get; set; }
		public Book(string name, int categoryId, int unitPrice)
		{
			this.Name = name;
			this.CategoryId = categoryId;
			this.UnitPrice = unitPrice;
		}
	}

	class Category
	{
		public int Id { get; set; }
		public string CategoryName { get; set; }
	}

	static class IEnumerableExts
	{
		public static void Dump<T>(this IEnumerable<T> source, string title)
		{
			if (!string.IsNullOrEmpty(title))
			{
				Console.WriteLine(title);
				Console.WriteLine(new string('=', 40));
			}

			foreach (var item in source)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine();
		}
	}

}
