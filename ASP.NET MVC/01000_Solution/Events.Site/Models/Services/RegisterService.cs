using Events.Site.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Events.Site.Models.ServicesObject
{
	public class RegisterService
	{
		private AppDbContext db = new AppDbContext();

		public void Create(Register register)
		{
			#region validation
			var data = db.Registers.FirstOrDefault(x => x.Email == register.Email);
			if (data != null)
			{
				throw new Exception("這個 email 已經報名過了，無法再次報名");
			}
			#endregion

			#region
			register.CreateTime = DateTime.Now;
			#endregion

			db.Registers.Add(register);
			db.SaveChanges();
		}
	}
}