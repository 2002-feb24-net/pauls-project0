using System;
using DataAccess.Entities;

namespace Library.Models
{
   public class Customer
    {
        //Fields

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }


        //Methods

        public static Customers AddCustomer(Customers cust)
        {
            Console.Write("Enter first name: ");
            cust.FirstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            cust.LastName = Console.ReadLine();
            Console.WriteLine("Enter your address: ");
            cust.Address = Console.ReadLine();
            Console.Write("Enter phone number: ");
            cust.PhoneNumber = Console.ReadLine();

            using (var db = new BurgerDbContext())
            {
                db.Customers.Add(cust);
                db.SaveChanges();
            }
            Console.Write("Your order has been placed. Thank you");
            return cust;
        }
    }
}
