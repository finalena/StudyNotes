using Ex_00200_15_30_EF.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_00200_15_30_EF
{
	class Program
	{
		static void Main(string[] args)
		{
		}
	}

	class CategoryService
	{
		private AppDBContext db;
		public CategoryService()
		{
			db = new AppDBContext();
		}

		/// <summary>
		/// 新增一筆Category 記錄
		/// </summary>
		/// <param name="categoryName"></param>
		/// <param name="displayOrder"></param>
		/// <param name="enbled"></param>
		public void Create(string categoryName, int displayOrder , bool enabled)
		{
			var entity = new Category
			{
				CategoryName = categoryName,
				DisplayOrder = displayOrder,
				Enabled = enabled
			};

			db.Categories.Add(entity);
			db.SaveChanges();
		}

		public List<Category> GetAll()
		{
			return db.Categories.OrderBy(x => x.DisplayOrder).ToList();
		}

		public Category Find(int categoryId)
		{
			return db.Categories.SingleOrDefault(x => x.Id == categoryId);
		}

		public void Update(int id, string categoryName, int displayOrder, bool enabled)
		{
			var entity = db.Categories.SingleOrDefault(x => x.Id == id);
			if (entity == null) throw new Exception("record not fount");

			entity.CategoryName = categoryName;
			entity.DisplayOrder = displayOrder;
			entity.Enabled = enabled;

			db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
		}

		public void Delete(int id)
		{
			var entity = db.Categories.Find(id);
			if (entity == null) return;

			db.Categories.Remove(entity);
			db.SaveChanges();
		}
	}
}
