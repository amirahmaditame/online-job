using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
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

                    string body = PartialToStringClass.RenderPartialView("ManageEmail", "ActivationEmail", user);
                    SendEmail.Send(user.Email, "Activation Email", body);

                    return View("SuccessRegister", user);
                }
                else
                {
                    ModelState.AddModelError("Email", "The Email Used Before");
                }
            }
            return View(register);

        }
        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginViewModel login , string ReturnUrl="/")
        {
            if (ModelState.IsValid)
            {
                string hashpassword = FormsAuthentication.HashPasswordForStoringInConfigFile(login.Password, "MD5");
                var user = db.UserTB.SingleOrDefault(u => u.Email == login.Email && u.Password == hashpassword);
                if (user != null)
                {
                    if (user.IsActive)
                    {
                        FormsAuthentication.SetAuthCookie(user.UserName, login.RememberMe);
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "Your Account not Activated");
                       
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "The User Not Found");
                }
            }
            return View(login);

        }
        public ActionResult ActiveUser(string id)
        {
            var user = db.UserTB.SingleOrDefault(u => u.ActiveCode == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            user.IsActive = true;
            user.ActiveCode = Guid.NewGuid().ToString();
            db.SaveChanges();
            ViewBag.username = user.UserName;
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}