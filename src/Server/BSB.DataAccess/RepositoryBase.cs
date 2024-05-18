using BSB.Models.Entity;
using System.Linq.Expressions;

namespace BSB.DataAccess;

public abstract class RepositoryBase<T> : IRepositoryBase<T> 
    where T : EntityBase
{
    protected BSBDbContext RepositoryContext { get; set; }
    public RepositoryBase(BSBDbContext repositoryContext)
    {
        RepositoryContext = repositoryContext;
    }
    public IQueryable<T> FindAll() => RepositoryContext.Set<T>();
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
        RepositoryContext.Set<T>().Where(expression);
    public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
    public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
    public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
}
