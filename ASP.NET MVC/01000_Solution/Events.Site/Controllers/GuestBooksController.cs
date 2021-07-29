using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Events.Site.Models.EFModels;

namespace Events.Site.Controllers
{
    public class GuestBooksController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: GuestBooks
        public ActionResult Index()
        {
            return View(db.GuestBooks.ToList());
        }

        // GET: GuestBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestBook guestBook = db.GuestBooks.Find(id);
            if (guestBook == null)
            {
                return HttpNotFound();
            }
            return View(guestBook);
        }

        // GET: GuestBooks/Create
        public ActionResult Create()
        {
            return View();
        }

		// POST: GuestBooks/Create
		// 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
		// 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateConfirmed([Bind(Include = "id,Name,Email,CellPhone,Message,CreateTime")] GuestBook guestBook)
        {
            if (ModelState.IsValid)
            {
                db.GuestBooks.Add(guestBook);
                db.SaveChanges();
				TempData["Created"] = "您的留言我們收到了, 將盡速與您聯絡";
				return RedirectToAction("Index");
            }

            return View(guestBook);
        }

        // GET: GuestBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestBook guestBook = db.GuestBooks.Find(id);
            if (guestBook == null)
            {
                return HttpNotFound();
            }
            return View(guestBook);
        }

        // POST: GuestBooks/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Email,CellPhone,Message,CreateTime")] GuestBook guestBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guestBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guestBook);
        }

        // GET: GuestBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestBook guestBook = db.GuestBooks.Find(id);
            if (guestBook == null)
            {
                return HttpNotFound();
            }
            return View(guestBook);
        }

        // POST: GuestBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GuestBook guestBook = db.GuestBooks.Find(id);
            db.GuestBooks.Remove(guestBook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
