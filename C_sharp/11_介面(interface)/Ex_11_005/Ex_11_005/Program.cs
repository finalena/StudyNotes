using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_11_005
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			IMember member = GetObject();
			member.DoA(1);
		}

		static IMember GetObject()
		{
			IMember member = new MemberA();
			return member;
		}
	}

	class MemberA : IMember
	{
		private string Name;
		public int Id { get; set; }

		public void DoA(int number)
		{
			// code
		}
	}
	class MemberB : IMember
	{
		private string Name;
		public int Id { get; set; }

		public void DoA(int number)
		{
			// code
		}
	}


	interface IMember
	{
		int Id { get; set; }
		void DoA(int number);
	}
}
