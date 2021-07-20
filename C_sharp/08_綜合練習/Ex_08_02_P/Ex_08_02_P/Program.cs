using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_08_02_P
{
	class Program
	{
		static void Main(string[] args)
		{
			int target = GetTargetNumber();

			while (true)
			{
				int number = GetNumber(target);

				if (number == -1) break;
				if (number == target)
				{
					Console.WriteLine("答對了!!");
					break;
				}
				else if (number < target)
				{
					Console.WriteLine("比你剛才輸入的數字還大");
				}
				else if (number > target)
				{
					Console.WriteLine("比你剛才輸入的數字還小");
				}
			}

			Console.ReadKey();
		}

		// 用亂數取得 >=1 and <=99 的數字
		private static int GetTargetNumber()
		{
			Random rnd = new Random();
			int num = rnd.Next(1,99);

			return num;
		}


		private static int GetNumber(int target)
		{
			int iResult;
			int beginNumber = 1, endNumber = 99;
			Console.Write($"請輸入 {beginNumber} ~ {endNumber} 之間的數, 若輸入 x 表示結束: ");

			string value = Console.ReadLine();
			if (value == "x") return -1;

			if (!int.TryParse(value, out iResult))
			{
				Console.WriteLine("您沒有輸入正確的數值, 請再試一次");
			}

			return iResult;
		}
	}
}
