  using System;

namespace Ex_14_500
{
	class Program
	{
		/* 計算商品售價
		 * - 如果是春/夏/冬季就傳回不同特價, 若是秋季就傳回原價
		 * - 春季是2~4月,依此類推
		 */
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			Console.ReadLine();
		}
	}

	public class Product
	{
		// 標準售價
		public int ListPrice { get; set; }

		/// <summary>
		/// 根據月份, 傳回不同特價或原價
		/// </summary>
		/// <param name="purchaseDate"></param>
		/// <returns></returns>
		public int GetPrice(DateTime purchaseDate)
		{
			int month = purchaseDate.Month;
			if (month >= 2 && month <= 4) return SprintPrice();
			if (month >= 5 && month <= 7) return SummerPrice();
			if(month == 1 || month >= 11) return WinterPrice();

			return ListPrice;
		}

		// 夏季特價
		public int SummerPrice()
			=> ListPrice / 2; // 五折

		public int WinterPrice()
			=> ListPrice * 4 / 5; // 八折

		public int SprintPrice()
			=> ListPrice * 9 / 10; // 九折
	}
}
