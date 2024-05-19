using System.ComponentModel.DataAnnotations;

namespace BSB.Models.Models;

public class Salesperson
{
    public string Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public DateTimeOffset StartDate { get; set; }
    [Required]
    public DateTimeOffset TerminationDate { get; set; }
    public string ManagerId { get; set; }
}
