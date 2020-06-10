using Microsoft.Build.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
  public  class JobsGroupMetaData
    {
        [Key]
        public int JobID { get; set; }

        [Display(Name ="Name")]

        [Required(ErrorMessage = "Plaase Enter the {0}")]
        public string JobCategory { get; set; }
    }

    [MetadataType(typeof(JobsGroupMetaData))]
    public partial class JobCategoryTB
    {

    }
}
