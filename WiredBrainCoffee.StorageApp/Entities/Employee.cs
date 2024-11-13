namespace WiredBrainCoffee.StorageApp.Entities;

public class Employee : EntityBase
{
    /*
     * `required` keyword breaks the new() constraint on SqlRepository and ListRepository
     */
    // public required string FirstName { get; set; }
    public string? FirstName { get; set; }

    public override string ToString() => $"Id: {Id}, Name: {FirstName}";
}