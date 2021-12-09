using Microsoft.EntityFrameworkCore;
using uuf.PersonManagement.Model;

namespace uuf.PersonManagement.Data.EfCore
{
    public class EFContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=PersonManagement_dev;Trusted_Connection=True;trustservercertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Person>().ToTable("Persons");
        }
    }
}
