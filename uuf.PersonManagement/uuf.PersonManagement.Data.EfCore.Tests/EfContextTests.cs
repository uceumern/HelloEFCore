using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
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
            // create
            var customer = new Customer { Number = "A000", Name = $"LolPatrol_{Guid.NewGuid()}" };
            using (var context = new EFContext())
            {
                context.Add(customer);
                Assert.Equal(2, context.SaveChanges());
                // SaveChanges updates Id from last insert id!
                var result = context.Customers.Single(x => x.Id == customer.Id);
                Assert.Equal(customer.Name, result.Name);
                Assert.Equal(customer.Number, result.Number);
            }

            // update
            using (var context = new EFContext())
            {
                var result = context.Customers.Single(x => x.Id == customer.Id);
                string newName = $"UpdatedName_{Guid.NewGuid()}";
                result.Name = newName;
                context.SaveChanges();
                var updated = context.Customers.Single(x => x.Id == customer.Id);
                Assert.Equal(newName, result.Name);
            }

            // delete
            using (var context = new EFContext())
            {
                context.Customers.Remove(customer);
                context.SaveChanges();
                Assert.False(context.Customers.Any(x => x.Id == customer.Id));

            }
        }

        [Fact]
        public void Can_create_Customer_AutoFixture()
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            fixture.Customizations.Add(new PropertyNameOmitter(nameof(Entity.Id))); // ID auf 0 lassen
            var customer = fixture.Create<Customer>();

            using (var context = new EFContext())
            {
                context.Add(customer);
                context.SaveChanges();
            }

            using (var context = new EFContext())
            {
                var loaded = context.Customers.Include(x => x.Employee).ThenInclude(x => x.Departments).First(x => x.Id == customer.Id);
                loaded.Should().BeEquivalentTo(customer, cfg => cfg.IgnoringCyclicReferences());
            }
        }
    }
}