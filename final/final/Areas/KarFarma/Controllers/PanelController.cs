using DataLayer;
using final.Areas.KarFarma.ViewModle;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace final.Areas.KarFarma.Controllers
{
    [Authorize(Roles = "employeer")]
    public class PanelController : Controller
    {
        // GET: KarFarma/Panel
        OnlineJobEntities online = new OnlineJobEntities();
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var id = online.UserTB.SingleOrDefault(u => u.UserName == username).UserID;
            var model = online.UserTB.Find(id);
            int employeeId = online.EmployeeTB.Where(p => p.UserID == id).FirstOrDefault().EmployeeID;
            IndexInformation index = new IndexInformation();
            index.Email = model.Email;
            index.UserName = model.UserName;
            index.PassWord = model.Password;
            index.RecievedResume = online.ResumeEmployeeTB.Where(p => p.EmployeeID == employeeId).Count();
            index.TotallForms = online.FormDetailTB.Where(p => p.EmployeeID == employeeId).Count();
            return View(index);
        }
        public ActionResult EmployeeInformation() {
            var model = online.UserTB.Find(1);
            MyInformation information = new MyInformation();
            information.Email = model.Email;
            information.UserName = model.UserName;
            information.PassWord = model.Password;
            information.UserID = model.UserID;
            return View(information);
        }
        [HttpPost]
        public ActionResult EmployeeInformation(int UserID,string UserName,string PassWord,String Email)
        {
            var model = online.UserTB.Find(UserID);
            model.UserName = UserName;
            model.Password = PassWord;
            model.Email = Email;
            online.SaveChanges();
            return Json(new JsonData()
            {
                Status = true
            });
        }
        public ActionResult Jobs()
        {

            int i = 1;
            List<JobForm> Jobs = new List<JobForm>();
            var model = online.ReportPerEmployeeForPeForm(1);
            foreach (var item in model)
            {
                var r = new JobForm();
                r.count = i++;
                r.date = item.RequestDtae;
                r.id = item.FormID;
                Jobs.Add(r);
            }
            return View(Jobs);
        }
        public ActionResult RecievedResume()
        {
            List<Resume> resume = new List<Resume>();
            var model = online.ReportPerEmployeeForEachResume1(2);

            foreach (var item in model)
            {
                var r = new Resume();
                r.FirstName = item.FirstName;
                r.LastName = item.LatName;
                r.id = item.ResumeID;
                r.date = item.SentDate;
                resume.Add(r);
            }
            return View(resume);
        }

        public ActionResult ShowResume(int id)
        {

            var model = online.ResumeTB.Find(id);
            return PartialView(model);

        }

        public ActionResult ShowForms(int id)
        {

            var model = online.FormTB.Find(id);
            return PartialView(model);

        }
        [HttpGet]
        public ActionResult EditForm(int id)
        {
            var model = online.FormTB.Find(id);
            return View(model);
        }
        [HttpPost]
        public JsonResult EditForm(FormTB form)
        {
            form.RequestDtae = DateTime.Now;
            online.Entry(form).State = EntityState.Modified;
            online.SaveChanges();
            return Json(new JsonData()
            {
                Status = true
            });
        }
        public ActionResult AddForm() {
            return View();
        }
        [HttpPost]
        public JsonResult AddForm(FormTB form)
        {
            form.RequestDtae = DateTime.Now;
            online.Entry(form).State = EntityState.Added;
            online.SaveChanges();
            return Json(new JsonData()
            {
                Status = true
            });
        }

        public void DeleteForm(int id) {
            var entity = online.FormTB.Find(id);
            online.Entry(entity).State = EntityState.Deleted;

            var entityd = online.FormDetailTB.Where(p => p.FormID == id).First();
            online.FormDetailTB.Remove(entityd);
            online.SaveChanges();
        }
        public class JsonData
        {
            public bool Status { get; set; }
            public string Message { get; set; }

        }
        public ActionResult test(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = online.FormTB.Find(id);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult test(FormTB form)
        {
            if (ModelState.IsValid)
            {
                online.Entry(form).State = EntityState.Modified;
                online.SaveChanges();
            }
            return View(form);
        }
    }
}