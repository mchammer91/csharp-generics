namespace WiredBrainCoffee.StorageApp.Entities;

public class Employee : EntityBase
{
    public required string FirstName { get; set; }

    public override string ToString() => $"Id: {Id}, Name: {FirstName}";
}