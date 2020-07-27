using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using Microsoft.Ajax.Utilities;

namespace final.Controllers
{
    public class HomeController : Controller
    {
        OnlineJobEntities db = new OnlineJobEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Slider()
        {
            ViewBag.category = db.JobCategoryTB.ToList();
            return PartialView();
        }

        public ActionResult showcategory()
        {
            var jobscategory = db.JobCategoryTB.Take(4).ToList();

            return PartialView(jobscategory);
        }
        public ActionResult lastjob()
        {
            var last = db.FormTB.OrderByDescending(s => s.RequestDtae).Take(6);

            return PartialView(last);


        }

        public ActionResult howitwork()
        {
            return PartialView();
        }
        public ActionResult needmore()
        {
            return PartialView();
        }

        public ActionResult ourcustomer()
        {
            return PartialView();
        }
    }
}