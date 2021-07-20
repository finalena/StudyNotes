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
		private string fileName = @"C:\Users\USER\source\repos\StudyNotes\C_sharp\13_三層式架構\Ex_13_10\members.txt";

		[TestCase(1, "allen")]
		[TestCase(2, "Aduery")]
		public void CreateMember(int id, string name)
		{
			string recode = $"{id}.{ name }";
			using (StreamWriter sw = File.AppendText(fileName))
			{
				sw.WriteLine(recode);
			}
		}

		[Test]
		public void GetAllMember()
		{
			var result = GetAll();
			result.ForEach(x =>
			{
				Console.WriteLine($"{x.Id}, {x.Name}");
			});
		}

		private List<Member> GetAll()
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

		[Test]
		public void GetMember()
		{
			int memberId = 1;
			var result = GetAll().Single(x => x.Id == memberId);

			Console.WriteLine($"{result.Id}, {result.Name}");
		}

		[Test]
		public void UpdateNember()
		{
			int memberId = 1;
			string name = "Anna Tsai";
			var members = GetAll();
			var member = members.Single(x => x.Id == memberId);
			member.Name = name;

			Save(members);
		}

		private void Save(List<Member> members)
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

		[Test]
		public void DeleteMember()
		{
			int memberId = 2;
			var members = GetAll();
			var member = members.Single(x => x.Id == memberId);
			members.Remove(member);

			Save(members);
		}
	}

	class Member
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
