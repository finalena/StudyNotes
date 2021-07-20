using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_05_02_01
{
	class Program
	{
		static void Main(string[] args)
		{
			//使用 try-catch 補捉 exception
			try
			{
				int result = GetIndexOfAt(null);
				Console.WriteLine($"@位置出現在{result}");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.ReadLine();
		}

		static int GetIndexOfAt(string email)
		{
			if (email == null)
			{
				throw new ArgumentNullException(paramName: "email", message: "email 不可為null");
			}

			return email.IndexOf('@');
		}
	}
}
