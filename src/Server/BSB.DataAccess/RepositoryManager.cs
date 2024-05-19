using BSB.DataAccess.Repository;

namespace BSB.DataAccess;

public class RepositoryManager : IRepositoryManager
{
    private BSBDbContext _dbContext;
    private ICoustomerRepository _coustomerRepository;
    private IProductRepository _productRepository;
    private ISalespersonRepository _salespersonRepository;
    private ISalesRepository _salesRepository;
    private IDiscountRepository _discountRepository;
    public RepositoryManager(BSBDbContext repositoryContext)
    {
        _dbContext = repositoryContext;
    }

    public ICoustomerRepository CustomerRepository
    {
        get
        {
            if (_coustomerRepository == null)
            {
                _coustomerRepository = new CustomerRepository(_dbContext);
            }
            return _coustomerRepository;
        }
    }

    public IProductRepository ProductRepository
    {
        get
        {
            if (_productRepository == null)
            {
                _productRepository = new ProductRepository(_dbContext);
            }
            return _productRepository;
        }
    }

    public ISalespersonRepository SalespersonRepository
    {
        get
        {
            if (_salespersonRepository == null)
            {
                _salespersonRepository = new SalespersonRepository(_dbContext);
            }
            return _salespersonRepository;
        }
    }
    public ISalesRepository SalesRepository
    {
        get
        {
            if (_salesRepository == null)
            {
                _salesRepository = new SalesRepository(_dbContext);
            }
            return _salesRepository;
        }
    }
    public IDiscountRepository DiscountRepository
    {
        get
        {
            if (_discountRepository == null)
            {
                _discountRepository = new DiscountRepository(_dbContext);
            }
            return _discountRepository;
        }
    }
    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
