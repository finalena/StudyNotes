using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_07_01._2
{
	class Program
	{
		/* 將 Ex_10_07_01 專案改成使用 Func 泛型委派
		 * 
		 * Func 是可以具有傳回值的委派
		 * 最後一個參數表示傳回值的型別，其他都是傳入參數的型別
		 * Action 是不會有回傳值的委派
		 */
		static void Main(string[] args)
		{
			var order = new Order();
			int price = 10000;

			//語法糖: 使用方法當作委派，編譯時會自動轉成委派
			int result = order.CalcTotal(price, Discount_80);
			Console.WriteLine(result);

			int resultA = order.CalcTotal(price, PromotionA);
			Console.WriteLine(resultA);

			Console.ReadLine();
		}

		//放進委派裡的方法，簽名碼必須和委派相同:傳入一個int物件，傳回int結果的物件
		static int Discount_80(int price)
		{
			return price * 8 / 10;
		}

		static int PromotionA(int price)
		{
			return (price >= 10000) ? price - 1000 : price;
		}
	}

	public class Order
	{
		//不自訂委派, 改成 Func<int, int>
		public int CalcTotal(int price, Func<int,int> handler)
		{
			if (price < 0) throw new ArgumentException(nameof(price), "price不可小於0");
			if (handler == null) throw new ArgumentException(nameof(handler), "必須傳入PromoHandler");

			return handler(price);
		}
	}
}
