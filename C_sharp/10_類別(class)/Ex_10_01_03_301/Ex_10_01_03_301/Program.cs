using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_01_03_301
{
	class Program
	{
		static void Main(string[] args)
		{
			decimal price = 100;
			var order = new Order();

			decimal tax = order.CalcTax(price);
			Console.WriteLine(tax);

			Console.ReadLine();
		}

		
	}

	public class Order
	{
		public decimal CalcTax(decimal price)
		{
			//return price / 20;
			return Math.Round(price / 20, MidpointRounding.AwayFromZero);
		}
	}
}
