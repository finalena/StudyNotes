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
			//先心算以下計算式, 再寫程式驗證結果與您想的是否相同
			Console.WriteLine(1 + (2 + 2) * 3 - 1);
			Console.WriteLine(2 + ((2 + 1) / 3 + 1) * 2);

			//寫程式, 計算並顯示 120 除以 7 的商數, 餘數, 各是多少
			int num1 = 120;
			int num2 = 7;
			Console.WriteLine($"{num1} 除以 {num2} 的商數={num1 / num2}, 餘數={ num1 % num2}");

			//寫程式, 計算並顯示 1 + 2 + 3 + ....+10 的總和
			int n = 10;
			Console.WriteLine(n * (n + 1) / 2);

			//計算 9, 202 是奇數或是偶數
			int result1 = 202 % 2;
			int result2 = 9 % 2;
			Console.WriteLine($"202是{EvenOrOdd(result1)}");
			Console.WriteLine($"9是{EvenOrOdd(result2)}");

			Console.ReadLine();
		}

		public static string EvenOrOdd(int num)
		{
			return (num == 0 ? "偶數" : "奇數");
		}
	}
}
