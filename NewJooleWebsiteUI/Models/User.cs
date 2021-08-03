using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace NewJooleWebsiteUI.Models
{
    public class User
    {
        //Login_Name property for the object
        [Required(ErrorMessage = "This field is required")]
        [StringLength(20, ErrorMessage = "User name cannot exceed 20 characters")]
        [Display(Name = "Username or Email")]
        public string UserName { get; set; }


        //password propery for the object
        [Required(ErrorMessage = "This field is required")]
        [StringLength(20, ErrorMessage = "Password cannot exceed 20 characters")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //Error message propery for the object
        public string LoginErrorMessage { get; set; }

        //email property for the object
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string userEmail { get; set; }

        //confirm password property for the object
        [Compare("Password", ErrorMessage = "Password does not match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string UserID { get; set; }
        public string userNameErrorMessage { get; set; }

        
    }
}