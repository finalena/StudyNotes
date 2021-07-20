using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_085
{
	class Program
	{
		/* Join: Inner Join
		 */
		static List<Book> books;
		static List<Category> categories;
		static void Main(string[] args)
		{
			books = new List<Book>
			{
				new Book("ASP.NET專題實務", 1, 620),
				new Book("煲湯熬粥128道", 2, 160),
				new Book("河鮮海鮮128道", 2, 88),
				new Book("日本觀察日記", 3, 238),
				new Book("日本鐵道繪旅行", 3, 228),
				new Book("沒有分類的書籍", 99, 399)
			};
			categories = new List<Category>
			{
				new Category{ Id=1, CategoryName="程式"},
				new Category{ Id=2, CategoryName="飲食"},
				new Category{ Id=3, CategoryName="旅遊"},
				new Category{ Id=4, CategoryName="音樂"}
			};

			DisplayHeader("集合中共有的項目");
			P1();

			DisplayHeader("顯示所有書籍");
			P2();

			Console.ReadLine();
		}

		/// <summary> 集合中共有的項目 Inner Join	 
		/// Join()
		/// 第一個參數是要進行關聯的集合
		/// 第二個參數: 各自集合要關聯的值 book.CategoryId
		/// 第三個參數: 各自集合要關聯的值 category.Id
		/// 第四個參數: 回傳的值
		/// </summary>
		private static void P1()
		{
			Func<Book, int> keySelectorOfBook = book => book.CategoryId;
			Func<Category, int> keySelectorOfCategory = category => category.Id;
			Func<Book, Category, BookResult> projecting =
				(book, category)
				=> new BookResult { Name = book.Name, CategoryName = category.CategoryName };

			var query = books
				.Join(categories, keySelectorOfBook, keySelectorOfCategory, projecting)
				.ToList();


			//查詢語法
			var queryA = (from book in books
						  join category in categories on book.CategoryId equals category.Id
						  select new BookResult { Name = book.Name, CategoryName = category.CategoryName })
						 .ToList();

			query.Dump();
		}

		/// <summary> 顯示所有書籍 Left Join
		/// </summary>
		private static void P2()
		{
			var query = (from book in books
						  join c in categories on book.CategoryId equals c.Id into gj //將對應的 c 填入 gj 暫存物件
						  from subCategory in gj.DefaultIfEmpty()	//subCategory=gj，如果 gj 為空，傳回 Cagefory 型別的預設值給 subCatefory
						  select new BookResult { Name = book.Name, CategoryName = subCategory?.CategoryName ?? "unknown" });
		

			//方法語法
			Func<Book, int> keySelectorOfBook = book => book.CategoryId;
			Func<Category, int> keySelectorOfCategory = category => category.Id;

			//Select() 若x.Categories不是null就叫用First(),若不是null就叫用CategoryName, 結果是null,就傳回"unknown"
			var queryA = books.GroupJoin(
							categories, 
							keySelectorOfBook, 
							keySelectorOfCategory,
							(b, subCategory) => new { Book = b, Categories = subCategory.DefaultIfEmpty()} 
						)
						.Select(x => new BookResult { Name = x.Book.Name, CategoryName = x.Categories?.First()?.CategoryName ?? "unknown" })
						.ToList();

			queryA.Dump();
		}

		private static void DisplayHeader(string title)
		{
			Console.WriteLine("\r\n");
			Console.WriteLine(title);
			Console.WriteLine(new string('=', 40));
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
		public static void Dump<T>(this IEnumerable<T> source)
		{
			foreach (var item in source)
			{
				Console.WriteLine(item);
			}
		}
	}
}
