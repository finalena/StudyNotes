using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// 氣泡排序法
    /// 陣列、泛型清單排序
    /// 參考資料: https://adon988.logdown.com/posts/1203957
    class Program
    {
        static void Main(string[] args)
        {
            P1();
            P2();
            P3();

            Console.ReadKey();
        }

        private static void P1()
        {
            Random random = new Random();
            Student<string, int> student = new Student<string, int>();

            for (int i = 0; i < 10; i++)
            {
                student.Add(random.Next(0, 99));
            }

			student.All().PrintAll(string.Empty);

            int[] BubbleResult = BubbleSort(student.All());
			BubbleResult.PrintAll("氣泡排序法，由小到大排序");

            Array.Reverse(student.All());
			student.All().PrintAll("使用Array類別，由大到小排序");

            Array.Sort(student.All());
			student.All().PrintAll("使用Array類別，由小到大排序");

		}

        private static void P2()   
        {
			Student<string, int>[] students = new Student<string, int>[]
			{
				new Student<string,int>("Alice", 34),
				new Student<string,int>("John", 59),
				new Student<string,int>("Kitty", 12),
				new Student<string,int>("May", 45)
			};

            for (int i = 0; i < students.Length; i++)
            {
                for (int j = i + 1; j < students.Length; j++)
                {
                    if (students[i].Age > students[j].Age)
                    {
                        Student<string, int> temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }

			students.ToList().PrintAll("氣泡排序法，依年齡由小到大排序");
        }

        private static void P3()
        {
            List<Student<string, int>> studentsA = new List<Student<string, int>>() 
            {
                new Student<string, int>("Nina", 21),
                new Student<string, int>("Toby", 33),
                new Student<string, int>("June", 43)
            };

            studentsA.Sort((x, y) => { return -x.Age.CompareTo(y.Age); });

			studentsA.PrintAll("泛型清單 利用 Lambda 運算式，由大到小排序");
        }

		/// <summary>
		/// 氣泡排序
		/// </summary>
		/// <param name="TArr"></param>
		/// <returns></returns>
        private static int[] BubbleSort(int[] TArr)
        {
            for (int i = 0; i < TArr.Length; i++)
            {
                for (int j = i + 1; j < TArr.Length; j++)
                {
                    if (TArr[i] > TArr[j])
                    {
                        int iTemp = TArr[i];
                        TArr[i] = TArr[j];
                        TArr[j] = iTemp;
                    }
                }
            }
            return TArr;
        }
       
    }

    class Student<S, T> 
    {
        public S Name;
        public T Age;
        public T[] TArr;
        
        public Student()
        {
            TArr = new T[0];        
        }

        public Student(S sName, T iAge) 
        {
            this.Name = sName;
            this.Age = iAge;
        }

        public void Add(T item) 
        {
            Array.Resize<T>(ref TArr, TArr.Length + 1);
            TArr[TArr.Length - 1] = item;
        }

        public T[] All() 
        {
            return TArr;
        }
    }

	static class Exts
	{
		public static void PrintAll<T>(this T[] source, string title)
		{
			if (!string.IsNullOrEmpty(title))
			{
				Console.WriteLine("\r\n");
				Console.WriteLine(title);
				Console.WriteLine(new string('=', 40));
			}

			foreach (T item in source)
			{
				Console.Write(item + " ");
			}
			Console.WriteLine();
		}

		public static void PrintAll<Student>(this IEnumerable<Student> source, string title)
		{
			if (!string.IsNullOrEmpty(title))
			{
				Console.WriteLine("\r\n");
				Console.WriteLine(title);
				Console.WriteLine(new string('=', 40));
			}

			var result = source
						.OfType<Student<string, int>>()
						.Select(x => x.Name + "\t" + x.Age)
						.Aggregate((acc, next) => acc.ToString() + "\r\n" + next.ToString());

			Console.WriteLine(result);
		}

	}
}