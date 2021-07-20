using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_01_03_301.UnitTests
{
	class OrderTests
	{
		[Test]
		public void CalcTax_傳入未稅金額_傳回5趴營業稅()
		{
			decimal price = 100;
			var order = new Order();

			decimal tax = order.CalcTax(price);

			Assert.AreEqual(expected: 5M, actual: tax);
		}

		[TestCase(190,10)]
		[TestCase(210,11)]
		public void CalcTax_傳入無法整除未稅金額_傳回四捨五入的營業稅(decimal price, decimal exptected)
		{
			var order = new Order();

			decimal tax = order.CalcTax(price);

			Assert.AreEqual(expected: exptected, actual: tax);
		}
	}
}
