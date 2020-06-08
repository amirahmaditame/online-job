using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace final.Areas.KarFarma.Controllers
{
    public class PanelController : Controller
    {
        // GET: KarFarma/Panel
        OnlineJobEntities online = new OnlineJobEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Jobs()
        {
            return View();
        }
        public ActionResult JobsForm()
        {
            return View();
        }
        public ActionResult RecievedResume()
        {
            OnlineJobEntities online = new OnlineJobEntities();

            return View(online.JobCategoryTB.ToList());
        }

        public ActionResult ShowResume(int id)
        {
            JobCategoryTB c = online.JobCategoryTB.Find(id); 
            return PartialView(c);

        }

        public class JsonData
        {
            public bool Status { get; set; }
            public string Message { get; set; }

        }
    }
}