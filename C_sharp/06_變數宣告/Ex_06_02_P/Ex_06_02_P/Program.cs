using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_06_02
{
	class Program
	{
		static void Main(string[] args)
		{
			Q1();
			Q2();
			Q3();

			Console.ReadLine();
		}

		static void Q1()
		{
			DisplayHeader("Q1.四捨五入到小數點以下一位");

			decimal[] items = new decimal[] { 12.54M, 12.55M, 12.56M };

			foreach (var item in items)
			{
				Console.WriteLine(Math.Round(item, 1, MidpointRounding.AwayFromZero));
			}
		}

		static void Q2()
		{
			DisplayHeader("Q2.無條件進位到整數");
		
			//整數使用Math.Ceiling()、負數使用Math.Floor()
			//Ceiling() 取大的那個整數，Floor() 取小的那個整數
			decimal valueB1 = 12.4M;
			decimal valueB2 = -12.5M;
			decimal valueB3 = -12.6M;

			Console.WriteLine(Math.Ceiling(valueB1));
			Console.WriteLine(Math.Ceiling(valueB2));
			Console.WriteLine(Math.Floor(valueB3));
		}

		static void Q3()
		{
			DisplayHeader("Q3.無條件捨去到整數");

			//整數，方法有三種
			decimal valueC1 = 12.4M;
			decimal valueC2 = 12.5M;
			decimal valueC3 = 12.6M;

			Console.WriteLine(Math.Floor(valueC1));
			Console.WriteLine((int)valueC2);
			Console.WriteLine(Math.Truncate(valueC3));

			//負數，方法有三種
			decimal valueC4 = -12.4M;
			decimal valueC5 = -12.5M;
			decimal valueC6 = -12.6M;

			Console.WriteLine(Math.Ceiling(valueC4));
			Console.WriteLine((int)valueC5);
			Console.WriteLine(Math.Truncate(valueC6));
		}

		static void DisplayHeader(string title)
		{
			Console.WriteLine("\r\n");
			Console.WriteLine(title);
			Console.WriteLine(new string('=', 40));
		}
	}
}
