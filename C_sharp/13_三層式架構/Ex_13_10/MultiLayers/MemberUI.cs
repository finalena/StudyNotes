using NUnit.Framework;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLayers
{
	class MemberUI
	{
		private IMemberRepository memberRepo;
		private MemberService memberService;

		[SetUp]
		public void Init()
		{
			this.memberRepo = new MemberRepository();
			this.memberService = new MemberService(this.memberRepo);
		}

		[TestCase(1, "allen")]
		public void CreateMember(int id, string name)
		{
			var member = new Member
			{
				Id = id,
				Name = name
			};
			memberService.Create(member);
		}

		[TestCase(1, null)]
		[TestCase(2, "")]
		[TestCase(3, "    ")]
		public void CreateMember_name是null丟出例外(int id, string name)
		{
			var member = new Member
			{
				Id = id,
				Name = name
			};
			var ex = Assert.Throws<Exception>(() => memberService.Create(member));
		}

		[TestCase(3, "012345678901234567890123456789A")]
		public void CreateMember_name太長_丟出例外(int id, string name)
		{
			var member = new Member
			{
				Id = id,
				Name = name
			};
			var ex = Assert.Throws<Exception>(() => memberService.Create(member));
		}

		[Test]
		public void GetAllMember()
		{
			var result = memberRepo.GetAll();
			result.ForEach(x =>
			{
				Console.WriteLine($"{x.Id}, {x.Name}");
			});
		}

		[Test]
		public void GetMember()
		{
			int memberId = 1;
			var result = memberRepo.Find(memberId);

			Console.WriteLine($"{result.Id}, {result.Name}");
		}

		[Test]
		public void UpdateNember()
		{
			int memberId = 1;
			string name = "Aduery 2";
			Member member = new Member { Id = memberId, Name = name };
			memberService.Update(member);
		}

		[Test]
		public void DeleteMember()
		{
			int memberId = 2;
			memberService.Delete(memberId);
		}
	}

	public class MemberService
	{
		private readonly IMemberRepository memberRepo;

		public interface IMemberService
		{
			void Create(Member member);
			void Update(Member member);
			void Delete(int memberId);
		}

		public MemberService(IMemberRepository memberRepo)
		{
			this.memberRepo = memberRepo;
		}

		public void Create(Member member)
		{
			//Validation
			if (member == null) throw new ArgumentNullException(nameof(member));
			if (string.IsNullOrWhiteSpace(member.Name)) throw new Exception("Name為必填");
			if (member.Name.Length > 30) throw new Exception("Name長度不可超過30字");

			memberRepo.Create(member);
		}

		public void Update(Member member)
		{
			//Validation
			if (member == null) throw new ArgumentNullException(nameof(member));
			if (string.IsNullOrWhiteSpace(member.Name)) throw new Exception("Name為必填");
			if (member.Name.Length > 30) throw new Exception("Name長度不可超過30字");

			memberRepo.Update(member);
		}

		public void Delete(int memberId)
		{
			//Validation
			memberRepo.Delete(memberId);
		}
	}

	public interface IMemberRepository
	{
		void Create(Member member);
		List<Member> GetAll();
		Member Find(int memberId);
		void Update(Member member);
		void Save(List<Member> members);
		void Delete(int memberId);
	}

	public class MemberRepository : IMemberRepository
	{
		private string fileName = @"C:\Users\USER\source\repos\StudyNotes\C_sharp\13_三層式架構\Ex_13_10\members.txt";

		public void Create(Member member)
		{
			string recode = $"{member.Id}.{member.Name}";
			using (StreamWriter sw = File.AppendText(fileName))
			{
				sw.WriteLine(recode);
			}
		}

		public List<Member> GetAll()
		{
			var data = File.ReadAllText(this.fileName);
			string[] rows = data.Split('\n');
			List<Member> result = new List<Member>();
			foreach (var row in rows)
			{
				if (string.IsNullOrEmpty(row)) continue;

				string[] items = row.Split('.');
				Member member = new Member
				{
					Id = Convert.ToInt32(items[0]),
					Name = items[1]
				};
				result.Add(member);
			}

			return result;
		}

		public Member Find(int memberId)
		{
			return GetAll().Single(x => x.Id == memberId);
		}

		public void Update(Member member)
		{
			var members = GetAll();
			var memberInDB = members.Single(x => x.Id == member.Id);
			memberInDB.Name = member.Name;

			Save(members);
		}

		public void Save(List<Member> members)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var member in members)
			{
				string row = $"{member.Id}.{member.Name}";
				sb.AppendLine(row);
			}

			using (StreamWriter sw = File.CreateText(this.fileName))
			{
				sw.Write(sb.ToString());
			}
		}

		public void Delete(int memberId)
		{
			var members = GetAll();
			var member = members.Single(x => x.Id == memberId);
			members.Remove(member);

			Save(members);
		}
	}

	public class Member
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
