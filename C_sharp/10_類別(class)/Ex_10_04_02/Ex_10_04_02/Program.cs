using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_04_02
{
	class Program
	{
		/*多載 Overloading
		 * 同一類別裡，
		 * 方法名稱可以相同，但是參數型別、參數數量需不相同
		 * 不可以參數名稱數量相同，但回傳型別不同
		 */
		static void Main(string[] args)
		{

		}

		/// <summary>
		/// 建立純文字檔, 若有既存檔案, 丟出例外
		/// </summary>
		/// <param name="context">文字內容</param>
		/// <param name="fullPath">完整路徑</param>
		static void CreateFile(string context, string fullPath) { }

		/// <summary>
		/// 建立純文字檔
		/// </summary>
		/// <param name="context">文字內容</param>
		/// <param name="fullPath">完整路徑</param>
		/// <param name="replaceOldFile">若有既存檔案,要直接覆蓋或丟出例外</param>
		static void CreateFile(string context, string fullPath, bool replaceOldFile) { }
	}
}
