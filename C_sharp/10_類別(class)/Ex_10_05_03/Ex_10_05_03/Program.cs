using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_05_03
{
	class Program
	{
		/* 常數
		 * 在宣告變數時就要給予值，之後不能再修改
		 * readonly field 
		 * 僅能在建構子動態指定值，之後不能再修改
		 */
		static void Main(string[] args)
		{
			decimal price = 100M;
			var order = new Order();
			int tax = order.CalcText(price);
			Console.WriteLine(tax);

			Console.ReadLine();
		}
	}


	class Order
	{
		private const decimal rate = 0.05M; //營業稅
		private readonly string test = string.Empty;

		public Order()
		{
			test = "test";
		}

		public int CalcText(decimal price)
		{
			return (int)Math.Round(price * rate, MidpointRounding.AwayFromZero);
		}
	}
}
