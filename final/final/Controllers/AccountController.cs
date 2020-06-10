using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace final.Controllers
{
    public class AccountController : Controller
    {
        OnlineJobEntities db = new OnlineJobEntities();
        // GET: Account
        [Route("Register")]
        public ActionResult Register()
        {
            return View();
        }

        [Route("Register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                if (!db.UserTB.Any(u => u.Email == register.Email.Trim().ToLower()))
                {
                    UserTB user = new UserTB()
                    {
                        UserName = register.UserName,
                        Email = register.Email.Trim().ToLower(),
                        Password = FormsAuthentication.HashPasswordForStoringInConfigFile(register.Password, "MD5"),
                        ActiveCode = Guid.NewGuid().ToString(),
                        IsActive = false,
                        RegisterDate = DateTime.Now,
                        RoleID = register.roleid
                    };

                    db.UserTB.Add(user);
                    db.SaveChanges();
                    return View("SuccessRegister", user);
                }
                else
                {
                    ModelState.AddModelError("Email", "The Email Used Before");
                }
            }
            return View(register);

        }
        public ActionResult Login()
        {
            return View();
        }
    }
}