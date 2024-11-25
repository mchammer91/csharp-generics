using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories;

public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly DbContext _dbContext;
    private readonly Action<T>? _itemAddedCallback;
    private readonly DbSet<T> _dbSet;

    public SqlRepository(DbContext dbContext, Action<T>? itemAddedCallback = null)
    {
        _dbContext = dbContext;
        _itemAddedCallback = itemAddedCallback;
        _dbSet = _dbContext.Set<T>();
    }

    /*
     * Returns a copy of all items in the collection.
     */
    public IEnumerable<T> GetAll() => _dbSet.ToList();

    public T CreateItem() => new T();

    public T GetById(int id) => _dbSet.Single(x => x.Id == id);

    public void Add(T item)
    {
        _dbSet.Add(item);
        _itemAddedCallback?.Invoke(item);
    }
    
    public void Remove(T entity) => _dbSet.Remove(entity);

    public void Save() => _dbContext.SaveChanges();
}