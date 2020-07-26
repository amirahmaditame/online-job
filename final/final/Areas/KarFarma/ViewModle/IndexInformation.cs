using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace final.Areas.KarFarma.ViewModle
{
    public class IndexInformation
    {
        public int RecievedResume { set; get; }
        public int TotallForms { set; get; }
        public int EmployeeID { set; get; }
        public string UserName { set; get; }
        public string PassWord { set; get; }
        public string Email { set; get; }

        public string WebSite { set; get; }
        public string Address { set; get; }
        
        public int PhoneNumber { set; get; }
        public string CompanyName { set; get; }

    }
}