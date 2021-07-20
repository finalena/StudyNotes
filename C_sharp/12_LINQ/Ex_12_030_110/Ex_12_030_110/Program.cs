using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Ex_12_030_110
{
	class Program
	{
		/* Cast 將實作 IEnumerable 介面的集合轉型成 IEnumerable<T>
		 */
		static void Main(string[] args)
		{
			DataTable data = new DataTable();
			AddColumns(data);
			AddData(data);

			// 繼承及實作關係: DataRowCollection => InternalDataCollectionBase => ICollection => IEnumerable
			IEnumerable<DataRow> rows = data.Rows.Cast<DataRow>();

			var query = rows
				.Select(x => x["Name"].ToString())
				.Where(x => x.Length == 5)
				.OrderBy(x => x)
				.ToList();

			query.Dump();

			Console.ReadLine();
		}

		private static void AddData(DataTable data)
		{
			string[] items = new string[] { "allen", "simon", "annie", "tom", "jhon", "bruce" };
			for (int i = 0; i < items.Length; i++)
			{
				DataRow newRow = data.NewRow();
				newRow["Id"] = i + 1;
				newRow["Name"] = items[i];
				data.Rows.Add(newRow);
			}

		}

		static void AddColumns(DataTable data)
		{
			data.Columns.Add("Id", typeof(int));
			data.Columns.Add("Name", typeof(string));
		}
	}

	abstract class Employee
	{
		public string Name { get; set; }
	}

	class Sales : Employee { }
	class Engineer : Employee { }
	class Manager : Employee
	{
		public List<Employee> TeamMembers { get; set; }

	}


	static class ArrayExts
	{
		public static void Dump<T>(this List<T> source)
		{
			string result = (source == null || source.Count == 0)
				? string.Empty
				: source.Select(x => x.ToString()).Aggregate((acc, next) => acc + ", " + next);
			Console.WriteLine(result);
		}
	}
}
