using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace final.Controllers
{
    public class PagesController : Controller
    {
        OnlineJobEntities db = new OnlineJobEntities();

       [Route("About")]
        public ActionResult About()
        {
            return View();
        }
        [Route("Contact")]
        public ActionResult Contact()
        {
            return View();
        }

        [Route("Contact")]
        [HttpPost]
        public ActionResult Contact(ContactMessage message)
        {
            return View();
        }
    }
}