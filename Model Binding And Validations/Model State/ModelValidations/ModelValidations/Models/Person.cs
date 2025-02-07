using System.ComponentModel.DataAnnotations;

namespace ModelValidations.Models
{
    public class Person
    {
        [Required(ErrorMessage ="PersonName can't be empty or null")]
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public double? Price { get; set; }

        public override string ToString()
        {
            return $"Person Object: {PersonName} {Email} {Phone} {Price}";
        }
    }
}
