using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace final.Controllers
{
    public class SearchController : Controller
    {
        OnlineJobEntities db = new OnlineJobEntities();
        public ActionResult Index(string q, string location)
        {
            List<DataLayer.FormTB> list = new List<DataLayer.FormTB>();
            list.AddRange(db.FormTB.Where(f => f.FormText.Contains(q)).ToList());
            list.AddRange(db.FormTB.Where(f => f.Region == location));
            list.Distinct();
            ViewBag.search = q;
            return View(list);
        }
    }
}