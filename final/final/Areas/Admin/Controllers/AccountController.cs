using DataLayer;
using InsertShowImage;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace final.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        OnlineJobEntities db = new OnlineJobEntities();
        // GET: Admin/Account
        public ActionResult adminprofile()
        {
            var admin = db.UserTB.SingleOrDefault(u=>u.RoleID == 1);
            return View(admin);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult adminprofile([Bind(Include = "UserID,RoleID,UserName,Email,Password,ActiveCode,IsActive,RegesterDate,ImageName")] UserTB adminuser, HttpPostedFileBase imgUp)
        {
           
            if (ModelState.IsValid)
            {
                adminuser.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgUp.FileName);
                imgUp.SaveAs(Server.MapPath("/Images/Admin/" + adminuser.ImageName));
                ImageResizer img = new ImageResizer();
                img.Resize(Server.MapPath("/Images/Admin/" + adminuser.ImageName) , Server.MapPath("/Images/Admin/Thumb/" + adminuser.ImageName));




                db.Entry(adminuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("adminprofile");
            }
     
            return View(adminuser);


        }
    }
}