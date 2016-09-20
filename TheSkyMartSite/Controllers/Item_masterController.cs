using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheSkyMartSite.Models;

namespace TheSkyMartSite.Controllers
{
    public class Item_masterController : Controller
    {
        private TheskymartEntities db = new TheskymartEntities();

        // GET: Item_master
        public ActionResult Index()
        {
            var item_master = db.Item_master.Include(i => i.Division_master).Include(i => i.Group_master).Include(i => i.Item_Details).Include(i => i.Sub_Group_master);
            return View(item_master.ToList());
        }

        // GET: Item_master/Details/5
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

        // GET: Item_master/Create
        public ActionResult Create()
        {
            ViewBag.Item_Division = new SelectList(db.Division_master, "Division_ID", "Division_Name");
            ViewBag.Item_Group = new SelectList(db.Group_master, "Group_ID", "Group_Name");
            ViewBag.Item_Code = new SelectList(db.Item_Details, "Item_code", "Item_main_image");
            ViewBag.Item_Sub_Group = new SelectList(db.Sub_Group_master, "Sub_Group_ID", "Sub_Group_Name");
            ViewBag.Supplier_ID = new SelectList(db.Supplier_Masters, "Supplier_ID", "Supplier_name");
            return View();
        }

        // POST: Item_master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Item_Code,Item_Name,Item_Brand,Item_Description,Item_Division,Item_Group,Item_Sub_Group")] Item_master item_master, HttpPostedFileBase Item_main_image, HttpPostedFileBase Image_1, HttpPostedFileBase Image_2, HttpPostedFileBase Image_3, HttpPostedFileBase Image_4, HttpPostedFileBase Image_5, Int32 Supplier_ID, float Item_price)
        {
            if (ModelState.IsValid)
            {
                db.Item_master.Add(item_master);
                db.SaveChanges();
                long id = item_master.Item_Code;


                Price_master price_obj = new Price_master();
                price_obj.Item_code = id;
                price_obj.Supplier_ID = Supplier_ID;
                price_obj.Supplier_Price = Item_price;
                db.Price_master.Add(price_obj);
                db.SaveChanges();

                Item_Details item_details_obj = new Item_Details();

                item_details_obj.Item_code = id;
                //Saving File to server
                if (Item_main_image !=null)
                {

                    string path = System.IO.Path.Combine(Server.MapPath("~/Resources/Item_images"), id.ToString() + "_Main"+ System.IO.Path.GetExtension(Item_main_image.FileName));
                    Item_main_image.SaveAs(path);
                    item_details_obj.Item_main_image = id.ToString() + "_Main" + System.IO.Path.GetExtension(Item_main_image.FileName);


                }
                if (Image_1 != null)
                {

                    string path = System.IO.Path.Combine(Server.MapPath("~/Resources/Item_images"), id.ToString() + "_Image_1" + System.IO.Path.GetExtension(Image_1.FileName));
                    Image_1.SaveAs(path);
                    item_details_obj.Item_image_1 = id.ToString() + "_Image_1" + System.IO.Path.GetExtension(Image_1.FileName);


                }
                if (Image_2 != null)
                {

                    string path = System.IO.Path.Combine(Server.MapPath("~/Resources/Item_images"), id.ToString() + "_Image_2" + System.IO.Path.GetExtension(Image_2.FileName));
                    Image_2.SaveAs(path);
                    item_details_obj.Item_image_2 = id.ToString() + "_Image_2" + System.IO.Path.GetExtension(Image_2.FileName);


                }
                if (Image_3 != null)
                {

                    string path = System.IO.Path.Combine(Server.MapPath("~/Resources/Item_images"), id.ToString() + "_Image_3" + System.IO.Path.GetExtension(Image_3.FileName));
                    Image_3.SaveAs(path);
                    item_details_obj.Item_image_3 = id.ToString() + "_Image_3" + System.IO.Path.GetExtension(Image_3.FileName);


                }
                if (Image_4 != null)
                {

                    string path = System.IO.Path.Combine(Server.MapPath("~/Resources/Item_images"), id.ToString() + "_Image_4" + System.IO.Path.GetExtension(Image_4.FileName));
                    Image_4.SaveAs(path);
                    item_details_obj.Item_image_4 = id.ToString() + "_Image_4" + System.IO.Path.GetExtension(Image_4.FileName);


                }
                if (Image_5 != null)
                {

                    string path = System.IO.Path.Combine(Server.MapPath("~/Resources/Item_images"), id.ToString() + "_Image_5" + System.IO.Path.GetExtension(Image_5.FileName));
                    Image_5.SaveAs(path);
                    item_details_obj.Item_image_5 = id.ToString() + "_Image_5" + System.IO.Path.GetExtension(Image_5.FileName);


                }



                db.Item_Details.Add(item_details_obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Item_Division = new SelectList(db.Division_master, "Division_ID", "Division_Name", item_master.Item_Division);
            ViewBag.Item_Group = new SelectList(db.Group_master, "Group_ID", "Group_Name", item_master.Item_Group);
            ViewBag.Item_Code = new SelectList(db.Item_Details, "Item_code", "Item_main_image", item_master.Item_Code);
            ViewBag.Item_Sub_Group = new SelectList(db.Sub_Group_master, "Sub_Group_ID", "Sub_Group_Name", item_master.Item_Sub_Group);
            return View(item_master);
        }

        // GET: Item_master/Edit/5
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
            ViewBag.Item_Code = new SelectList(db.Item_Details, "Item_code", "Item_main_image", item_master.Item_Code);
            ViewBag.Item_Sub_Group = new SelectList(db.Sub_Group_master, "Sub_Group_ID", "Sub_Group_Name", item_master.Item_Sub_Group);
            return View(item_master);
        }

        // POST: Item_master/Edit/5
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
            ViewBag.Item_Code = new SelectList(db.Item_Details, "Item_code", "Item_main_image", item_master.Item_Code);
            ViewBag.Item_Sub_Group = new SelectList(db.Sub_Group_master, "Sub_Group_ID", "Sub_Group_Name", item_master.Item_Sub_Group);
            return View(item_master);
        }

        // GET: Item_master/Delete/5
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

        // POST: Item_master/Delete/5
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

        public JsonResult GetSubGroups(string id)
        {
            List<SelectListItem> subgroups = new List<SelectListItem>();
            var SubGrouplist = this.GetSubGroup(Convert.ToInt32(id));
            var SubGroupData = SubGrouplist.Select(m => new SelectListItem()
            {
                Text = m.Sub_Group_Name,
                Value = m.Sub_Group_ID.ToString(),
            });
            return Json(SubGroupData, JsonRequestBehavior.AllowGet);
        }

        // Get Group from DB by Division ID
        public IList<Sub_Group_master> GetSubGroup(int GroupID)
        {
            return db.Sub_Group_master.Where(m => m.Group_ID == GroupID).ToList();
        }

    }
}
