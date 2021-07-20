using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_11_110
{
	class Program
	{
		//as 手動轉型
		static void Main(string[] args)
		{
			A obj = new A();
			B objB = obj as B;
			IC objC = obj as IC;
			ID objD = obj as ID;

			B2 objB2 = obj as B2; //轉型失敗
			Console.WriteLine(objB2 == null);

			IE objIE = obj as IE;
			Console.WriteLine(objIE == null);

			Console.ReadLine();
		}
	}

	class A : B, IC, ID { }
	class B { }
	class B2 { }
	interface IC { }
	interface ID { }
	interface IE { }
}
