using BSB.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSB.DataAccess.Repository;

public class SalespersonRepository : RepositoryBase<Salesperson>, ISalespersonRepository
{
    public SalespersonRepository(BSBDbContext repositoryContext) : base(repositoryContext)
    {
    }
}
