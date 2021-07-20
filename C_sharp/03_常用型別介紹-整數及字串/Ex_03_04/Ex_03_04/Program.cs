
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_03_04
{
	class Program
	{
		static void Main(string[] args)
		{
			Book book = new Book();
			book.Open();

			Order order = new Order();
			int subTotal = order.CalcSubTotal(1000, 2);
			Console.WriteLine("小計: "+subTotal);

			Member member = new Member();
			//傳回字串
			Console.WriteLine(member.GetFullName("Tsai", "Fan");
			//無回傳值
			member.DrawLine(new string('*', 1));
			member.DrawLine(new string('*', 2));
			member.DrawLine(new string('*', 3));
			member.DrawLine(new string('*', 4));
			member.DrawLine(new string('*', 5));

			//靜態方法
			Order.DoB();	//有static，所以不用初始化物件 就可叫用
			Order order2 = new Order();
			order2.DoA();   //沒有static

		}
	}
	class Member
	{
		public string GetFullName(string firstName, string lastName)
		{
			string result = string.Empty;
			if (!string.IsNullOrEmpty(firstName))
			{
				result += firstName + " ";
			}
			if (!string.IsNullOrEmpty(lastName))
			{
				result += lastName;
			}
			return result.Trim();
		}
		
		public void DrawLine(string msg)
		{
			if (string.IsNullOrEmpty(msg)) return;

			Console.WriteLine(msg);
		}
	}

	class Order
	{
		public int CalcSubTotal(int unitPrice, int qty)
		{
			return unitPrice * qty;
		}

		public void DoA() { }
		public static void DoB() { }
	}

	class Book
	{
		public void Open() { }
		void Closed() { }
	}
}
