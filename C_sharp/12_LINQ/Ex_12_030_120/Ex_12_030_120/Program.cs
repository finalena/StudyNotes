using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_120
{
	class Program
	{
		/*  OfType 找出集合中某型別的項目
		 */
		static void Main(string[] args)
		{
			Employee allen = new Engineer { Name = "Allen" };
			Employee annie = new Sales { Name = "Annie" };
			Employee tom = new Sales { Name = "Tom" };
			Employee simon = new Manager
			{
				Name = "Simon",
				TeamMembers = new List<Employee> { tom, annie }
			};

			Employee jerry = new Manager
			{
				Name = "Jerry",
				TeamMembers = new List<Employee> { allen }
			};

			Employee[] allEmployees = new Employee[] { allen, annie, tom, simon, jerry };

			//找出主管, 並顯示其姓名
			IEnumerable<Manager> managers = allEmployees.OfType<Manager>();
			managers.Select(x => x.Name).ToList().Dump();

			Console.ReadLine();
			
		}
	}

	abstract class Employee
	{
		public string Name { get; set; }
	}
	class Sales : Employee { }
	class Engineer : Employee { }
	class Manager : Employee
	{
		public List<Employee> TeamMembers { get; set; }
	}

	static class IEnumerableExts
	{
		static public void Dump<T>(this IEnumerable<T> source)
		{
			string result = (source == null || source.Count() == 0)
				? string.Empty
				: source.Select(x => x.ToString()).Aggregate((acc, next) => acc + ", " + next);

			Console.WriteLine(result);
		}
	}
}
