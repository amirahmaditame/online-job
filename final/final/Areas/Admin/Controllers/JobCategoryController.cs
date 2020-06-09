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
            return View();
        }

        public ActionResult JobGroups()
        {
            return PartialView(jobGroupRepository.GetAllGroups());
        }
        // GET: Admin/JobCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobCategoryTB jobCategoryTB = jobGroupRepository.GetGroupById(id.Value);
            if (jobCategoryTB == null)
            {
                return HttpNotFound();
            }
            return View(jobCategoryTB);
        }

        // GET: Admin/JobCategory/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/JobCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobID,JobCategory")] JobCategoryTB jobCategoryTB)
        {
            if (ModelState.IsValid)
            {
                jobGroupRepository.InsertGroup(jobCategoryTB);
                jobGroupRepository.save();
                return PartialView("JobGroups", jobGroupRepository.GetAllGroups());
            }

            return View(jobCategoryTB);
        }

        // GET: Admin/JobCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobCategoryTB jobCategoryTB = jobGroupRepository.GetGroupById(id.Value);
            if (jobCategoryTB == null)
            {
                return HttpNotFound();
            }
            return PartialView(jobCategoryTB);
        }

        // POST: Admin/JobCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobID,JobCategory")] JobCategoryTB jobCategoryTB)
        {
            if (ModelState.IsValid)
            {
                jobGroupRepository.UpdateGroup(jobCategoryTB);
                jobGroupRepository.save();
                return PartialView("JobGroups", jobGroupRepository.GetAllGroups());
            }
            return View(jobCategoryTB);
        }

        // GET: Admin/JobCategory/Delete/5
        public void Delete(int? id)
        {
            jobGroupRepository.DeleteGroup(id.Value);
            jobGroupRepository.save();
        }

        // POST: Admin/JobCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            jobGroupRepository.DeleteGroup(id);
            jobGroupRepository.save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                jobGroupRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult summaryBox()
        {
            return PartialView();
        }
    }
}
