using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_04_04
{
	class Program
	{
		static void Main(string[] args)
		{
		}
	}

	public class EmployeeRepository
	{
		/// <summary>
		/// 傳回所有員工紀錄
		/// </summary>
		/// <returns></returns>
		public List<Employee> GetAll()
		{ }	

		/// <summary>
		/// 查詢並傳回單頁紀錄
		/// </summary>
		/// <param name="account">要查詢的帳號</param>
		/// <param name="pageNumber">想傳回的頁碼</param>
		/// <param name="pageSize">一頁多少筆</param>
		/// <returns></returns>
		public PageList<Employee> Search(string account, int pageNumber, int pageSize)
		{ }
	}

	public class PageList<TModel>
	{
		public TModel[] PagedData { get; set; }	//單頁紀錄
		public PaginationInfo PaginationInfo { get; set; }
	}

	public struct PaginationInfo
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public int RecordCount { get; set; }

		public int Pages
		{
			get
			{
				return (int)Math.Ceiling((double)RecordCount / PageSize);
			}
		}
	}

	public class Employee
	{
		public string Name;
		public bool Gender;
	}
}
