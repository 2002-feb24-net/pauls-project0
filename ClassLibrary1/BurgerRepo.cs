using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;




namespace ClassLibrary1
{
    public class BurgerRepo
    {
        private readonly BurgerDbContext _context;

        public BurgerRepo(BurgerDbContext context)
        {
            context.Database.EnsureCreated();

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Store GetStore(string search)
        {
            using var context = new BurgerDbContext();
            Store store = context.Store.Find(search);
            return store;
        }

        public Customer GetCustomer(string search)
        {
            using var context = new BurgerDbContext();
            Customer customer = context.Customer.Find(search);
            return customer;
        }

        public void AddStore(string name)
        {
            using var context = new BurgerDbContext();
            Store store = new Store();

            context.Store.Add(store);
            context.SaveChanges();
        }

        public void DeleteStore(string name)
        {
            using var context = new BurgerDbContext();
            Store store = context.Store.Find(name);

            context.Store.Remove(store);
            context.SaveChanges();
        }

        public void AddCustomer(string firstName, string lastName)
        {
            using var context = new BurgerDbContext();
            Customer customer = new Customer();

            context.Customer.Add(customer);
            context.SaveChanges();
        }

        public void DeleteCustomer(string firstName, string lastName)
        {
            using var context = new BurgerDbContext();
            Customer customer = context.Customer.Find(firstName, lastName);

            context.Customer.Remove(customer);
            context.SaveChanges();
        }
        
    }
}
