using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_06_03_01
{
	class Program
	{
		static void Main(string[] args)
		{
			T1();
			T2();
			T3();
			T4();

			Console.ReadLine();
		}

		/// <summary>int 轉換成 decimal</summary>
		static void T1()
		{
			//隱式類型轉換(implicit type conversion)
			int iNum = 100;
			decimal dNum = iNum;
			Console.WriteLine(dNum);

			//明確類型轉換(explicit type conversion)
			int iNum2 = int.MinValue;
			decimal dNum2 = (decimal)iNum2;
			Console.WriteLine(dNum2);

			int iNum3 = int.MaxValue;
			decimal dNum3 = (decimal)iNum3;
			Console.WriteLine(dNum3);

		}

		/// <summary>decimal 轉換成 int</summary>
		static void T2()
		{
			decimal dNum1 = 10.0M;
			//int iNum = dNum1;   //無法編譯成功

			int iNum2 = (int)dNum1;
			int iNum3 = Convert.ToInt32(dNum1);

		}

		static void T3()
		{
			//*四捨六入五成雙*

			decimal dNum1 = 10.9M;
			Console.WriteLine((int)dNum1);
			Console.WriteLine(Convert.ToInt32(dNum1));

			decimal dNum2 = 10.4M;
			Console.WriteLine(Convert.ToInt32(dNum2));

			decimal dNum3 = 10.5M;
			Console.WriteLine(Convert.ToInt32(dNum3));

			decimal dNum4 = 11.5M;
			Console.WriteLine(Convert.ToInt32(dNum4));
		}

		/// <summary>decimal 值超出 int 範圍, 會轉換失敗</summary>
		static void T4()
		{
			decimal dNum = decimal.MinValue;
			int iNum1 = (int)dNum;
			int iNum2 = Convert.ToInt32(dNum);
		}
	}
}
