using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_05_06
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine(CalcTotal(0, 20));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.ReadLine();
		}

		private static int CalcTotal(int price, int tax)
		{
			if (price < 1 || tax < 1) throw new Exception("price 或 tax 必需大於等於零");
			if (price < tax) throw new Exception("price 必需大於或等於 tax");

			return (price + tax);
		}
	}
}
