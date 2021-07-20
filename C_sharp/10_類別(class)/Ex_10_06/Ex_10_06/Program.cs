using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_06
{
	class Program
	{
		//自訂類別如何宣告 indexer(索引子)
		static void Main(string[] args)
		{
			string context = "A:台北; B:桃園;;;;;; C:高雄";
			var cityProvider = new CityProvider(context);
			string city = cityProvider["b"];
			Console.WriteLine(city);

			Console.ReadLine();
		}
	}

	class CityProvider
	{
		private Dictionary<string, string> cities;
		public CityProvider(string context)
		{
			if (string.IsNullOrWhiteSpace(context)) throw new ArgumentException(nameof(context));

			cities = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			string[] items = context.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (var item in items)
			{
				ParseCities(item);
			}
		}

		public string this[string cityKey]
		{//使用this關鍵字，get存取子取得值、set存取子設定值
			get
			{
				if (this.cities.ContainsKey(cityKey))
				{
					return cities[cityKey];
				}
				else
				{
					return string.Empty;
				}
			}
		}

		private void ParseCities(string item)
		{
			string[] pair = item.Split(':');
			string key = pair[0].Trim();
			string value = pair[1].Trim();

			cities.Add(key, value);
		}
	}
}
