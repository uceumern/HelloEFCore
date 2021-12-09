namespace uuf.PersonManagement.Model
{
    public class Customer : Person
    {
        public string Number { get; set; }
        public Employee Employee { get; set; }
    }

}