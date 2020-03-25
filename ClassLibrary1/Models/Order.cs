using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Entities;
using System.Linq;

namespace Library.Models
{
    public class Order //: IOrder
    {
        //Fields & properties
        public string Store { get; set; }

        string customer;
        public string Customer { get; set; }

        public string OrderTime { get; set; }

        // if order burger plain, comes with bun alone.
        // for items besides burger and bun: 0 is none, 
        //     1 is light, 2 is normal, and 3 is extra.
        int burgers = 0;
        int buns = 2;
        int lettuce = 0;
        int onions = 0;
        int cheese = 0;
        int ketchup = 0;
        int mayo = 0;
        int mustard = 0;
        int edSauce = 0;

        int fries = 0;

        int soda = 0;

        //Methods
        
        public static void PlaceOrder(OrderHistory order, Customers cust)
        {
            order.CustomerName = cust.FirstName + " " + cust.LastName;
            order.CustomerId = cust.Id;
            //Console.Write("Enter store location: ");
            //order.Location = Console.ReadLine();
            order.DateTime = DateTime.Now;
            Console.Write("would you like a hamburger? ");
            var input = Console.ReadLine();
            if (input == "y")
            {
                order = AddBurger(order);
            }

            using (var db = new BurgerDbContext())
            {
                db.OrderHistory.Add(order);
                db.SaveChanges();
            }
            Console.Write("Your order has been placed. Thank you");
        }

        public static OrderHistory AddBurger(OrderHistory order)
        {
            order.Order = order.Order + "1 Hamburger + ";
            using (var db = new BurgerDbContext())
            {
                var product = (from p in db.Inventory
                               where p.Location == order.Location
                                 select p).SingleOrDefault();

                product.Hamburgers = product.Hamburgers - 1;
                db.SaveChanges();
            }
            Console.WriteLine("Hamburger added");
            return order;
        }

        public void AddLettuce(char x)
        {
            if (x == 'l')
            {
                lettuce++;
            }
            else if (x == 'n')
            {
                lettuce = 2;
            }
            else if (x == 'x')
            {
                lettuce = 3;
            }
            else
                Console.WriteLine("Please enter either 'l', 'n', or 'x'");
        }

        public void AddOnions(char x)
        {
            if (x == 'l')
            {
                onions++;
            }
            else if (x == 'n')
            {
                onions = 2;
            }
            else if (x == 'x')
            {
                onions = 3;
            }
            else
                Console.WriteLine("Please enter either 'l', 'n', or 'x'");
        }

        public void AddCheese(char x)
        {
            if (x == 'l')
            {
                cheese++;
            }
            else if (x == 'n')
            {
                cheese = 2;
            }
            else if (x == 'x')
            {
                cheese = 3;
            }
            else
                Console.WriteLine("Please enter either 'l', 'n', or 'x'");
        }

        public void AddKetchup(char x)
        {
            if (x == 'l')
            {
                ketchup++;
            }
            else if (x == 'n')
            {
                ketchup = 2;
            }
            else if (x == 'x')
            {
                ketchup = 3;
            }
            else
                Console.WriteLine("Please enter either 'l', 'n', or 'x'");
        }

        public void AddMayo(char x)
        {
            if (x == 'l')
            {
                mayo++;
            }
            else if (x == 'n')
            {
                mayo = 2;
            }
            else if (x == 'x')
            {
                mayo = 3;
            }
            else
                Console.WriteLine("Please enter either 'l', 'n', or 'x'");
        }

        public void AddMustard(char x)
        {
            if (x == 'l')
            {
                mustard++;
            }
            else if (x == 'n')
            {
                mustard = 2;
            }
            else if (x == 'x')
            {
                mustard = 3;
            }
            else
                Console.WriteLine("Please enter either 'l', 'n', or 'x'");
        }

        public void AddEdSauce(char x)
        {
            if (x == 'l')
            {
                edSauce++;
            }
            else if (x == 'n')
            {
                edSauce = 2;
            }
            else if (x == 'x')
            {
                edSauce = 3;
            }
            else
                Console.WriteLine("Please enter either 'l', 'n', or 'x'");
        }

        public void AddFries(char x)
        {
            if (x == 'l')
            {
                fries++;
            }
            else if (x == 'n')
            {
                fries = 2;
            }
            else if (x == 'x')
            {
                fries = 3;
            }
            else
                Console.WriteLine("Please enter either 'l', 'n', or 'x'");
        }

        public void AddSoda(char x)
        {
            if (x == 'l')
            {
                soda++;
            }
            else if (x == 'n')
            {
                soda = 2;
            }
            else if (x == 'x')
            {
                soda = 3;
            }
            else
                Console.WriteLine("Please enter either 'l', 'n', or 'x'");
        }


    }
}
