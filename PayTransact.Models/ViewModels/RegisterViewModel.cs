using System;
using System.ComponentModel.DataAnnotations;

namespace PayTransact.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "*First name required.")]
        [Display(Name = "First name", Prompt = "Enter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*Last name required.")]
        [Display(Name = "Last name", Prompt = "Enter your Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*Email address required.")]
        [Display(Name = "Email address", Prompt = "Enter your email address")]
        [EmailAddress(ErrorMessage = @"^Invalid email address supplied.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Date of birth required.")]
        [Display(Name = "Date of birth", Prompt = "Enter your date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "*Mobile number required.")]
        [Display(Name = "Mobile number", Prompt = "Enter your mobile number")]
        public string TelePhoneNumber { get; set; }

        [Required(ErrorMessage = "*Password required.")]
        [Display(Prompt = "Enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "*Confirm Password required.")]
        [Display(Name = "Confirm password", Prompt = "Re-enter your password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
