using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories;

public class SqlRepository<T> where T : class, IEntity, new()
{
    private readonly DbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public SqlRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }
    
    public T CreateItem() => new T();

    public T GetById(int id) => _dbSet.Single(x => x.Id == id);

    public void Add(T item)
    {
        item.Id = _dbSet.Any() ? _dbSet.Max(x => x.Id) + 1 : 1;
        _dbSet.Add(item);
    }
    
    public void Remove(T entity) => _dbSet.Remove(entity);

    public void Save() => _dbContext.SaveChanges();
}