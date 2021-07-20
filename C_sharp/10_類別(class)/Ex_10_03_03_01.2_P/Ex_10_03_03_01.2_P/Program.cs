using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_03_03_01._2_P
{
	class Program
	{
		static void Main(string[] args)
		{
		}
	}

	class Address
	{
		public string CityName { get; set; }
		public string TownShip { get; set; }
		public int ZipCode { get; set; }
		public string Street { get; set; }
	}

	class CreditCard
	{
		public string CreditCardType { get; set; }

		public int CardNumber { get; set; }

		public int CheckNumber { get; set; }

		public DateTime DueDate { get; set; }
	}

	class IdNumber
	{
		private string _ID;

		public string ID
		{
			get { return this._ID; }
			set
			{
				string id = value;
				if (id.Length > 10) throw new ArgumentException("長度需大於 10");
				if (char.IsUpper(id[0])) throw new ArgumentException("第 1 個字需為 A~Z 大寫英文字母");
				if (id.Substring(1).All(char.IsDigit)) throw new ArgumentException("第 2~10 個字需為數字");

				int[] weights = new int[] { 1, 9, 8, 7, 6, 5, 4, 3, 2, 1, 1 }; //權重
				string countryCode = "ABCDEFGHJKLMNPQRSTUVXYWZIO";
				string chkId = (countryCode.IndexOf(id[0]) + 10).ToString() + id.Substring(1);

				int sum = 0;
				for (int i = 0; i < chkId.Length; i++)
				{
					sum += chkId[i] * weights[i];	
				}
				if (sum % 10 != 0) throw new ArgumentException("身分證檢查碼有誤");

				this._ID = id;
			}
		}
	}

	class Member
	{
		public string Name { get; set; }

		public bool Gender { get; set; }

		public DateOfBirth DateofBirthday { get; set; }

		public IdNumber Id { get; set; }

		public Address Address { get; set; }

		public CreditCard CreditCard { get; set; }
	}

	class DateOfBirth
	{
		private DateTime _Birthday;

		public DateTime Birthday
		{
			get	{ return this._Birthday; }

			set
			{
				DateTime dTime = value.Date;
				
				if (dTime > dTime.Date)
				{
					throw new ArgumentException("請輸入日期，不用輸入時間");
				}

				if (dTime > DateTime.Today)
				{
					throw new ArgumentException("生日不能比今天還大");
					
				}

				this._Birthday = dTime;
			}
		}
	}
}
