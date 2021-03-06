﻿using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Security.Policy;
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


        [HttpPost]
        [Route("Register")]
        public ActionResult Register(RegisterViewModel register)
        {

            if (register.roleid == 2)
            {
                ModelState["RePassword_H"].Errors.Clear();
                ModelState["Password_H"].Errors.Clear();
                if (ModelState.IsValid)
                {
                    if (!db.UserTB.Any(u => u.Email == register.Email.Trim().ToLower()))
                    {
                        UserTB user = new UserTB()
                        {
                            UserName = register.UserName,
                            Email = register.Email.Trim().ToLower(),
                            Password = FormsAuthentication.HashPasswordForStoringInConfigFile(register.Password_E, "MD5"),
                            ActiveCode = Guid.NewGuid().ToString(),
                            IsActive = false,
                            RegesterDate = DateTime.Now,
                            RoleID = register.roleid
                        };

                        db.UserTB.Add(user);



                        var useremployee = new EmployeeTB()
                        {
                            UserID = user.UserID,
                            PhoneNumber = register.PhoneNumber,
                            Site = register.Site,
                            Adress = register.Adress,
                            CompanyName = register.CompanyName
                        };
                        db.EmployeeTB.Add(useremployee);

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
            }
            else if (register.roleid == 3)
            {
                ModelState["RePassword_E"].Errors.Clear();
                ModelState["Password_E"].Errors.Clear();
                ModelState["PhoneNumber"].Errors.Clear();
                if (ModelState.IsValid)
                {
                    if (!db.UserTB.Any(u => u.Email == register.Email.Trim().ToLower()))
                    {
                        UserTB user1 = new UserTB()
                        {
                            UserName = register.UserName,
                            Email = register.Email.Trim().ToLower(),
                            Password = FormsAuthentication.HashPasswordForStoringInConfigFile(register.Password_H, "MD5"),
                            ActiveCode = Guid.NewGuid().ToString(),
                            IsActive = false,
                            RegesterDate = DateTime.Now,
                            RoleID = register.roleid
                        };

                        db.UserTB.Add(user1);

                        var useremployer = new EmployerTB()
                        {
                            UserID = user1.UserID
                        };
                        db.EmployerTB.Add(useremployer);
                        db.SaveChanges();
                        string body = PartialToStringClass.RenderPartialView("ManageEmail", "ActivationEmail", user1);
                        SendEmail.Send(user1.Email, "Activation Email", body);

                        return View("SuccessRegister", user1);

                    }
                    else
                    {
                        ModelState.AddModelError("Email", "The Email Used Before");
                    }

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
        public ActionResult Login(LoginViewModel login, string ReturnUrl = "/")
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

        [Route("ForgotPassword")]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [Route("ForgotPassword")]
        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordViewModel forgot)
        {
            if (ModelState.IsValid)
            {
                var user = db.UserTB.SingleOrDefault(u => u.Email == forgot.Email);
                if (user != null)
                {
                    if (user.IsActive)
                    {
                        string body = PartialToStringClass.RenderPartialView("ManageEmail", "RecoverPassword", user);
                        SendEmail.Send(user.Email, "Recovery Password", body);
                        return View("SuccessForgotPassword", user);
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "User Not Activated");
                    }

                }
                else
                {
                    ModelState.AddModelError("Email", "USer Not Found");
                }
            }
            return View(forgot);
        }

        public ActionResult RecoveryPassword(string id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecoveryPassword(string id, RecoveryPasswordViewModel recovery)
        {
            if (ModelState.IsValid)
            {
                var user = db.UserTB.SingleOrDefault(u => u.ActiveCode == id);
                if (user == null)
                {
                    return HttpNotFound();

                }
                user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(recovery.Password, "MD5");
                user.ActiveCode = Guid.NewGuid().ToString();
                db.SaveChanges();
                return Redirect("/Login?recovery=true");


            }

            return View();
        }





    }
}