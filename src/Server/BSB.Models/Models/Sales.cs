namespace BSB.Models.Models;

public class Sales
{
    public string Id { get; set; }
    public string ProductName { get; set; }
    public string SalespersonName { get; set; }
    public string CustomerName { get; set; }
    public DateTimeOffset SalesDate { get; set; }
}
