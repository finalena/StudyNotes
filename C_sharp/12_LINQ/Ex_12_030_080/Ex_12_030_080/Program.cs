using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_12_030_080
{
	class Program
	{
		/* SelectMany- 針對有巢狀集合的情境, 可以直接傳回下一層的集合
		 */
		static void Main(string[] args)
		{
			Order order1 = new Order
			{
				Id = 1,
				Items = new List<OrderItem> {
				new OrderItem{ ProductId = 1, UnitPrice = 100, Qty =5},
				new OrderItem{ ProductId = 2, UnitPrice = 200, Qty =1},
				new OrderItem{ ProductId = 3, UnitPrice = 300, Qty =2}
			}
			};

			Order order2 = new Order
			{
				Id = 2,
				Items = new List<OrderItem> {
				new OrderItem{ ProductId = 3, UnitPrice = 300, Qty =1},
				new OrderItem{ ProductId =4, UnitPrice = 100, Qty =2},
				new OrderItem{ ProductId = 5, UnitPrice = 200, Qty =3}
			}
			};

			//使用迴圈，取得Qty >= 2的項目
			var orders = new Order[] { order1, order2 };
			List<OrderItem> orderItems = new List<OrderItem>();
			foreach (var order in orders)
			{
				IEnumerable<OrderItem> morethanOneItem = order.Items.Where(x => x.Qty >= 2);
				orderItems.AddRange(morethanOneItem);
			}

			List<int> result = orderItems.Select(x => x.ProductId).ToList();
			result.Dump();


			//列出所有訂單採購的細項-SelectMany()
			IEnumerable<OrderItem> queryA = orders.SelectMany(order => order.Items);
			List<int> resultA = queryA.Select(x => x.ProductId).ToList();
			resultA.Dump();


			List<int> resultB = queryA
								.Where(x => x.Qty >= 2)
								.Select(x=> x.ProductId)
								.ToList();
			resultB.Dump();

			Console.ReadLine();
		}
	}

	class OrderItem
	{
		public int ProductId { get; set; }
		public int UnitPrice { get; set; }
		public int Qty { get; set; }
	}

	class Order
	{
		public int Id { get; set; }
		public List<OrderItem> Items { get; set; }
	}

	static class ArrExts
	{
		public static void Dump<T>(this IEnumerable<T> source)
		{
			string result = (source == null || source.Count() == 0)
				? string.Empty
				: source.Select(x => x.ToString()).Aggregate((acc, next) => acc + ", " + next);

			Console.WriteLine(result);
		}
	}
}
