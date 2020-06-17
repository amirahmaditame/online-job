using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace final.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        OnlineJobEntities db = new OnlineJobEntities();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult summaryBox()
        {
            ViewBag.employee = db.UserTB.Where(u=>u.RoleID == 3).Count();
            ViewBag.employer = db.UserTB.Where(u=>u.RoleID == 2).Count();
            ViewBag.listings = db.FormTB.Count();
            ViewBag.jobcategory = db.JobCategoryTB.Count();

            return PartialView();
        }
        public ActionResult menuProfile()
        {
            ViewBag.imagename = db.UserTB.SingleOrDefault(u => u.RoleID == 1).ImageName;
            return PartialView();
        }
    }
}