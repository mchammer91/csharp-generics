using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories;

public interface IReadRepository<out T>
{
    IEnumerable<T> GetAll();
    T CreateItem();
    T GetById(int id);
}

/*
 We want to keep this IEntity type constraint because the `GetById` method is intended to only work with types
 that implement IEntity's `Id` property.
*/
public interface IRepository<T> : IReadRepository<T> where T : IEntity 
{
    void Add(T item);
    void Remove(T entity);
    void Save();
}