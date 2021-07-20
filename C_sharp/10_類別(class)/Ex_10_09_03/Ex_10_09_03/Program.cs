using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_09_03
{
	class Program
	{
		/* 部分類別 partial class
		 * 宣告成相同的 partial class，在編譯時，會合併成同一個 class
		 */
		static void Main(string[] args)
		{
			var member = new Member();
			member.Id = 1;
			member.Name = "Alice";
			member.Delete(1);
			member.Create("John", "johnn@gmail.com");
		}
	}

	public partial class Member
	{
		public int Id { get; set; }


		public void Create(string name, string email) { }
	}
}
