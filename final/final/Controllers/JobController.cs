using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View(job);
        }
    }
}