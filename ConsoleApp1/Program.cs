using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ClassLibrary1;

namespace ConsoleApp1
{
    class Program
    {
        // place orders to store locations for customers
        // add a new customer
        // search customers by name
        // display details of an order
        // display all order history of a store location
        // display all order history of a customer
        // input validation
        // (optional: order history can be sorted by earliest, latest, cheapest, most expensive)
        // (optional: get a suggested order for a customer based on his order history)
        // (optional: display some statistics based on order history)

        static void Main(string[] args)
        {
            using var dataSource = new BurgerContext();
            var burgerRepo = new BurgerRepo(dataSource);

            Console.WriteLine("Welcome to Good Burger, home of The Good Burger, can I take your order?");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("p:\tPlace your order.");
                Console.WriteLine("d:\tDisplay your order.");
                Console.WriteLine("m:\tIf you are a manager.");
                Console.WriteLine();
                Console.Write("Enter valid menu option, or \"q\" to quit: ");
                var input = Console.ReadLine();
                if (input == "r")
                {
                }
            }
        }
    }
}
