using Events.Site.Models.EFModels;
using Events.Site.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Events.Site.Models.ServicesObject
{
	public class RegisterService
	{
		private RegisterRepo repo = new RegisterRepo();
		public void Create(Register register)
		{
			#region validation
			if (!repo.IsExists(register.Email))
			{
				throw new Exception("這個 email 已經報名過了，無法再次報名");
			}
			#endregion
			
			#region
			register.CreateTime = DateTime.Now;
			#endregion

			repo.Create(register);
		}

		public Register Find(int id)
		{
			return repo.Find(id);
		}
	}
}