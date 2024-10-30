using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories;

public class ListRepository<T> where T : IEntity, new()
{
    private readonly List<T> _items = new();
    
    public T CreateItem() => new T();

    public T GetById(int id) => _items.Single(x => x.Id == id);

    public void Add(T item)
    {
        item.Id = _items.Any() ? _items.Max(x => x.Id) + 1 : 1;
        _items.Add(item);
    }
    
    public void Remove(T entity) => _items.Remove(entity);

    public void Save()
    {
        foreach (var item in _items)
        {
            Console.WriteLine(item);
        }
    }
}

// Example showing multiple type parameters, each with its own respective type constraints
public record Example<T1, T2>(T1 Id1, T2 Id2)
    where T1 : class
    where T2 : struct; // could also use other type parameter as constraint like: where T2 : T1