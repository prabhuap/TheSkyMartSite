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
    public class Supplier_MastersController : Controller
    {
        private TheskymartEntities db = new TheskymartEntities();

        // GET: Supplier_Masters
        public ActionResult Index()
        {
            var supplier_Masters = db.Supplier_Masters.Include(s => s.Location_master);
            return View(supplier_Masters.ToList());
        }

        // GET: Supplier_Masters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier_Masters supplier_Masters = db.Supplier_Masters.Find(id);
            if (supplier_Masters == null)
            {
                return HttpNotFound();
            }
            return View(supplier_Masters);
        }

        // GET: Supplier_Masters/Create
        public ActionResult Create()
        {
            ViewBag.Location_ID = new SelectList(db.Location_master, "Location_ID", "Location_Name");
            return View();
        }

        // POST: Supplier_Masters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Supplier_ID,Supplier_name,Mobile,Telephone,Fax,Email_id,Credit_limit,Payment_term,Address,Active_status,Location_ID")] Supplier_Masters supplier_Masters)
        {
            if (ModelState.IsValid)
            {
                db.Supplier_Masters.Add(supplier_Masters);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Location_ID = new SelectList(db.Location_master, "Location_ID", "Location_Name", supplier_Masters.Location_ID);
            return View(supplier_Masters);
        }

        // GET: Supplier_Masters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier_Masters supplier_Masters = db.Supplier_Masters.Find(id);
            if (supplier_Masters == null)
            {
                return HttpNotFound();
            }
            ViewBag.Location_ID = new SelectList(db.Location_master, "Location_ID", "Location_Name", supplier_Masters.Location_ID);
            return View(supplier_Masters);
        }

        // POST: Supplier_Masters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Supplier_ID,Supplier_name,Mobile,Telephone,Fax,Email_id,Credit_limit,Payment_term,Address,Active_status,Location_ID")] Supplier_Masters supplier_Masters)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier_Masters).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Location_ID = new SelectList(db.Location_master, "Location_ID", "Location_Name", supplier_Masters.Location_ID);
            return View(supplier_Masters);
        }

        // GET: Supplier_Masters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier_Masters supplier_Masters = db.Supplier_Masters.Find(id);
            if (supplier_Masters == null)
            {
                return HttpNotFound();
            }
            return View(supplier_Masters);
        }

        // POST: Supplier_Masters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier_Masters supplier_Masters = db.Supplier_Masters.Find(id);
            db.Supplier_Masters.Remove(supplier_Masters);
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
