using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_08_02
{
	class Program
	{
		/* 抽象方法
		 * 類別中的功能無法事先寫出來，可以將方法宣告成 abstract 方法，待子類別實作
		 * 抽象方法只能存在於抽象類別。
		 */
		static void Main(string[] args)
		{
		}
	}

	public class Member
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public abstract class MemberStorage
	{
		private bool IsValid(Member member)
		{
			if (member == null) return false;
			if (string.IsNullOrWhiteSpace(member.Name)) return false;
			if (member.Name.Length > 30) return false;

			return true;
		}

		public void Create(Member member)
		{
			bool isValid = IsValid(member);
			if (!isValid) throw new Exception("傳入的物件無法通過驗證");

			DoCreate(member);
		}

		protected abstract void DoCreate(Member member);
	}

	public class MemberFileStorage: MemberStorage
	{
		protected override void DoCreate(Member member)
		{
			//todo 將 member 存入實體檔案
		}
	}

	public class MemberSqlStorage : MemberStorage
	{
		protected override void DoCreate(Member member)
		{
			//todo 將 member 存入 Database
		}
	}
}
