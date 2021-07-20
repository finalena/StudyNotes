using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_03_02_05
{
	class Program
	{
		static void Main(string[] args)
		{
			//刪除字串空白
			Demo01(" abc def ");

			//字串長度處理
			Demo02("abcdefghijklmnopqrstuvwxyz", "123");

			//擷取字串
			string text = " @ 字元將程式碼元素當成前置詞";
			string subText = text.Substring(3, 2);
			Console.WriteLine(subText);

			//比對兩個字串是否相等(不拘大小寫)
			string s1 = "test";
			string s2 = "test";
			string s3 = "test1".Substring(0, 4);
			object s4 = s3;

			Console.WriteLine($"{object.ReferenceEquals(s1, s2)} {s1 == s2} {s1.Equals(s2)}");
			Console.WriteLine($"{object.ReferenceEquals(s1, s3)} {s1 == s3} {s1.Equals(s3)}");
			Console.WriteLine($"{object.ReferenceEquals(s1, s4)} {s1 == s4} {s1.Equals(s4)}");

			//字串比較大小 - CompareTo( )
			string valueA = "ab";
			string valueB = "ac";
			Console.WriteLine(valueA.CompareTo(valueB));

			//串比較大小 - String.Compare( )
			valueA = "ALaN";
			valueB = "alAn";
			Console.WriteLine(string.Compare(valueA, valueB, StringComparison.CurrentCultureIgnoreCase));

			//判斷字串的開頭文字
			string url = "http://www.google.com/";
			bool isHttps = url.StartsWith("https://");
			if (!isHttps)
			{
				Console.WriteLine("網址必需是 https:// 開頭, 請修改之後再試一次");
			}

			//判斷字串的結尾文字
			string path = @"d:\temp";
			bool isValidPath = path.EndsWith("\\");
			if(isValidPath == false)
			{
				Console.WriteLine("路徑的最後請加反斜線");
			}

			//取得字串出現某些字的位置
			string sentence = "this's a book";
			int location = sentence.IndexOf('\'');
			if (location < 0)
			{
				Console.WriteLine("字串裡沒有單引號");
			}
			else
			{
				Console.WriteLine("輸入的內容不允許單引號, 請修改後再試一次");
			}

			//尋找字串裡第一個出現 a 或 s 的位置
			int locationA = sentence.IndexOfAny(new char[] { 'a', 's' });
			if (locationA < 0)
			{
				Console.WriteLine("字串裡沒有 a 或 s");
			}
			else
			{
				Console.WriteLine($"第一個出現 a 或 s 的位置在{locationA}");
			}

			//判斷字串是否包含某些字，Contains()會區分大小寫
			string email = "test@gmail.com";
			if (email.Contains("gmail"))
			{
				Console.WriteLine("字串裡包含gmail");
			}

			//截取字串某一段文字
			string template ="Cuz you make me feel breathless";
			int startIndex = template.IndexOf('f');
			int length = template.Length - startIndex;
			Console.WriteLine(template.Substring(startIndex, length));

			//分割字串
			string time = DateTime.Now.ToString("yyyy/MM/dd/HH:mm:ss");
			string[] aryTime = time.Split('/');
			Console.WriteLine(aryTime.Length);

			Console.ReadLine();
		}

		private static void Demo01(string originalValue)
		{
			if (originalValue == null)
			{
				originalValue = string.Empty;
			}

			string trimLeft = originalValue.TrimStart();
			string trimRight = originalValue.TrimEnd();
			string trimResult = originalValue.Trim();

			Console.WriteLine(trimLeft);
			Console.WriteLine(trimRight);
			Console.WriteLine(trimResult);

		}

		private static void Demo02(string account, string password)
		{
			if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(account))
			{
				Console.WriteLine("帳號或密碼不可為空");
				return;
			}

			int lengthOfAccount = account.Length;
			if (lengthOfAccount > 20)
			{
				Console.WriteLine("帳號最多只能 20 個字,您輸入了" + lengthOfAccount + " 個字");
				return;
			}

			int lengthOfPassword = password.Length;
			if (lengthOfPassword < 6)
			{
				Console.WriteLine("密碼必需至少 6 個字,您只輸入了" + lengthOfPassword + " 個字");
				return;
			}
		}
	}
}
