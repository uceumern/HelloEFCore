// See https://aka.ms/new-console-template for more information
using uuf.PersonManagement.API.ConsoleClient;

Console.WriteLine("Hello, World!");

var client = new swaggerClient("https://localhost:7273/", new HttpClient());

foreach (var item in client.GetWeatherForecastAsync().Result)
{
    Console.WriteLine(item.Summary);
}
