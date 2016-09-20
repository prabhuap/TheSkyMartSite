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
    public class HomeController : Controller
    {
        private TheskymartEntities db = new TheskymartEntities();
        public ActionResult Index(int id)
        {
            var Supplier_item_list = from lists in db.V_Home_Page
                                     where lists.Supplier_ID == id
                                     select lists;
            return View("Index",Supplier_item_list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }   
        public ActionResult Category_Selection()
        {
            ViewBag.Category_selection = new SelectList(db.Category_Master, "Category_ID", "Category_Name");
            ViewBag.Location_selection = new SelectList(db.Location_master, "Location_ID", "Location_Name");
            return View();
        }

        [HttpPost]
        public ActionResult Category_Selection(string Category_selection, string Location_selection)
        {
            var model_var = from supp in db.Supplier_Masters
                        where supp.Category_ID.ToString() == Category_selection && supp.Location_ID.ToString() == Location_selection
                        select supp;
  
            return View("Supplier_List",model_var);
        }

        public ActionResult Supplier_List()
        {
            var model = db.Supplier_Masters.ToList();
            return View(model);
        }

        public ActionResult NoResults()
        {
 
            return View();
        }
    }
}