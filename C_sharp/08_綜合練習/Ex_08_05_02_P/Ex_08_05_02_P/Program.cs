using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_08_05_02_P
{
	class Program
	{
		//輸入生日, 取得生日的年份, 與電腦今天日期的年份, 兩者相減, 顯示年齡是多少
		static void Main(string[] args)
		{
			DateTime dateOfBirth = GetDateOfBirth();
			int age;

			age = DateTime.Today.Year - dateOfBirth.Year;

			Console.WriteLine(age);

			Console.ReadLine();
		}
		private static DateTime GetDateOfBirth()
		{
			DateTime dTime;

			while (true)
			{
				Console.WriteLine("請輸入生日:");
				string value = Console.ReadLine();

				if (!DateTime.TryParse(value, out dTime))
				{
					Console.WriteLine("輸入錯誤，請重新輸入生日");
				}
				else
				{
					break;
				}
			}

			return dTime;
		}
	}
}
