using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using Library.Models;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            var order = new OrderHistory();
            var customer = new Customers();
            var menu = new Inventory();
            var history = new OrderHistory();

            Console.WriteLine("Welcome to Good Burger, home of The Good Burger, can I take your order?");
            bool loop = true;
            while (loop)
            {
                 
                Console.WriteLine();
                Console.WriteLine("l:\tlogin as existing customer");
                Console.WriteLine("c:\tIf you're a new customer.");
                Console.WriteLine("m:\tIf you are a manager.");

                Console.WriteLine();
                Console.Write("Enter valid menu option, or 'q' to quit: ");
                var input = Console.ReadLine();

                if (input == "l")
                {
                    customer = Login(order);
                    if (customer == null)
                    {
                        break;
                    }
                    order = InitializeOrder(order, customer);

                    Console.WriteLine("d: Display menu.");
                    Console.WriteLine("b: Go back.");
                    input = Console.ReadLine();
                    if (input == "b")
                        continue;
                    if (input == "d")
                    {
                        input = Order.PlaceOrder(order);
                    }
                }

                else if (input == "c")
                {
                    customer = Customer.AddCustomer(customer);

                    Console.WriteLine("d: Display menu.");
                    Console.WriteLine("b: Go back.");
                    input = Console.ReadLine();
                    if (input == "b")
                        continue;
                    if (input == "d")
                    {
                        input = Order.PlaceOrder(order);
                    }
                }

                else if (input == "m")
                {
                    Console.WriteLine("Enter password");
                    var pw = Console.ReadLine();

                    if (pw == " ")
                    {
                        Console.WriteLine("1: Display Order History of Store");
                        Console.WriteLine("2: Display Order History of Customer");
                        input = Console.ReadLine();
                        Console.WriteLine();
                        if (input == "1")
                        {
                            using (var db = new BurgerDbContext())
                            {
                                Console.Write("Enter Store Location: ");
                                input = Console.ReadLine();
                                var ordersQuery =
                                    from entry in db.OrderHistory
                                    .AsEnumerable()
                                    where entry.Location == input
                                    group entry by entry.StoreId;

                                foreach (var entries in ordersQuery)
                                {
                                    Console.WriteLine(entries.Key);
                                    foreach (OrderHistory orders in entries)
                                    {
                                        Console.WriteLine("    {0}: {1}, {2}, {3}", orders.Location, orders.CustomerName, orders.DateTime, orders.Order);
                                    }
                                }
                            }
                        }

                        else if (input == "2")
                        {
                            using (var db = new BurgerDbContext())
                            {
                                Console.Write("Enter full name of customer: ");
                                input = Console.ReadLine();
                                var ordersQuery =
                                    from entry in db.OrderHistory
                                    .AsEnumerable()
                                    where entry.CustomerName == input
                                    group entry by entry.CustomerName;

                                foreach (var entries in ordersQuery)
                                {
                                    Console.WriteLine(entries.Key);
                                    foreach (OrderHistory orders in entries)
                                    {
                                        Console.WriteLine("    {0}: {1}, {2}, {3}", orders.Location, orders.CustomerName, orders.DateTime, orders.Order);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Invalid entry. Please try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid password. Please try again.");
                    }

                }

                else if(input == "b")
                {
                    continue;
                }

                else if (input == "q")
                {
                    loop = false;
                    break;
                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid entry. Please try again.");
                }
            }

            Console.WriteLine("Goodbye.");
        }

        public static Customers Login(OrderHistory order)
        {
            var cust = new Customers();
            Console.WriteLine();
            Console.Write("Enter first name (or press b to go back): ");
            var firstName = Console.ReadLine();
            if(firstName == "b")
            {
                return cust;
            }
            Console.Write("Enter last name: ");
            var lastName = Console.ReadLine();

            using (var db = new BurgerDbContext())
            {
                var cus = from c in db.Customers
                             where c.LastName.Equals(lastName)
                                && c.FirstName.Equals(firstName)
                             select c;
                
                 cust = cus.FirstOrDefault();
                if (cust == null)
                {
                    Console.WriteLine("No Customers found. Please try again");
                    Login(order);
                }
                else
                {
                        Console.WriteLine("    {0} {1}, {2}, {3}", cust.FirstName, cust.LastName, cust.PhoneNumber, cust.Address);
                }
            }
   
            Console.WriteLine("Is your informaion correct? (y/n)");
            var input = Console.ReadLine();
            if (input == "n")
            {
                Login(order);
            }
            else if (input == "y")
            {
                return cust;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid entry. Please try again.");
                Login(order);
            }
            return cust;
        }

        public static OrderHistory InitializeOrder(OrderHistory order, Customers cust)
        {
            order.CustomerName = cust.FirstName + " " + cust.LastName;
            order.CustomerId = cust.Id;
            order.TotalPrice = 0;
            Console.WriteLine("Enter store location you would like to order from: ");
            Console.WriteLine("1: Leominster");
            Console.WriteLine("2: Gardner");
            Console.WriteLine("3: Worcester");
            string input = Console.ReadLine();
            Console.WriteLine();
            if (input == "1" || input == "2" || input == "3")
            {
                int storeId = int.Parse(input);
;                using (var db = new BurgerDbContext())
                {
                    var store = (from s in db.Stores
                                 where s.StoreId == storeId
                                 select s).SingleOrDefault();


                    order.StoreId = store.StoreId;
                    return order;
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid entry. Please try again.");
                InitializeOrder(order, cust);
                return order;
            }
        }
    }
}
