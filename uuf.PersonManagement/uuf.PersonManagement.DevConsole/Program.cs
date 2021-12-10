// See https://aka.ms/new-console-template for more information
using Autofac;
using System.Reflection;
using uuf.PersonManagement.Data.EfCore;
using uuf.PersonManagement.Logic;
using uuf.PersonManagement.Model;
using uuf.PersonManagement.Model.Contracts;

Console.WriteLine("Hello, World!");

// dependency injection by reference
//var core = new Core(new EfRepository());

// manual dependency injection by refelection
// dependencies of EfCore.dll needs to be placed manually into out dir :(
/*
var path = @"C:\Users\ppedv\source\repos\uuf.PersonManagement\uuf.PersonManagement.Data.EfCore\bin\Debug\net6.0\uuf.PersonManagement.Data.EfCore.dll";
var assembly = Assembly.LoadFrom(path);
var typeWithRepo = assembly.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IRepository)));
IRepository repository = Activator.CreateInstance(typeWithRepo) as IRepository;
var core = new Core(repository);
*/

// dependency injection framework, e.g. AutoFac:
var builder = new ContainerBuilder();
// requires reference
// but can also work via configuration files and magic strings -> see documentation
builder.RegisterType<EfRepository>().AsImplementedInterfaces();
var container = builder.Build();
var core = new Core(container.Resolve<IRepository>());

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