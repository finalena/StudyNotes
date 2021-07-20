using System;

namespace example_03_02_01
{
	class Program
	{
		static void Main(string[] args)
		{
			//字串相加
			string firstName = "Kara";
			string lastName = "Rich";
			string fullName = firstName + lastName;

			//字串+數值
			int sum = 1 + 2 + 3 + 4 + 5;
			string leading = "1~5的總和=";
			Console.WriteLine(leading + sum);

			//字串+多個數值
			int num1 = 100;
			int num2 = 20;
			leading = "abc";
			Console.WriteLine(leading + num1 + num2);
			Console.WriteLine(leading + (num1 + num2));
			Console.WriteLine(leading + num1.ToString() + num2.ToString());

			//宣告字串變數值為 null
			string value1 = null;
			string value2 = "Kuno";
			string result = value1 + value2;
			Console.WriteLine(value1 + value2);

			//空字串
			string value3 = "";
			string value4 = string.Empty;

			//判斷字串是不是 null
			Console.WriteLine(value1 == null);

			//判斷字串是不是空字串
			Console.WriteLine(value3 == string.Empty);

			//判斷字串是不是連續空白
			Console.WriteLine("     ".Trim() == string.Empty);

			//判斷字串是不是null或空字串
			Console.WriteLine(string.IsNullOrEmpty(value1));
			Console.WriteLine(string.IsNullOrWhiteSpace(value2));
			Console.WriteLine(string.IsNullOrWhiteSpace("    "));
		}
	}
}
