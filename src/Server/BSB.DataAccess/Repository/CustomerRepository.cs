using BSB.Models.Entity;

namespace BSB.DataAccess.Repository;

public class CustomerRepository : RepositoryBase<Customer>, ICoustomerRepository
{
    public CustomerRepository(BSBDbContext repositoryContext) : base(repositoryContext)
    {
    }
}
