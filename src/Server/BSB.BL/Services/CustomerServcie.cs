using AutoMapper;
using BSB.DataAccess;
using BSB.Models.Models;

namespace BSB.BL.Services;

public class CustomerServcie : ICustomerService
{
    private IRepositoryManager repositoryManager;
    private IMapper mapper;
    public CustomerServcie(IRepositoryManager repositoryManager, IMapper mapper)
    {
        this.repositoryManager = repositoryManager;
        this.mapper = mapper;
    }

    public async Task<(IEnumerable<Customer> customers, bool success, string errorMessage)> GetCustomersAsync()
    {
        var customers = this.repositoryManager.CustomerRepository.FindByCondition(c => !c.IsDeleted).ToList();

        var cus = this.mapper.Map<IEnumerable<Models.Models.Customer>>(customers);

        return (cus, true, string.Empty);
    }

    public async Task<(IEnumerable<Customer> customers, bool success, string errorMessage)> GetCustomersByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }
        var customers = this.repositoryManager.CustomerRepository.FindByCondition(c => !c.IsDeleted && (c.FirstName.Contains(name) || c.LastName.Contains(name))).ToList();

        var cus = this.mapper.Map<IEnumerable<Models.Models.Customer>>(customers);

        return (cus, true, string.Empty);
    }

    public async Task<(Customer customer, bool success, string errorMessage)> CreateCutomerAsync(Customer customer)
    {
        ArgumentNullException.ThrowIfNull(customer);
        try
        {
            var cus = this.mapper.Map<Models.Entity.Customer>(customer);
            cus.Id = Guid.NewGuid().ToString();
            this.repositoryManager.CustomerRepository.Create(cus);
            await this.repositoryManager.SaveChangesAsync();
            customer.Id = cus.Id;
            return (customer, true, "");

        }
        catch (Exception)
        {
            return (null, false, "Failed to create customer");
        }

    }
}
