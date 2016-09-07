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
    public class Price_masterController : Controller
    {
        private TheskymartEntities db = new TheskymartEntities();

        // GET: Price_master
        public ActionResult Index()
        {
            var price_master = db.Price_master.Include(p => p.Item_master).Include(p => p.Supplier_Masters);
            return View(price_master.ToList());
        }

        // GET: Price_master/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price_master price_master = db.Price_master.Find(id);
            if (price_master == null)
            {
                return HttpNotFound();
            }
            return View(price_master);
        }

        // GET: Price_master/Create
        public ActionResult Create()
        {
            ViewBag.Item_code = new SelectList(db.Item_master, "Item_Code", "Item_Name");
            ViewBag.Supplier_ID = new SelectList(db.Supplier_Masters, "Supplier_ID", "Supplier_name");
            return View();
        }

        // POST: Price_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Item_code,Supplier_ID,Supplier_Price")] Price_master price_master)
        {
            if (ModelState.IsValid)
            {
                db.Price_master.Add(price_master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Item_code = new SelectList(db.Item_master, "Item_Code", "Item_Name", price_master.Item_code);
            ViewBag.Supplier_ID = new SelectList(db.Supplier_Masters, "Supplier_ID", "Supplier_name", price_master.Supplier_ID);
            return View(price_master);
        }

        // GET: Price_master/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price_master price_master = db.Price_master.Find(id);
            if (price_master == null)
            {
                return HttpNotFound();
            }
            ViewBag.Item_code = new SelectList(db.Item_master, "Item_Code", "Item_Name", price_master.Item_code);
            ViewBag.Supplier_ID = new SelectList(db.Supplier_Masters, "Supplier_ID", "Supplier_name", price_master.Supplier_ID);
            return View(price_master);
        }

        // POST: Price_master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Item_code,Supplier_ID,Supplier_Price")] Price_master price_master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(price_master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Item_code = new SelectList(db.Item_master, "Item_Code", "Item_Name", price_master.Item_code);
            ViewBag.Supplier_ID = new SelectList(db.Supplier_Masters, "Supplier_ID", "Supplier_name", price_master.Supplier_ID);
            return View(price_master);
        }

        // GET: Price_master/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price_master price_master = db.Price_master.Find(id);
            if (price_master == null)
            {
                return HttpNotFound();
            }
            return View(price_master);
        }

        // POST: Price_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Price_master price_master = db.Price_master.Find(id);
            db.Price_master.Remove(price_master);
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
