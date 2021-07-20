using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_07_04_02
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] items = new[] { 1, 55, 22, 33, 44, 11 };
			//x會背後執行迴圈，一一比對傳回符合(x>30)的值
			int[] result = items.Where(x => x > 30).OrderBy(x => x).ToArray();
			Dump(result);

			Console.ReadLine();
		}

		private static void Dump<T>(T[] items)
		{
			foreach (var item in items)
			{
				Console.WriteLine($"{item}\t");
			}

			Console.WriteLine("\r\n");
		}
	}
}
