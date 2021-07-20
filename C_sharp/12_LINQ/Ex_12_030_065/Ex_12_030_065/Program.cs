using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_065
{
	class Program
	{
		/* 延遲執行 Defererred Execution
		 * First()、Sum()、ToList()等方法都是立刻執行
		 * Where()、Take()等是延遲執行，只會先記錄要擷取項目,但還沒真的擷取
		 */
		static void Main(string[] args)
		{
			var item = Enumerable.Range(1, 3).ToList();
			IEnumerable<int> result = item.Where(x => x > 2);

			item.Add(10);
			int count = result.ToList().Count; 
			Console.WriteLine(count);

			var itemA = Enumerable.Range(1, 3).ToList();
			IEnumerable<int> resultA = itemA.Take(1);

			itemA.Insert(0, 10);
			Console.WriteLine(resultA.First());

			Console.ReadLine();
		}
	}
}
