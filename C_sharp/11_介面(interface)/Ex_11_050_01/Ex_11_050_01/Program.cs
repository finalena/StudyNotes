using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_11_050_01
{
	class Program
	{
		//物件導向-依賴反轉
		static void Main(string[] args)
		{
			string title = "aaa", message = "test";

			//IGuestBookRepository repo = new GuestBookOraRepository();
			//IGuestBookRepository repo = new GuestBookSqlRepository();
			IGuestBookRepository repo = GetGuestBookRepository();
			new GuestService(repo).ApplyThread(title, message);
		}

		private static IGuestBookRepository GetGuestBookRepository()
		{
			return new GuestBookSqlRepository();
			//return new GuestBookOraRepository();
		}
	}

	class GuestService
	{
		private readonly IGuestBookRepository _repo;

		//針對介面寫程式
		public GuestService(IGuestBookRepository repo)
		{
			this._repo = repo;
		}

		/// <summary>
		/// 新增一筆留言
		/// </summary>
		/// <param name="title"></param>
		/// <param name="message"></param>
		public void ApplyThread(string title, string message)
		{
			//驗證欄位是否合理

			//建檔
			this._repo.Create(title, message);
			//new GuestBookSqlRepository().Create(title, message);
		}
	}

	interface IGuestBookRepository
	{
		void Create(string title, string message);
	}

	class GuestBookOraRepository : IGuestBookRepository
	{
		public void Create(string title, string message)
		{
			
		}
	}

	class GuestBookSqlRepository : IGuestBookRepository
	{
		public void Create(string title, string message)
		{
			//todo
		}
	}
}
