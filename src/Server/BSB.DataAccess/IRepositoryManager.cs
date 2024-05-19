using BSB.DataAccess.Repository;

namespace BSB.DataAccess;

public interface IRepositoryManager
{
    ICoustomerRepository CustomerRepository { get; }
    IProductRepository ProductRepository { get; }
    ISalespersonRepository SalespersonRepository { get; }
    ISalesRepository SalesRepository { get; }
    IDiscountRepository DiscountRepository { get; }
    Task SaveChangesAsync();
}
