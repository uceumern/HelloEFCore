namespace uuf.PersonManagement.Model
{
    public abstract class Person : Entity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;
    }

}