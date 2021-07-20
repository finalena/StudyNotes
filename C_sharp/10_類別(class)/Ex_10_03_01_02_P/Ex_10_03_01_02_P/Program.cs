using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_03_01_02_P
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 *程式規則: 計算總金額, 如果在優惠期間內, 就套用 原始金額 * RegularRage + RegularServiceCharge
			 * 若不在優惠期間, 就套用 原始金額 * Rate 就好,連 RegularServiceCharge都不必收
			 */
			DateTime beginDate = new DateTime(2021, 1, 1),
				endDate = new DateTime(2021, 5, 25);
			decimal regularRate = 0.95M, // 不在優惠期間, 折九五折
				rate = 0.75M; // 若在優惠期間, 打七五折

			int regularServiceCharge = 80; // 若不在優惠期間, 要額外加運費 80 元

			var promotion = new Promotion(beginDate, endDate, regularRate, rate, regularServiceCharge);
			DateTime dt = new DateTime(2021, 3, 8); // 購買日期
			int price = 1000; // 訂單金額1千元
			int total = promotion.CalcTotal(price);

			Console.WriteLine(total);

			Console.ReadLine();
		}

	}

	/// <summary>
	/// 商品促銷計劃, 不同日期有不同折扣
	/// </summary>
	class Promotion
	{
		public DateTime BeginDate { get; } // 優惠開始日
		public DateTime EndDate { get; } // 優惠結束日
		public decimal RegularRate { get; } // 如果不在優惠期間,可享的折扣
		public decimal Rate { get; } // 如果在優惠期間, 購買商品可享的折扣
		public int RegularServiceCharge { get; } // 基本運費
		private bool InpromotionPeriod   // 判斷是否介於優惠期間
		{
			get { return DateTime.Today >= this.BeginDate && DateTime.Today <= this.EndDate}
		}

		public Promotion(DateTime beginDate, DateTime endDate, decimal regularRate, decimal rate, int regularServiceCharge)
		{
			BeginDate = beginDate;
			EndDate = endDate;
			RegularRate = regularRate; // [20201/06/24 更正]
			Rate = rate;
			RegularServiceCharge = regularServiceCharge;
		}

		public int CalcTotal(int price)
		{
			int total; // 最後應付金額
			if (InpromotionPeriod)
			{
				total = (int)(price * Rate);
			}
			else
			{
				total = (int)(price * RegularRate) + RegularServiceCharge;
			}

			return total;
		}
	}
}
