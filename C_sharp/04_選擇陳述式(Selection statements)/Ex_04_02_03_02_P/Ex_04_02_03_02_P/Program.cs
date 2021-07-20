using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_04_02_03_02
{
	class Program
	{
		static void Main(string[] args)
		{
			Q1();
		}
		static void Q1()
		{
			DisplayHeader("Q1.計算 1 + 2 + 3+ ... + N 的總和");
			int beginNumber = 1, endNumber = 10000;

			int reslut = (beginNumber + endNumber) * endNumber / 2;
			Console.WriteLine("總和為:" + reslut);

			Console.WriteLine("遞迴解總和為: " + Sum(beginNumber, endNumber));

			Console.ReadLine();
		}

		static int Sum(int beginNum, int endNum)
		{
			if (endNum < beginNum) return 0;

			return endNum + Sum(beginNum, endNum - beginNum);
		}

		static void DisplayHeader(string title)
		{
			Console.WriteLine("\r\n");
			Console.WriteLine(title);
			Console.WriteLine(new string('=', 40));

		}
	}
}
