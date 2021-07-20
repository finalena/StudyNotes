using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_05_02_04
{
	class Program
	{
		static void Main(string[] args)
		{
			string template = null;
			string UserName = "SimSim";

			try
			{
				Console.WriteLine(GetGreeing(template, UserName));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.ReadLine();
		}

		private static string GetGreeing(string templete, string userName)
		{
			if (string.IsNullOrWhiteSpace(templete))
				throw new ArgumentNullException(paramName: "templete", message: "templete 不能為 null 或空字串");

			try
			{
				return string.Format(templete, userName);
			}
			catch (FormatException FEx)
			{
				throw new Exception(message: "格式化失敗, 請檢查傳入的 template 版型是否正確然後再試一次");
			}
			catch (Exception ex) {
				throw new Exception(message: $"格式化失敗,原因:{ex.Message}");
			}
			
		}
	}
}
