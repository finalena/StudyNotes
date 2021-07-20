using System;

namespace Ex_06_03_02_01
{
	class Program
	{
		static void Main(string[] args)
		{
			Int64 numA = 12;
			string valueA = Convert.ToString(numA, 16); //轉型成十六進制再取得字串
			Console.WriteLine(valueA);

			string valueB = Convert.ToString(numA, 2); //轉型成二進制再取得字串
			Console.WriteLine(valueB);

			string valueC = Convert.ToString(numA, 8); //轉型成八進制再取得字串
			Console.WriteLine(valueC);
		}
	}
}
