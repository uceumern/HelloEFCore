namespace uuf.PersonManagement.Model
{
    public class Employee : Person
    {
        public string Job { get; set; }
        public ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
    }

}