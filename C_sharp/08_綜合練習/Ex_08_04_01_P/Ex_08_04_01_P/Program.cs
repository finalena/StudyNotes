using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_08_04_01_P
{
    class Program
    {
		static void Main(string[] args)
		{
			int[] items = new int[] { 5, 6, 2, 99, 1, 108, 12 };
			M1(items);
			M2(items);

			Console.ReadLine();
		}

		/// <summary>方法一-使用Array類別排序
		/// </summary>
		/// <param name="items"></param>
		private static void M1(int[] items)
		{
			Array.Sort(items);
			DisplayResult(items);
		}

		/// <summary> 方法二-氣泡排序法 </summary>
		/// <param name="items"></param>
		private static void M2(int[] items)
		{
			int[] itemsR = BubbleSort(items);
			DisplayResult(itemsR);
		}
		
		private static int[] BubbleSort(int[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				for (int j = i + 1; j < arr.Length; j++)
				{
					if (arr[i] > arr[j])
					{
						int iTemp = arr[i];
						arr[i] = arr[j];
						arr[j] = iTemp;
					}
				}
			}
			return arr;
		}

		private static void DisplayResult(int[] items)
		{
			string result = string.Empty;
			foreach (var item in items)
			{
				result += ", " + item;
			}
			if (result != string.Empty) result = result.Substring(1);
			Console.WriteLine(result);
		}
	}
}
