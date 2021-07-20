using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_041
{
	class Program
	{
		//Sum, Count, Average
		static void Main(string[] args)
		{
			int[] items = new int[] { 1, 5, 12, 100 };
			Console.WriteLine(items.Sum());
			Console.WriteLine(items.Sum(x => (decimal)x));

			List<Student> source = new List<Student>
			{
				new Student("王吉霸", 90,100),
				new Student("李小華", 100,45),
				new Student("柯玲芬", 10, 58),
				new Student("王小明", 42, 50),
			};
			Console.WriteLine(source.Count(x => x.國文 >= 60));
			Console.WriteLine(source.Count(x => x.英文 < 60));

			double AvgA1 = source.Average(x => x.國文);
			decimal AvgA2 = source.Average(x => (decimal)x.國文);

			double AvgA3 = (from s in source
						   select s.英文).Average();
			decimal AvgA4 = (from s in source
							select s).Average(x => (decimal)x.英文);


			int?[] itemsA = new int?[] { 1, 5, null, 100 };
			int? sum1 = itemsA.Sum();   //可能有null, 所以傳回型別是 double?
			int? sum2 = itemsA.Sum(x => x.ValueOrZero()); //若沒有值先轉換成零,再加總, 型別是 int


			double? avgB1 = itemsA.Average();
			double avgB2 = itemsA
						   .Select(x => x.ValueOrZero())
						   .Average();
			double avgB3 = itemsA
						   .Average(x => x.ValueOrZero());

			Console.Read();
		}
	}

	static class IntExts
	{
		public static int ValueOrZero(this int? source)
		{
			return (source.HasValue) ? (int)source : 0;
		}
	}
	class Student
	{
		public Student(string name, int 國分文數, int 英文分數)
		{
			this.Name = name;
			this.國文 = 國分文數;
			this.英文 = 英文分數;
		}
		public string Name { get; set; }
		public int 國文 { get; set; }
		public int 英文 { get; set; }
	}
}
