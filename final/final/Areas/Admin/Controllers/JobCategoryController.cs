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

        // GET: Admin/JobCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobCategoryTB jobCategoryTB = db.JobCategoryTB.Find(id);
            if (jobCategoryTB == null)
            {
                return HttpNotFound();
            }
            return View(jobCategoryTB);
        }

        // GET: Admin/JobCategory/Create
        public ActionResult Create()
        {
            return View();
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
                db.JobCategoryTB.Add(jobCategoryTB);
                db.SaveChanges();
                return RedirectToAction("Index");
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
            JobCategoryTB jobCategoryTB = db.JobCategoryTB.Find(id);
            if (jobCategoryTB == null)
            {
                return HttpNotFound();
            }
            return View(jobCategoryTB);
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
                db.Entry(jobCategoryTB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobCategoryTB);
        }

        // GET: Admin/JobCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobCategoryTB jobCategoryTB = db.JobCategoryTB.Find(id);
            if (jobCategoryTB == null)
            {
                return HttpNotFound();
            }
            return View(jobCategoryTB);
        }

        // POST: Admin/JobCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobCategoryTB jobCategoryTB = db.JobCategoryTB.Find(id);
            db.JobCategoryTB.Remove(jobCategoryTB);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
