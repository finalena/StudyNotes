using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_08_01
{
	class Program
	{
		/* 抽象類別
		 * 當類別只是為了讓其他類別繼承用，並沒有實際意義
		 * 如果不讓其他人 new 出物件，可以將 class 宣告 abstract
		 */
		static void Main(string[] args)
		{
			//People p1 = new People(); // 這是不合理的
			//People p2 = new Employee(); // 這是不合理的
			People p3 = new Engineer();
			People p4 = new Sales();
			People p5 = new Manager();
		}
	}

	abstract class People
	{
		public string Name;
		public bool Gender; // 性別
	}

	abstract class Employee : People
	{
		public string BadgeNumber; // 員工編號
		public int BaseSalary; // 基本月薪
	}

	class Engineer : Employee
	{ }

	class Sales : Employee
	{
		public int PerformanceInThisMonth; // 本月績效
		public decimal BonusRate; // 獎金比率
	}

	class Manager : Employee
	{
		public Employee[] TeamMembers; // 帶領的員工
	}
}
