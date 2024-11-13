// See https://aka.ms/new-console-template for more information

using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
AddEmployees(employeeRepository);

/*
 * Able to pass SqlRepository<Employee> into method requiring IWriteRepository<Manager>
 * because of contravariance (allowing less derived type). 
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
    
    // repository.Add(julia);
    // repository.Add(anna);
    // repository.Add(thomas);
    // repository.Save();
    
    AddBatch(repository, employees);
}

void AddOrganizations(IRepository<Organization> repository)
{
    var pluralsight = new Organization { Name = "Pluralsight" };
    var globometrics = new Organization { Name = "Globomantics" };
    
    var organizations = new[] { pluralsight, globometrics };
    
    // repository.Add(pluralsight);
    // repository.Add(globometrics);
    // repository.Save();
    
    AddBatch(repository, organizations);
}

/*
 * First attempt: this doesn't work because IRepository<IEntity> is invariant
 * so can't use Employee or Organization as generic type parameter
 */
// void AddBatch(IRepository<IEntity> repository, IEntity[] employees)
// {
//     foreach (var employee in employees) 
//     {
//         repository.Add(employee);
//     }
//     
//     repository.Save();
// }

/*
 * Second attempt: although this is better in one sense because IReadRepository<IEntity> is
 * covariant, it won't work because IReadRepository doesn't have the Add or Save methods
 * defined on it
 */
// void AddBatch(IReadRepository<IEntity> repository, IEntity[] employees)
// {
//     foreach (var employee in employees) 
//     {
//         repository.Add(employee);
//     }
//     
//     repository.Save();
// }

/*
 * Third attempt: although this is better in one sense because IWriteRepository<IEntity> has
 * the Add and Save methods defined, it won't work because IWriteRepository is contravariant
 */
// void AddBatch(IWriteRepository<IEntity> repository, IEntity[] employees)
// {
//     foreach (var employee in employees) 
//     {
//         repository.Add(employee);
//     }
//     
//     repository.Save();
// }

/*
 * Final attempt: by making the method take a generic type parameter, we can mitigate all
 * the issues of the previous attempts.
 */
void AddBatch<T>(IWriteRepository<T> repository, T[] employees)
{
    foreach (var employee in employees) 
    {
        repository.Add(employee);
    }
    
    repository.Save();
}

/*
 * Note: we could have used IRepository<T> rather than IWriteRepository but that would have
 * required adding `where T : IEntity`
 * Concern: IWriteRepository doesn't have the `where T : IEntity` type constraint on it, but all
 * implementations inherit from IRepository - think through this more
 * Concern: how are we able to get around the type constraints of the interface argument by
 * using a generic method? Seems like that allows room for potentially breaking the
 * contract created by the interface and its generic type parameter in the first place...
 */

/*
 * The solution is that both ListRepository and SqlRepository have their generic type constraints
 * specified to adhere to the IRepository interface's constraints
 */
