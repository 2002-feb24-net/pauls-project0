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
            //var order = new Order();
            var customer = new Customers();
            var menu = new Inventory();
            var history = new OrderHistory();

            Console.WriteLine("Welcome to Good Burger, home of The Good Burger, can I take your order?");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("l:\tlogin as existing customer");
                Console.WriteLine("c:\tIf you're a new customer.");
                Console.WriteLine("m:\tIf you are a manager.");

                Console.WriteLine();
                Console.Write("Enter valid menu option, or \"q\" to quit: ");
                var input = Console.ReadLine();

                if (input == "l")
                {
                    customer = Login(customer);
                }

                else if (input == "c")
                {
                        customer = Customer.AddCustomer(customer);
                }

                else if (input == "m")
                {
                    Console.WriteLine("Enter password");
                    Console.ReadLine();
                    Console.WriteLine("1: Display Order History of Store");
                    Console.WriteLine("2: Display Order History of Customer");
                    input = Console.ReadLine();
                    if (input == "1")
                    {
                        using (var db = new BurgerDbContext())
                        {
                            Console.Write("Enter Store Location: ");
                            input = Console.ReadLine();
                            var ordersQuery =
                                from order in db.OrderHistory
                                .AsEnumerable()
                                where order.Location == input 
                                group order by order.StoreId;
                            
                            foreach (var order in ordersQuery)
                            {
                                Console.WriteLine(order.Key);
                                foreach (OrderHistory orders in order)
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
                                from order in db.OrderHistory
                                .AsEnumerable()
                                where order.CustomerName == input
                                group order by order.CustomerName;

                            foreach (var order in ordersQuery)
                            {
                                Console.WriteLine(order.Key);
                                foreach (OrderHistory orders in order)
                                {
                                    Console.WriteLine("    {0}: {1}, {2}, {3}", orders.Location, orders.CustomerName, orders.DateTime, orders.Order);
                                }
                            }
                        }
                    }

                }


                Console.WriteLine("d:\tDisplay menu.");
                input = Console.ReadLine();


                if (input == "d")
                {
                    var order = new OrderHistory();
                    Console.WriteLine("Enter store location");
                    order.Location = Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine("1: Good Burger with nothing on it: $2.00");
                    Console.WriteLine("2: Good Burger: $4.00");
                    Console.WriteLine("3: Good Cheeseburger: $4.50 ");
                    Console.WriteLine("4: Good Bacon Burger: $4.50");
                    Console.WriteLine("5: Good Bacon Cheeseburger: $5.00");
                    Console.WriteLine("6: Good Cheeseburger Deluxe (w/ lettuce, tomato, onion, pickle, ketchup, mayo, Ed's Sauce): $5.50");
                    Console.WriteLine("7: Good Bacon Cheeseburger Deluxe: $6.00");
                    Console.WriteLine("w/ Fries and Soda: add $2.00");
                    Console.WriteLine("Condiment options include bacon, cheese, lettuce, tomatoes, onions, pickles, ketchup, mayo, mustard, and our famous Ed's Sauce!");
                    Console.WriteLine();
                    Console.Write("Choose an option to customize, or press 'b' to go back: ");
                    input = Console.ReadLine();
                    if (input == "b")
                        continue;

                    Order.PlaceOrder(order, customer);

                }

                else if (input == "q")
                {
                    Console.WriteLine("Goodbye.");
                    return;
                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid entry. Please try again.");
                }

           
            }
        }

        public static Customers Login(Customers cust)
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
            return cust;
        }
    }
}
