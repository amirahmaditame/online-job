using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class FormMetaData
    {
        [Key]
        public int FormID { get; set; }
        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Plaase Enter the {0}")]
      

        public string Region { get; set; }

        public string City { get; set; }

        public string Benefits { get; set; }

        public string WorkingDays { get; set; }

        public string Gender { get; set; }

        public System.DateTime RequestDtae { get; set; }

        public string FormText { get; set; }


    }

    [MetadataType(typeof(FormMetaData))]
    public partial class FormTB
    {

    }
}
