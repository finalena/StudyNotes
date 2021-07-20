using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYH.eStore.Domain;

namespace Ex_10_01_03_101
{
	class Program
	{
		static void Main(string[] args)
		{
			Order order = new Order();
			int result = order.Add(100, 50);
			Console.WriteLine(result);

			Console.ReadLine();
		}
	}
}
