using Events.Site.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Events.Site.Models.Repositories
{
	public class RegisterRepo
	{
		private AppDbContext db = new AppDbContext();

		public void Create(Register register)
		{
			db.Registers.Add(register);
			db.SaveChanges();
		}

		public bool IsExists(string email)
		{
			var register = db.Registers.FirstOrDefault(x => x.Email == email);
			return register == null;
		}
	}
}