using BSB.Models.Entity;

namespace BSB.DataAccess.Repository;

public class SalespersonRepository : RepositoryBase<Salesperson>, ISalespersonRepository
{
    public SalespersonRepository(BSBDbContext repositoryContext) : base(repositoryContext)
    {
    }
}
