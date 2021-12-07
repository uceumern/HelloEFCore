using System.Collections.Generic;

namespace HelloEFCore.Model
{
    class Employee : Person
    {
        public string Job { get; set; }

        public List<Customer> Customers { get; set; } = new List<Customer>();

        public List<Department> Departments { get; set; } = new List<Department>();
    }
}
