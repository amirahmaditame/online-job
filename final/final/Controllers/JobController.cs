using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace final.Controllers
{
    public class JobController : Controller
    {
        OnlineJobEntities db = new OnlineJobEntities();
        // GET: Job
        [Route("ShowJob/{id}")]
        public ActionResult ShowJob(int id)
        {
           
                var job = db.FormTB.Find(id);
                //var username = User.Identity.Name;
                //var userid = db.UserTB.SingleOrDefault(u => u.UserName == username).UserID;
                //var resumeid = db.EmployerTB.SingleOrDefault(r => r.UserID == userid).ResumeID;
                ViewBag.category = db.JobCategoryTB.ToList();



                //var jobDetail = new jobDetailViewModel()
                //{
                //    form = job,
                //    resumeId = resumeid.Value


                //};

                ViewBag.benefits = job.Benefits.Split(',').ToList();
                return View(job);
           
        }

        [HttpPost]
        public void sendresume(int resumeId , int FormID)
        {
            var jobb = new ResumeEmployeeTB()
            {
                ResumeID = resumeId,
                Date = DateTime.Now,
                FormID = FormID
            };

            db.ResumeEmployeeTB.Add(jobb);
            db.SaveChanges();
           
        }

    }
}