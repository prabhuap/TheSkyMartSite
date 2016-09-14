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
    public class Item_master1Controller : Controller
    {
        private TheskymartEntities db = new TheskymartEntities();

        // GET: Item_master1
        public ActionResult Index()
        {
            var item_master = db.Item_master.Include(i => i.Division_master).Include(i => i.Group_master).Include(i => i.Sub_Group_master);
            return View(item_master.ToList());
        }

        // GET: Item_master1/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item_master item_master = db.Item_master.Find(id);
            if (item_master == null)
            {
                return HttpNotFound();
            }
            return View(item_master);
        }

        // GET: Item_master1/Create
        public ActionResult Create()
        {
            ViewBag.Item_Division = new SelectList(db.Division_master, "Division_ID", "Division_Name");
            ViewBag.Item_Group = new SelectList(db.Group_master, "Group_ID", "Group_Name");
            ViewBag.Item_Sub_Group = new SelectList(db.Sub_Group_master, "Sub_Group_ID", "Sub_Group_Name");
            return View();
        }

        // POST: Item_master1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Item_Code,Item_Name,Item_Brand,Item_Description,Item_Division,Item_Group,Item_Sub_Group")] Item_master item_master)
        {
            if (ModelState.IsValid)
            {
                db.Item_master.Add(item_master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Item_Division = new SelectList(db.Division_master, "Division_ID", "Division_Name", item_master.Item_Division);
            ViewBag.Item_Group = new SelectList(db.Group_master, "Group_ID", "Group_Name", item_master.Item_Group);
            ViewBag.Item_Sub_Group = new SelectList(db.Sub_Group_master, "Sub_Group_ID", "Sub_Group_Name", item_master.Item_Sub_Group);
            return View(item_master);
        }

        // GET: Item_master1/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item_master item_master = db.Item_master.Find(id);
            if (item_master == null)
            {
                return HttpNotFound();
            }
            ViewBag.Item_Division = new SelectList(db.Division_master, "Division_ID", "Division_Name", item_master.Item_Division);
            ViewBag.Item_Group = new SelectList(db.Group_master, "Group_ID", "Group_Name", item_master.Item_Group);
            ViewBag.Item_Sub_Group = new SelectList(db.Sub_Group_master, "Sub_Group_ID", "Sub_Group_Name", item_master.Item_Sub_Group);
            return View(item_master);
        }

        // POST: Item_master1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Item_Code,Item_Name,Item_Brand,Item_Description,Item_Division,Item_Group,Item_Sub_Group")] Item_master item_master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item_master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Item_Division = new SelectList(db.Division_master, "Division_ID", "Division_Name", item_master.Item_Division);
            ViewBag.Item_Group = new SelectList(db.Group_master, "Group_ID", "Group_Name", item_master.Item_Group);
            ViewBag.Item_Sub_Group = new SelectList(db.Sub_Group_master, "Sub_Group_ID", "Sub_Group_Name", item_master.Item_Sub_Group);
            return View(item_master);
        }

        // GET: Item_master1/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item_master item_master = db.Item_master.Find(id);
            if (item_master == null)
            {
                return HttpNotFound();
            }
            return View(item_master);
        }

        // POST: Item_master1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Item_master item_master = db.Item_master.Find(id);
            db.Item_master.Remove(item_master);
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
