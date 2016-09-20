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
            var supplier_Masters = db.Supplier_Masters.Include(s => s.Location_master).Include(s => s.Category_Master);
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
            ViewBag.Category_ID = new SelectList(db.Category_Master, "Category_ID", "Category_Name");
            return View();
        }

        // POST: Supplier_Masters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Supplier_ID,Supplier_name,Mobile,Telephone,Fax,Email_id,Credit_limit,Payment_term,Address,Active_status,Location_ID,Category_ID")] Supplier_Masters supplier_Masters, HttpPostedFileBase logo_image, HttpPostedFileBase Image_1, HttpPostedFileBase Image_2, HttpPostedFileBase Image_3, HttpPostedFileBase Image_4, HttpPostedFileBase Image_5)
        {
            if (ModelState.IsValid)
            {


                var id = supplier_Masters.Supplier_name;

           
                #region Supplier Image Loading
                if (logo_image != null)
                {

                    string path = System.IO.Path.Combine(Server.MapPath("~/Resources/Supplier_images"), id.ToString() + "_Logo" + System.IO.Path.GetExtension(logo_image.FileName));
                    logo_image.SaveAs(path);
                    supplier_Masters.Logo_image = id.ToString() + "_Logo" + System.IO.Path.GetExtension(logo_image.FileName);


                }
                if (Image_1 != null)
                {

                    string path = System.IO.Path.Combine(Server.MapPath("~/Resources/Supplier_images"), id.ToString() + "_Image_1" + System.IO.Path.GetExtension(Image_1.FileName));
                    Image_1.SaveAs(path);
                    supplier_Masters.Slide_1 = id.ToString() + "_Image_1" + System.IO.Path.GetExtension(Image_1.FileName);


                }
                if (Image_2 != null)
                {

                    string path = System.IO.Path.Combine(Server.MapPath("~/Resources/Supplier_images"), id.ToString() + "_Image_2" + System.IO.Path.GetExtension(Image_2.FileName));
                    Image_2.SaveAs(path);
                    supplier_Masters.Slide_2 = id.ToString() + "_Image_2" + System.IO.Path.GetExtension(Image_2.FileName);


                }
                if (Image_3 != null)
                {

                    string path = System.IO.Path.Combine(Server.MapPath("~/Resources/Supplier_images"), id.ToString() + "_Image_3" + System.IO.Path.GetExtension(Image_3.FileName));
                    Image_3.SaveAs(path);
                    supplier_Masters.Slide_3 = id.ToString() + "_Image_3" + System.IO.Path.GetExtension(Image_3.FileName);


                }
                if (Image_4 != null)
                {

                    string path = System.IO.Path.Combine(Server.MapPath("~/Resources/Supplier_images"), id.ToString() + "_Image_4" + System.IO.Path.GetExtension(Image_4.FileName));
                    Image_4.SaveAs(path);
                    supplier_Masters.Slide_4= id.ToString() + "_Image_4" + System.IO.Path.GetExtension(Image_4.FileName);


                }
                if (Image_5 != null)
                {

                    string path = System.IO.Path.Combine(Server.MapPath("~/Resources/Supplier_images"), id.ToString() + "_Image_5" + System.IO.Path.GetExtension(Image_5.FileName));
                    Image_5.SaveAs(path);
                    supplier_Masters.Slide_5= id.ToString() + "_Image_5" + System.IO.Path.GetExtension(Image_5.FileName);


                }

                #endregion
                db.Supplier_Masters.Add(supplier_Masters);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Location_ID = new SelectList(db.Location_master, "Location_ID", "Location_Name", supplier_Masters.Location_ID);
            ViewBag.Category_ID = new SelectList(db.Category_Master, "Category_ID", "Category_Name", supplier_Masters.Category_ID);
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
            ViewBag.Category_ID = new SelectList(db.Category_Master, "Category_ID", "Category_Name", supplier_Masters.Category_ID);
            return View(supplier_Masters);
        }

        // POST: Supplier_Masters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Supplier_ID,Supplier_name,Mobile,Telephone,Fax,Email_id,Credit_limit,Payment_term,Address,Active_status,Location_ID,Category_ID")] Supplier_Masters supplier_Masters, HttpPostedFileBase logo_image, HttpPostedFileBase Image_1, HttpPostedFileBase Image_2, HttpPostedFileBase Image_3, HttpPostedFileBase Image_4, HttpPostedFileBase Image_5)
        {
            if (ModelState.IsValid)
            {
                var id = supplier_Masters.Supplier_ID;
                #region Supplier Image Loading
                if (logo_image != null)
                {

                    string path = System.IO.Path.Combine(Server.MapPath("~/Resources/Supplier_images"), id.ToString() + "_Logo" + System.IO.Path.GetExtension(logo_image.FileName));
                    logo_image.SaveAs(path);
                    supplier_Masters.Logo_image = id.ToString() + "_Logo" + System.IO.Path.GetExtension(logo_image.FileName);


                }
                if (Image_1 != null)
                {

                    string path = System.IO.Path.Combine(Server.MapPath("~/Resources/Supplier_images"), id.ToString() + "_Image_1" + System.IO.Path.GetExtension(Image_1.FileName));
                    Image_1.SaveAs(path);
                    supplier_Masters.Slide_1 = id.ToString() + "_Image_1" + System.IO.Path.GetExtension(Image_1.FileName);


                }
                if (Image_2 != null)
                {

                    string path = System.IO.Path.Combine(Server.MapPath("~/Resources/Supplier_images"), id.ToString() + "_Image_2" + System.IO.Path.GetExtension(Image_2.FileName));
                    Image_2.SaveAs(path);
                    supplier_Masters.Slide_2 = id.ToString() + "_Image_2" + System.IO.Path.GetExtension(Image_2.FileName);


                }
                if (Image_3 != null)
                {

                    string path = System.IO.Path.Combine(Server.MapPath("~/Resources/Supplier_images"), id.ToString() + "_Image_3" + System.IO.Path.GetExtension(Image_3.FileName));
                    Image_3.SaveAs(path);
                    supplier_Masters.Slide_3 = id.ToString() + "_Image_3" + System.IO.Path.GetExtension(Image_3.FileName);


                }
                if (Image_4 != null)
                {

                    string path = System.IO.Path.Combine(Server.MapPath("~/Resources/Supplier_images"), id.ToString() + "_Image_4" + System.IO.Path.GetExtension(Image_4.FileName));
                    Image_4.SaveAs(path);
                    supplier_Masters.Slide_4 = id.ToString() + "_Image_4" + System.IO.Path.GetExtension(Image_4.FileName);


                }
                if (Image_5 != null)
                {

                    string path = System.IO.Path.Combine(Server.MapPath("~/Resources/Supplier_images"), id.ToString() + "_Image_5" + System.IO.Path.GetExtension(Image_5.FileName));
                    Image_5.SaveAs(path);
                    supplier_Masters.Slide_5 = id.ToString() + "_Image_5" + System.IO.Path.GetExtension(Image_5.FileName);


                }

                #endregion
                db.Entry(supplier_Masters).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Location_ID = new SelectList(db.Location_master, "Location_ID", "Location_Name", supplier_Masters.Location_ID);
            ViewBag.Category_ID = new SelectList(db.Category_Master, "Category_ID", "Category_Name", supplier_Masters.Category_ID);
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
