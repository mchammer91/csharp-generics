// See https://aka.ms/new-console-template for more information

using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

var employeeRepository = new GenericRepository<Employee>();
employeeRepository.Add(new Employee { FirstName = "Julia" });
employeeRepository.Add(new Employee { FirstName = "Anna" });
employeeRepository.Add(new Employee { FirstName = "Thomas" });

employeeRepository.Save();

var organizationRepository = new GenericRepository<Organization>();
organizationRepository.Add(new Organization { Name = "Pluralsight" });
organizationRepository.Add(new Organization { Name = "Globomantics" });

organizationRepository.Save();

Console.ReadLine();
