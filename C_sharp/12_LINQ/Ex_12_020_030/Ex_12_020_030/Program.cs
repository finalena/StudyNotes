using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_020_030
{
	class Program
	{
		/* Select 傳回一個新的結果，並不是篩選值
		 */
		static void Main(string[] args)
		{
			int[] source = new int[] { 1, 3, 5, 30 };
			int[] result = source.Select(Func).ToArray();
			int[] resultB = source.Select(x => x * 2).ToArray();
			
			Console.ReadLine();
		}

		static int Func(int value)
		{
			return value * 2;
		}
	
	}

	static class IEnumerableExts
	{
		public static void Dump<T>(this IEnumerable<T> source)
		{
			foreach (var item in source)
			{
				Console.Write(item + ", ");
			}
			Console.WriteLine();
		}
	}
}
