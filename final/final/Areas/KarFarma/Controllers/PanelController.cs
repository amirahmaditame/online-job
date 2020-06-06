using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace final.Areas.KarFarma.Controllers
{
    public class PanelController : Controller
    {
        // GET: KarFarma/Panel
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Jobs()
        {
            return View();
        }
        public ActionResult JobsForm()
        {
            return View();
        }
        public ActionResult RecievedResume()
        {
            return View();
        }
    }
}