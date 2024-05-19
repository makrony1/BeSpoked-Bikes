using BSB.Models.Models;
namespace BSB.BL.Services;

public interface ISalesServcie
{
    Task<IEnumerable<Sales>> GetSalesAsync();
    Task<(Sales sales, bool success, string errorMessage)> CreateSalesAsync(SalesCreate salesCreate);
}
