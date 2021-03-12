using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayTransact.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "*Email address required.")]
        [Display(Name = "Username", Prompt = "Enter your email address as username")]
        [EmailAddress(ErrorMessage = @"^Invalid email address supplied.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "*Password required.")]
        [Display(Prompt = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
