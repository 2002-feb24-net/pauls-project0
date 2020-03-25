using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Entities;
using System.Linq;

namespace Library.Models
{
    public class Order 
    {
        //Methods
        
        public static string DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1: Add one Good Burger with nothing on it: $2.00");
            Console.WriteLine("2: Add one Good Burger: $4.00");
            Console.WriteLine("3: Add Cheese: $1.00");
            Console.WriteLine("4: Add Bacon: $1.00");
            Console.WriteLine("5: Add our famous Ed's Sauce: $1.00");
            Console.WriteLine("6: Add Fries: $1.00 ");
            Console.WriteLine("7: Add a Cola: $1.00 ");
            Console.WriteLine("8: Select some free optional condiments to add");
            Console.WriteLine();
            Console.WriteLine("Select an option to add to your order, press 'b' to go back,");
            Console.WriteLine("  or '0' if you are done with your order: ");
            var input = Console.ReadLine();
            Console.WriteLine();
            return input;
        }

        public static string DisplayCondims()
        {
            Console.WriteLine();
            Console.WriteLine("1: Add lettuce");
            Console.WriteLine("2: Add onions");
            Console.WriteLine("3: Add pickles");
            Console.WriteLine("4: Add tomatoes");
            Console.WriteLine("5: Add mayo");
            Console.WriteLine("6: Add ketchup");
            Console.WriteLine("7: Add mustard");
            Console.WriteLine();
            Console.WriteLine("Select an option to add to your order,");
            Console.WriteLine("  or press 'b' to go back.");
            var input = Console.ReadLine();
            Console.WriteLine();
            return input;
        }

        public static string PlaceOrder(OrderHistory order)
        {

            bool loop = true;
            string input;
            do {
                Console.WriteLine();
                input = DisplayMenu();
                if (input == "b")
                {
                    return input;
                }
                else if (input == "1")
                {
                    order = PlainBurger(order);
                }
                else if (input == "2")
                {
                    order = GoodBurger(order);
                }
                else if (input == "3")
                {
                    order = AddCheese(order);
                }
                else if (input == "4")
                {
                    order = AddBacon(order);
                }
                else if (input == "5")
                {
                    order = AddEdSauce(order);
                }
                else if (input == "6")
                {
                    order = AddFries(order);
                }
                else if (input == "7")
                {
                    order = AddCola(order);
                }
                else if (input == "8")
                {
                    var loop2 = true;
                    do
                    {
                        Console.WriteLine();
                        input = DisplayCondims();
                        if (input == "b")
                        {
                            loop2 = false;
                        }
                        else if (input == "1")
                        {
                            order = AddLettuce(order);
                        }
                        else if (input == "2")
                        {
                            order = AddOnions(order);
                        }
                        else if (input == "3")
                        {
                            order = AddPickles(order);
                        }
                        else if (input == "4")
                        {
                            order = AddTomatoes(order);
                        }
                        else if (input == "5")
                        {
                            order = AddMayo(order);
                        }
                        else if (input == "6")
                        {
                            order = AddKetchup(order);
                        }
                        else if (input == "7")
                        {
                            order = AddMustard(order);
                        }

                    } while (loop2);
                }
                else if (input == "0")
                {
                    loop = false;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid entry. Please try again.");
                }

            } while (loop);

            do
            {
                Console.WriteLine(order.Order + " = $" + order.TotalPrice);
                Console.WriteLine();
                Console.Write("Are you finished with your order? (y/n)");
                Console.WriteLine();
                input = Console.ReadLine();
                if (input == "n")
                {
                    PlaceOrder(order);
                }
                else if (input == "y")
                {
                    order.DateTime = DateTime.Now;
                    using (var db = new BurgerDbContext())
                    {
                        db.OrderHistory.Add(order);
                        db.SaveChanges();
                    }
                    Console.Write("Your order has been placed. Thank you");
                    Console.WriteLine();
                    input = "q";
                    return input;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid entry. Please try again.");
                }
            } while (true);

        }

        public static OrderHistory PlainBurger(OrderHistory order)
        {
            order.Order += "1 Good Burger with nothing on it.";
            using (var db = new BurgerDbContext())
            {
                var product = (from p in db.Inventory
                               where p.Location == order.Location
                               select p).SingleOrDefault();

                product.Buns -= 1;

                var price = (from p in db.Prices
                               where p.Product == "Buns"
                               select p).SingleOrDefault();

                order.TotalPrice += price.Price;
                db.SaveChanges();
            }
            Console.WriteLine("'1 Good Burger with nothing on it' ordered.");
            return order;
        }

        public static OrderHistory GoodBurger(OrderHistory order)
        {
            order.Order = order.Order + "1 Good Burger ";
            using (var db = new BurgerDbContext())
            {
                var product = (from p in db.Inventory
                               where p.Location == order.Location
                                 select p).SingleOrDefault();

                product.Hamburgers -= 1;
                product.Buns -= 1;

                var price = (from p in db.Prices
                             where p.Product == "Buns"
                             select p).SingleOrDefault();

                order.TotalPrice += price.Price;

                price = (from p in db.Prices
                             where p.Product == "Hamburgers"
                             select p).SingleOrDefault();

                order.TotalPrice += price.Price;

                db.SaveChanges();

                Console.WriteLine("Good Burger added");
                return order;
            }
           
        }

