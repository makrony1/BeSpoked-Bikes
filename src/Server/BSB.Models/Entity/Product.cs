using System.ComponentModel.DataAnnotations.Schema;

namespace BSB.Models.Entity;

[Table("Products")]
public class Product : EntityBase
{
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public string Style { get; set; }
    public double SalePrice { get; set; }
    public Single PurchasePrice { get; set; }
    public int QtyOnHand { get; set; }
    public double CommissionPercentage { get; set; }

    public ICollection<Sales> Sales { get; set; }
    public ICollection<Discount> Discounts { get; set; }
}
