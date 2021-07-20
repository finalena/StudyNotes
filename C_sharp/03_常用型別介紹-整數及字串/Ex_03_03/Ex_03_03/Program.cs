using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_03_03
{
	class Program
	{
		static void Main(string[] args)
		{
			//宣告陣列長度，並事後填入值
			int[] numbers = new int[4];
			numbers[0] = 1;
			numbers[1] = 2;
			numbers[2] = 3;
			numbers[3] = 4;

			//宣告陣列時，一併填入值
			string[] items = new string[] { "A", "B", "C" };

			//取得陣列長度
			int length = items.Length;
		}
	}
}
