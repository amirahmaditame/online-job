using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ContactMessageMetaData
    {
        [Key]
        public int ContactMessageID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please Enter the {0}")]
      
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Enter the {0}")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [Display(Name = "Subject")]
        [Required(ErrorMessage = "Please Enter the {0}")]
       
        public string Subject { get; set; }

        [Display(Name = "Text")]
        [Required(ErrorMessage = "Please Enter the {0}")]
       
        public string MessageText { get; set; }
    }

    [MetadataType(typeof(ContactMessageMetaData))]
    public partial class ContactMessage
    {

    }
}
