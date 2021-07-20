using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_03_03_01_P
{
	class Program
	{
		static void Main(string[] args)
		{
		}
	}

	struct Address
	{
		public string CityName { get; set; }
		public string TownShip { get; set; }
		public int ZipCode { get; set; }
		public string  Street { get; set; }
	}

	struct Telephone
	{
		public string CountryCode { get; set; }
		public int AreaCode { get; set; }
		public string PhoneNumber { get; set; }
		public int Ext { get; set; }
	}

	class Member
	{
		public int Id { get; }
		public string Name { get; set; }

		public string  Email { get; set; }

		public DateTime Birthday { get; set; }

		public Address Address { get; set; }

		public Telephone TelHome { get; set; }

		public Telephone TelOffice { get; set; }

	}
}
