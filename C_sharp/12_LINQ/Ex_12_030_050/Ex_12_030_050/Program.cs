using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_050
{
	class Program
	{
		//Aggregate 累績計算
		static void Main(string[] args)
		{
			//數字累加
			int[] items = new[] { 1, 3, 5, 100 };
			//acc, next, 它分別表示 accumulation(累積) , Next Item(下一個項目)
			int sum = items.Aggregate((acc, next) => acc + next);
			Console.WriteLine(sum);

			//串接字串
			string[] itemsA = new string[] { "AB", "C", "D" };
			string resultA = itemsA.Aggregate((acc, next) => acc + next + ", ");
			Console.WriteLine(resultA);

			//預防空項目導致的例外
			try
			{
				string resultA1 = itemsA
								.Where(x => x.Length > 10)
								.Aggregate((acc, next) => acc + next + ", ");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			string resultB = itemsA
							.Where(x => x.Length > 10)
							.Aggregate(string.Empty, (acc, next) => acc + next + ", ");
			Console.WriteLine(resultB);
	
		
			Console.ReadLine();

		}
	}
}
