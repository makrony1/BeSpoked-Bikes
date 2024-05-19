using System.ComponentModel.DataAnnotations;

namespace BSB.Models.Models;

public class SalesCreate : IValidatableObject
{
    [Required]
    public string ProductId { get; set; }
    [Required]
    public string SalespersonId { get; set; }
    [Required]
    public string CustomerId { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        ArgumentNullException.ThrowIfNull(nameof(validationContext));
        var validationResult = new List<ValidationResult>();
        if (string.IsNullOrWhiteSpace(CustomerId))
        {
            validationResult.Add(new ValidationResult("Required property Customer Id cannot be null or empty"));
        }

        if (string.IsNullOrWhiteSpace(SalespersonId))
        {
            validationResult.Add(new ValidationResult("Required property Salesperson Id cannot be null or empty"));
        }

        if (string.IsNullOrWhiteSpace(ProductId))
        {
            validationResult.Add(new ValidationResult("Required property product Id cannot be null or empty."));
        }
        return validationResult;
    }
}
