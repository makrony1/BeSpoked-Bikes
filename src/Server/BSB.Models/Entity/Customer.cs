using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSB.Models.Entity;

[Table("Customer")]
public class Customer : EntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public ICollection<Sales> Sales { get; set; }
}
