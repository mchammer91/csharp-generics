namespace WiredBrainCoffee.StorageApp.Repositories;

public static class RepositoryExtensions
{
    public static void AddBatch<T>(this IWriteRepository<T> repository, T[] employees)
    {
        foreach (var employee in employees) 
        {
            repository.Add(employee);
        }
    
        repository.Save();
    }
}