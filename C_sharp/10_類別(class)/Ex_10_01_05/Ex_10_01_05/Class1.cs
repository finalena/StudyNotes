using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_01_05
{
    public class Class1
    {
    }

	public struct Size
	{
		public int Width { get; }
		public int Height { get; }

		public Size(int width, int height)
		{
			if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width), "寬度必需是正整數") ;
			if (height <= 0) throw new ArgumentOutOfRangeException("height", "高度必需是正整數");

			this.Width = width;
			this.Height = height;
		}
	}

	public struct Birthday
	{
		public DateTime Value { get; private set; }

		public Birthday(DateTime birthday)
		{
			if (birthday.Date > DateTime.Today) throw new ArgumentOutOfRangeException(nameof(birthday), "生日不能比今天還晚");
			Value = birthday;
		}
	}

	public struct Address
	{
		//public Address() { }	//不能有無參數的建構子
	}
}
