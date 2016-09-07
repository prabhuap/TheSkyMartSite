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
    public class Sub_Group_masterController : Controller
    {
        private TheskymartEntities db = new TheskymartEntities();

        // GET: Sub_Group_master
        public ActionResult Index()
        {
            var sub_Group_master = db.Sub_Group_master.Include(s => s.Group_master);
            return View(sub_Group_master.ToList());
        }

        // GET: Sub_Group_master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sub_Group_master sub_Group_master = db.Sub_Group_master.Find(id);
            if (sub_Group_master == null)
            {
                return HttpNotFound();
            }
            return View(sub_Group_master);
        }

        // GET: Sub_Group_master/Create
        public ActionResult Create()
        {
            ViewBag.Division_ID = new SelectList(db.Division_master, "Division_ID", "Division_Name");
            //ViewBag.Group_ID = new SelectList(db.Group_master, "Group_ID", "Group_Name");
            return View();
        }

        // POST: Sub_Group_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sub_Group_ID,Sub_Group_Name,Group_ID")] Sub_Group_master sub_Group_master)
        {
            if (ModelState.IsValid)
            {
                db.Sub_Group_master.Add(sub_Group_master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Group_ID = new SelectList(db.Group_master, "Group_ID", "Group_Name", sub_Group_master.Group_ID);
            return View(sub_Group_master);
        }

        // GET: Sub_Group_master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sub_Group_master sub_Group_master = db.Sub_Group_master.Find(id);
            if (sub_Group_master == null)
            {
                return HttpNotFound();
            }
            ViewBag.Group_ID = new SelectList(db.Group_master, "Group_ID", "Group_Name", sub_Group_master.Group_ID);
            return View(sub_Group_master);
        }

        // POST: Sub_Group_master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sub_Group_ID,Sub_Group_Name,Group_ID")] Sub_Group_master sub_Group_master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sub_Group_master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Group_ID = new SelectList(db.Group_master, "Group_ID", "Group_Name", sub_Group_master.Group_ID);
            return View(sub_Group_master);
        }

        // GET: Sub_Group_master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sub_Group_master sub_Group_master = db.Sub_Group_master.Find(id);
            if (sub_Group_master == null)
            {
                return HttpNotFound();
            }
            return View(sub_Group_master);
        }

        // POST: Sub_Group_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sub_Group_master sub_Group_master = db.Sub_Group_master.Find(id);
            db.Sub_Group_master.Remove(sub_Group_master);
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

        public JsonResult GetGroups(string id)
        {
            List<SelectListItem> groupa = new List<SelectListItem>();
            var Grouplist = this.GetGroup(Convert.ToInt32(id));
            var GroupData = Grouplist.Select(m => new SelectListItem()
            {
                Text = m.Group_Name,
                Value = m.Group_ID.ToString(),
            });
            return Json(GroupData, JsonRequestBehavior.AllowGet);
        }

        // Get Group from DB by Division ID
        public IList<Group_master> GetGroup(int DivisionID)
        {
            return db.Group_master.Where(m => m.Division_ID == DivisionID).ToList();
        }
    }
}
