using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_11
{
	class Program
	{
		static void Main(string[] args)
		{
			var member = new Member();
			member.Name = "Gina";
			string name = member.Name;

			//vip 和 vip2 能夠叫用的成員不同，是因為前面宣告的型別有關
			VIP vip = new VIP();
			IMember vip2 = new VIP();

			bool resultA = IsGreater(3, 5);
			bool resultB = IsGreater(2.4M, 5.7M);
			bool resultC = IsGreater(1.6F, 8.5F);
		}

		static bool IsGreater(IComparable souce, IComparable targer)
		{
			int result = souce.CompareTo(targer);
			return (result > 0);
		}

		//static bool IsGreater(int source, int target)
		//{
		//	return (source > target);
		//}
		//static bool IsGreater(decimal source, decimal target)
		//{
		//	return (source > target);
		//}
	}

	class Member
	{
		public int Id; //field
		private string _Name;

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		public int Add(int num1, int num2)
		{
			return num1 * num2;
		}
	}

	interface IMember
	{
		//public int Id; //無法宣告field

		//宣告有Name這個屬性
		//不能加上public、protected 和 private，存取子裡也不能寫程式
		string Name { get; set; } 

		//宣告有Add這個方法，不能有大括號
		int Add(int num1, int num2);
	}

	/* 實作介面
	 * 1.必須實作介面中所有成員
	 * 2.且成員必需宣告成 public
	 */
	class VIP : IMember
	{
		public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public int Add(int num1, int num2)
		{
			throw new NotImplementedException();
		}

		public void DoA() { }
	}
}
