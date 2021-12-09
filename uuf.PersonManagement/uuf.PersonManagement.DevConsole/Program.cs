// See https://aka.ms/new-console-template for more information
using uuf.PersonManagement.Logic;

Console.WriteLine("Hello, World!");

var core = new Core();

var customers = core.GetCustomersThatHaveBirthdayThatMonth(12);
foreach (var item in customers)
{
    Console.WriteLine($"{item.Name}");
}
