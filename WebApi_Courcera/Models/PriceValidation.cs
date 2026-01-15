using System.ComponentModel.DataAnnotations;

namespace WebApi_Courcera.Models
{
    public class PriceValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is decimal price)
            {
                if (price < 0)
                {
                    return new ValidationResult("Price cannot be negative.");
                }
                return ValidationResult.Success!;
            }
            return new ValidationResult("Invalid price value.");
        }   
    }
}
