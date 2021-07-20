using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_03_01_02
{
	class Program
	{
		static void Main(string[] args)
		{
			//先乘除後加減
			int reslut = 1 + 2 * 3 - 4;
			int reslut2 = (1 + 2) * 3 - 4;

			//取餘數
			int remainder = 10 % 3;

			//比較數值大小
			int num1 = 39;
			int num2 = 55;
			int minValue = Math.Min(num1, num2);
			int maxValue = Math.Max(num1, num2);

			//數值溢位
			int number = 65535;
			Console.WriteLine(number * number);

			//checked關鍵字檢查溢位
			checked
			{
				Console.WriteLine(number * number);
			}
			
		}
	}
}
