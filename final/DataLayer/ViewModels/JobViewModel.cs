using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
  public  class HomeJobViewModel
    {
        public FormTB form;
        public int phoneNumber;
    }

    public class jobDetailViewModel
    {
        public FormTB form;
        public int resumeId { get; set; }
    }
}
