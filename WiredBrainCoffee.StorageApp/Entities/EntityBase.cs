namespace WiredBrainCoffee.StorageApp.Entities;

public class EntityBase : IEntity
{
    public int Id { get; set; }
}

struct MyStruct : IEntity
{
    public int Id { get; set; }
}