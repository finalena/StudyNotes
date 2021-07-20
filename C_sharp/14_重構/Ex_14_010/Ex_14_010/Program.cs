using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_14_010
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> items = GetInputNumbers();

			(string even, string odd) result = BuildEventOddString(items);

			Console.WriteLine(result.even);
			Console.WriteLine(result.odd);

			Console.ReadLine();
		}

		private static (string,string) BuildEventOddString(List<int> inputlist)
		{
			string even = "偶數:";
			string odd = "奇數";
			foreach (int item in inputlist)
			{
				if (item % 2 == 0)
				{//偶數
					even += item.ToString() + ",";
				}
				else
				{//奇數
					odd += item.ToString() + ",";
				}
			}

			even = even.TrimEnd(',');
			odd = odd.TrimEnd(',');

			return (even, odd);
		}

		public static List<int> GetInputNumbers()
		{
			Console.WriteLine("請輸入數值以判斷基偶數，一串數值請以空白鍵分隔: ");
			string value = Console.ReadLine();

			string[] input = value.Split(' ');
			List<int> items = new List<int>();
			foreach (string item in input)
			{
				if (int.TryParse(item, out int iTmp))
				{
					items.Add(iTmp);
				}
			}
			items.Sort();

			return items;
		}
	}
}
