namespace WiredBrainCoffee.StorageApp.Repositories;

public class GenericRepositoryWithRemove<T> : GenericRepository<T>
{
    public void Remove(T entity) => _items.Remove(entity);
}