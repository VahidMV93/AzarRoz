using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AzarRoz.Data;
using AzarRoz.Data.Models;

namespace AzarRoz.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GroupProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.GroupProducts.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Unit,Price")] GroupProduct groupProduct)
        {
            if (ModelState.IsValid)
            {
                db.GroupProducts.Add(groupProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groupProduct);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupProduct groupProduct = db.GroupProducts.Find(id);
            if (groupProduct == null)
            {
                return HttpNotFound();
            }
            return View(groupProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Unit,Price")] GroupProduct groupProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groupProduct);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupProduct groupProduct = db.GroupProducts.Find(id);
            if (groupProduct == null)
            {
                return HttpNotFound();
            }
            return View(groupProduct);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupProduct groupProduct = db.GroupProducts.Find(id);
            db.GroupProducts.Remove(groupProduct);
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
