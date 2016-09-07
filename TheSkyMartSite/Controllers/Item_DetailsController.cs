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
    public class Item_DetailsController : Controller
    {
        private TheskymartEntities db = new TheskymartEntities();

        // GET: Item_Details
        public ActionResult Index()
        {
            var item_Details = db.Item_Details.Include(i => i.Item_master);
            return View(item_Details.ToList());
        }

        // GET: Item_Details/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item_Details item_Details = db.Item_Details.Find(id);
            if (item_Details == null)
            {
                return HttpNotFound();
            }
            return View(item_Details);
        }

        // GET: Item_Details/Create
        public ActionResult Create()
        {
            ViewBag.Item_code = new SelectList(db.Item_master, "Item_Code", "Item_Name");
            return View();
        }

        // POST: Item_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Item_code,Item_main_image,Item_image_1,Item_image_2,Item_image_3,Item_image_4,Item_image_5")] Item_Details item_Details)
        {
            if (ModelState.IsValid)
            {
                db.Item_Details.Add(item_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Item_code = new SelectList(db.Item_master, "Item_Code", "Item_Name", item_Details.Item_code);
            return View(item_Details);
        }

        // GET: Item_Details/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item_Details item_Details = db.Item_Details.Find(id);
            if (item_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Item_code = new SelectList(db.Item_master, "Item_Code", "Item_Name", item_Details.Item_code);
            return View(item_Details);
        }

        // POST: Item_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Item_code,Item_main_image,Item_image_1,Item_image_2,Item_image_3,Item_image_4,Item_image_5")] Item_Details item_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Item_code = new SelectList(db.Item_master, "Item_Code", "Item_Name", item_Details.Item_code);
            return View(item_Details);
        }

        // GET: Item_Details/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item_Details item_Details = db.Item_Details.Find(id);
            if (item_Details == null)
            {
                return HttpNotFound();
            }
            return View(item_Details);
        }

        // POST: Item_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Item_Details item_Details = db.Item_Details.Find(id);
            db.Item_Details.Remove(item_Details);
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
