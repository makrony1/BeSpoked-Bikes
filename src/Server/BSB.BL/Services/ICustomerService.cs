using BSB.Models.Models;

namespace BSB.BL.Services;

public interface ICustomerService
{
    Task<(Customer customer, bool success, string errorMessage)> CreateCutomerAsync(Customer customer);
    Task<(IEnumerable<Customer> customers, bool success, string errorMessage)> GetCustomersAsync();
    Task<(IEnumerable<Customer> customers, bool success, string errorMessage)> GetCustomersByName(string name);
}
