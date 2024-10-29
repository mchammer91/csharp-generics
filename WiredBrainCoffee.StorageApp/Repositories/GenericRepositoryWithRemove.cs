namespace WiredBrainCoffee.StorageApp.Repositories;

// Passing all required type parameters to parent type
public class GenericRepositoryWithRemove<T, TKey> : GenericRepository<T, TKey>
{
    public void Remove(T entity) => _items.Remove(entity);
}

// Child type can have additional type parameters not passed to the parent 
public class GenericRepositoryWithRemove<T, TKey, TNotUsedKey> : GenericRepository<T, TKey>
{
    public void Remove(T entity) => _items.Remove(entity);
}

// Child type can hard-code the type parameter on the inherited parent type 
public class GenericRepositoryWithRemove<T> : GenericRepository<T, string>
{
    public void Remove(T entity) => _items.Remove(entity);
}