// See https://aka.ms/new-console-template for more information

using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

/*
 * Initialize delegate implementation, and then pass it into the SqlRepository constructor
 */
var itemAdded = new ItemAdded(EmployeeAdded);
var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext(), itemAdded);
AddEmployees(employeeRepository);

/*
 * Able to pass SqlRepository<Employee> into method requiring IWriteRepository<Manager>
 * because of contravariance (allowing less derived type). 
 */
AddManagers(employeeRepository);

void EmployeeAdded(object item)
{
    var employee = (Employee)item;
    Console.WriteLine(employee.FirstName);
}

void AddManagers(IWriteRepository<Manager> repository)
{
    // repository.Add(new Employee()); // only want to be able to add Managers
    var saraManager = new Manager() { FirstName = "Sara" };
    var saraManagerCopy = saraManager.Copy();

    if (saraManagerCopy is not null)
    {
        saraManagerCopy.FirstName += "_Copy";
        repository.Add(saraManagerCopy);
    }
    
    repository.Add(saraManager);
    repository.Add(new Manager() { FirstName = "Henry" });
}

/*
 * Able to pass employeeRepository or organizationRepository into method requiring IReadRepository<IEntity>
 * because of covariance (accepting more derived type).
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
    var julia = new Employee { FirstName = "Julia" };
    var anna = new Employee { FirstName = "Anna" };
    var thomas = new Employee { FirstName = "Thomas" };
    
    var employees = new[] { julia, anna, thomas };
    
    /*
     * Fun fact: could also be called as static method like so:
     * RepositoryExtensions.AddBatch(repository, organizations);
     */
    repository.AddBatch(employees);
}

void AddOrganizations(IWriteRepository<Organization> repository)
{
    var pluralsight = new Organization { Name = "Pluralsight" };
    var globometrics = new Organization { Name = "Globomantics" };
    
    var organizations = new[] { pluralsight, globometrics };
    
    repository.AddBatch(organizations);
}
