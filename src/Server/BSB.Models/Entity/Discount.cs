using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSB.Models.Entity;

[Table("Discount")]
public class Discount : EntityBase
{
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
    public DateTimeOffset BeginDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public double DiscountPercentage { get; set; }

}
