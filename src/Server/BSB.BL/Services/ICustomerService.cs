using BSB.Models.Models;

namespace BSB.BL.Services;

public interface ICustomerService
{
    Task CreateCutomerAsync(Customer customer);
}
