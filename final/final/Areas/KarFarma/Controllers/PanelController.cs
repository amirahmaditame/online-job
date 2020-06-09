using DataLayer;
using final.Areas.KarFarma.ViewModle;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
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

            int i = 1;
            List<JobForm> Jobs = new List<JobForm>();
            var model = online.ReportPerEmployeeForPeForm(2);
            foreach (var item in model)
            {
                var r = new JobForm();
                r.count = i ++;
                r.date = item.RequestDtae;
                r.id = item.FormID;
                Jobs.Add(r);
            }
            return View(Jobs);
        }
        public ActionResult JobsForm()
        {
         
            return View();
        }
        public ActionResult RecievedResume()
        {
            List<Resume> resume = new List<Resume>();
            var model = online.ReportPerEmployeeForEachResume1(2);
            
            foreach (var item in model)
            {
                var r = new Resume();
                r.FirstName = item.FirstName;
                r.LastName= item.LatName;
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
    }
}