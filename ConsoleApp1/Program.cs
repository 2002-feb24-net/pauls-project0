using System;
using System.Collections.Generic;
using System.Linq;
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
                    customer = Login(customer, order);
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
                                    where order.Location == input
                                    group order by order.StoreId;

                                foreach (var entry in ordersQuery)
                                {
                                    Console.WriteLine(entry.Key);
                                    foreach (OrderHistory orders in entry)
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
                                    where order.CustomerName == input
                                    group order by order.CustomerName;

                                foreach (var entry in ordersQuery)
                                {
                                    Console.WriteLine(entry.Key);
                                    foreach (OrderHistory orders in entry)
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
                    return;
                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid entry. Please try again.");
                }
            }

            Console.WriteLine("Goodbye.");
        }

        public static Customers Login(Customers cust, OrderHistory order)
        {
            using (var db = new BurgerDbContext())
            {
                Console.Write("Enter fisrt name: ");
                var firstName = Console.ReadLine();
                Console.Write("Enter last name: ");
                var lastName = Console.ReadLine();
                cust = (from c in db.Customers
                        where c.LastName == lastName && c.FirstName == firstName
                        select c).SingleOrDefault();
            }

            Console.WriteLine("    {0} {1}, {2}, {3}", cust.FirstName, cust.LastName, cust.PhoneNumber, cust.Address);
            Console.WriteLine("Is your informaion correct? (y/n)");
            var input = Console.ReadLine();
            if (input == "n")
            {

            }
            else if (input == "y")
            {
             
            }
            return cust;
        }

        public static OrderHistory InitializeOrder(OrderHistory order, Customers cust)
        {
            order.CustomerName = cust.FirstName + " " + cust.LastName;
            order.CustomerId = cust.Id;
            Console.Write("Enter store location you would like to order from: ");
            order.Location = Console.ReadLine();
            using (var db = new BurgerDbContext())
            {
                var store = (from s in db.Stores
                             where s.Location == order.Location
                             select s).SingleOrDefault();

                order.StoreId = store.StoreId;
                return order;
            }
        }
    }
}
