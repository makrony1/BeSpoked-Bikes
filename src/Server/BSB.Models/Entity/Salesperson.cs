using System.ComponentModel.DataAnnotations.Schema;

namespace BSB.Models.Entity;

[Table("Salesperson")]
public class Salesperson : EntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset TerminationDate { get; set; }
    [ForeignKey("ManagerId")]
    public virtual Salesperson? Manager { get; set; }
    public ICollection<Sales> Sales { get; set; }
}
