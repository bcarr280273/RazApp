using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RazApp.Web.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage="Username required")]
        
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]        
        public string Password { get; set; }

        [DataType(DataType.Password)]        
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
      

        [Required(ErrorMessage = "Email required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]               
        [EmailAddress(ErrorMessage="Invalid Email")]
        public string Email { get; set; }

    

    }
}