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
        [Display(Name = "Username or Email")]
        public string UserName { get; set; }


        //password propery for the object
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //Error message propery for the object
        public string LoginErrorMessage { get; set; }
    }
}