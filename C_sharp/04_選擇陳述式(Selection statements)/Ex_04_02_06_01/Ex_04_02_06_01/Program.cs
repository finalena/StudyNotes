using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_06_02_06_01
{
	class Program
	{
		static void Main(string[] args)
		{
			//使用 while , 在畫面顯示所有可以整除 300 的整數, 例如: 1, 2, 3, 4, 5, 6, 10, ...., 300
			int num = 300;
			int endNum = (int)Math.Sqrt(num);

			string result = string.Empty;
			int index = 1;
			while (index < endNum)
			{
				if (num % index ==0)
				{
					int quotient = num / index;
					result += index + ",";	
					if (quotient != index) result +=  quotient + ",";
				}

				index++;
			}

			Console.WriteLine(result);

			Console.ReadLine();
		}
	}
}
