using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYH.eStore.Domain
{
    public class Order
    {
		public int Add(int num1, int num2)
		{
			return num1 + num2+13;
		}

    }
}

/*	類別庫命名: {公司名稱}.{專案名稱}.{類別庫功能}
 *	類別庫專案的Frmaework版本要考慮其他專案的相容性，
 *	一般來說會選擇低一點的，以利其他較低版本的專案可以使用
 */
