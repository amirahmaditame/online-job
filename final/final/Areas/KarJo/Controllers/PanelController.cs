using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace final.Areas.KarJo.Controllers
{
    public class PanelController : Controller
    {
        // GET: KarJo/Panel

        OnlineJobEntities online = new OnlineJobEntities();
        public ActionResult Index()
        {
            var model = online.UserTB.Find(4);
            int employerId = online.EmployerTB.Where(p => p.UserID == 4).FirstOrDefault().EmployerID;
            var resumeid = online.EmployerTB.Where(p => p.EmployerID == employerId).First().ResumeID;
            ViewBag.id = resumeid;
            return View();
        }
        [HttpGet]
        public ActionResult CreateResume() 
        {
            ResumeTB resume = new ResumeTB();
            return View(resume);
        }
        [HttpPost]
        public ActionResult CreateResume(ResumeTB resume)
        {
            var model = online.UserTB.Find(4);
            int employerId = online.EmployerTB.Where(p => p.UserID == 4).FirstOrDefault().EmployerID;
            resume.RequestDate = DateTime.Now;
            online.ResumeTB.Add(resume);
            var m=online.EmployerTB.Where(p => p.EmployerID == employerId).First();
            m.ResumeID = resume.ResumeID;
            online.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EditResume() {
            return View();
        }
        public class JsonData
        {
            public bool Status { get; set; }
            public string Message { get; set; }

        }
    }
}