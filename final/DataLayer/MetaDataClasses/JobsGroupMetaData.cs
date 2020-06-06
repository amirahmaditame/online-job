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
        public string JobCategory { get; set; }
    }

    [MetadataType(typeof(JobsGroupMetaData))]
    public partial class JobCategoryTB
    {

    }
}
