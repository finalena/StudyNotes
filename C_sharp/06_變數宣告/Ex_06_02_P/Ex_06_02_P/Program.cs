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
			
			decimal valueA1 = 12.54M;
			decimal valueA2 = 12.55M;
			decimal valueA3 = 12.56M;

			Console.WriteLine(Math.Round(valueA1, 1, MidpointRounding.AwayFromZero));
			Console.WriteLine(Math.Round(valueA2, 1, MidpointRounding.AwayFromZero));
			Console.WriteLine(Math.Round(valueA3, 1, MidpointRounding.AwayFromZero));
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
			
			decimal valueC1 = 12.4M;
			decimal valueC2 = 12.5M;
			decimal valueC3 = 12.6M;

			//整數，方法有三種
			Console.WriteLine(Math.Floor(valueC1));
			Console.WriteLine((int)valueC2);
			Console.WriteLine(Math.Truncate(valueC3));

			//負數，方法有三種
			Console.WriteLine(Math.Ceiling(-12.4M));
			Console.WriteLine((int)-12.5M);
			Console.WriteLine(Math.Truncate(-12.6M));
		}

		static void DisplayHeader(string title)
		{
			Console.WriteLine("\r\n");
			Console.WriteLine(title);
			Console.WriteLine(new string('=', 40));
		}
	}
}
