using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSB.Models.Entity;

[Table("Sales")]
public class Sales : EntityBase
{
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
    [ForeignKey("SalespersonId")]
    public virtual Salesperson Salesperson { get;set; }
    [ForeignKey("CustomerId")]
    public virtual Customer Customer { get;set; }
    public DateTimeOffset SalesDate { get; set; }
}
