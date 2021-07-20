	using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_05
{
	class Program
	{
		static void Main(string[] args)
		{
			//NullReferenceException
			string email = null;
			int location = email.IndexOf('@');

			//DivideByZeroException
			int num1 = 10;
			int num2 = 0;
			int result = num1 / num2;

			//ArgumentOutOfRangeException 傳入數值大於字串長度
			string value = "0123456";
			string result2 = value.Substring(100);

			//ArgumentNullException 值不能為 null
			string template = null;
			string result3 = string.Format(template, "123");

			//FormatException
			string template2 = "Hi {a}";
			string result4 = string.Format(template2, "123");
		}
	}
}