        public static OrderHistory AddCheese(OrderHistory order)
        {
            order.Order = order.Order + "+ cheese ";
            using (var db = new BurgerDbContext())
            {
                var product = (from p in db.Inventory
                               where p.Location == order.Location
                               select p).SingleOrDefault();

                product.Cheese -= 1;

                var price = (from p in db.Prices
                             where p.Product == "Cheese"
                             select p).SingleOrDefault();

                order.TotalPrice += price.Price;

                db.SaveChanges();
            }
            Console.WriteLine("cheese added");
            return order;
        }

        public static OrderHistory AddBacon(OrderHistory order)
        {
            order.Order = order.Order + "+ bacon ";
            using (var db = new BurgerDbContext())
            {
                var product = (from p in db.Inventory
                               where p.Location == order.Location
                               select p).SingleOrDefault();

                product.Bacon -= 1;

                var price = (from p in db.Prices
                             where p.Product == "Bacon"
                             select p).SingleOrDefault();

                order.TotalPrice += price.Price;

                db.SaveChanges();
            }
            Console.WriteLine("bacon added");
            return order;
        }

        public static OrderHistory AddEdSauce(OrderHistory order)
        {
            order.Order = order.Order + "+ Ed's Sauce ";
            using (var db = new BurgerDbContext())
            {
                var product = (from p in db.Inventory
                               where p.Location == order.Location
                               select p).SingleOrDefault();

                product.EdSauce -= 1;

                var price = (from p in db.Prices
                             where p.Product == "EdSauce"
                             select p).SingleOrDefault();

                order.TotalPrice += price.Price;

                db.SaveChanges();
            }
            Console.WriteLine("Ed's Sauce added");
            return order;
        }
        public static OrderHistory AddFries(OrderHistory order)
        {
            order.Order = order.Order + "+ fries ";
            using (var db = new BurgerDbContext())
            {
                var product = (from p in db.Inventory
                               where p.Location == order.Location
                               select p).SingleOrDefault();

                product.Fries -= 1;

                var price = (from p in db.Prices
                             where p.Product == "Fries"
                             select p).SingleOrDefault();

                order.TotalPrice += price.Price;
                db.SaveChanges();
            }
            Console.WriteLine("fries added");
            return order;
        }

        public static OrderHistory AddCola(OrderHistory order)
        {
            order.Order = order.Order + "+ cola ";
            using (var db = new BurgerDbContext())
            {
                var product = (from p in db.Inventory
                               where p.Location == order.Location
                               select p).SingleOrDefault();

                product.Cola -= 1;

                var price = (from p in db.Prices
                             where p.Product == "Cola"
                             select p).SingleOrDefault();

                order.TotalPrice += price.Price;

                db.SaveChanges();
            }
            Console.WriteLine("cola added");
            return order;
        }

        public static OrderHistory AddLettuce(OrderHistory order)
        {
            order.Order = order.Order + "+ lettuce ";
            using (var db = new BurgerDbContext())
            {
                var product = (from p in db.Inventory
                               where p.Location == order.Location
                               select p).SingleOrDefault();

                product.Lettuce -= 1;

                db.SaveChanges();
            }
            Console.WriteLine("lettuce added");
            return order;
        }

        public static OrderHistory AddOnions(OrderHistory order)
        {
            order.Order = order.Order + "+ onions ";
            using (var db = new BurgerDbContext())
            {
                var product = (from p in db.Inventory
                               where p.Location == order.Location
                               select p).SingleOrDefault();

                product.Onions -= 1;

                db.SaveChanges();
            }
            Console.WriteLine("onions added");
            return order;
        }

        public static OrderHistory AddPickles(OrderHistory order)
        {
            order.Order = order.Order + "+ pickles ";
            using (var db = new BurgerDbContext())
            {
                var product = (from p in db.Inventory
                               where p.Location == order.Location
                               select p).SingleOrDefault();

                product.Pickles -= 1;

                db.SaveChanges();
            }
            Console.WriteLine("pickles added");
            return order;
        }

        public static OrderHistory AddTomatoes(OrderHistory order)
        {
            order.Order = order.Order + "+ tomatoes ";
            using (var db = new BurgerDbContext())
            {
                var product = (from p in db.Inventory
                               where p.Location == order.Location
                               select p).SingleOrDefault();

                product.Tomatoes -= 1;

                db.SaveChanges();
            }
            Console.WriteLine("tomatoes added");
            return order;
        }

        public static OrderHistory AddMayo(OrderHistory order)
        {
            order.Order = order.Order + "+ mayo ";
            using (var db = new BurgerDbContext())
            {
                var product = (from p in db.Inventory
                               where p.Location == order.Location
                               select p).SingleOrDefault();

                product.Mayonaise -= 1;

                db.SaveChanges();
            }
            Console.WriteLine("mayo added");
            return order;
        }

        public static OrderHistory AddKetchup(OrderHistory order)
        {
            order.Order = order.Order + "+ ketchup ";
            using (var db = new BurgerDbContext())
            {
                var product = (from p in db.Inventory
                               where p.Location == order.Location
                               select p).SingleOrDefault();

                product.Ketchup -= 1;

                db.SaveChanges();
            }
            Console.WriteLine("ketchup added");
            return order;
        }

        public static OrderHistory AddMustard(OrderHistory order)
        {
            order.Order = order.Order + "+ mustard ";
            using (var db = new BurgerDbContext())
            {
                var product = (from p in db.Inventory
                               where p.Location == order.Location
                               select p).SingleOrDefault();

                product.Mustard -= 1;

                db.SaveChanges();
            }
            Console.WriteLine("mustard added");
            return order;
        }
    }
}
