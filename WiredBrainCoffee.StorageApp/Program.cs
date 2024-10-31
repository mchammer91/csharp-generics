// See https://aka.ms/new-console-template for more information

using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
AddEmployees(employeeRepository);
var shouldBeAnna = employeeRepository.GetById(2);
Console.WriteLine($"Should be Anna: {shouldBeAnna}");

var organizationRepository = new ListRepository<Organization>();
AddOrganizations(organizationRepository);
var shouldBePluralsight = organizationRepository.GetById(1);
Console.WriteLine($"Should be Pluralsight: {shouldBePluralsight}");

Console.ReadLine();
return;

void AddEmployees(IRepository<Employee> repository)
{
    repository.Add(new Employee { FirstName = "Julia" });
    repository.Add(new Employee { FirstName = "Anna" });
    repository.Add(new Employee { FirstName = "Thomas" });
    repository.Save();
}

void AddOrganizations(IRepository<Organization> repository)
{
    repository.Add(new Organization { Name = "Pluralsight" });
    repository.Add(new Organization { Name = "Globomantics" });
    repository.Save();
}