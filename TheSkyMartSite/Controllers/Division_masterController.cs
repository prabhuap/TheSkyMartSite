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
    public class Division_masterController : Controller
    {
        private TheskymartEntities db = new TheskymartEntities();

        // GET: Division_master
        public ActionResult Index()
        {
            return View(db.Division_master.ToList());
        }

        // GET: Division_master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division_master division_master = db.Division_master.Find(id);
            if (division_master == null)
            {
                return HttpNotFound();
            }
            return View(division_master);
        }

        // GET: Division_master/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Division_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Division_ID,Division_Name")] Division_master division_master)
        {
            if (ModelState.IsValid)
            {
                db.Division_master.Add(division_master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(division_master);
        }

        // GET: Division_master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division_master division_master = db.Division_master.Find(id);
            if (division_master == null)
            {
                return HttpNotFound();
            }
            return View(division_master);
        }

        // POST: Division_master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Division_ID,Division_Name")] Division_master division_master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(division_master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(division_master);
        }

        // GET: Division_master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division_master division_master = db.Division_master.Find(id);
            if (division_master == null)
            {
                return HttpNotFound();
            }
            return View(division_master);
        }

        // POST: Division_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Division_master division_master = db.Division_master.Find(id);
            db.Division_master.Remove(division_master);
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
