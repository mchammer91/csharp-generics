using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories;

public class GenericRepository<T> where T : EntityBase
{
    private readonly List<T> _items = new();
    
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