using DataLayer;
using final.Areas.KarJo.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace final.Areas.KarJo.Controllers
{
    [Authorize(Roles = "employeer")]
    public class PanelController : Controller
    {
        // GET: KarJo/Panel

        OnlineJobEntities online = new OnlineJobEntities();
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var id = online.UserTB.SingleOrDefault(u => u.UserName == username).UserID;
            var model = online.UserTB.Find(id);
            int employerId = online.EmployerTB.Where(p => p.UserID == id).FirstOrDefault().EmployerID;
            var resumeid = online.EmployerTB.Where(p => p.EmployerID == employerId).First().ResumeID;
            ViewBag.id = resumeid;
            int count = online.FormForeachResume(resumeid).Count();
            ViewBag.count = count;
            return View();
        }

        [HttpGet]
        public ActionResult CreateResume() 
        {
            var username = User.Identity.Name;
            var id = online.UserTB.SingleOrDefault(u => u.UserName == username).UserID;
            var model = online.UserTB.Find(id);
            int employerId = online.EmployerTB.Where(p => p.UserID == id).FirstOrDefault().EmployerID;
            var resumeid = online.EmployerTB.Where(p => p.EmployerID == employerId).First().ResumeID;
            if (resumeid !=null) {
                var resumesample = online.ResumeTB.Where(p => p.ResumeID == resumeid).First();
                return View("EditResume", resumesample);
            }
                ResumeTB resume = new ResumeTB();
                return View(resume);
        }
        [HttpPost]
        public ActionResult CreateResume(ResumeTB resume)
        {
            var username = User.Identity.Name;
            var id = online.UserTB.SingleOrDefault(u => u.UserName == username).UserID;
            var model = online.UserTB.Find(id);
            int employerId = online.EmployerTB.Where(p => p.UserID == id).FirstOrDefault().EmployerID;
            resume.RequestDate = DateTime.Now;
            online.ResumeTB.Add(resume);
            var m=online.EmployerTB.Where(p => p.EmployerID == employerId).First();
            m.ResumeID = resume.ResumeID;
            online.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditResume() {
            var username = User.Identity.Name;
            var id = online.UserTB.SingleOrDefault(u => u.UserName == username).UserID;
            var model = online.UserTB.Find(id);
            int employerId = online.EmployerTB.Where(p => p.UserID == id).FirstOrDefault().EmployerID;
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
            var username = User.Identity.Name;
            var id = online.UserTB.SingleOrDefault(u => u.UserName == username).UserID;
            var model = online.UserTB.Find(id);
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
        public ActionResult SendResume() {
            var username = User.Identity.Name;
            var id = online.UserTB.SingleOrDefault(u => u.UserName == username).UserID;
            var model = online.UserTB.Find(id);
            int employerId = online.EmployerTB.Where(p => p.UserID == id).FirstOrDefault().EmployerID;
            int? resumeid = online.EmployerTB.Where(p => p.EmployerID == employerId).Select(p => p.ResumeID).First();
            var Forms = online.FormForeachResume(resumeid);
            int i;i = 1;
            List<ResumeDisplay> resumes = new List<ResumeDisplay>();
            foreach (var item in Forms)
            {
                var r = new ResumeDisplay();
                r.count = i++;
                r.date = item.RequestDtae;
                r.id = item.FormID;
                resumes.Add(r);
            }
            return View(resumes);
        }
        public ActionResult ShowForms(int id)
        {
            var model = online.FormTB.Find(id);
            int employeeId = online.FormDetailTB.Where(p => p.FormID == id).Select(p => p.EmployeeID).FirstOrDefault();
            ViewBag.CompanyName = online.EmployeeTB.Where(p => p.EmployeeID == employeeId).Select(p => p.CompanyName).First();
            var catid = online.FormTB.Where(p => p.FormID == id).FirstOrDefault().JobID;
            ViewBag.category = online.JobCategoryTB.Where(p => p.JobID == catid).FirstOrDefault().JobCategory;
            return PartialView(model);

        }
        public void DeleteForm(int id)
        {
            var entityd = online.ResumeEmployeeTB.Where(p => p.FormID == id).First();
            online.ResumeEmployeeTB.Remove(entityd);
            online.SaveChanges();
        }
        public class JsonData
        {
            public bool Status { get; set; }
            public string Message { get; set; }

        }
    }
}