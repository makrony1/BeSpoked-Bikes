using System.ComponentModel.DataAnnotations;

namespace BSB.Models.Models;

public class Product : IValidatableObject
{
    public string Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Manufacturer { get; set; }
    [Required]
    public string Style { get; set; }
    [Required]
    public double SalePrice { get; set; }
    [Required]
    public Single PurchasePrice { get; set; }
    [Required]
    public int QtyOnHand { get; set; }
    [Required]
    public double CommissionPercentage { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        ArgumentNullException.ThrowIfNull(nameof(validationContext));
        var validationResult = new List<ValidationResult>();
        if (this.CommissionPercentage < 0)
        {
            validationResult.Add(new ValidationResult("Negative value not allowed for the Commission Percentage"));
        }

        if (this.QtyOnHand <= 0)
        {
            validationResult.Add(new ValidationResult("Negative value not allowed for quantity"));
        }

        if (this.PurchasePrice <= 0)
        {
            validationResult.Add(new ValidationResult("Negative value not allowed for PurchasePrice"));
        }

        if (this.SalePrice <= 0)
        {
            validationResult.Add(new ValidationResult("Negative value not allowed for sales price"));
        }

        return validationResult;
    }
}
