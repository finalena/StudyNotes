using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_03_01
{
	class Program
	{
		static void Main(string[] args)
		{
		}
		class Member
		{
			private DateTime _Birthday;

			public int Id { get; set; }
			public string Name { get; set; }
			public DateTime Birthday
			{
				get { return _Birthday; }
				set
				{
					if (value.Date > DateTime.Today) throw new ArgumentException(message: "生日不可以比今天還晚");
					_Birthday = value.Date;
				}
			}

			//readonly property(唯讀屬性)
			public int Age
			{
				get
				{
					if (Birthday == DateTime.MinValue) throw new Exception(message: "請先指定 Birthday 值, 才能計算年齡");
					return DateTime.Today.Year - Birthday.Year;
				}
			}
			/// <summary>
			/// 商品促銷計劃, 不同日期有不同折扣
			/// </summary>
			class Promotion
			{
				public DateTime BeginDate { get; }
				public DateTime EndDate { get; }


				public Promotion(DateTime beginDate, DateTime endDate)
				{
					BeginDate = beginDate;
					EndDate = endDate;
				}
			}
		}
	}
}
