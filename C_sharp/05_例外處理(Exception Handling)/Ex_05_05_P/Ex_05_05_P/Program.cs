using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace example_05_05
{
	class Program
	{

		static void Main(string[] args)
		{
			FileStream fileStream = null;
			byte content = 0x25; //0x表示16進位, 0x25 表示一個byte(位元組),值為37
			try
			{

				FileInfo fileInfo = new FileInfo(fileName: "G:\\test.txt");
				fileStream = fileInfo.OpenWrite();
				fileStream.WriteByte(content);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				Console.WriteLine("執行到finally區塊");
				if (fileStream != null)
				{
					fileStream.Close();
				}
			}

			Console.ReadLine();
		}
	}
}
