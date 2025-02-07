using System.ComponentModel.DataAnnotations;

namespace ModelValidations.CustomValidators
{
    public class MinimumYearValidatorAttribute: ValidationAttribute
    {
        public int MinimumYear { get; set; } = 2000;

        public string DefaultErrorMessage => $"The year must be greater than {MinimumYear}";
        public MinimumYearValidatorAttribute() {
        
        }

        public MinimumYearValidatorAttribute(int minimumYear)
        {
            MinimumYear = minimumYear;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year < MinimumYear)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumYear));
                }
            }
            return ValidationResult.Success;
        }
    }
}
