namespace WiredBrainCoffee.StorageApp.Entities;

public class Employee
{
    public int Id { get; set; }
    public required string FirstName { get; set; }

    public override string ToString() => $"Id: {Id}, Name: {FirstName}";
}