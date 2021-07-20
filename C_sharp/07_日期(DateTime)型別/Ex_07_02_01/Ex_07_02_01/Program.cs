using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_07_02_01
{
	class Program
	{
		static void Main(string[] args)
		{
			P1();
			P2();
			P3();
			P4();
			P5();

			Console.ReadLine();
		}

		//判斷是不是閏年
		static void P1()
		{
			bool isLeapYear = DateTime.IsLeapYear(DateTime.Today.Year);
			Console.WriteLine(DateTime.Today.Year + ":" + isLeapYear);

			int iYear = new DateTime(2000, 01, 01).Year;
			Console.WriteLine(iYear + ":" + DateTime.IsLeapYear(iYear));

			//閨年要能以 100 整除，同時也要能以 400 整除
			int iYear2 = new DateTime(1900, 01, 01).Year;
			Console.WriteLine(iYear2 + ":" + DateTime.IsLeapYear(iYear2));
		}

		//計算月初和月底
		static void P2()
		{
			DateTime today = DateTime.Today;
			int year = today.Year;
			int month = today.Month;

			DateTime result = new DateTime(year, month, 1);
			Console.WriteLine("月初:" + result);
			Console.WriteLine("月底:" + result.AddMonths(1).AddMonths(-1));
		}

		//計算下個月的今天
		static void P3()
		{
			DateTime today = new DateTime(2021, 1, 31);
			DateTime result = today.AddMonths(1);
			Console.WriteLine(result);
		}

		//計算本月有幾天
		static void P4()
		{
			DateTime today = DateTime.Now;
			int year = today.Year;
			int month = today.Month;
			Console.WriteLine($"本月有{DateTime.DaysInMonth(year,month)}天");
		}

		//計算今天是星期幾
		static void P5()
		{
			DateTime today = DateTime.Today;
			Console.WriteLine(today);

			DayOfWeek dayOfWeek = today.DayOfWeek;
			Console.WriteLine(dayOfWeek);

			int iDatOfWeek = (int)dayOfWeek;
			Console.WriteLine(iDatOfWeek);
		}
	}
}
