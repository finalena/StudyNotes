using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_00200_15_30_DapperDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			//Query();
			Create();
			Delete();
		}

		static void Query()
		{
			string connStr = System.Configuration
							.ConfigurationManager
							.ConnectionStrings["dbTestConnStr"]
							.ToString();
			string sql = "SELECT * FROM Members";
			IEnumerable<Member> result;
			using (var conn = new SqlConnection(connStr))
			{
				result = conn.Query<Member>(sql);
			}

			result.ToList()
				.ForEach(x => Console.WriteLine(x));

		}

		static void Create()
		{
			string connStr = System.Configuration
							.ConfigurationManager
							.ConnectionStrings["dbTestConnStr"]
							.ToString();
			string sql = "INSERT INTO Members(Name, Account, Password, Email)VALUES(@Name, @Account, @Password, @Email)";
			var model = new Member { Name = "Eddie", Account = "eddie", Password = "123", Email = "eddit@xxx.com" };
			using (var conn = new SqlConnection(connStr))
			{
				conn.Execute(sql, model);
			}

			Console.WriteLine("記錄已新增");
		}

		static void Delete()
		{
			string connStr = System.Configuration
							.ConfigurationManager
							.ConnectionStrings["dbTestConnStr"]
							.ToString();
			string sql = "Delete from Members where Account = @Account";
			var model = new Member { Account = "eddie" };
			using (var conn  = new SqlConnection(connStr))
			{
				conn.Execute(sql, model);
			}
		}
	}

	class Member
	{
		public string Name { get; set; }
		public string Account { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }

		public override string ToString()
		{
			return $"{Name}, {Email}";
		}
	}
}
