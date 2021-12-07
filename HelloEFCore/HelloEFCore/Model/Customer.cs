namespace HelloEFCore.Model
{
    class Customer : Person
    {
        public string CustomerId { get; set; }

        public Employee Employee { get; set; }
    }
}
