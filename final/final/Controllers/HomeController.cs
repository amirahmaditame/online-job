using System;
using System.Collections.Generic;
using System.Linq;
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
            return PartialView();
        }

        public ActionResult showcategory()
        {
            var jobscategory = db.JobCategoryTB.Take(4).ToList();

            return PartialView(jobscategory);
        }
        public ActionResult lastjob()
        {
            var lastJob = db.FormTB.OrderByDescending(j=>j.RequestDtae).Take(6);
            return PartialView(lastJob);
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