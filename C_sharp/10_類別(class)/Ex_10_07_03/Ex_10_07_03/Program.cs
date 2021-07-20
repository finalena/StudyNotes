using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_07_03
{
	class Program
	{
		/* 匿名方法: 不用為方法命名的函數
		 * 
		 * 簡化寫法:
		 * Func<int, int> discount_80 = (p) => { return p * 8 / 10; }; 可以明白傳入參數型一定是int, 所以可以省略
		 * statement Lambda(陳述式 Lambda)
		 * Func<int, int> discount_80 = p => { return p * 8 / 10; }; 只有一個參數, 小括號可以省略
		 * 沒有大括號的寫法, 稱為 expression Lambda(運算式 Lambda)
		 * Func<int, int> discount_80 = p => p * 8 / 10; 程式碼只有一行, 大括號和return可以省略 
		 */
		static void Main(string[] args)
		{
			var order = new Order();
			int price = 10000;
			Func<int, int> discount_80 = (int p) => { return p * 8 / 10; };
			int result = order.CalcTotal(price, discount_80);
			Console.WriteLine(result);

			Func<int, int> promotionA = (int p) => { return (price >= 10000) ? price - 1000 : price; };
			int resultA = order.CalcTotal(price, promotionA);
			Console.WriteLine(resultA);

			Console.ReadLine();
		}

		//static int Discount_80(int price)
		//{
		//	return price * 8 / 10;
		//}

		//static int PromotionA(int price)
		//{
		//	return (price >= 10000) ? price - 1000 : price;
		//}
	}

	// public delegate int PromoHandler(int price);

	public class Order
	{
		public int CalcTotal(int price, Func<int, int> handler)
		{
			if (price < 0) throw new ArgumentOutOfRangeException(nameof(price), "price 不可以小於零");

			if (handler == null) throw new ArgumentNullException(nameof(handler), "必需傳入 PromoHandler");

			return handler(price);
		}
	}
}
