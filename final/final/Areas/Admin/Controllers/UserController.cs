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
  
    public class UserController : Controller
    {
        private OnlineJobEntities db = new OnlineJobEntities();

        // GET: Admin/User
        public ActionResult Index()
        {
            var userTB = db.UserTB.Include(u => u.RoleTB);
            return View(userTB.ToList());
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTB userTB = db.UserTB.Find(id);
            if (userTB == null)
            {
                return HttpNotFound();
            }
            return View(userTB);
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.RoleTB, "RoleID", "RoleTitle");
            return View();
        }

        // POST: Admin/User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,RoleID,UserName,Email,Password,ActiveCode,IsActive,RegisterDate")] UserTB userTB)
        {
            if (ModelState.IsValid)
            {
                db.UserTB.Add(userTB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.RoleTB, "RoleID", "RoleTitle", userTB.RoleID);
            return View(userTB);
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTB userTB = db.UserTB.Find(id);
            if (userTB == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.RoleTB, "RoleID", "RoleTitle", userTB.RoleID);
            return View(userTB);
        }

        // POST: Admin/User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,RoleID,UserName,Email,Password,ActiveCode,IsActive,RegisterDate")] UserTB userTB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.RoleTB, "RoleID", "RoleTitle", userTB.RoleID);
            return View(userTB);
        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTB userTB = db.UserTB.Find(id);
            if (userTB == null)
            {
                return HttpNotFound();
            }
            return View(userTB);
        }

        // POST: Admin/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserTB userTB = db.UserTB.Find(id);
            db.UserTB.Remove(userTB);
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
