using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheSkyMartSite.Models;

namespace TheSkyMartSite.Controllers
{
    public class Category_MasterController : Controller
    {
        private TheskymartEntities db = new TheskymartEntities();

        // GET: Category_Master
        public ActionResult Index()
        {
            return View(db.Category_Master.ToList());
        }

        // GET: Category_Master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Master category_Master = db.Category_Master.Find(id);
            if (category_Master == null)
            {
                return HttpNotFound();
            }
            return View(category_Master);
        }

        // GET: Category_Master/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category_Master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Category_ID,Category_Name")] Category_Master category_Master)
        {
            if (ModelState.IsValid)
            {
                db.Category_Master.Add(category_Master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category_Master);
        }

        // GET: Category_Master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Master category_Master = db.Category_Master.Find(id);
            if (category_Master == null)
            {
                return HttpNotFound();
            }
            return View(category_Master);
        }

        // POST: Category_Master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Category_ID,Category_Name")] Category_Master category_Master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category_Master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category_Master);
        }

        // GET: Category_Master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Master category_Master = db.Category_Master.Find(id);
            if (category_Master == null)
            {
                return HttpNotFound();
            }
            return View(category_Master);
        }

        // POST: Category_Master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category_Master category_Master = db.Category_Master.Find(id);
            db.Category_Master.Remove(category_Master);
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
