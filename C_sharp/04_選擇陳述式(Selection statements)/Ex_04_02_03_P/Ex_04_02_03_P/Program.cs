using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_04_02_03
{
	class Program
	{
		static void Main(string[] args)
		{
			//乘法表練習
			for (int i = 1; i <= 9; i++)
			{
				for (int j = 1; j <= 9; j++)
				{
					Console.Write($"{j} * {i} = {j * i}\t");
				}
				Console.WriteLine();
			}

			Console.WriteLine("第二種方式");
			for (int i = 1; i <= 9; i+=3)
			{
				for (int j = 1; j <= 9; j++)
				{
					Console.Write($"{i:##} * {j:##} = {i * j}\t");
					Console.Write($"{(i + 1):##} * {j:##} = {(i + 1) * j}\t");
					Console.WriteLine($"{(i + 2):##} * {j:##} = {(i + 2) * j}");

				}
				Console.WriteLine();
			}

			Console.ReadLine();
		}
	}
}
