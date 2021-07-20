using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_14_020
{
	class Program
	{
		//重構-是否為質數
		static void Main(string[] args)
		{
			int beginNumber = 11;
			int count = 101 - beginNumber + 1;

			Enumerable.Range(beginNumber, count)
				.ToList()
				.ForEach(x =>
				{
					Console.WriteLine($"輸入的數字:{x} {(x.IsPrime() ? "是" : "不是")} 質數");
				});
		

			Console.ReadKey();
		}

		
	}

	public static class MathHelper
	{
		public static bool IsPrime(this int targetNumber)
		{
			if (targetNumber == 2) return true;
			if (targetNumber % 2 == 0) return false;

			int maxValue = (int)Math.Sqrt((double)targetNumber);

			for (int currentNum = 3; currentNum <= maxValue; currentNum+=2)
			{
				if (targetNumber % currentNum == 0) return false;
			}

			return true;
		}
	}

	public class MathHelperTests
	{
		[TestCase(2)]
		[TestCase(3)]
		[TestCase(11)]
		public void IsPrime_returnsTrue(int number)
		{
			bool actual = MathHelper.IsPrime(number);

			Assert.IsTrue(actual);
		}

		[TestCase(4)]
		[TestCase(6)]
		[TestCase(9)]
		public void IsPrime_returnsFalse(int number)
		{
			bool actual = MathHelper.IsPrime(number);

			Assert.IsFalse(actual);
		}
	}
}
