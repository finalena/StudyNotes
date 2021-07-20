using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_03_02_06
{
	class Program
	{
		static void Main(string[] args)
		{
			//將字串左右空白刪除後, 顯示最後字串長度是多少
			Console.WriteLine("  abc  ".Trim().Length);

			//轉換成全部大寫
			Console.WriteLine("Allen Kuo".ToUpper());

			//第一個單字的開頭大寫,其餘小寫
			string name = "aLLeN kUO";
			Console.WriteLine(name.Substring(0,1).ToUpper() + name.Substring(1).ToLower());

			Console.ReadLine();
		}
	}
}
