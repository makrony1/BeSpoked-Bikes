using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSB.Models.Entity;

[Table("Products")]
public class Product: EntityBase
{
	public string Name { get; set; }
	public string Manufacturer { get; set; }
	public double SalePrice { get; set; }
	public double PurchasePrice { get; set; }
	public int QtyOnHand { get; set; }
	public double CommissionPercentage { get; set; }

	public ICollection<Sales> Sales { get; set; }
	public ICollection<Discount> Discounts { get; set; }
}
