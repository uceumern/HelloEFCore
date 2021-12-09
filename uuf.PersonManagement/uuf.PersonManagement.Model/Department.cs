namespace uuf.PersonManagement.Model
{
    public class Department : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }

}