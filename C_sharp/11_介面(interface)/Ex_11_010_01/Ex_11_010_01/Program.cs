using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_11_010_01
{
	class Program
	{
		/* 明確實作介面
		 */
		static void Main(string[] args)
		{
			/* Array類別有實作IList介面，卻沒有Array.Add()，是因為Array是以明確方式實作介面
			 * 如果要使用Add方法，可以透過轉型，如下所示
			 */
			int[] nums = new int[] { 1, 2, 3, 4 };
			((IList<int>)nums).Add(8);


			Member member = new Member();
			member.Delete(11);
			((IStorage)member).DoA();

			Console.ReadLine();
		}
	}

	public interface IStorage
	{
		int Id { get; set; }
		void Save(string content);
		void Delete(int filedId);
		void DoA();
	}

	public interface IMember
	{
		string Name { get; set; }
		void Delete(int memberId);
	}

	public class Member : IMember , IStorage
	{
		
		public string Name { get; set; }
		int IStorage.Id { get; set; }

		/* 如果實作的介面有相同method名稱，想實作的功能卻不同，要以明確實作介面
		 * 明確實作介面會沒有 public 存取修飾詞、成員以完整名稱宣告
		 */
		void IMember.Delete(int memberId)
		{
		}

		void IStorage.Delete(int filedId)
		{
		}
		
		void IStorage.DoA()
		{
		}

		public void Save(string content)
		{
		}

		void IStorage.Save(string content)
		{
			throw new NotImplementedException();
		}
	}
}
