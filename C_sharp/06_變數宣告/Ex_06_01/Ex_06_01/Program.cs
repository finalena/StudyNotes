
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_06_01
{
	class Program
	{
		static void Main(string[] args)
		{
			//小數點宣告方式
			//雙精準數, 可以直接指定數值, 或在數值最後加 D 或 d
			double A1 = 1.2;
			double A2 = 1.2D;
			double A3 = 1.2d;

			//單精準數, 不可以直接只指定數值, 必需在數值最後加 F 或 f
			float B1 = 1.2F;
			float B2 = 1.2f;

			//十進位數, 不可以直接只指定數值, 必需在數值最後加 M 或 m
			decimal C1 = 1.2M;
			decimal C2 = 1.2m;

			//與錢有關的計算, 請用 decimal , 不要使用 double, float
			CalcDouble();
			CalcFloat();

			Console.WriteLine(10 / 4);
			Console.WriteLine(10.0 / 4);

			//四捨五入
			decimal total = 310M;	//金額310元
			decimal tax = total * 0.05M;	//15.5元
			decimal result = Math.Round(tax);	//16元
			Console.WriteLine(result);

			decimal total2 = 330M;	//金額330元
			decimal tax2 = total * 0.05M;	//16.5 元
			decimal result2 = Math.Round(tax);	//不是17元
			Console.WriteLine(result2);

			//符合現實世界的四捨五入寫法
			decimal total3 = 330M;
			decimal tax3 = total3 * 0.05M;
			Console.WriteLine(Math.Round(tax3, MidpointRounding.AwayFromZero));

			Console.ReadLine();
		}

		private static void CalcDouble()
		{
			double number1 = 0.3;
			double number2 = 0.1;
			double result = number1 - number2;
			Console.WriteLine(result);

			bool isEqual = (result == 0.2);
			Console.WriteLine(isEqual);

			double number3 = 0.2;
			bool isEqual3 = (number3 == 0.2);
			Console.WriteLine(isEqual3);

			double result2 = result * 100;
			Console.WriteLine(result2);
		}

		private static void CalcFloat()
		{
			decimal number1 = 0.3M;
			decimal number2 = 0.1M;
			decimal result = number1 - number2;
			Console.WriteLine(result);

			bool isEqual = (result == 0.2M);
			Console.WriteLine(isEqual);

			decimal number3 = 0.2M;
			bool isEqual3 = (number3 == 0.2M);
			Console.WriteLine(isEqual3);

			decimal result2 = result * 100;
			Console.WriteLine(result2);
		}
	}
}
