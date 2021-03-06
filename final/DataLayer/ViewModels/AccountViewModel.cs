﻿using System;
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
        public string Password_H { get; set; }

        [Display(Name = "RePassword")]
        [Required(ErrorMessage = "please Enter the {0}")]
        [DataType(DataType.Password)]
        [Compare("Password_H", ErrorMessage = "Not Match")]
        public string RePassword_H { get; set; }

        [Display(Name = "password")]
        [Required(ErrorMessage = "please Enter the {0}")]
        [DataType(DataType.Password)]
        public string Password_E { get; set; }

        [Display(Name = "RePassword")]
        [Required(ErrorMessage = "please Enter the {0}")]
        [DataType(DataType.Password)]
        [Compare("Password_E", ErrorMessage = "Not Match")]
        public string RePassword_E { get; set; }

        public int roleid { get; set; }

        [Display(Name = "Phone")]
        public int PhoneNumber { get; set; }

        [Display(Name = "Site")]
        public string Site { get; set; }

        [Display(Name = "Address")]
        public string Adress { get; set; }

        [Display(Name = "CompanyName")]
        public string CompanyName { get; set; }

    }

    public class RegisteremployeerViewModel
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
        [Compare("Password", ErrorMessage = "Not Match")]
        public string RePassword { get; set; }

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
    public class RecoveryPasswordViewModel
    {

        [Display(Name = "New password")]
        [Required(ErrorMessage = "please Enter the {0}")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "New Repeat Password")]
        [Required(ErrorMessage = "please Enter the {0}")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Not Match")]
        public string RePassword { get; set; }

    }

}
