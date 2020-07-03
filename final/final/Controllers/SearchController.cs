using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace final.Controllers
{
    public class SearchController : Controller
    {
        OnlineJobEntities db = new OnlineJobEntities();
        public ActionResult Index(string q)
        {
            List<DataLayer.FormTB> list = new List<DataLayer.FormTB>();
            list.AddRange(db.FormTB.Where(f => f.CompanyName.Contains(q) || f.FormText.Contains(q)).ToList());

            ViewBag.search = q;
            return View(list);
        }
    }
}