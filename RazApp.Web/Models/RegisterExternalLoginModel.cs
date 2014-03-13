using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RazApp.Web.Models
{
    public class RegisterExternalLoginModel
    {
        [Required(ErrorMessage="Username required")]
        [Display(Name = "User name")]
        public string UserName { get; set; }




        [Required(ErrorMessage = "Mobile required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]        
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Email required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]       
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage="Invalid Email")]
        public string Email { get; set; }

         [Required(ErrorMessage = "Address required")]
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [Display(Name = "Address")]      
        public string Address { get; set; }

        public string ExternalLoginData { get; set; }
    }
}