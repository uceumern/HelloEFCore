namespace uuf.PersonManagement.Model
{
    public class Customer : Person
    {
        public string Number { get; set; }
        public virtual Employee Employee { get; set; }
    }

}