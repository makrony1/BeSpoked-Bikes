using BSB.Models.Entity;

namespace BSB.DataAccess.Repository;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(BSBDbContext repositoryContext) : base(repositoryContext)
    {
    }
}
