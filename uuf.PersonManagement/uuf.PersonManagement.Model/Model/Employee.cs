namespace uuf.PersonManagement.Model
{
    public class Employee : Person
    {
        public string Job { get; set; }
        public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
        public virtual ICollection<Department> Departments { get; set; } = new HashSet<Department>();
    }

}