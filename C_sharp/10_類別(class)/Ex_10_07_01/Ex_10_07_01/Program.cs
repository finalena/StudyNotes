using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_07_01
{
	class Program
	{
		static void Main(string[] args)
		{
			var order = new Order();
			int price = 10000;
			//3.用 new 建立委派，方法可以放入委派當作參數傳遞
			var handler = new PromoHandler(Discount_80);
			//4.委派可以當作其他方法的參數
			int result = order.CalcTotal(price, handler);
			Console.WriteLine(result);

			//建立委派語法糖
			PromoHandler handlerA = PromotionA; 
			int resultA = order.CalcTotal(price, handlerA);
			Console.WriteLine(resultA);

			Console.ReadLine();
		}

		//2.放進委派裡的方法，簽名碼必須和委派相同:傳入一個int物件，傳回int結果的物件
		static int Discount_80(int price)
		{
			return price * 8 / 10;
		}

		static int PromotionA(int price)
		{
			return (price >= 10000) ? price - 1000 : price;
		}
	}

	//1.宣告委派，表示傳入一個int物件，傳回int結果的物件
	public delegate int PromoHandler(int price);

	public class Order
	{
		public int CalcTotal(int price, PromoHandler handler)
		{
			if (price < 0) throw new ArgumentException(nameof(price), "price不可小於0");
			if (handler == null) throw new ArgumentException(nameof(handler), "必須傳入PromoHandler");

			return handler(price);
		}
	}
}
