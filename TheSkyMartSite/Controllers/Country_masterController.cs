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
    public class Country_masterController : Controller
    {
        private TheskymartEntities db = new TheskymartEntities();

        // GET: Country_master
        public ActionResult Index()
        {
            return View(db.Country_master.ToList());
        }

        // GET: Country_master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country_master country_master = db.Country_master.Find(id);
            if (country_master == null)
            {
                return HttpNotFound();
            }
            return View(country_master);
        }

        // GET: Country_master/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Country_ID,Country_name")] Country_master country_master)
        {
            if (ModelState.IsValid)
            {
                db.Country_master.Add(country_master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(country_master);
        }

        // GET: Country_master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country_master country_master = db.Country_master.Find(id);
            if (country_master == null)
            {
                return HttpNotFound();
            }
            return View(country_master);
        }

        // POST: Country_master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Country_ID,Country_name")] Country_master country_master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(country_master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(country_master);
        }

        // GET: Country_master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country_master country_master = db.Country_master.Find(id);
            if (country_master == null)
            {
                return HttpNotFound();
            }
            return View(country_master);
        }

        // POST: Country_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Country_master country_master = db.Country_master.Find(id);
            db.Country_master.Remove(country_master);
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
