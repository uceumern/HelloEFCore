using System;
using System.Linq;
using uuf.PersonManagement.Model;
using Xunit;

namespace uuf.PersonManagement.Data.EfCore.Tests
{
    public class EfContextTests
    {
        [Fact]
        public void Can_create_db()
        {
            using var context = new EFContext();
            context.Database.EnsureDeleted();

            Assert.True(context.Database.EnsureCreated());
        }

        [Fact]
        public void Can_CRUD_Customer()
        {
            using var context = new EFContext();
            //context.Database.EnsureDeleted();
            //Assert.True(context.Database.EnsureCreated());

            // create
            var customer = new Customer { Number = "A000", Name = $"LolPatrol_{Guid.NewGuid()}" };
            context.Add(customer);
            Assert.Equal(2, context.SaveChanges());

            // SaveChanges updates Id from last insert id!
            var result = context.Customers.Single(x => x.Id == customer.Id);
            Assert.Equal(customer.Name, result.Name);
            Assert.Equal(customer.Number, result.Number);

            // update
            string newName = $"UpdatedName_{Guid.NewGuid()}";
            result.Name = newName;
            context.SaveChanges();
            var updated = context.Customers.Single(x => x.Id == customer.Id);
            Assert.Equal(newName, result.Name);

            // delete
            context.Customers.Remove(customer);
            context.SaveChanges();
            Assert.False(context.Customers.Any(x => x.Id == customer.Id));
        }
    }
}