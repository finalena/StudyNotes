using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_06_03_02_03_P
{
	class Program
	{
		//使用者輸入值, 必需介於 0.1~ 99.9 之間
		static void Main(string[] args)
		{
			decimal beginNumber = 0.1M, endNumber = 99.9M;
			decimal number = GetNumber(beginNumber, endNumber);

			if (number > beginNumber)
			{
				Console.WriteLine($"您輸入的值是 {number}");
			}
			else
			{
				Console.WriteLine("使用者強制結束");
			}

			Console.ReadLine();
		}

		private static decimal GetNumber(decimal beginNumber, decimal endNumber)
		{
			decimal dReslut;

			Console.Write($"請輸入 {beginNumber} ~ {endNumber} 之間的數, 若輸入 x 表示結束: ");

			string value = Console.ReadLine();
			if (value.ToLower() == "x") return -1;

			if (!decimal.TryParse(value, out dReslut))
			{
				Console.WriteLine("請輸入數值");
			}
			else if (dReslut < beginNumber || dReslut > endNumber)
			{
				Console.WriteLine("輸入的數值超出範圍");
			}
			else
			{
				return dReslut;
			}

			return GetNumber(beginNumber, endNumber);
		}
	}
}
