// See https://aka.ms/new-console-template for more information

using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

var employeeRepository = new GenericRepository<Employee>();
AddEmployees();
var shouldBeAnna = employeeRepository.GetById(2);
Console.WriteLine($"Should be Anna: {shouldBeAnna}");

var organizationRepository = new GenericRepository<Organization>();
AddOrganizations(organizationRepository);
var shouldBePluralsight = organizationRepository.GetById(1);
Console.WriteLine($"Should be Pluralsight: {shouldBePluralsight}");

Console.ReadLine();
return;

void AddEmployees()
{
    employeeRepository.Add(new Employee { FirstName = "Julia" });
    employeeRepository.Add(new Employee { FirstName = "Anna" });
    employeeRepository.Add(new Employee { FirstName = "Thomas" });
    employeeRepository.Save();
}

void AddOrganizations(GenericRepository<Organization> genericRepository)
{
    genericRepository.Add(new Organization { Name = "Pluralsight" });
    genericRepository.Add(new Organization { Name = "Globomantics" });
    genericRepository.Save();
}