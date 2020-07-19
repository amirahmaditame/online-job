using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        [HttpGet]
        public ActionResult EditResume() {
            var model = online.UserTB.Find(4);
            int employerId = online.EmployerTB.Where(p => p.UserID == 4).FirstOrDefault().EmployerID;
            int? resumeid = online.EmployerTB.Where(p => p.EmployerID == employerId).Select(p=>p.ResumeID).First();
            var resume = online.ResumeTB.Where(p => p.ResumeID == resumeid).First();
            return View(resume);
        }
        [HttpPost]
        public JsonResult EditResume(ResumeTB resume)
        {
            resume.RequestDate = DateTime.Now;
            online.Entry(resume).State = EntityState.Modified;

            online.SaveChanges();
            return Json(new JsonData()
            {
                Status = true
            });
        }
        [HttpGet]
        public ActionResult EditPersonalInformation() 
        {
            var model = online.UserTB.Find(4);
            return View(model);
        }

        [HttpPost]
        public JsonResult EditPersonalInformation(UserTB user)
        {
            user.RegesterDate = DateTime.Now;
            online.Entry(user).State = EntityState.Modified;

            online.SaveChanges();
            return Json(new JsonData()
            {
                Status = true
            });
        }
        public class JsonData
        {
            public bool Status { get; set; }
            public string Message { get; set; }

        }
    }
}