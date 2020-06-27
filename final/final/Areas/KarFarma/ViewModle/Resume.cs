using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;

namespace final.Areas.KarFarma.ViewModle
{
    public class Resume
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int id { get; set; }
        public DateTime ? date { get; set; }
    }
}