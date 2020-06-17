using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserMetaData
    {
        public int UserID { get; set; }

        [Display(Name = "Role")]
        public int RoleID { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Please Enter the {0}")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Enter the {0}")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter the {0}")]
        public string Password { get; set; }

        [Display(Name = "Active Code")]
        public string ActiveCode { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }

        [Display(Name = "Register Date")]
        public System.DateTime RegesterDate { get; set; }

        public virtual RoleTB RoleTB { get; set; }

    }

    [MetadataType(typeof(UserMetaData))]
    public partial class UserTB
    {

    }
}
