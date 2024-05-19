using System.ComponentModel.DataAnnotations.Schema;

namespace BSB.Models.Entity;

[Table("Sales")]
public class Sales : EntityBase
{
    [ForeignKey("ProductId")]
    public virtual Product? Product { get; set; }
    [ForeignKey("SalespersonId")]
    public virtual Salesperson? Salesperson { get; set; }
    [ForeignKey("CustomerId")]
    public virtual Customer? Customer { get; set; }
    public DateTimeOffset SalesDate { get; set; }
}
