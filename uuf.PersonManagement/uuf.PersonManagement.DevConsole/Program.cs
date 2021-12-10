// See https://aka.ms/new-console-template for more information
using uuf.PersonManagement.Data.EfCore;
using uuf.PersonManagement.Logic;
using uuf.PersonManagement.Model;

Console.WriteLine("Hello, World!");

// dependency injection per reference
var core = new Core(new EfRepository());

Console.WriteLine($"==== Customers ====");
var customers = core.GetCustomersThatHaveBirthdayThatMonth(12);
foreach (var item in customers)
{
    Console.WriteLine($"{item.Name}");
}

Console.WriteLine($"==== Departments ====");
foreach (var item in core.Repository.GetAll<Department>())
{
    Console.WriteLine($"{item.Name}");
}