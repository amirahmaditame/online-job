using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class RegisterViewModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "please Enter the {0}")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "please Enter the {0}")]
        [EmailAddress(ErrorMessage = "Please Enter valid Email")]
        public string Email { get; set; }

        [Display(Name = "password")]
        [Required(ErrorMessage = "please Enter the {0}")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "RePassword")]
        [Required(ErrorMessage = "please Enter the {0}")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Error")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Choose at least one")]
        public int roleid { get; set; }
    }
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "please Enter the {0}")]
        [EmailAddress(ErrorMessage = "Invlid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "please Enter the {0}")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
    public class ForgotPasswordViewModel
    {

        [Display(Name = "Email")]
        [Required(ErrorMessage = "please Enter the {0}")]
        [EmailAddress(ErrorMessage = "Please Enter valid Email")]
        public string Email { get; set; }
    }

}
