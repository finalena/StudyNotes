using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_08_03_P
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] nums = new int[] { 2, 11, 7, 15 };
			int target = 9;
			int[] result = GetResult(nums, target);

			Console.WriteLine(result[0] + ", " + result[1]);

			Console.ReadLine();
		}

		private static int[] GetResult(int[] nums, int target)
		{
			// todo
			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] > target) continue;
				
			}

			
		}
	}
}
