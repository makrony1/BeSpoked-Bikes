using BSB.Models.Entity;

namespace BSB.DataAccess.Repository;

public class SalesRepository : RepositoryBase<Sales>, ISalesRepository
{
    public SalesRepository(BSBDbContext repositoryContext) : base(repositoryContext)
    {
    }
}
