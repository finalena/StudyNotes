using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_08_04_02_P
{
	class Program
	{
		//將字母順序顛倒
		static void Main(string[] args)
		{
			string source = "ABCDEF";
			string result = Reverse(source);

			Console.WriteLine(result);
			Console.ReadLine();
		}

		private static string Reverse(string source)
		{
			string result = string.Empty;
			char[] temp = source.ToCharArray();

			for (int i = temp.Length-1; i >= 0; i--)
			{
				result += temp[i];
			}

			return result;
		}
	}
}
