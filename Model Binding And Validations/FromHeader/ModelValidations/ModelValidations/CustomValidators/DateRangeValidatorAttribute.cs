using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidations.CustomValidators
{
    public class DateRangeValidatorAttribute(string otherPropertyName) : ValidationAttribute
    {
        public string OtherPropertyName { get; set; } = otherPropertyName;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime to_date = Convert.ToDateTime(value);

                PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherPropertyName);
                if (otherPropertyInfo != null)
                {
                    DateTime from_date = Convert.ToDateTime(otherPropertyInfo.GetValue(validationContext.ObjectInstance));

                    if (from_date > to_date)
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
