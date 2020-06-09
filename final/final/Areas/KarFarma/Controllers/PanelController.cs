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
            return View();
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
            

            return PartialView();

        }
    }
}