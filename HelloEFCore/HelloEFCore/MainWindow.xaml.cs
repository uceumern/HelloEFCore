using HelloEFCore.Data;
using HelloEFCore.Model;
using System;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace HelloEFCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region private fields
        readonly EFContext _context = new();
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            _context.Database.EnsureCreated();
        }

        private void LoadEmployees(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = _context.Employees.Include(x => x.Departments).ToList();
        }

        private void LoadCustomers(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = _context.Customers.ToList();
        }

        private void CreateDemoData(object sender, RoutedEventArgs e)
        {
            var dept1 = new Department { Description = "Sales" };
            var dept2 = new Department { Description = "PIT" };

            for (int i = 0; i < 100; i++)
            {
                var employee = new Employee
                {
                    Name = $"Hans #{i:0000}",
                    BirthDate = DateTime.UtcNow.AddYears(-33).AddDays(i * 17),
                    Job = "Does stuff"
                };
                if (i % 2 == 0)
                {
                    employee.Departments.Add(dept1);
                }
                if (i % 3 == 0)
                {
                    employee.Departments.Add(dept2);
                }
                _context.Employees.Add(employee);
            }

            _context.SaveChanges();
        }
    }
}
