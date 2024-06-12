using System.ComponentModel.DataAnnotations;

namespace system.Models.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Name is Required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}