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
    public class Location_masterController : Controller
    {
        private TheskymartEntities db = new TheskymartEntities();

        // GET: Location_master
        public ActionResult Index()
        {
            var location_master = db.Location_master.Include(l => l.Country_master);
            return View(location_master.ToList());
        }

        // GET: Location_master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location_master location_master = db.Location_master.Find(id);
            if (location_master == null)
            {
                return HttpNotFound();
            }
            return View(location_master);
        }

        // GET: Location_master/Create
        public ActionResult Create()
        {
            ViewBag.Country_ID = new SelectList(db.Country_master, "Country_ID", "Country_name");
            return View();
        }

        // POST: Location_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Location_ID,Location_Name,Location_Currency,Location_Currency_value,Country_ID")] Location_master location_master)
        {
            if (ModelState.IsValid)
            {
                db.Location_master.Add(location_master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Country_ID = new SelectList(db.Country_master, "Country_ID", "Country_name", location_master.Country_ID);
            return View(location_master);
        }

        // GET: Location_master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location_master location_master = db.Location_master.Find(id);
            if (location_master == null)
            {
                return HttpNotFound();
            }
            ViewBag.Country_ID = new SelectList(db.Country_master, "Country_ID", "Country_name", location_master.Country_ID);
            return View(location_master);
        }

        // POST: Location_master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Location_ID,Location_Name,Location_Currency,Location_Currency_value,Country_ID")] Location_master location_master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location_master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Country_ID = new SelectList(db.Country_master, "Country_ID", "Country_name", location_master.Country_ID);
            return View(location_master);
        }

        // GET: Location_master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location_master location_master = db.Location_master.Find(id);
            if (location_master == null)
            {
                return HttpNotFound();
            }
            return View(location_master);
        }

        // POST: Location_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Location_master location_master = db.Location_master.Find(id);
            db.Location_master.Remove(location_master);
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
