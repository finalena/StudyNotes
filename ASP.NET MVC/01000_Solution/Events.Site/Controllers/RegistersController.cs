using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Events.Site.Models.EFModels;
using Events.Site.Models.Repositories;
using Events.Site.Models.ServicesObject;

namespace Events.Site.Controllers
{
    public class RegistersController : Controller
    {
		private RegisterRepo repo = new RegisterRepo();

        // GET: Registers
        public ActionResult Index()
        {
			return View(repo.Search());
        }

        // GET: Registers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

			try
			{
				var register = new RegisterService().Find(id.Value);

				return View(register);
			}
			catch (Exception ex)
			{
				return HttpNotFound();
			}
        }

        // GET: Registers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registers/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Email")] Register register)
        {
			try
			{
				new RegisterService().Create(register);
			}
			catch (Exception ex)
			{

				ModelState.AddModelError("email", ex.Message);
			}

			if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(register);
        }
    }
}
