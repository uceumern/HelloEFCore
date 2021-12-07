using System.Collections.Generic;

namespace HelloEFCore.Model
{
    class Department
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
