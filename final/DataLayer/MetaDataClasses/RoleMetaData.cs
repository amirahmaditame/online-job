using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class RoleMetaData
    {
        [Key]
        public int RoleID { get; set; }

        [Display(Name = "User Role")]
        [Required(ErrorMessage = "Please Enter the {0}")]
        public string RoleTitle { get; set; }

        [Display(Name = "System Role")]
        [Required(ErrorMessage = "Please Enter the {0}")]
        public string RoleName { get; set; }
    }


    [MetadataType(typeof(RoleMetaData))]
    public partial class RoleTB
    {

    }
}
