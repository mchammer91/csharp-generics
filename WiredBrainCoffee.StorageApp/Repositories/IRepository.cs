using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories;

/*
 We want to keep this IRepository type constraint because the `GetById` method is intended to only work with types
 that implement IEntity's `Id` property.
*/
public interface IRepository<T> where T : IEntity 
{
    T CreateItem();
    T GetById(int id);
    void Add(T item);
    void Remove(T entity);
    void Save();
}