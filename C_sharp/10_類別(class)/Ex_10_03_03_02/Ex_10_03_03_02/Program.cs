using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_03_03_02
{
	class Program
	{
		static void Main(string[] args)
		{
			var range = new IntRange(1, 10);

			bool result;
			Console.WriteLine(range.IsValid(0));  // false
			Console.WriteLine(range.IsValid(1));  // true
			Console.WriteLine(range.IsValid(2));  // true
			Console.WriteLine(range.IsValid(9));  // true
			Console.WriteLine(range.IsValid(10));  // false
			Console.WriteLine(range.IsValid(11));  // false

			Console.ReadLine();
		}
	}

	public struct IntRange
	{
		public int MinValue { get; }
		public int MaxValue { get; }

		public IntRange(int minValue, int maxValue)
		{
			MinValue = minValue;
			MaxValue = maxValue;
		}

		/// <summary>
		/// 如果 value 介於 MinValue, MaxValue 之間, 傳回true
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool IsValid(int value)
		{
			if (value >= MinValue && value < MaxValue)
			{
				return true;
			}

			return false;
		}
	}
}
