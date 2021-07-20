
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_08_01_P
{
	class Program
	{
		static void Main(string[] args)
		{
			M1();
			M2();

			Console.ReadLine();
		}

		/// <summary>
		/// 使用迴圈, 持續地取得1~42之間的亂數, 存放進陣列前檢查是否已取過重覆的數值
		/// </summary>
		static void M2()
		{
			DisplayHeader("M2");
			Random rnd = new Random();
			int[] result = new int[6];
			int index = 0;

			while (index < 6)
			{
				int item = rnd.Next(1, 42);
				if ((Array.IndexOf(result, item) == -1))
				{
					result[index] = item;
					index++;
				}
			}
			
			foreach (var item in result)
			{
				Console.WriteLine(item);
			}
		}

		/// <summary>
		/// 將1~42依序放入陣列, 再將陣列裡的項目順序打亂(會使用到亂數), 再列出前六項
		/// </summary>
		static void M1()
		{
			DisplayHeader("M1");

			int[] items = SetUpNumbers(); 
			int[] result = Shuffle(items);

			for (int i = 0; i < 6; i++)
			{
				Console.WriteLine(result[i]);
			}
		}

		/// <summary>洗牌, 將陣列順序打亂</summary>
		/// <param name="items"></param>
		/// <returns></returns>
		private static int[] Shuffle(int[] items)
		{
			int length = items.Length;
			Random rnd = new Random();
			int iNum;
			int iTmp;
			for (int i = 0; i < length - 1; i++)
			{
				iNum = rnd.Next(i, length);	//亂數取得要交換的位置
				if (i == iNum) continue;

				iTmp = items[i];
				items[i] = items[iNum];
				items[iNum] = iTmp; 
			}

			return items;
		}

		/// <summary>建立1~42</summary>
		/// <returns></returns>
		private static int[] SetUpNumbers()
		{
			int[] items = new int[42];
			for (int i = 0; i < 42; i++)
			{
				items[i] = i + 1;
			}

			return items;
		}

		static void DisplayHeader(string title)
		{
			Console.WriteLine("\r\n");
			Console.WriteLine(title);
			Console.WriteLine(new string('=', 40));

		}
	}
}
