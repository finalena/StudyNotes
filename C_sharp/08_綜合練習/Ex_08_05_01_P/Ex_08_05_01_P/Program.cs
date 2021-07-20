using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Ex_08_05_01_P
{
	class Program
	{
		/*
		 * 判斷它必需是日期
		 * 該日期不允許比今天還大(因為沒有人是明天以後才出生的)
		 * 只能輸入日期, 不能包含時間
		 */
		static void Main(string[] args)
		{
			string format = "yyyy/MM/dd";
			while (true)
			{
				Console.Write("請輸入生日，結束請輸入x :");

				string value = Console.ReadLine();
				if (value.ToLower() == "x".ToLower())
				{
					Console.WriteLine("您已離開..");
					break;
				}

				string birthday = CheckData(value, format);
				if (birthday != "")
				{
					Console.WriteLine($"您的生日是:{birthday}");
				}
				
			}

			Console.ReadLine();
		}

		private static string CheckData(string value, string format)
		{
			DateTime dTime;
			if (!DateTime.TryParse(value, out dTime))
			{
				Console.WriteLine("請輸入日期，格式為yyyy/MM/dd");
				return "";
			}

			if (dTime > dTime.Date)
			{
				Console.WriteLine("請輸入日期，不用輸入時間");
			}

			if (dTime > DateTime.Today)
			{
				Console.WriteLine("生日不能比今天還大");
				return "";
			}

		
			return dTime.ToString("yyyy/MM/dd");
		}
	}
}
