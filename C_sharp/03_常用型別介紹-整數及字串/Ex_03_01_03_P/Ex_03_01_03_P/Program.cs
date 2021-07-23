using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_03_01_03
{
	class Program
	{
		static void Main(string[] args)
		{
			Q1();
			Q2();
			Q3();
			Q4();

			Console.ReadLine();
		}

		private static void Q1()
		{
			DisplayHeader("先心算以下計算式, 再寫程式驗證結果與您想的是否相同");
			Console.WriteLine(1 + (2 + 2) * 3 - 1);
			Console.WriteLine(2 + ((2 + 1) / 3 + 1) * 2);
		}


		private static void Q2()
		{
			DisplayHeader("寫程式, 計算並顯示 120 除以 7 的商數, 餘數, 各是多少");
			int num1 = 120;
			int num2 = 7;
			Console.WriteLine($"{num1} 除以 {num2} 的商數={num1 / num2}, 餘數={ num1 % num2}");
		}

		private static void Q3()
		{
			DisplayHeader("寫程式, 計算並顯示 1 + 2 + 3 + ....+10 的總和");
			int beginNum = 1;
			int endNum = 10;
			Console.WriteLine(endNum * (endNum + beginNum) / 2);
		}

		private static void Q4()
		{
			DisplayHeader("計算 9, 202 是奇數或是偶數");
			int result1 = 202;
			int result2 = 9;
			Console.WriteLine($"202是{EvenOrOdd(result1)}");
			Console.WriteLine($"9是{EvenOrOdd(result2)}");
		}

		public static string EvenOrOdd(int num)
		{
			int result = num % 2;
			return (result == 0 ? "偶數" : "奇數");
		}

		public static void DisplayHeader(string title)
		{
			Console.WriteLine("\r\n");
			Console.WriteLine(title);
			Console.WriteLine(new string ( '=', 40 ));
		}
	}
}
