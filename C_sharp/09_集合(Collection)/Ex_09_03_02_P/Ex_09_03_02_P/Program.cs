using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_09_03_02_P
{
	class Program
	{
		static void Main(string[] args)
		{
			//計算陣列，每一種值出現的次數
			string[] items = new string[] { "A", "C", "B", "A", "Z", "A", "C" };

			Dictionary<string, int> dic = new Dictionary<string, int>();
			foreach (var item in items)
			{
				if (dic.ContainsKey(item))
				{
					dic[item]++;
				}
				else
				{
					dic.Add(item, 1);
				}
			}

			
			foreach (var item in dic)
			{
				Console.WriteLine($"Key = {item.Key}, 數目 = {item.Value}");
			}

			Console.ReadLine();
		}
	}
}
