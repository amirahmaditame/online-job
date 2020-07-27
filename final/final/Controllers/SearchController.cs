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
        public ActionResult Index(string q, string location , string categorySelected)
        {
            List<DataLayer.FormTB> list = new List<DataLayer.FormTB>();
            if(q!="")
            {
                list.AddRange(db.FormTB.Where(f => f.FormText.Contains(q) || f.JobDescRiption.Contains(q)).ToList());
            }
            if (location != "")
            {
                list.AddRange(db.FormTB.Where(f => f.Region == location));
            }
            if (categorySelected != "")
            {
                list.AddRange(db.FormTB.Where(f => f.JobCategoryTB.JobCategory.Contains(categorySelected)));
            }
            list.Distinct();
           
            ViewBag.search = q;
            return View(list);
        }
    }
}