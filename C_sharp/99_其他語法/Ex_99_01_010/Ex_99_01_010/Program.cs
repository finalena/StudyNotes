using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_99_01_010
{
	class Program
	{
		/* ?? 運算子 - ?? 左邊的變數值為 null, 就傳回 ?? 右邊的值
		 */
		static void Main(string[] args)
		{
			string value = null;
			string result = value ?? "";
			Console.WriteLine(result);

			string value2 = "abc";
			string result2 = value2 ?? "unknown";
			Console.WriteLine(result2);

			Console.ReadLine();
		}
	}
}
