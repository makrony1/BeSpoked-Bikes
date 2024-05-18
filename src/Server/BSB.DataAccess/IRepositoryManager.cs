using BSB.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
