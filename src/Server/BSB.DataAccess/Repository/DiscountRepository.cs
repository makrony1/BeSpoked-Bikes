using BSB.Models.Entity;

namespace BSB.DataAccess.Repository;

public class DiscountRepository : RepositoryBase<Discount>, IDiscountRepository
{
    public DiscountRepository(BSBDbContext repositoryContext) : base(repositoryContext)
    {
    }
}
