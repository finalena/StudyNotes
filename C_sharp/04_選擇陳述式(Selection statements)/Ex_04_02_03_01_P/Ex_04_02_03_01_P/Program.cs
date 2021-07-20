using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_04_02_03_01
{
	class Program
	{
		static void Main(string[] args)
		{
			Q1();
			Q2();
			Q3();
			Q4();
			Q5();
			Q6();
			Console.ReadLine();
		}

		static void Q1()
		{
			DisplayHeader("Q1.三角形");
			int rows = 5;

			for (int i = 1; i <= rows; i++)
			{
				Console.WriteLine(new string('*', i));
			}
		}

		static void Q2()
		{
			DisplayHeader("Q2.倒三角形");
			int rows = 5;

			for (int i = rows; i >= 1; i--)
			{
				Console.WriteLine(new string('*', i));
			}
		}

		static void Q3()
		{
			DisplayHeader("Q3.靠右對齊三角形");
			int rows = 5;

			for (int i = 1; i <= rows; i++)
			{
				Console.WriteLine(new string('*', i).PadLeft(rows));
			}
		}

		static void Q4()
		{
			DisplayHeader("Q4.靠右對齊倒三角形");
			int rows = 5;

			for (int i = 1; i <= rows; i++)
			{
				Console.WriteLine(new string('*', i).PadLeft(rows));
			}
		}

		static void Q5()
		{
			DisplayHeader("Q5.等腰三角形");
			int rows = 4;

			for (int i = 1; i <= rows; i++)
			{
				for (int j = 1; j <= rows-i; j++)
				{
					Console.Write(" ");
				}
				for (int k = 1; k <= (i*2)-1; k++)
				{
					Console.Write("*");
				}
				Console.WriteLine();
			}
		}

		static void Q6()
		{
			DisplayHeader("Q6");
			int rows = 4;

			for (int i = rows; i >= 1; i--)
			{
				for (int j = 1; j <= rows - i; j++)
				{
					Console.Write(" ");
				}
				for (int k = 1; k <= (i * 2) - 1; k++)
				{
					Console.Write("*");
				}
				Console.WriteLine();
			}
		}

		static void DisplayHeader(string title)
		{
			Console.WriteLine("\r\n");
			Console.WriteLine(title);
			Console.WriteLine(new string('=', 40));
		}
	}
}
