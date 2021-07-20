using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_03_02_04
{
	class Program
	{
		static void Main(string[] args)
		{
			string temp1 = @"D:\temp\animal.jpg";
			Console.WriteLine(temp1);

			string temp2 = "我是一個\"好學生\", 會乖乘練習寫作業";
			Console.WriteLine(temp2);

			string temp3 = "我是第一行文字" + Environment.NewLine + "我是第二行文字";
			Console.WriteLine(temp3);

			string temp4 = @"< select >
	< option value = ""1"" > 台北 </ option >
	< option value = ""2"" > 台中 </ option >
</ select >";
			Console.WriteLine(temp4);

			Console.ReadLine();
		}
	}
}
