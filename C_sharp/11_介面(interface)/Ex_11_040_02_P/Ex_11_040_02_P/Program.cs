using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_11_040_02_P
{
	/* interface 開放封閉原則
	 * 如何做到能抽換購物車的折扣計算方式
	 * - 七折
	 * - 超過一萬元，一律優惠一千元
	 * - 每超過一萬元，就優惠一千元
	 * Ref: 
	 * https://dotblogs.com.tw/initials/2016/07/11/214002
	 */
	class Program
	{
		static void Main(string[] args)
		{

			IDiscount discountType = DiscountFactory.GetDiscountType("七折");
			discountType.DiscountCalc(10000);
			decimal fee = discountType.Fee;

			Console.WriteLine(fee);

			Console.ReadLine();
		}
	}

	public class DiscountFactory
	{
		public static IDiscount GetDiscountType(string type)
		{
			switch (type)
			{
				case "七折":
					return new Discount30Percent();
				case "超過一萬元":
					return new DiscountExceed();
				case "每超過一萬元":
					return new DiscountEveryMoreThen();
				default:
					return null;
			}
		}
	}

	public interface IDiscount
	{
		int Discount { get; set; }
		decimal Fee { get; set; }
		void DiscountCalc(int total);
	}

	class Discount30Percent : IDiscount
	{
		public int Discount { get; set; }

		public decimal Fee { get; set; }

		public void DiscountCalc(int total)
		{
			this.Discount = 30;
			this.Fee = total * (100 - this.Discount) / 100; 
		}
	}

	class DiscountExceed : IDiscount
	{
		public int Discount { get; set; }
		public decimal Fee { get; set; }
		public void DiscountCalc(int total)
		{
			this.Discount = 1000;
			this.Fee = (total > 10000) ? this.Discount : 0;
		}
	}

	class DiscountEveryMoreThen : IDiscount
	{
		public int Discount { get; set; }
		public decimal Fee { get; set; }
		public void DiscountCalc(int total)
		{
			this.Discount = 1000;
			int count = total / 10000;
			this.Fee = count * this.Discount;
		}
	}
}
