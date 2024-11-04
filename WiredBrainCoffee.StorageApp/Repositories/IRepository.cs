using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories;

/*
 * `in` keyword to allow contravariant types as method arguments 
 */
public interface IWriteRepository<in T>
{
    void Add(T item);
    void Remove(T entity);
    void Save();
}

/*
 * `out` keyword to allow covariant types as return types
 */
public interface IReadRepository<out T>
{
    IEnumerable<T> GetAll();
    T CreateItem();
    T GetById(int id);
}

/*
 * We want to keep this IEntity type constraint because the `GetById` method is intended to only work with types
 * that implement IEntity's `Id` property.
 * 
 * Implement both the read and write repository interfaces to get the benefits of both
 * covariance and contravariance.
*/
public interface IRepository<T> : IWriteRepository<T>, IReadRepository<T> where T : IEntity 
{
}