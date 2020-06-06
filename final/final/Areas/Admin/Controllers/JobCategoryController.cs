using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace final.Areas.Admin.Controllers
{
    public class JobCategoryController : Controller
    {
        private IJobGroupRepository jobGroupRepository;
        public JobCategoryController()
        {
            jobGroupRepository = new JobGroupRepository();
        }

        // GET: Admin/JobCategory
        public ActionResult Index()
        {
            return View(jobGroupRepository.GetAllGroups());
        }
 
    }
}
