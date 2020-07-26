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
    [Authorize(Roles = "employee")]
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
            var resume = online.ReportPerKarfarmaPerResume(employeeId);
            index.Email = model.Email;
            index.UserName = model.UserName;
            index.PassWord = model.Password;
            index.RecievedResume = resume.Count();
            index.TotallForms = online.FormDetailTB.Where(p => p.EmployeeID == employeeId).Count();
            index.WebSite = online.EmployeeTB.Where(p => p.EmployeeID == employeeId).Select(p => p.Site).First();
            index.PhoneNumber = online.EmployeeTB.Where(p => p.EmployeeID == employeeId).Select(p => p.PhoneNumber.Value).First();
            index.Address = online.EmployeeTB.Where(p => p.EmployeeID == employeeId).Select(p => p.Adress).First();
            index.CompanyName = online.EmployeeTB.Where(p => p.EmployeeID == employeeId).Select(p => p.CompanyName).First();
            return View(index);
        }
        public ActionResult EmployeeInformation() {
            var username = User.Identity.Name;
            var id = online.UserTB.SingleOrDefault(u => u.UserName == username).UserID;
            var model = online.UserTB.Find(id);
            int employeeId = online.EmployeeTB.Where(p => p.UserID == id).FirstOrDefault().EmployeeID;
            MyInformation information = new MyInformation();
            information.CompanyName= online.EmployeeTB.Where(p => p.EmployeeID == employeeId).Select(p => p.CompanyName).First();
            information.Email = model.Email;
            information.UserName = model.UserName;
            information.PassWord = model.Password;
            information.UserID = model.UserID;
            information.WebSite = online.EmployeeTB.Where(p => p.EmployeeID == employeeId).Select(p => p.Site).First();
            information.PhoneNumber = online.EmployeeTB.Where(p => p.EmployeeID == employeeId).Select(p => p.PhoneNumber.Value).First();
            information.Address = online.EmployeeTB.Where(p => p.EmployeeID == employeeId).Select(p => p.Adress).First();
            return View(information);
        }
        [HttpPost]
        public ActionResult EmployeeInformation(MyInformation information)
        {
            var model = online.UserTB.Find(information.UserID);
            var employee = online.EmployeeTB.Where(p => p.UserID == information.UserID).FirstOrDefault();
            model.UserName = information.UserName;
            model.Password = information.PassWord;
            model.Email = information.Email;
            employee.CompanyName = information.CompanyName;
            employee.Adress = information.Address;
            employee.PhoneNumber = information.PhoneNumber;
            employee.Site = information.WebSite;
            online.SaveChanges();
            return Json(new JsonData()
            {
                Status = true
            });
        }
        public ActionResult Jobs()
        {
            var username = User.Identity.Name;
            var id = online.UserTB.SingleOrDefault(u => u.UserName == username).UserID;
            int employeeId = online.EmployeeTB.Where(p => p.UserID == id).FirstOrDefault().EmployeeID;
            int i = 1;
            List<JobForm> Jobs = new List<JobForm>();
            var model = online.ReportEmployeeForPerForm(employeeId);
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
            var username = User.Identity.Name;
            var id = online.UserTB.SingleOrDefault(u => u.UserName == username).UserID;
            int employeeId = online.EmployeeTB.Where(p => p.UserID == id).FirstOrDefault().EmployeeID;
            var model = online.ReportPerKarfarmaEachResume(employeeId);

            foreach (var item in model)
            {
                var r = new Resume();
                r.FirstName = item.FirstName;
                r.LastName = item.LatName;
                r.id = item.ResumeID;
                r.date = item.sentdate;
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
            var username = User.Identity.Name;
            var i = online.UserTB.SingleOrDefault(u => u.UserName == username).UserID;
            int employeeId = online.EmployeeTB.Where(p => p.UserID == id).FirstOrDefault().EmployeeID;
            var model = online.FormTB.Find(id);
            ViewBag.CompanyName = online.EmployeeTB.Where(p => p.EmployeeID == employeeId).Select(p => p.CompanyName).First();
            var catid = online.FormTB.Where(p => p.FormID == id).FirstOrDefault().JobID;
            ViewBag.category = online.JobCategoryTB.Where(p => p.JobID == catid).FirstOrDefault().JobCategory;
            return PartialView(model);

        }
        [HttpGet]
        public ActionResult EditForm(int id)
        {
            EditFormViewModel editForm = new EditFormViewModel(); 
            var username = User.Identity.Name;
            var userid = online.UserTB.SingleOrDefault(u => u.UserName == username).UserID;
            int employeeId = online.EmployeeTB.Where(p => p.UserID == userid).FirstOrDefault().EmployeeID;
            var model = online.FormTB.Find(id);
            editForm.Form = model;
            editForm.JobCategory = online.JobCategoryTB.ToList();
            var catid = online.FormTB.Where(p => p.FormID == id).FirstOrDefault().JobID;
            ViewBag.category = online.JobCategoryTB.Where(p => p.JobID == catid).Select(p=>p.JobCategory).FirstOrDefault();
            ViewBag.CompanyName = online.EmployeeTB.Where(p => p.EmployeeID == employeeId).Select(p => p.CompanyName).First();
            return View(editForm);
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
        public ActionResult AddForm()
        {
            var username = User.Identity.Name;
            var id = online.UserTB.SingleOrDefault(u => u.UserName == username).UserID;
            int employeeId = online.EmployeeTB.Where(p => p.UserID == id).FirstOrDefault().EmployeeID;
            ViewBag.CompanyName = online.EmployeeTB.Where(p => p.EmployeeID == employeeId).Select(p => p.CompanyName).First();
            AddForm category = new AddForm();
            var model = online.JobCategoryTB.ToList();
            return View(model);
        }
        [HttpPost]
        public JsonResult AddForm(FormTB form)
        {
            form.RequestDtae = DateTime.Now;
            online.FormTB.Add(form);
            var username = User.Identity.Name;
            var id = online.UserTB.SingleOrDefault(u => u.UserName == username).UserID;
            int employeeId = online.EmployeeTB.Where(p => p.UserID == id).FirstOrDefault().EmployeeID;
            FormDetailTB form1 = new FormDetailTB() {
                EmployeeID = employeeId,
                FormID=form.FormID
            };
            online.FormDetailTB.Add(form1);
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
    }
}