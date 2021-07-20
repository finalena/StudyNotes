using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Ex_11_050_02_P
{
	class Program
	{
		/* 練習 IoC, 依賴反轉
		 * -藉由 IRepository, 可以與service object 分開工作
		 * 
		 * 將 Repository 共同的部分抽離，建立泛型 IRepository 介面，外面都是對介面寫程式 存取資料
		 * 
		 * Ref:
		 * 用Repository Pattern抽離對Entity Framework的依賴- https://reurl.cc/GmD5GZ
		 * ASP.NET MVC 專案分層架構 Part.2 抽出 Repository 裡相同的部份- https://reurl.cc/gWler7
		 * 隨手 Design Pattern (4) - Repository 模式 (Repository Pattern)- https://reurl.cc/dG8182
		 * 
		 * 待練習:
		 * Expression<Func<TEntity, bool>>
		 * 個別 Repository 的資料存取操作
		 */
		static void Main(string[] args)
		{
			IRepository<GuestBook> repo = GetRepository();
			new Service<GuestBook>(repo).ApplyThread(new GuestBook());
		}

		private static IRepository<GuestBook> GetRepository()
		{
			return new OraRepository<GuestBook>();
		}
	}

	class Service<TEntity>
	{
		private readonly IRepository<TEntity> _repo;

		//針對介面寫程式
		public Service(IRepository<TEntity> repo)
		{
			this._repo = repo;
		}

		/// <summary>
		/// 新增一筆留言
		/// </summary>
		/// <param name="title"></param>
		/// <param name="message"></param>
		public void ApplyThread(TEntity entity)
		{
			//驗證欄位是否合理

			//建檔
			this._repo.Create(entity);
		}
	}

	class GuestBook
	{

	}

	public interface IRepository<TEntity>
	{
		void Create(TEntity entity);
	}

	class OraRepository<TEntity> : IRepository<TEntity>
	{
		public void Create(TEntity entity)
		{
			
		}
	}

	class SqlRepository<TEntity> : IRepository<TEntity>
	{

		public void Create(TEntity entity)
		{

		}
	}
}
