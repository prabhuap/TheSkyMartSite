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
    public class Group_masterController : Controller
    {
        private TheskymartEntities db = new TheskymartEntities();

        // GET: Group_master
        public ActionResult Index()
        {
            var group_master = db.Group_master.Include(g => g.Division_master);
            return View(group_master.ToList());
        }

        // GET: Group_master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group_master group_master = db.Group_master.Find(id);
            if (group_master == null)
            {
                return HttpNotFound();
            }
            return View(group_master);
        }

        // GET: Group_master/Create
        public ActionResult Create()
        {
            ViewBag.Division_ID = new SelectList(db.Division_master, "Division_ID", "Division_Name");
            return View();
        }

        // POST: Group_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Group_ID,Group_Name,Division_ID")] Group_master group_master)
        {
            if (ModelState.IsValid)
            {
                db.Group_master.Add(group_master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Division_ID = new SelectList(db.Division_master, "Division_ID", "Division_Name", group_master.Division_ID);
            return View(group_master);
        }

        // GET: Group_master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group_master group_master = db.Group_master.Find(id);
            if (group_master == null)
            {
                return HttpNotFound();
            }
            ViewBag.Division_ID = new SelectList(db.Division_master, "Division_ID", "Division_Name", group_master.Division_ID);
            return View(group_master);
        }

        // POST: Group_master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Group_ID,Group_Name,Division_ID")] Group_master group_master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group_master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Division_ID = new SelectList(db.Division_master, "Division_ID", "Division_Name", group_master.Division_ID);
            return View(group_master);
        }

        // GET: Group_master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group_master group_master = db.Group_master.Find(id);
            if (group_master == null)
            {
                return HttpNotFound();
            }
            return View(group_master);
        }

        // POST: Group_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group_master group_master = db.Group_master.Find(id);
            db.Group_master.Remove(group_master);
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
