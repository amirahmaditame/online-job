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
        public ActionResult Resume() 
        {
            var model = online.UserTB.Find(4);
            int employerId = online.EmployerTB.Where(p => p.UserID == 4).FirstOrDefault().EmployerID;
            var resumeid = online.EmployerTB.Where(p => p.EmployerID == employerId).FirstOrDefault().ResumeID;
            if (resumeid != null)
            {
                return RedirectToAction("EditResume");
            }
            return View();
        }
        
        public JsonResult AddResume(ResumeTB resume) {

            var model = online.UserTB.Find(4);
            int employerId = online.EmployerTB.Where(p => p.UserID == 4).FirstOrDefault().EmployerID;
            resume.RequestDate= DateTime.Now;
            online.ResumeTB.Add(resume);
            var employer= online.EmployerTB.Where(p => p.EmployerID == employerId).FirstOrDefault();
            employer.ResumeID = resume.ResumeID;
            online.SaveChanges();
            return Json(new JsonData()
            {
                Status = true
            });
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