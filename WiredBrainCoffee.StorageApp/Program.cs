// See https://aka.ms/new-console-template for more information

using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
AddEmployees(employeeRepository);

/*
 * Able to pass SqlRepository<Employee> into method requiring IWriteRepository<Manager>
 * because of contravariance (allowing more derived type). 
 */
AddManagers(employeeRepository);

void AddManagers(IWriteRepository<Manager> repository)
{
    // employeeRepository.Add(new Employee()); // only want to be able to add Managers
    employeeRepository.Add(new Manager() { FirstName = "Sara" });
    employeeRepository.Add(new Manager() { FirstName = "Henry" });
}

/*
 * Able to pass employeeRepository or organizationRepository into method requiring IReadRepository<IEntity>
 * because of covariance (accepting less derived type).
 */
WriteAllToConsole(employeeRepository);

void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var employees = repository.GetAll();
    foreach (var employee in employees) 
    {
        Console.Write(employee);
    }
}

var shouldBeAnna = employeeRepository.GetById(2);
Console.WriteLine($"Should be Anna: {shouldBeAnna}");

var organizationRepository = new ListRepository<Organization>();
AddOrganizations(organizationRepository);
var shouldBePluralsight = organizationRepository.GetById(1);
Console.WriteLine($"Should be Pluralsight: {shouldBePluralsight}");
WriteAllToConsole(organizationRepository);

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