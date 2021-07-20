using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_09_02_P
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(100.Round());
			Console.WriteLine(119.Round());
			Console.WriteLine(210.Round());

			Console.WriteLine("01".ToInt());
			Console.WriteLine("ABC".ToInt());

			Console.ReadLine();
		}
	}

	public static class IntExts
	{
		/// <summary>
		/// 針對未稅金額計算 5% 營業稅, 傳回四捨五入的結果
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static int Round(this int value)
		{
			return (int)Math.Round(value * 0.05M, MidpointRounding.AwayFromZero);
		}
	}

	public static class StringExts
	{
		/// <summary>
		/// 將 string 轉換成 int 型別, 如果無法轉型成功, 傳回 defaultValue
		/// </summary>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static int ToInt(this string defaultValue)
		{
			if (!int.TryParse(defaultValue, out int result)) return -1;

			return result;
		}
	}
}
