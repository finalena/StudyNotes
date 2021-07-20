using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_06_03_02_02
{
	class Program
	{
		static void Main(string[] args)
		{
			string signal = "x";
			string greetingMessage = $"請輸入您的年齡(整數),如果輸入 {signal} 表示要結束程式:";
			string alertMessage = "您沒有輸入正確的數值, 請再試一次\r\n";

			try
			{
				int age = GetInputInteger(signal, greetingMessage, alertMessage);
				Console.WriteLine($"您輸入的值是 {age}");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.ReadLine();
		}

		static int GetInputInteger(string signal, string greetingMessage, string alertMessage)
		{
			int age;

			while (true)
			{
				Console.Write(greetingMessage);
				string value = Console.ReadLine();

				if (value.Equals(signal)) throw new Exception("使用者強制結束");

				bool isInt = int.TryParse(value, out age);

				if (isInt)
				{
					return age;
				}
				else
				{
					Console.WriteLine(alertMessage);
				}
			}
		}
	}
}
