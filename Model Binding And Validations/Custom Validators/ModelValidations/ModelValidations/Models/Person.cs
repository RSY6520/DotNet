using System.ComponentModel.DataAnnotations;
using ModelValidations.CustomValidators;

namespace ModelValidations.Models
{
    public class Person
    {
        [Required(ErrorMessage = "{0} can't be empty or null")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} characters")]
        [RegularExpression(@"^[a-zA-Z]$", ErrorMessage = "{0} can only contain letters and spaces and dot .")]
        public string? PersonName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "{0} can't be empty or null")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "{0} should contain 10 digits")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "{0} can't be empty or null")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} can't be empty or null")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [Display(Name = "Re-enter Password")]
        public string? ConfirmPassword { get; set; }

        [Range(0, 999.99, ErrorMessage = "{0} must be between {1} and {2}")]
        public double? Price { get; set; }

        [MinimumYearValidator(2005, ErrorMessage = "{0} must be greater than {1}")]
        public DateTime? DateOfBirth { get; set; }

        public override string ToString()
        {
            return $"Person Object: {PersonName} {Email} {Phone} {Price}";
        }
    }
}
