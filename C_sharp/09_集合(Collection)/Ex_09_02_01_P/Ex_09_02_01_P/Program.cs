using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_09_02_01_P
{
	class Program
	{
		static void Main(string[] args)
		{
			var mvc = new Book { Name = "一次就懂 ASP.NET MVC", UnitPrice = 790 };
			var vue = new Book { Name = "8天絕對學不完的 Vue.js 3", UnitPrice = 600 };
			var cleanCode = new Book { Name = "Clean Code 無瑕的程式碼", UnitPrice = 580 };

			List<Book> books = new List<Book>();
			books.Add(mvc);
			books.Add(vue);
			books.Add(cleanCode);

			books.RemoveAt(0);  // 刪除第一本書
			books.Add(new Book {Name = "為你自己學 Git", UnitPrice = 500 }); // 加入一本書在最後
																		
			// 條列出 books 中的所有書名
			foreach (var item in books)
			{
				Console.WriteLine($"書名:{item.Name}");
			}

			Console.ReadLine();
		}
	}
	class Book
	{
		public string Name { get; set; }
		public int UnitPrice { get; set; }
	}
}
