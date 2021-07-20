using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_04_02._1
{
	class Program
	{
		/* 複寫 Override
		 * 父類別方法加上 virtual 關鍵字，即可在子類別使用 override 複寫該方法
		 */
		static void Main(string[] args)
		{
		}
	}

	class Employee
	{
		public string Name;
		public bool Gender;
		public string BadgeNumber; //員工編號
		public int BaseSalary; //基本月薪
		
		public virtual int GetSalary()
		{
			return BaseSalary;
		}

		public void Test() { }
	}

	class Sales: Employee
	{
		public int PerformanceInthisMonth; //本月績效
		public decimal BonusRate; //獎金比率

		public override int GetSalary()
		{
			return base.GetSalary() + (int)(PerformanceInthisMonth * BonusRate);
		}

		public override string ToString()
		{//所有的方法皆直接或間接繼承object，因此可以複寫Tostring()等虛擬方法
			return base.ToString();
		}
	}

	class Manger: Employee
	{
		public Employee[] TemaMembers; //帶領的員工

		public override int GetSalary()
		{ //每帶領一個員工加給500元
			return base.GetSalary() + TemaMembers.Length * 500;
		}
	}
}
