using AutoMapper;
using BSB.DataAccess;
using BSB.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BSB.BL.Services;

public class SalesServcie : ISalesServcie
{
    private IRepositoryManager repositoryManager;
    private IMapper mapper;
    public SalesServcie(IRepositoryManager repositoryManager, IMapper mapper)
    {
        this.repositoryManager = repositoryManager;
        this.mapper = mapper;
    }

    public async Task<(Sales sales, bool success, string errorMessage)> CreateSalesAsync(SalesCreate salesCreate)
    {
        ArgumentNullException.ThrowIfNull(salesCreate);
        var product = this.repositoryManager.ProductRepository.FindByCondition(p => p.Id.Equals(salesCreate.ProductId)).FirstOrDefault();
        if (product == null || product.QtyOnHand == 0)
        {
            return (null, false, "Target product not found");
        }
        var customer = this.repositoryManager.CustomerRepository.FindByCondition(p => p.Id.Equals(salesCreate.CustomerId)).FirstOrDefault();
        if (customer == null)
        {
            return (null, false, "Target customer not found");
        }
        var salesperson = this.repositoryManager.SalespersonRepository.FindByCondition(p => p.Id.Equals(salesCreate.SalespersonId)).FirstOrDefault();
        if (salesperson == null)
        {
            return (null, false, "Target salesperson not found");
        }

        var salesToInsert = new Models.Entity.Sales()
        {
            Id = Guid.NewGuid().ToString(),
            Product = product,
            Customer = customer,
            Salesperson = salesperson,
            SalesDate = DateTimeOffset.UtcNow,
        };
        try
        {
            this.repositoryManager.SalesRepository.Create(salesToInsert);
            product.QtyOnHand--;
            this.repositoryManager.ProductRepository.Update(product);
            await this.repositoryManager.SaveChangesAsync();
        }
        catch (Exception)
        {
            return (null, false, "Failed to create sales.");
        }

        var sales = this.mapper.Map<Models.Models.Sales>(salesToInsert);
        return (sales, true, String.Empty);
    }

    public async Task<IEnumerable<Sales>> GetSalesAsync()
    {
        var sales = this.repositoryManager.SalesRepository.FindByCondition(s => s.SalesDate > DateTimeOffset.UtcNow.AddMonths(-3))
            .Include(p => p.Product)
            .Include(p => p.Customer)
            .Include(p => p.Salesperson)
            .ToList();
        return this.mapper.Map<IEnumerable<Models.Models.Sales>>(sales);
    }
}
