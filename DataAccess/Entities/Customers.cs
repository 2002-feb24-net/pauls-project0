using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Customers
    {
        public Customers()
        {
            OrderHistory = new HashSet<OrderHistory>();
            Reviews = new HashSet<Reviews>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int? FavoriteStoreId { get; set; }
        public string FavoriteItem { get; set; }

        public virtual Stores FavoriteStore { get; set; }
        public virtual ICollection<OrderHistory> OrderHistory { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }

        public static void AddCustomer(Customers customer)
        {
            Console.Write("Enter first name: ");
            customer.FirstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            customer.LastName = Console.ReadLine();
            Console.Write("Enter address: ");
            customer.Address = Console.ReadLine();
            Console.Write("Enter phone number: ");
            customer.PhoneNumber = Console.ReadLine();
            using (var db = new BurgerDbContext())
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                
            }
            Console.Write("New customer added.");
        }
    }
}
